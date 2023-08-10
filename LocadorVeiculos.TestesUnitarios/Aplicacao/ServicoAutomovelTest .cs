using FluentAssertions;
using FluentResults;
using FluentResults.Extensions.FluentAssertions;
using FluentValidation.Results;
using LocadorAutomoveis.Aplicacao.ModuloAutomovel;
using LocadorAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadorAutomoveis.Dominio.ModuloAutomovel;
using Moq;
using LocadorAutomoveis.Dominio;

namespace LocadorAutomoveis.TestesUnitarios.Aplicacao
{
    [TestClass]
    public class ServicoAutomovelTest
    {
        Mock<IRepositorioAutomovel> repositorioAutomovelMoq;
        Mock<IValidadorAutomovel> validadorMoq;
        Mock<IContextoPersistencia> contextoPersistencia;

        private ServicoAutomovel servicoAutomovel;

        Automovel automovel;
        GrupoAutomoveis grupo;

        public ServicoAutomovelTest()
        {
            repositorioAutomovelMoq = new Mock<IRepositorioAutomovel>();
            validadorMoq = new Mock<IValidadorAutomovel>();
            servicoAutomovel = new ServicoAutomovel(repositorioAutomovelMoq.Object, validadorMoq.Object, contextoPersistencia.Object);
            grupo = new GrupoAutomoveis("Esportivo");
            automovel = new Automovel(
                "Marca",
                "azul",
                "Modelo",
                2000,
                10,
                TipoCombustivelEnum.Gasolina,
                10,
                "abc-1234",
                new byte[] { Convert.ToByte(true) },
                grupo);
        }

        public ServicoAutomovelTest(Mock<IRepositorioAutomovel> repositorioAutomovelMoq, Mock<IValidadorAutomovel> validadorMoq, Mock<IContextoPersistencia> contextoPersistencia)
        {
            this.repositorioAutomovelMoq = repositorioAutomovelMoq;
            this.validadorMoq = validadorMoq;
            this.contextoPersistencia = contextoPersistencia;
        }

        [TestMethod]
        public void Deve_inserir_automovel_caso_ele_for_valido() 
        {
            //action
            Result resultado = servicoAutomovel.Inserir(automovel);

            //assert 
            resultado.Should().BeSuccess();
            repositorioAutomovelMoq.Verify(x => x.Inserir(automovel), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_inserir_automovel_caso_ele_seja_invalido()
        {
            //arrange
            validadorMoq.Setup(x => x.Validate(It.IsAny<Automovel>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Marca", "Marca não pode ser null"));
                    return resultado;
                });

            //action
            var resultado = servicoAutomovel.Inserir(automovel);

            //assert             
            resultado.Should().BeFailure();
            repositorioAutomovelMoq.Verify(x => x.Inserir(automovel), Times.Never());
        }

        [TestMethod]
        public void Nao_deve_inserir_automovel_caso_a_marca_e_modelo_ja_esteja_cadastrado() //cenário 3
        {
            //arrange
            repositorioAutomovelMoq.Setup(x => x.SelecionarPorMarcaModelo(
                automovel.Marca, automovel.Modelo))
                .Returns(() =>
                {
                    return  new Automovel(
                automovel.Marca,
                "azul",
                automovel.Modelo,
                2000,
                10,
                TipoCombustivelEnum.Gasolina,
                10,
                "abc-1234",
                new byte[] { Convert.ToByte(true) },
                grupo);
                });
          
            //action
            var resultado = servicoAutomovel.Inserir(automovel);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be($"Este modelo '{automovel.Modelo}' da marca {automovel.Marca} já está sendo utilizado");
            repositorioAutomovelMoq.Verify(x => x.Inserir(automovel), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_inserir_automovel()
        {
            repositorioAutomovelMoq.Setup(x => x.Inserir(It.IsAny<Automovel>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = servicoAutomovel.Inserir(automovel);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar inserir automóvel.");
        }


        [TestMethod]
        public void Deve_editar_automovel_caso_ele_for_valido() 
        {
            //arrange           
            automovel.Marca = "Outra Marca";

            //action
            Result resultado = servicoAutomovel.Editar(automovel);

            //assert 
            resultado.Should().BeSuccess();
            repositorioAutomovelMoq.Verify(x => x.Editar(automovel), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_automovel_caso_ele_seja_invalido()
        {
            //arrange
            validadorMoq.Setup(x => x.Validate(It.IsAny<Automovel>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Marca", "Marca não pode ser null"));
                    return resultado;
                });

            //action
            var resultado = servicoAutomovel.Editar(automovel);

            //assert             
            resultado.Should().BeFailure();
            repositorioAutomovelMoq.Verify(x => x.Editar(automovel), Times.Never());
        }

        [TestMethod]
        public void Deve_editar_automovel_com_a_mesma_marca_e_modelo()
        {
            //arrange
            Automovel outroAutomovel = new Automovel(
                "OutraMarca",
                "azul",
                "OutroModelo",
                2000,
                10,
                TipoCombustivelEnum.Gasolina,
                10,
                "abc-1234",
                new byte[] { Convert.ToByte(true) },
                grupo);
            Guid id = outroAutomovel.Id;

            repositorioAutomovelMoq.Setup(x => x.SelecionarPorMarcaModelo(outroAutomovel.Marca,outroAutomovel.Modelo))
                 .Returns(() =>
                 {
                     return  new Automovel(
                id,
                outroAutomovel.Marca,
                "azul",
                outroAutomovel.Modelo,
                2000,
                10,
                TipoCombustivelEnum.Gasolina,
                10,
                "abc-1234",
                new byte[] { Convert.ToByte(true) },
                grupo);
                 });

            //action
            var resultado = servicoAutomovel.Editar(outroAutomovel);

            //assert 
            resultado.Should().BeSuccess();

            repositorioAutomovelMoq.Verify(x => x.Editar(outroAutomovel), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_automovel_caso_a_marca_e_modelo_ja_esteja_cadastrado()
        {
            //arrange
            repositorioAutomovelMoq.Setup(x => x.SelecionarPorMarcaModelo(automovel.Marca, automovel.Modelo))
                 .Returns(() =>
                 {
                     return new Automovel(
                automovel.Marca,
                "azul",
                automovel.Modelo,
                2000,
                10,
                TipoCombustivelEnum.Gasolina,
                10,
                "abc-1234",
                new byte[] { Convert.ToByte(true) },
                grupo);
                 });

            Automovel novoAutomovel = new Automovel(
               automovel.Marca,
               "azul",
               automovel.Modelo,
               2000,
               10,
               TipoCombustivelEnum.Gasolina,
               10,
               "abc-1234",
               new byte[] { Convert.ToByte(true) },
               grupo);

            //action
            var resultado = servicoAutomovel.Editar(novoAutomovel);

            //assert 
            resultado.Should().BeFailure();

            repositorioAutomovelMoq.Verify(x => x.Editar(novoAutomovel), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_editar_automovel()
        {
            repositorioAutomovelMoq.Setup(x => x.Editar(It.IsAny<Automovel>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = servicoAutomovel.Editar(automovel);

            //assert 
            resultado.Should().BeFailure();
            resultado.Errors[0].Message.Should().Be("Falha ao tentar editar automóvel.");
        }


        [TestMethod]
        public void Deve_excluir_automovel_caso_ela_esteja_cadastrado()
        {
            //arrange

            repositorioAutomovelMoq.Setup(x => x.Existe(automovel))
               .Returns(() =>
               {
                   return true;
               });

            //action
            var resultado = servicoAutomovel.Excluir(automovel);

            //assert 
            resultado.Should().BeSuccess();
            repositorioAutomovelMoq.Verify(x => x.Excluir(automovel), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_excluir_automovel_caso_ele_nao_esteja_cadastrado()
        {
            //arrange

            repositorioAutomovelMoq.Setup(x => x.Existe(automovel))
               .Returns(() =>
               {
                   return false;
               });

            //action
            var resultado = servicoAutomovel.Excluir(automovel);

            //assert 
            resultado.Should().BeFailure();
            repositorioAutomovelMoq.Verify(x => x.Excluir(automovel), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_excluir_automovel()
        {

            repositorioAutomovelMoq.Setup(x => x.Existe(automovel))
              .Throws(() =>
              {
                  return SqlExceptionCreator.NewSqlException();
              });

            //action
            Result resultado = servicoAutomovel.Excluir(automovel);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar excluir automóvel");
        }

    }    
}
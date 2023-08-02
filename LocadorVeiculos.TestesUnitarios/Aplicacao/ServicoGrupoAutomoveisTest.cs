using FluentAssertions;
using FluentResults;
using FluentResults.Extensions.FluentAssertions;
using FluentValidation.Results;
using LocadorAutomoveis.Aplicacao.ModuloGrupoAutomoveis;
using LocadorAutomoveis.Dominio.ModuloGrupoAutomoveis;
using Moq;

namespace LocadorAutomoveis.TestesUnitarios.Aplicacao
{
    [TestClass]
    public class ServicoGrupoAutomoveisTest
    {
        Mock<IRepositorioGrupoAutomoveis> repositorioGrupoAutomoveisMoq;
        Mock<IValidadorGrupoAutomoveis> validadorMoq;

        private ServicoGrupoAutomoveis servicoGrupoAutomoveis;

        GrupoAutomoveis grupo;

        public ServicoGrupoAutomoveisTest()
        {
            repositorioGrupoAutomoveisMoq = new Mock<IRepositorioGrupoAutomoveis>();
            validadorMoq = new Mock<IValidadorGrupoAutomoveis>();
            servicoGrupoAutomoveis = new ServicoGrupoAutomoveis(repositorioGrupoAutomoveisMoq.Object, validadorMoq.Object);
            grupo = new GrupoAutomoveis("Esportivo");
        }

        [TestMethod]
        public void Deve_inserir_grupoAutomoveis_caso_ele_for_valido() 
        {
            //arrange
            grupo = new GrupoAutomoveis("Esportivo");

            //action
            Result resultado = servicoGrupoAutomoveis.Inserir(grupo);

            //assert 
            resultado.Should().BeSuccess();
            repositorioGrupoAutomoveisMoq.Verify(x => x.Inserir(grupo), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_inserir_grupoAutomoveis_caso_ele_seja_invalido()
        {
            //arrange
            validadorMoq.Setup(x => x.Validate(It.IsAny<GrupoAutomoveis>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais"));
                    return resultado;
                });

            //action
            var resultado = servicoGrupoAutomoveis.Inserir(grupo);

            //assert             
            resultado.Should().BeFailure();
            repositorioGrupoAutomoveisMoq.Verify(x => x.Inserir(grupo), Times.Never());
        }

        [TestMethod]
        public void Nao_deve_inserir_grupoAutomoveis_caso_o_nome_ja_esteja_cadastrado() //cenário 3
        {
            //arrange
            string nomeGrupoAutomoveis = "Esportivo";
            repositorioGrupoAutomoveisMoq.Setup(x => x.SelecionarPorNome(nomeGrupoAutomoveis))
                .Returns(() =>
                {
                    return new GrupoAutomoveis(nomeGrupoAutomoveis);
                });
          
            //action
            var resultado = servicoGrupoAutomoveis.Inserir(grupo);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be($"Este nome '{nomeGrupoAutomoveis}' já está sendo utilizado");
            repositorioGrupoAutomoveisMoq.Verify(x => x.Inserir(grupo), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_inserir_grupoAutomoveis()
        {
            repositorioGrupoAutomoveisMoq.Setup(x => x.Inserir(It.IsAny<GrupoAutomoveis>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = servicoGrupoAutomoveis.Inserir(grupo);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar inserir grupoAutomóveis.");
        }


        [TestMethod]
        public void Deve_editar_grupoAutomoveis_caso_ele_for_valido() 
        {
            //arrange           
            grupo = new GrupoAutomoveis( "Utilitário");

            //action
            Result resultado = servicoGrupoAutomoveis.Editar(grupo);

            //assert 
            resultado.Should().BeSuccess();
            repositorioGrupoAutomoveisMoq.Verify(x => x.Editar(grupo), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_grupoAutomoveis_caso_ele_seja_invalido()
        {
            //arrange
            validadorMoq.Setup(x => x.Validate(It.IsAny<GrupoAutomoveis>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais"));
                    return resultado;
                });

            //action
            var resultado = servicoGrupoAutomoveis.Editar(grupo);

            //assert             
            resultado.Should().BeFailure();
            repositorioGrupoAutomoveisMoq.Verify(x => x.Editar(grupo), Times.Never());
        }

        [TestMethod]
        public void Deve_editar_grupoAutomoveis_com_o_mesmo_nome()
        {
            //arrange
            GrupoAutomoveis outroGrupo = new GrupoAutomoveis("Esportivo");
            Guid id = outroGrupo.Id;

            repositorioGrupoAutomoveisMoq.Setup(x => x.SelecionarPorNome("Esportivo"))
                 .Returns(() =>
                 {
                     return new GrupoAutomoveis(id, "Esportivo");
                 });

            //action
            var resultado = servicoGrupoAutomoveis.Editar(outroGrupo);

            //assert 
            resultado.Should().BeSuccess();

            repositorioGrupoAutomoveisMoq.Verify(x => x.Editar(outroGrupo), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_grupoAutomoveis_caso_o_nome_ja_esteja_cadastrado()
        {
            //arrange
            repositorioGrupoAutomoveisMoq.Setup(x => x.SelecionarPorNome("Esportivo"))
                 .Returns(() =>
                 {
                     return new GrupoAutomoveis( "Esportivo");
                 });

            GrupoAutomoveis novoGrupo = new GrupoAutomoveis("Esportivo");

            //action
            var resultado = servicoGrupoAutomoveis.Editar(novoGrupo);

            //assert 
            resultado.Should().BeFailure();

            repositorioGrupoAutomoveisMoq.Verify(x => x.Editar(novoGrupo), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_editar_grupoAutomoveis()
        {
            repositorioGrupoAutomoveisMoq.Setup(x => x.Editar(It.IsAny<GrupoAutomoveis>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = servicoGrupoAutomoveis.Editar(grupo);

            //assert 
            resultado.Should().BeFailure();
            resultado.Errors[0].Message.Should().Be("Falha ao tentar editar grupoAutomóveis.");
        }


        [TestMethod]
        public void Deve_excluir_grupoAutomoveis_caso_ela_esteja_cadastrado()
        {
            repositorioGrupoAutomoveisMoq.Setup(x => x.Existe(grupo))
               .Returns(() =>
               {
                   return true;
               });

            //action
            var resultado = servicoGrupoAutomoveis.Excluir(grupo);

            //assert 
            resultado.Should().BeSuccess();
            repositorioGrupoAutomoveisMoq.Verify(x => x.Excluir(grupo), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_excluir_grupoAutomoveis_caso_ele_nao_esteja_cadastrado()
        {
            //arrange

            var grupo = new GrupoAutomoveis( "Esportivo");

            repositorioGrupoAutomoveisMoq.Setup(x => x.Existe(grupo))
               .Returns(() =>
               {
                   return false;
               });

            //action
            var resultado = servicoGrupoAutomoveis.Excluir(grupo);

            //assert 
            resultado.Should().BeFailure();
            repositorioGrupoAutomoveisMoq.Verify(x => x.Excluir(grupo), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_excluir_grupoAutomoveis()
        {
            var grupo = new GrupoAutomoveis( "Esportivo");

            repositorioGrupoAutomoveisMoq.Setup(x => x.Existe(grupo))
              .Throws(() =>
              {
                  return SqlExceptionCreator.NewSqlException();
              });

            //action
            Result resultado = servicoGrupoAutomoveis.Excluir(grupo);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar excluir grupoAutomóveis");
        }

    }    
}
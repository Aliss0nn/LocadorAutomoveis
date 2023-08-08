using FluentAssertions;
using FluentResults;
using FluentResults.Extensions.FluentAssertions;
using FluentValidation.Results;
using LocadorAutomoveis.Aplicacao.ModuloPlanoCobranca;
using LocadorAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadorAutomoveis.Dominio.ModuloPlanoCobranca;
using Moq;

namespace LocadorAutomoveis.TestesUnitarios.Aplicacao
{
    [TestClass]
    public class ServicoPlanoCobrancaTest
    {
        Mock<IRepositorioPlanoCobranca> repositorioPlanoCobrancaMoq;
        Mock<IValidadorPlanoCobranca> validadorMoq;

        private ServicoPlanoCobranca servicoPlanoCobranca;

        PlanoCobranca plano;
        GrupoAutomoveis grupo;

        public ServicoPlanoCobrancaTest()
        {
            repositorioPlanoCobrancaMoq = new Mock<IRepositorioPlanoCobranca>();
            validadorMoq = new Mock<IValidadorPlanoCobranca>();
            servicoPlanoCobranca = new ServicoPlanoCobranca(repositorioPlanoCobrancaMoq.Object, validadorMoq.Object);
            grupo = new GrupoAutomoveis("Esportivo");
            plano = new PlanoCobranca(grupo, TipoPlanoEnum.Livre, 10, 0, 0);
        }

        [TestMethod]
        public void Deve_inserir_planoCobranca_caso_ele_for_valido() 
        {
            //action
            Result resultado = servicoPlanoCobranca.Inserir(plano);

            //assert 
            resultado.Should().BeSuccess();
            repositorioPlanoCobrancaMoq.Verify(x => x.Inserir(plano), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_inserir_planoCobranca_caso_ele_seja_invalido()
        {
            //arrange
            validadorMoq.Setup(x => x.Validate(It.IsAny<PlanoCobranca>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("PrecoDiario", "Preço diário não pode ser null"));
                    return resultado;
                });

            //action
            var resultado = servicoPlanoCobranca.Inserir(plano);

            //assert             
            resultado.Should().BeFailure();
            repositorioPlanoCobrancaMoq.Verify(x => x.Inserir(plano), Times.Never());
        }

        [TestMethod]
        public void Nao_deve_inserir_planoCobranca_caso_o_grupo_e_tipo_ja_esteja_cadastrado() //cenário 3
        {
            //arrange
            repositorioPlanoCobrancaMoq.Setup(x => x.SelecionarPorGrupoTipo(plano.Grupo, plano.TipoPlano))
                .Returns(() =>
                {
                    return new PlanoCobranca(plano.Grupo, plano.TipoPlano, 10, 0, 0);
                });
          
            //action
            var resultado = servicoPlanoCobranca.Inserir(plano);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be($"Este grupo '{plano.Grupo}' já está usando o plano '{plano.TipoPlano}'");
            repositorioPlanoCobrancaMoq.Verify(x => x.Inserir(plano), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_inserir_planoCobranca()
        {
            repositorioPlanoCobrancaMoq.Setup(x => x.Inserir(It.IsAny<PlanoCobranca>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = servicoPlanoCobranca.Inserir(plano);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar inserir plano de cobrança.");
        }


        [TestMethod]
        public void Deve_editar_planoCobranca_caso_ele_for_valido() 
        {
            //arrange           
            plano = new PlanoCobranca(grupo, TipoPlanoEnum.Diario, 20, 0, 0);

            //action
            Result resultado = servicoPlanoCobranca.Editar(plano);

            //assert 
            resultado.Should().BeSuccess();
            repositorioPlanoCobrancaMoq.Verify(x => x.Editar(plano), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_planoCobranca_caso_ele_seja_invalido()
        {
            //arrange
            validadorMoq.Setup(x => x.Validate(It.IsAny<PlanoCobranca>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("PrecoDiario", "Preço diário não pode ser null"));
                    return resultado;
                });

            //action
            var resultado = servicoPlanoCobranca.Editar(plano);

            //assert             
            resultado.Should().BeFailure();
            repositorioPlanoCobrancaMoq.Verify(x => x.Editar(plano), Times.Never());
        }

        [TestMethod]
        public void Deve_editar_planoCobranca_com_o_mesmo_grupo_e_tipo()
        {
            //arrange
            PlanoCobranca outroPlano = new PlanoCobranca(grupo, TipoPlanoEnum.Diario, 10, 0, 0);
            Guid id = outroPlano.Id;

            repositorioPlanoCobrancaMoq.Setup(x => x.SelecionarPorGrupoTipo(outroPlano.Grupo,outroPlano.TipoPlano))
                 .Returns(() =>
                 {
                     return new PlanoCobranca(id, outroPlano.Grupo, outroPlano.TipoPlano, 10, 0, 0);
                 });

            //action
            var resultado = servicoPlanoCobranca.Editar(outroPlano);

            //assert 
            resultado.Should().BeSuccess();

            repositorioPlanoCobrancaMoq.Verify(x => x.Editar(outroPlano), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_planoCobranca_caso_o_grupo_e_tipo_ja_esteja_cadastrado()
        {
            //arrange
            repositorioPlanoCobrancaMoq.Setup(x => x.SelecionarPorGrupoTipo(plano.Grupo, plano.TipoPlano))
                 .Returns(() =>
                 {
                     return new PlanoCobranca(plano.Grupo, plano.TipoPlano, 10, 0, 0);
                 });

            PlanoCobranca novoPlano = new PlanoCobranca(plano.Grupo, plano.TipoPlano, 10, 0, 0);

            //action
            var resultado = servicoPlanoCobranca.Editar(novoPlano);

            //assert 
            resultado.Should().BeFailure();

            repositorioPlanoCobrancaMoq.Verify(x => x.Editar(novoPlano), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_editar_planoCobranca()
        {
            repositorioPlanoCobrancaMoq.Setup(x => x.Editar(It.IsAny<PlanoCobranca>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = servicoPlanoCobranca.Editar(plano);

            //assert 
            resultado.Should().BeFailure();
            resultado.Errors[0].Message.Should().Be("Falha ao tentar editar plano de cobrança.");
        }


        [TestMethod]
        public void Deve_excluir_planoCobranca_caso_ela_esteja_cadastrado()
        {
            //arrange

            repositorioPlanoCobrancaMoq.Setup(x => x.Existe(plano))
               .Returns(() =>
               {
                   return true;
               });

            //action
            var resultado = servicoPlanoCobranca.Excluir(plano);

            //assert 
            resultado.Should().BeSuccess();
            repositorioPlanoCobrancaMoq.Verify(x => x.Excluir(plano), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_excluir_planoCobranca_caso_ele_nao_esteja_cadastrado()
        {
            //arrange

            repositorioPlanoCobrancaMoq.Setup(x => x.Existe(plano))
               .Returns(() =>
               {
                   return false;
               });

            //action
            var resultado = servicoPlanoCobranca.Excluir(plano);

            //assert 
            resultado.Should().BeFailure();
            repositorioPlanoCobrancaMoq.Verify(x => x.Excluir(plano), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_excluir_planoCobranca()
        {

            repositorioPlanoCobrancaMoq.Setup(x => x.Existe(plano))
              .Throws(() =>
              {
                  return SqlExceptionCreator.NewSqlException();
              });

            //action
            Result resultado = servicoPlanoCobranca.Excluir(plano);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar excluir plano de cobrança");
        }

    }    
}
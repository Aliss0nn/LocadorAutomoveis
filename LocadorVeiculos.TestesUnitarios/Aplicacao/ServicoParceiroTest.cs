using FluentAssertions;
using FluentResults;
using FluentResults.Extensions.FluentAssertions;
using FluentValidation.Results;
using LocadorAutomoveis.Aplicacao.ModuloParceiro;
using LocadorAutomoveis.Dominio;
using LocadorAutomoveis.Dominio.ModuloParceiro;
using Moq;

namespace LocadorAutomoveisTestesUnitarios.Aplicacao
{
    [TestClass]
    public class ServicoParceiroTest
    {
        Mock<IRepositorioParceiro> repositorioParceiroMoq;
        Mock<IValidadorParceiro> validadorMoq;
        Mock<IContextoPersistencia> contextoPersistenciaMoq;

        private ServicoParceiro servicoParceiro;

        Parceiro parceiro;

        public ServicoParceiroTest()
        {
            repositorioParceiroMoq = new Mock<IRepositorioParceiro>();
            validadorMoq = new Mock<IValidadorParceiro>();
            servicoParceiro = new ServicoParceiro(repositorioParceiroMoq.Object, validadorMoq.Object, contextoPersistenciaMoq.Object);
            parceiro = new Parceiro("Posto Shell");
        }

        [TestMethod]
        public void Deve_inserir_parceiro_caso_ela_for_valida() //cenário 1
        {
            //arrange
            parceiro = new Parceiro("Posto Shell");

            //action
            Result resultado = servicoParceiro.Inserir(parceiro);

            //assert 
            resultado.Should().BeSuccess();
            repositorioParceiroMoq.Verify(x => x.Inserir(parceiro), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_inserir_parceiro_caso_ela_seja_invalida() //cenário 2
        {
            //arrange
            validadorMoq.Setup(x => x.Validate(It.IsAny<Parceiro>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais"));
                    return resultado;
                });

            //action
            var resultado = servicoParceiro.Inserir(parceiro);

            //assert             
            resultado.Should().BeFailure();
            repositorioParceiroMoq.Verify(x => x.Inserir(parceiro), Times.Never());
        }

        [TestMethod]
        public void Nao_deve_inserir_parceiro_caso_o_nome_ja_esteja_cadastrado() //cenário 3
        {
            //arrange
            string nomeparceiro = "parceiro";
            repositorioParceiroMoq.Setup(x => x.SelecionarPorNome(nomeparceiro))
                .Returns(() =>
                {
                    return new Parceiro(nomeparceiro);
                });

            //action
            var resultado = servicoParceiro.Inserir(parceiro);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be($"Este nome '{nomeparceiro}' já está sendo utilizado");
            repositorioParceiroMoq.Verify(x => x.Inserir(parceiro), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_inserir_parceiro() //cenário 4
        {
            repositorioParceiroMoq.Setup(x => x.Inserir(It.IsAny<Parceiro>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = servicoParceiro.Inserir(parceiro);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar inserir parceiro.");
        }


        [TestMethod]
        public void Deve_editar_parceiro_caso_ela_for_valida() //cenário 1
        {
            //arrange           
            parceiro = new Parceiro("parceiro");

            //action
            Result resultado = servicoParceiro.Editar(parceiro);

            //assert 
            resultado.Should().BeSuccess();
            repositorioParceiroMoq.Verify(x => x.Editar(parceiro), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_parceiro_caso_ela_seja_invalida() //cenário 2
        {
            //arrange
            validadorMoq.Setup(x => x.Validate(It.IsAny<Parceiro>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais"));
                    return resultado;
                });

            //action
            var resultado = servicoParceiro.Editar(parceiro);

            //assert             
            resultado.Should().BeFailure();
            repositorioParceiroMoq.Verify(x => x.Editar(parceiro), Times.Never());
        }

        [TestMethod]
        public void Deve_editar_parceiro_com_o_mesmo_nome() //cenário 3
        {
            //arrange
            Parceiro outraparceiro = new Parceiro("parceiro");

            Guid id = outraparceiro.Id;

            repositorioParceiroMoq.Setup(x => x.SelecionarPorNome("parceiro"))
                 .Returns(() =>
                 {
                     return new Parceiro(id, "parceiro");
                 });

            //action
            var resultado = servicoParceiro.Editar(outraparceiro);

            //assert 
            resultado.Should().BeSuccess();

            repositorioParceiroMoq.Verify(x => x.Editar(outraparceiro), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_parceiro_caso_o_nome_ja_esteja_cadastrado() //cenário 4
        {
            //arrange
            repositorioParceiroMoq.Setup(x => x.SelecionarPorNome("parceiro"))
                 .Returns(() =>
                 {
                     return new Parceiro("parceiro");
                 });

            Parceiro novaparceiro = new Parceiro("parceiro");

            //action
            var resultado = servicoParceiro.Editar(novaparceiro);

            //assert 
            resultado.Should().BeFailure();

            repositorioParceiroMoq.Verify(x => x.Editar(novaparceiro), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_editar_parceiro() //cenário 5
        {
            repositorioParceiroMoq.Setup(x => x.Editar(It.IsAny<Parceiro>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = servicoParceiro.Editar(parceiro);

            //assert 
            resultado.Should().BeFailure();
            resultado.Errors[0].Message.Should().Be("Falha ao tentar editar parceiro.");
        }


        [TestMethod]
        public void Deve_excluir_parceiro_caso_ela_esteja_cadastrada() //cenário 1
        {
            //arrange
            var parceiro = new Parceiro("parceiro");

            repositorioParceiroMoq.Setup(x => x.Existe(parceiro))
               .Returns(() =>
               {
                   return true;
               });

            //action
            var resultado = servicoParceiro.Excluir(parceiro);

            //assert 
            resultado.Should().BeSuccess();
            repositorioParceiroMoq.Verify(x => x.Excluir(parceiro), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_excluir_parceiro_caso_ela_nao_esteja_cadastrada() //cenário 2
        {
            //arrange

            var parceiro = new Parceiro("parceiro");

            repositorioParceiroMoq.Setup(x => x.Existe(parceiro))
               .Returns(() =>
               {
                   return false;
               });

            //action
            var resultado = servicoParceiro.Excluir(parceiro);

            //assert 
            resultado.Should().BeFailure();
            repositorioParceiroMoq.Verify(x => x.Excluir(parceiro), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_excluir_parceiro() //cenário 4
        {
            var parceiro = new Parceiro("parceiro");

            repositorioParceiroMoq.Setup(x => x.Existe(parceiro))
              .Throws(() =>
              {
                  return SqlExceptionCreator.NewSqlException();
              });

            //action
            Result resultado = servicoParceiro.Excluir(parceiro);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar excluir parceiro");
        }
    }
        

}

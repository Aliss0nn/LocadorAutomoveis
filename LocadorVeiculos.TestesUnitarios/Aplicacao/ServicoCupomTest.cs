using FluentAssertions;
using FluentResults;
using FluentResults.Extensions.FluentAssertions;
using FluentValidation.Results;
using LocadorAutomoveis.Aplicacao.ModuloCupom;
using LocadorAutomoveis.Dominio;
using LocadorAutomoveis.Dominio.ModuloCupom;
using LocadorAutomoveis.Dominio.ModuloParceiro;
using Moq;

namespace LocadorAutomoveisTestesUnitarios.Aplicacao
{
    public class ServicoCupomTest
    {
        Mock<IRepositorioCupom> repositorioCupomMoq;
        Mock<IValidadorCupom> validadorCupomMoq;
        Mock<IContextoPersistencia> contextoPersistenciaMoq;

        ServicoCupom servicoCupom;
        Cupom cupom;
        Parceiro parceiro;

        ServicoCupomTest()
        {
            repositorioCupomMoq = new Mock<IRepositorioCupom>();
            validadorCupomMoq = new Mock<IValidadorCupom>();
            servicoCupom = new ServicoCupom(repositorioCupomMoq.Object, validadorCupomMoq.Object, contextoPersistenciaMoq.Object);
            parceiro = new Parceiro("Parceiro");
            cupom = new Cupom("cupom",100,DateTime.Today,parceiro);
        }
        [TestMethod]
        public void Deve_inserir_cupom_caso_ela_for_valido() //cenário 1
        {
            //arrange
            cupom = new Cupom("cupom", 100, DateTime.Today, parceiro);

            //action
            Result resultado = servicoCupom.Inserir(cupom);

            //assert 
            resultado.Should().BeSuccess();
            repositorioCupomMoq.Verify(x => x.Inserir(cupom), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_inserir_cupom_caso_ela_seja_invalido() //cenário 2
        {
            //arrange
            validadorCupomMoq.Setup(x => x.Validate(It.IsAny<Cupom>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais"));
                    return resultado;
                });

            //action
            var resultado = servicoCupom.Inserir(cupom);

            //assert             
            resultado.Should().BeFailure();
            repositorioCupomMoq.Verify(x => x.Inserir(cupom), Times.Never());
        }

        [TestMethod]
        public void Nao_deve_inserir_cupom_caso_o_nome_ja_esteja_cadastrado() //cenário 3
        {
            //arrange
            string nomeCupom = "cupom";
            repositorioCupomMoq.Setup(x => x.SelecionarPorNome(nomeCupom))
                .Returns(() =>
                {
                    return new Exception(nomeCupom);
                });

            //action
            var resultado = servicoCupom.Inserir(cupom);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be($"Este nome '{nomeCupom}' já está sendo utilizado");
            repositorioCupomMoq.Verify(x => x.Inserir(cupom), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_inserir_cupom() //cenário 4
        {
            repositorioCupomMoq.Setup(x => x.Inserir(It.IsAny<Cupom>()))
            .Throws(() =>
            {
                return new Exception();
                });

            //action
            Result resultado = servicoCupom.Inserir(cupom);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar inserir cupom.");
        }


        [TestMethod]
        public void Deve_editar_cupom_caso_ela_for_valida() //cenário 1
        {
            //arrange           
            cupom = new Cupom("cupom", 100, DateTime.Today, parceiro);

            //action
            Result resultado = servicoCupom.Editar(cupom);

            //assert 
            resultado.Should().BeSuccess();
            repositorioCupomMoq.Verify(x => x.Editar(cupom), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_cupom_caso_ela_seja_invalida() //cenário 2
        {
            //arrange
            validadorCupomMoq.Setup(x => x.Validate(It.IsAny<Cupom>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais"));
                    return resultado;
                });

            //action
            var resultado = servicoCupom.Editar(cupom);

            //assert             
            resultado.Should().BeFailure();
            repositorioCupomMoq.Verify(x => x.Editar(cupom), Times.Never());
        }

        [TestMethod]
        public void Deve_editar_cupom_com_o_mesmo_nome() //cenário 3
        {
            //arrange
            Cupom outraDisciplina = new Cupom("cupom", 100, DateTime.Today, parceiro);

            Guid id = outraDisciplina.Id;

            repositorioCupomMoq.Setup(x => x.SelecionarPorNome("Educação Física"))
                 .Returns(() =>
                 {
                     return new Cupom(id, "cupom", 100, DateTime.Today, parceiro);
                 });

            //action
            var resultado = servicoCupom.Editar(outraDisciplina);

            //assert 
            resultado.Should().BeSuccess();

            repositorioCupomMoq.Verify(x => x.Editar(outraDisciplina), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_cupom_caso_o_nome_ja_esteja_cadastrado() //cenário 4
        {
            //arrange
            repositorioCupomMoq.Setup(x => x.SelecionarPorNome("cupom"))
                 .Returns(() =>
                 {
                     return new Cupom("cupom", 100, DateTime.Today, parceiro);
                 });

            Cupom novaDisciplina = new Cupom("cupom", 100, DateTime.Today, parceiro);

            //action
            var resultado = servicoCupom.Editar(novaDisciplina);

            //assert 
            resultado.Should().BeFailure();

            repositorioCupomMoq.Verify(x => x.Editar(novaDisciplina), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_editar_cupom() //cenário 5
        {
            repositorioCupomMoq.Setup(x => x.Editar(It.IsAny<Cupom>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = servicoCupom.Editar(cupom);

            //assert 
            resultado.Should().BeFailure();
            resultado.Errors[0].Message.Should().Be("Falha ao tentar editar cupom.");
        }


        [TestMethod]
        public void Deve_excluir_cupom_caso_ela_esteja_cadastrada() //cenário 1
        {
            //arrange
            var cupom = new Cupom("cupom", 100, DateTime.Today, parceiro);

            repositorioCupomMoq.Setup(x => x.Existe(cupom))
            .Returns(() =>
            {
                   return true;
               });

            //action
            var resultado = servicoCupom.Excluir(cupom);

            //assert 
            resultado.Should().BeSuccess();
            repositorioCupomMoq.Verify(x => x.Excluir(cupom), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_excluir_cupom_caso_ela_nao_esteja_cadastrada() //cenário 2
        {
            //arrange

            var cupom = new Cupom("cupom", 100, DateTime.Today, parceiro);

            repositorioCupomMoq.Setup(x => x.Existe(cupom))
               .Returns(() =>
               {
                   return false;
               });

            //action
            var resultado = servicoCupom.Excluir(cupom);

            //assert 
            resultado.Should().BeFailure();
            repositorioCupomMoq.Verify(x => x.Excluir(cupom), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_excluir_cupom() //cenário 4
        {
            var cupom = new Cupom("cupom", 100, DateTime.Today, parceiro);

            repositorioCupomMoq.Setup(x => x.Existe(cupom))
              .Throws(() =>
              {
                  return SqlExceptionCreator.NewSqlException();
              });

            //action
            Result resultado = servicoCupom.Excluir(cupom);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar excluir cupom");
        }


    }
}

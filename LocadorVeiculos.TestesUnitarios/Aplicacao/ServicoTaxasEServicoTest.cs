using FluentAssertions;
using FluentResults;
using FluentResults.Extensions.FluentAssertions;
using FluentValidation.Results;
using LocadorAutomoveis.Aplicacao.ModuloTaxasEServicos;
using LocadorAutomoveis.Dominio;
using LocadorAutomoveis.Dominio.ModuloTaxasEServicos;
using Moq;

namespace LocadorAutomoveisTestesUnitarios.Aplicacao
{
 
    public class ServicoTaxasEServicoTest
    {
        Mock<IRepositorioTaxasServico> repositorioMoq;
        Mock<IValidadorTaxasServico> validadorMoq;
        Mock<IContextoPersistencia> contextoPersistenciaMoq;

        private ServicoTaxasEServicos servicoTaxasEServicos;
        private TaxasEServico taxasEServico;

        public ServicoTaxasEServicoTest()
        {
            repositorioMoq = new Mock <IRepositorioTaxasServico>();
            validadorMoq = new Mock<IValidadorTaxasServico>();
            contextoPersistenciaMoq = new Mock<IContextoPersistencia>();
            servicoTaxasEServicos = new ServicoTaxasEServicos(repositorioMoq.Object,validadorMoq.Object,contextoPersistenciaMoq.Object);
            taxasEServico = new TaxasEServico("TaxaServico",50,"Plano Diário");
        }

        [TestMethod]
        public void Deve_inserir_TaxasEServico_caso_ela_for_valida() //cenário 1
        {
            //arrange
            taxasEServico = new TaxasEServico("teste",30,"teste2");

            //action
            Result resultado = servicoTaxasEServicos.Inserir(taxasEServico);

            //assert 
            resultado.Should().BeSuccess();
            repositorioMoq.Verify(x => x.Inserir(taxasEServico),Times.Once());
        }

        [TestMethod]
        public void Nao_deve_inserir_TaxasEServico_caso_ela_seja_invalida() //cenário 2
        {
            //arrange
            validadorMoq.Setup(x => x.Validate(It.IsAny<TaxasEServico>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais"));
                    return resultado;
                });

            //action
            var resultado = servicoTaxasEServicos.Inserir(taxasEServico);

            //assert             
            resultado.Should().BeFailure();
            repositorioMoq.Verify(x => x.Inserir(taxasEServico), Times.Never());
        }

        [TestMethod]
        public void Nao_deve_inserir_TaxasEServico_caso_o_nome_ja_esteja_cadastrado() //cenário 3
        {
            //arrange
            string nomeTaxasEServico = "TaxasEServico";
            repositorioMoq.Setup(x => x.SelecionarPorNome(nomeTaxasEServico))
                .Returns(() =>
                {
                    return new Exception(nomeTaxasEServico);
                });

            //action
            var resultado = servicoTaxasEServicos.Inserir(taxasEServico);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be($"Este nome '{nomeTaxasEServico}' já está sendo utilizado");
            repositorioMoq.Verify(x => x.Inserir(taxasEServico), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_inserir_TaxasEServico() //cenário 4
        {
            repositorioMoq.Setup(x => x.Inserir(It.IsAny<TaxasEServico>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = servicoTaxasEServicos.Inserir(taxasEServico);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar inserir TaxasEServico.");
        }


        [TestMethod]
        public void Deve_editar_TaxasEServico_caso_ela_for_valida() //cenário 1
        {
            //arrange           
            taxasEServico = new TaxasEServico("TaxasEServico",100,"planoTeste");

            //action
            Result resultado = servicoTaxasEServicos.Editar(taxasEServico);

            //assert 
            resultado.Should().BeSuccess();
            repositorioMoq.Verify(x => x.Editar(taxasEServico), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_TaxasEServico_caso_ela_seja_invalida() //cenário 2
        {
            //arrange
            validadorMoq.Setup(x => x.Validate(It.IsAny<TaxasEServico>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais"));
                    return resultado;
                });

            //action
            var resultado = servicoTaxasEServicos.Editar(taxasEServico);

            //assert             
            resultado.Should().BeFailure();
            repositorioMoq.Verify(x => x.Editar(taxasEServico), Times.Never());
        }

        [TestMethod]
        public void Deve_editar_TaxasEServico_com_o_mesmo_nome() //cenário 3
        {
            //arrange
            TaxasEServico outraTaxasEServico = new TaxasEServico("TaxasEServico", 100, "Preço Fixo");

            Guid id = outraTaxasEServico.Id;

            repositorioMoq.Setup(x => x.SelecionarPorNome("TaxasEServico"))
                 .Returns(() =>
                 {
                     return new TaxasEServico(id, "TaxasEServico",100,"Preço Fixo");
                 });

            //action
            var resultado = servicoTaxasEServicos.Editar(taxasEServico);

            //assert 
            resultado.Should().BeSuccess();

            repositorioMoq.Verify(x => x.Editar(outraTaxasEServico), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_TaxasEServico_caso_o_nome_ja_esteja_cadastrado() //cenário 4
        {
            //arrange
            repositorioMoq.Setup(x => x.SelecionarPorNome("TaxasEServico"))
                 .Returns(() =>
                 {
                     return new TaxasEServico("TaxasEServico", 100, "planoTeste");
                 });

            TaxasEServico novaTaxasEServico = new TaxasEServico("TaxasEServico", 100, "planoTeste");

            //action
            var resultado = servicoTaxasEServicos.Editar(taxasEServico);

            //assert 
            resultado.Should().BeFailure();

            repositorioMoq.Verify(x => x.Editar(novaTaxasEServico), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_editar_TaxasEServico() //cenário 5
        {
            repositorioMoq.Setup(x => x.Editar(It.IsAny<TaxasEServico>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = servicoTaxasEServicos.Editar(taxasEServico);

            //assert 
            resultado.Should().BeFailure();
            resultado.Errors[0].Message.Should().Be("Falha ao tentar editar TaxasEServico.");
        }


        [TestMethod]
        public void Deve_excluir_TaxasEServico_caso_ela_esteja_cadastrada() //cenário 1
        {
            //arrange
            var TaxasEServico = new TaxasEServico("TaxasEServico", 100, "planoTeste");

            repositorioMoq.Setup(x => x.Existe(TaxasEServico))
            .Returns(() =>
            {
                   return true;
               });

            //action
            var resultado = servicoTaxasEServicos.Excluir(taxasEServico);

            //assert 
            resultado.Should().BeSuccess();
            repositorioMoq.Verify(x => x.Excluir(TaxasEServico), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_excluir_TaxasEServico_caso_ela_nao_esteja_cadastrada() //cenário 2
        {
            //arrange

            var TaxasEServico = new TaxasEServico("TaxasEServico", 100, "planoTeste");

            repositorioMoq.Setup(x => x.Existe(TaxasEServico))
            .Returns(() =>
            {
                   return false;
               });

            //action
            var resultado = servicoTaxasEServicos.Excluir(taxasEServico);

            //assert 
            resultado.Should().BeFailure();
            repositorioMoq.Verify(x => x.Excluir(TaxasEServico), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_excluir_TaxasEServico() //cenário 4
        {
            var TaxasEServico = new TaxasEServico("TaxasEServico", 100, "planoTeste");

            repositorioMoq.Setup(x => x.Existe(TaxasEServico))
              .Throws(() =>
              {
                  return SqlExceptionCreator.NewSqlException();
              });

            //action
            Result resultado = servicoTaxasEServicos.Excluir(taxasEServico);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar excluir TaxasEServico");
        }
    }
}

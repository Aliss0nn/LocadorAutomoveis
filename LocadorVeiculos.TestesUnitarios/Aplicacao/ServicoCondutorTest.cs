using FluentAssertions;
using FluentResults;
using FluentResults.Extensions.FluentAssertions;
using FluentValidation.Results;
using LocadorAutomoveis.Aplicacao.ModuloCondutor;
using LocadorAutomoveis.Dominio;
using LocadorAutomoveis.Dominio.ModuloClientes;
using LocadorAutomoveis.Dominio.ModuloCondutor;
using Moq;

namespace LocadorAutomoveisTestesUnitarios.Aplicacao
{
    [TestClass]
    public class ServicoCondutorTest
    {
        Mock<IRepositorioCondutor> repositorioCondutorMoq;
        Mock<IValidadorCondutor> validadorCondutorMoq;
        Mock<IContextoPersistencia> contextoPersistenciaMoq;

        ServicoCondutor servicoCondutor;
        Condutor condutor;
        Clientes clientes;

        ServicoCondutorTest()
        {
            repositorioCondutorMoq = new Mock<IRepositorioCondutor>();
            validadorCondutorMoq = new Mock<IValidadorCondutor>();
            contextoPersistenciaMoq = new Mock<IContextoPersistencia>();
            servicoCondutor = new ServicoCondutor(repositorioCondutorMoq.Object,validadorCondutorMoq.Object,contextoPersistenciaMoq.Object);
            clientes = new Clientes();
            condutor = new Condutor("TesteNome","email@gmail.com","123456789","323222121","321312312314",DateTime.Today,condutor.ClienteEhCondutor,clientes);
        }

        [TestMethod]
        public void Deve_inserir_condutor_caso_ela_for_valido() //cenário 1
        {
            //arrange
            condutor = new Condutor("TesteNome", "email@gmail.com", "123456789", "323222121", "321312312314", DateTime.Today, condutor.ClienteEhCondutor, clientes);

            //action
            Result resultado = servicoCondutor.Inserir(condutor);

            //assert 
            resultado.Should().BeSuccess();
            repositorioCondutorMoq.Verify(x => x.Inserir(condutor), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_inserir_condutor_caso_ela_seja_invalido() //cenário 2
        {
            //arrange
            validadorCondutorMoq.Setup(x => x.Validate(It.IsAny<Condutor>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais"));
                    return resultado;
                });

            //action
            var resultado = servicoCondutor.Inserir(condutor);

            //assert             
            resultado.Should().BeFailure();
            repositorioCondutorMoq.Verify(x => x.Inserir(condutor), Times.Never());
        }

        [TestMethod]
        public void Nao_deve_inserir_condutor_caso_o_nome_ja_esteja_cadastrado() //cenário 3
        {
            //arrange
            string nomeCupom = "condutor";
            repositorioCondutorMoq.Setup(x => x.SelecionarPorNome(nomeCupom))
            .Returns(() =>
            {
                    return new Exception(nomeCupom);
                });

            //action
            var resultado = servicoCondutor.Inserir(condutor);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be($"Este nome '{nomeCupom}' já está sendo utilizado");
            repositorioCondutorMoq.Verify(x => x.Inserir(condutor), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_inserir_condutor() //cenário 4
        {
            repositorioCondutorMoq.Setup(x => x.Inserir(It.IsAny<Condutor>()))
            .Throws(() =>
            {
                return new Exception();
            });

            //action
            Result resultado = servicoCondutor.Inserir(condutor);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar inserir condutor.");
        }


        [TestMethod]
        public void Deve_editar_condutor_caso_ela_for_valida() //cenário 1
        {
            //arrange           
            condutor = new Condutor("TesteNome", "email@gmail.com", "123456789", "323222121", "321312312314", DateTime.Today, condutor.ClienteEhCondutor, clientes);

            //action
            Result resultado = servicoCondutor.Editar(condutor);

            //assert 
            resultado.Should().BeSuccess();
            repositorioCondutorMoq.Verify(x => x.Editar(condutor), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_condutor_caso_ela_seja_invalida() //cenário 2
        {
            //arrange
            validadorCondutorMoq.Setup(x => x.Validate(It.IsAny<Condutor>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais"));
                    return resultado;
                });

            //action
            var resultado = servicoCondutor.Editar(condutor);

            //assert             
            resultado.Should().BeFailure();
            repositorioCondutorMoq.Verify(x => x.Editar(condutor), Times.Never());
        }

        [TestMethod]
        public void Deve_editar_condutor_com_o_mesmo_nome() //cenário 3
        {
            //arrange
            Condutor outroCondutor = new Condutor("TesteNome", "email@gmail.com", "123456789", "323222121", "321312312314", DateTime.Today, condutor.ClienteEhCondutor, clientes);

            Guid id = outroCondutor.Id;

            repositorioCondutorMoq.Setup(x => x.SelecionarPorNome("Educação Física"))
                 .Returns(() =>
                 {
                     return new Condutor(id, "TesteNome", "email@gmail.com", "123456789", "323222121", "321312312314", DateTime.Today, condutor.ClienteEhCondutor, clientes);
                 });

            //action
            var resultado = servicoCondutor.Editar(outroCondutor);

            //assert 
            resultado.Should().BeSuccess();

            repositorioCondutorMoq.Verify(x => x.Editar(outroCondutor), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_condutor_caso_o_nome_ja_esteja_cadastrado() //cenário 4
        {
            //arrange
            repositorioCondutorMoq.Setup(x => x.SelecionarPorNome("condutor"))
            .Returns(() =>
            {
                     return new Condutor("TesteNome", "email@gmail.com", "123456789", "323222121", "321312312314", DateTime.Today, condutor.ClienteEhCondutor, clientes);
            });

            Condutor novoCondutor = new Condutor("TesteNome", "email@gmail.com", "123456789", "323222121", "321312312314", DateTime.Today, condutor.ClienteEhCondutor, clientes);

            //action
            var resultado = servicoCondutor.Editar(novoCondutor);

            //assert 
            resultado.Should().BeFailure();

            repositorioCondutorMoq.Verify(x => x.Editar(novoCondutor), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_editar_condutor() //cenário 5
        {
            repositorioCondutorMoq.Setup(x => x.Editar(It.IsAny<Condutor>()))
            .Throws(() =>
            {
                return new Exception();
                });

            //action
            Result resultado = servicoCondutor.Editar(condutor);

            //assert 
            resultado.Should().BeFailure();
            resultado.Errors[0].Message.Should().Be("Falha ao tentar editar condutor.");
        }


        [TestMethod]
        public void Deve_excluir_condutor_caso_ela_esteja_cadastrada() //cenário 1
        {
            //arrange
            var condutor = new Condutor("TesteNome", "email@gmail.com", "123456789", "323222121", "321312312314", DateTime.Today, false, clientes);

            repositorioCondutorMoq.Setup(x => x.Existe(condutor))
            .Returns(() =>
            {
                return true;
            });

            //action
            var resultado = servicoCondutor.Excluir(condutor);

            //assert 
            resultado.Should().BeSuccess();
            repositorioCondutorMoq.Verify(x => x.Excluir(condutor), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_excluir_condutor_caso_ela_nao_esteja_cadastrada() //cenário 2
        {
            //arrange

            var condutor = new Condutor("TesteNome", "email@gmail.com", "123456789", "323222121", "321312312314", DateTime.Today, false, clientes);

            repositorioCondutorMoq.Setup(x => x.Existe(condutor))
            .Returns(() =>
            {
                   return false;
               });

            //action
            var resultado = servicoCondutor.Excluir(condutor);

            //assert 
            resultado.Should().BeFailure();
            repositorioCondutorMoq.Verify(x => x.Excluir(condutor), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_excluir_condutor() //cenário 4
        {
            var condutor = new Condutor("TesteNome", "email@gmail.com", "123456789", "323222121", "321312312314", DateTime.Today, false, clientes);

            repositorioCondutorMoq.Setup(x => x.Existe(condutor))
              .Throws(() =>
              {
                  return SqlExceptionCreator.NewSqlException();
              });

            //action
            Result resultado = servicoCondutor.Excluir(condutor);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar excluir condutor");
        }
    }
}

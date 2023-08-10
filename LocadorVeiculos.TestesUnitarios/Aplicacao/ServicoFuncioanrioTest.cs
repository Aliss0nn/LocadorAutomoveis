using FluentAssertions;
using FluentResults;
using FluentResults.Extensions.FluentAssertions;
using FluentValidation.Results;
using LocadorAutomoveis.Aplicacao.ModuloFuncionario;
using LocadorAutomoveis.Dominio;
using LocadorAutomoveis.Dominio.ModuloFuncionario;
using Moq;

namespace LocadorAutomoveisTestesUnitarios.Aplicacao
{
    [TestClass]
    public class ServicoFuncionarioTest
    {
        Mock<IRepositorioFuncionario> repositorioFuncionarioMoq;
        Mock<IValidadorFuncionario> validadorMoq;
        Mock<IContextoPersistencia> contextoPersistenciaMoq;

        private ServicoFuncionario servicoFuncionario;

        Funcionario funcionario;

        DateTime novadata =  DateTime.Now.AddDays(1);

        public ServicoFuncionarioTest()
        {
            repositorioFuncionarioMoq = new Mock<IRepositorioFuncionario>();
            validadorMoq = new Mock<IValidadorFuncionario>();
            contextoPersistenciaMoq = new Mock<IContextoPersistencia>();
            servicoFuncionario = new ServicoFuncionario(repositorioFuncionarioMoq.Object, validadorMoq.Object, contextoPersistenciaMoq.Object);
            funcionario = new Funcionario("funcionario");
        }

        [TestMethod]
        public void Deve_inserir_funcionario_caso_ele_for_valida() //cenário 1
        {
            //arrange
            funcionario = new Funcionario("funcionario",novadata,1280);

            //action
            Result resultado = servicoFuncionario.Inserir(funcionario);

            //assert 
            resultado.Should().BeSuccess();
            repositorioFuncionarioMoq.Verify(x => x.Inserir(funcionario), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_inserir_funcionario_caso_ela_seja_invalida() //cenário 2
        {
            //arrange
            validadorMoq.Setup(x => x.Validate(It.IsAny<Funcionario>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais"));
                    return resultado;
                });

            //action
            var resultado = servicoFuncionario.Inserir(funcionario);

            //assert             
            resultado.Should().BeFailure();
            repositorioFuncionarioMoq.Verify(x => x.Inserir(funcionario), Times.Never());
        }

        [TestMethod]
        public void Nao_deve_inserir_funcionario_caso_o_nome_ja_esteja_cadastrado() //cenário 3
        {
            //arrange
            string nomefuncionario = "funcionario";
            repositorioFuncionarioMoq.Setup(x => x.SelecionarPorNome(nomefuncionario))
                .Returns(() =>
                {
                    return new Funcionario(nomefuncionario);
                });

            //action
            var resultado = servicoFuncionario.Inserir(funcionario);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be($"Este nome '{nomefuncionario}' já está sendo utilizado");
            repositorioFuncionarioMoq.Verify(x => x.Inserir(funcionario), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_inserir_funcionario() //cenário 4
        {
            repositorioFuncionarioMoq.Setup(x => x.Inserir(It.IsAny<Funcionario>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = servicoFuncionario.Inserir(funcionario);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar inserir Funcionario.");
        }


        [TestMethod]
        public void Deve_editar_funcionarios_caso_ela_for_valida() //cenário 1
        {
            //arrange           
            funcionario = new Funcionario("funcionario",novadata,1200);

            //action
            Result resultado = servicoFuncionario.Editar(funcionario);

            //assert 
            resultado.Should().BeSuccess();
            repositorioFuncionarioMoq.Verify(x => x.Editar(funcionario), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_funcionario_caso_ela_seja_invalida() //cenário 2
        {
            //arrange
            validadorMoq.Setup(x => x.Validate(It.IsAny<Funcionario>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais"));
                    return resultado;
                });

            //action
            var resultado = servicoFuncionario.Editar(funcionario);

            //assert             
            resultado.Should().BeFailure();
            repositorioFuncionarioMoq.Verify(x => x.Editar(funcionario), Times.Never());
        }

        [TestMethod]
        public void Deve_editar_funcionario_com_o_mesmo_nome() //cenário 3
        {
            //arrange
            Funcionario outrafuncionario = new Funcionario("funcionario",novadata,1220);

            Guid id = outrafuncionario.Id;

            repositorioFuncionarioMoq.Setup(x => x.SelecionarPorNome("funcionario"))
                 .Returns(() =>
                 {
                     return new Funcionario(id,"funcionario", novadata, 1220);
                 });

            //action
            var resultado = servicoFuncionario.Editar(outrafuncionario);

            //assert 
            resultado.Should().BeSuccess();

            repositorioFuncionarioMoq.Verify(x => x.Editar(outrafuncionario), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_funcionario_caso_o_nome_ja_esteja_cadastrado() //cenário 4
        {
            //arrange
            repositorioFuncionarioMoq.Setup(x => x.SelecionarPorNome("funcionario"))
                 .Returns(() =>
                 {
                     return new Funcionario("funcionario");
                 });

            Funcionario novafuncionario = new Funcionario("funcionario", novadata, 1220);

            //action
            var resultado = servicoFuncionario.Editar(novafuncionario);

            //assert 
            resultado.Should().BeFailure();

            repositorioFuncionarioMoq.Verify(x => x.Editar(novafuncionario), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_editar_funcionario() //cenário 5
        {
            repositorioFuncionarioMoq.Setup(x => x.Editar(It.IsAny<Funcionario>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = servicoFuncionario.Editar(funcionario);

            //assert 
            resultado.Should().BeFailure();
            resultado.Errors[0].Message.Should().Be("Falha ao tentar editar Funcionario.");
        }


        [TestMethod]
        public void Deve_excluir_funcionario_caso_ela_esteja_cadastrada() //cenário 1
        {
            //arrange
            var funcionario = new Funcionario("funcionario",novadata,1220);

            repositorioFuncionarioMoq.Setup(x => x.Existe(funcionario))
               .Returns(() =>
               {
                   return true;
               });

            //action
            var resultado = servicoFuncionario.Excluir(funcionario);

            //assert 
            resultado.Should().BeSuccess();
            repositorioFuncionarioMoq.Verify(x => x.Excluir(funcionario), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_excluir_funcionario_caso_ela_nao_esteja_cadastrada() //cenário 2
        {
            //arrange

            var funcionario = new Funcionario("funcionario", novadata, 1220);

            repositorioFuncionarioMoq.Setup(x => x.Existe(funcionario))
               .Returns(() =>
               {
                   return false;
               });

            //action
            var resultado = servicoFuncionario.Excluir(funcionario);

            //assert 
            resultado.Should().BeFailure();
            repositorioFuncionarioMoq.Verify(x => x.Excluir(funcionario), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_excluir_funcionario() //cenário 4
        {
            var funcionario = new Funcionario("funcionario", novadata, 1220);

            repositorioFuncionarioMoq.Setup(x => x.Existe(funcionario))
              .Throws(() =>
              {
                  return SqlExceptionCreator.NewSqlException();
              });

            //action
            Result resultado = servicoFuncionario.Excluir(funcionario);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar excluir Funcionario");
        }
    }
        

}

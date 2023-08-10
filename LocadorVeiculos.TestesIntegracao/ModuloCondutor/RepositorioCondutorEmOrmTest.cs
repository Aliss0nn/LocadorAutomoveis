using FizzWare.NBuilder;
using FluentAssertions;
using LocadorAutomoveis.Dominio.ModuloClientes;
using LocadorAutomoveis.Dominio.ModuloCondutor;
using LocadorAutomoveis.Dominio.ModuloCupom;

namespace LocadorAutomoveis.TestesIntegracao.ModuloCondutor
{
    [TestClass]
    public class RepositorioCondutorEmOrmTest : TestesIntegracaoBase
    {
        [TestMethod]
        public void Deve_inserir_condutor()
        {
            //arrange
            var condutor = Builder<Condutor>.CreateNew().Build();
            condutor.Clientes = Builder<Clientes>.CreateNew().Build();

            //action
            repositorioCondutor.Inserir(condutor);
            contextoPersistencia.GravarDados();

            //assert
            repositorioCondutor.SelecionarPorId(condutor.Id).Should().Be(condutor);
        }

        [TestMethod]
        public void Deve_Editar_condutor()
        {
            var condutorId = Builder<Condutor>.CreateNew().Persist().Id;

            var condutor = repositorioCondutor.SelecionarPorId(condutorId);
            condutor.Nome = "mario";

            repositorioCondutor.Editar(condutor);
            contextoPersistencia.GravarDados();

            repositorioCondutor.SelecionarPorId(condutor.Id).Should().Be(condutor);
        }

        [TestMethod]
        public void Deve_Excluir_condutor()
        {
            var condutor = Builder<Condutor>.CreateNew().Persist();

            repositorioCondutor.Excluir(condutor);
            contextoPersistencia.GravarDados();

            repositorioCondutor.SelecionarPorId(condutor.Id).Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_todos_condutores()
        {
            //arrange
            var condutor = Builder<Condutor>.CreateNew().Persist();
            var condutor2 = Builder<Condutor>.CreateNew().Persist();

            //action
            var condutores = repositorioCondutor.SelecionarTodos();

            //assert
            condutores.Should().ContainInOrder(condutor, condutor2);
            condutores.Should().HaveCount(2);
        }


        [TestMethod]
        public void Deve_selecionar_cupom_por_nome()
        {
            //arrange
            var condutor = Builder<Condutor>.CreateNew().Persist();

            //action
            var condutorEncontrado = repositorioCondutor.SelecionarPorNome(condutor.Nome);

            //assert
            condutorEncontrado.Should().Be(condutor);
        }

        [TestMethod]
        public void Deve_selecionar_cupom_por_id()
        {
            //arrange
            var condutor = Builder<Condutor>.CreateNew().Persist();

            //action
            var condutorEncontrado = repositorioCondutor.SelecionarPorId(condutor.Id);

            //assert            
            condutorEncontrado.Should().Be(condutor);
        }
    }
}

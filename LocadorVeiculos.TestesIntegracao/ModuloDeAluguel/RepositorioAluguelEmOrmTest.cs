using FizzWare.NBuilder;
using FluentAssertions;
using LocadorAutomoveis.Dominio.ModuloAluguel;

namespace LocadorAutomoveis.TestesIntegracao.ModuloDeAluguel
{
   
    public class RepositorioAluguelEmOrmTest : TestesIntegracaoBase
    {
        [TestMethod]
        public void Deve_inserir_aluguel()
        {
            //arrange
            var aluguel = Builder<Aluguel>.CreateNew().Build();

            //action
            repositorioAluguel.Inserir(aluguel);
            contextoPersistencia.GravarDados();

            //assert
            repositorioAluguel.SelecionarPorId(aluguel.Id).Should().Be(aluguel);
        }

        [TestMethod]
        public void Deve_editar_aluguel()
        {
            //arrange
            var aluguelId = Builder<Aluguel>.CreateNew().Persist().Id;

            var aluguel = repositorioAluguel.SelecionarPorId(aluguelId);
            aluguel.NivelTanque = NivelTanqueEnum.Meio_Cheio;

            //action
            repositorioAluguel.Editar(aluguel);
            contextoPersistencia.GravarDados();

            //assert
            repositorioAluguel.SelecionarPorId(aluguel.Id)
                .Should().Be(aluguel);
        }

        [TestMethod]
        public void Deve_excluir_aluguel()
        {
            //arrange
            var aluguel = Builder<Aluguel>.CreateNew().Persist();

            //action
            repositorioAluguel.Excluir(aluguel);

            //assert
            repositorioAluguel.SelecionarPorId(aluguel.Id).Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_todos_os_alugueis()
        {
            //arrange
            var aluguel = Builder<Aluguel>.CreateNew().Persist();
            var aluguel2 = Builder<Aluguel>.CreateNew().Persist();

            //action
            var alugueis = repositorioAluguel.SelecionarTodos();

            //assert
            alugueis.Should().ContainInOrder(aluguel, aluguel2);
            alugueis.Should().HaveCount(2);
        }


        [TestMethod]
        public void Deve_selecionar_aluguel_por_automovel()
        {
            //arrange
            var aluguel = Builder<Aluguel>.CreateNew().Persist();

            //action
            var aluguelEncontrado = repositorioAluguel.SelecionarPorAutomovel(aluguel.Automovel);

            //assert
            aluguelEncontrado.Should().Be(aluguel);
        }

        [TestMethod]
        public void Deve_selecionar_aluguel_por_id()
        {
            //arrange
            var aluguel = Builder<Aluguel>.CreateNew().Persist();

            //action
            var aluguelEncontrado = repositorioAluguel.SelecionarPorId(aluguel.Id);

            //assert            
            aluguelEncontrado.Should().Be(aluguel);
        }
    }
}

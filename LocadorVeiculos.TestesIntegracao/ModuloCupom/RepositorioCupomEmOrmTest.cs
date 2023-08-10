using FizzWare.NBuilder;
using FluentAssertions;
using LocadorAutomoveis.Dominio.ModuloCupom;
using LocadorAutomoveis.Dominio.ModuloParceiro;

namespace LocadorAutomoveis.TestesIntegracao.ModuloCupom
{
    [TestClass]
    public class RepositorioCupomEmOrmTest : TestesIntegracaoBase
    {
        [TestMethod]
        public void Deve_inserir_cupom()
        {
            //arrange
            var cupom = Builder<Cupom>.CreateNew().Build();
            cupom.Parceiro = Builder<Parceiro>.CreateNew().Persist();

            //action
            repositorioCupom.Inserir(cupom);
            contextoPersistencia.GravarDados();

            //assert
            repositorioCupom.SelecionarPorId(cupom.Id).Should().Be(cupom);
        }

        [TestMethod]
        public void Deve_editar_cupom()
        {
            //arrange
            var cupomId = Builder<Cupom>.CreateNew().Persist().Id;

            var cupom = repositorioCupom.SelecionarPorId(cupomId);
            cupom.Nome = "Desconto";

            //action
            repositorioCupom.Editar(cupom);
            contextoPersistencia.GravarDados();

            //assert
            repositorioCupom.SelecionarPorId(cupom.Id)
                .Should().Be(cupom);
        }

        [TestMethod]
        public void Deve_excluir_cupom()
        {
            //arrange
            var cupom = Builder<Cupom>.CreateNew().Persist();

            //action
            repositorioCupom.Excluir(cupom);
            contextoPersistencia.GravarDados();

            //assert
            repositorioCupom.SelecionarPorId(cupom.Id).Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_todos_cupons()
        {
            //arrange
            var desconto = Builder<Cupom>.CreateNew().Persist();
            var descontodoDeco = Builder<Cupom>.CreateNew().Persist();

            //action
            var cupons = repositorioCupom.SelecionarTodos();

            //assert
            cupons.Should().ContainInOrder(desconto, descontodoDeco);
            cupons.Should().HaveCount(2);
        }


        [TestMethod]
        public void Deve_selecionar_cupom_por_nome()
        {
            //arrange
            var desconto = Builder<Cupom>.CreateNew().Persist();

            //action
            var cupomsEncontrado = repositorioCupom.SelecionarPorNome(desconto.Nome);

            //assert
            cupomsEncontrado.Should().Be(desconto);
        }

        [TestMethod]
        public void Deve_selecionar_cupom_por_id()
        {
            //arrange
            var desconto = Builder<Cupom>.CreateNew().Persist();

            //action
            var descontoEncontrado = repositorioCupom.SelecionarPorId(desconto.Id);

            //assert            
            descontoEncontrado.Should().Be(desconto);
        }
    }
}

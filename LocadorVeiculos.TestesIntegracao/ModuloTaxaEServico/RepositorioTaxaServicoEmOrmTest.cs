using FizzWare.NBuilder;
using FluentAssertions;
using LocadorAutomoveis.Dominio.ModuloParceiro;
using LocadorAutomoveis.Dominio.ModuloTaxasEServicos;

namespace LocadorAutomoveis.TestesIntegracao.ModuloTaxaEServico
{
    public class RepositorioTaxaServicoEmOrmTest : TestesIntegracaoBase
    {
        [TestMethod]
        public void Deve_inserir_TaxaEServico()
        {
            //arrange
            var taxaEServico = Builder<TaxasEServico>.CreateNew().Build();
            //action
            repositorioTaxasServico.Inserir(taxaEServico);

            //assert
            repositorioTaxasServico.SelecionarPorId(taxaEServico.Id).Should().Be(taxaEServico);
        }

        [TestMethod]
        public void Deve_editar_TaxaEServico()
        {
            //arrange
            var taxaEServicoId = Builder<TaxasEServico>.CreateNew().Persist().Id;

            var taxaEServico = repositorioTaxasServico.SelecionarPorId(taxaEServicoId);
            taxaEServico.Nome = "Limpeza no interior do carro";

            //action
            repositorioTaxasServico.Editar(taxaEServico);

            //assert
            repositorioTaxasServico.SelecionarPorId(taxaEServico.Id)
                .Should().Be(taxaEServico);
        }

        [TestMethod]
        public void Deve_excluir_TaxaEServico()
        {
            //arrange
            var taxaServico = Builder<TaxasEServico>.CreateNew().Persist();

            //action
            repositorioTaxasServico.Excluir(taxaServico);

            //assert
            repositorioTaxasServico.SelecionarPorId(taxaServico.Id).Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_todos_TaxaEServico()
        {
            //arrange
            var primeiraTaxaServico = Builder<TaxasEServico>.CreateNew().Persist();
            var segundaTaxaServico = Builder<TaxasEServico>.CreateNew().Persist();

            //action
            var taxasEServicos = repositorioTaxasServico.SelecionarTodos();

            //assert
            taxasEServicos.Should().ContainInOrder(primeiraTaxaServico, segundaTaxaServico);
            taxasEServicos.Should().HaveCount(2);
        }


        [TestMethod]
        public void Deve_selecionar_TaxaEServico_por_nome()
        {
            //arrange
            var taxasEServico = Builder<TaxasEServico>.CreateNew().Persist();

            //action
            var taxasEServicosEncontrado = repositorioTaxasServico.SelecionarPorNome(taxasEServico.Nome);

            //assert
            taxasEServicosEncontrado.Should().Be(taxasEServico);
        }

        [TestMethod]
        public void Deve_selecionar_TaxaEServico_por_id()
        {
            //arrange
            var taxasEServico = Builder<TaxasEServico>.CreateNew().Persist();

            //action
            var taxasEServicosEncontrado = repositorioTaxasServico.SelecionarPorId(taxasEServico.Id);

            //assert            
            taxasEServicosEncontrado.Should().Be(taxasEServico);
        }
    }
}

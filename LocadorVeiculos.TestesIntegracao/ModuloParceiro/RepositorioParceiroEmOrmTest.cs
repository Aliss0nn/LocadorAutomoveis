using FizzWare.NBuilder;
using FluentAssertions;
using LocadorAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadorAutomoveis.Dominio.ModuloParceiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadorAutomoveis.TestesIntegracao.ModuloParceiro
{
    public class RepositorioParceiroEmOrmTest : TestesIntegracaoBase
    {
        [TestMethod]
        public void Deve_inserir_Parceiro()
        {
            //arrange
            var parceiro = Builder<Parceiro>.CreateNew().Build();
            //action
            repositorioParceiro.Inserir(parceiro);

            //assert
            repositorioParceiro.SelecionarPorId(parceiro.Id).Should().Be(parceiro);
        }

        [TestMethod]
        public void Deve_editar_Parceiro()
        {
            //arrange
            var parceiroId = Builder<Parceiro>.CreateNew().Persist().Id;

            var parceiro = repositorioParceiro.SelecionarPorId(parceiroId);
            parceiro.Nome = "Posto Shell";

            //action
            repositorioParceiro.Editar(parceiro);

            //assert
            repositorioParceiro.SelecionarPorId(parceiro.Id)
                .Should().Be(parceiro);
        }

        [TestMethod]
        public void Deve_excluir_Parceiro()
        {
            //arrange
            var parceiro = Builder<Parceiro>.CreateNew().Persist();

            //action
            repositorioParceiro.Excluir(parceiro);

            //assert
            repositorioParceiro.SelecionarPorId(parceiro.Id).Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_todos_Parceiros()
        {
            //arrange
            var primeiroParceiro = Builder<Parceiro>.CreateNew().Persist();
            var segundoParceiro = Builder<Parceiro>.CreateNew().Persist();

            //action
            var parceiros = repositorioParceiro.SelecionarTodos();

            //assert
            parceiros.Should().ContainInOrder(primeiroParceiro, segundoParceiro);
            parceiros.Should().HaveCount(2);
        }


        [TestMethod]
        public void Deve_selecionar_Parceiro_por_nome()
        {
            //arrange
            var parceiro = Builder<Parceiro>.CreateNew().Persist();

            //action
            var parceiroEncontrado = repositorioParceiro.SelecionarPorNome(parceiro.Nome);

            //assert
            parceiroEncontrado.Should().Be(parceiro);
        }

        [TestMethod]
        public void Deve_selecionar_Parceiro_por_id()
        {
            //arrange
            var parceiro = Builder<Parceiro>.CreateNew().Persist();

            //action
            var parceiroEncontrado = repositorioParceiro.SelecionarPorId(parceiro.Id);

            //assert            
            parceiroEncontrado.Should().Be(parceiro);
        }
    }
}

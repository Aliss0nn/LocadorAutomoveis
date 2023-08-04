using FizzWare.NBuilder;
using FluentAssertions;
using LocadorAutomoveis.Dominio.ModuloCupom;
using LocadorAutomoveis.Dominio.ModuloDisciplina;
using LocadorAutomoveis.TestesIntegracao.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadorAutomoveis.TestesIntegracao.ModuloCupom
{
    public class RepositorioCupomEmOrmTest : TestesIntegracaoBase
    {
        [TestMethod]
        public void Deve_inserir_disciplina()
        {
            //arrange
            var cupom = Builder<Cupom>.CreateNew().Build();

            //action
            repositorioCupom.Inserir(cupom);

            //assert
            repositorioCupom.SelecionarPorId(cupom.Id).Should().Be(cupom);
        }

        [TestMethod]
        public void Deve_editar_disciplina()
        {
            //arrange
            var cupomId = Builder<Cupom>.CreateNew().Persist().Id;

            var cupom = repositorioCupom.SelecionarPorId(cupomId);
            cupom.Nome = "Desconto";

            //action
            repositorioCupom.Editar(cupom);

            //assert
            repositorioCupom.SelecionarPorId(cupom.Id)
                .Should().Be(cupom);
        }

        [TestMethod]
        public void Deve_excluir_disciplina()
        {
            //arrange
            var cupom = Builder<Cupom>.CreateNew().Persist();

            //action
            repositorioCupom.Excluir(cupom);

            //assert
            repositorioCupom.SelecionarPorId(cupom.Id).Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_todas_disciplinas()
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
        public void Deve_selecionar_disciplina_por_nome()
        {
            //arrange
            var desconto = Builder<Cupom>.CreateNew().Persist();

            //action
            var disciplinasEncontrada = repositorioCupom.SelecionarPorNome(desconto.Nome);

            //assert
            disciplinasEncontrada.Should().Be(desconto);
        }

        [TestMethod]
        public void Deve_selecionar_disciplina_por_id()
        {
            //arrange
            var desconto = Builder<Cupom>.CreateNew().Persist();

            //action
            var descontoEncontrado = repositorioDisciplina.SelecionarPorId(desconto.Id);

            //assert            
            descontoEncontrado.Should().Be(desconto);
        }
    }
}

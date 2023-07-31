using FizzWare.NBuilder;
using FluentAssertions;
using LocadorAutomoveis.Dominio.ModuloDisciplina;

namespace LocadorAutomoveis.TestesIntegracao.ModuloDisciplina
{
    [TestClass]
    public class RepositorioDisciplinaEmSqlTest : TestesIntegracaoBase
    {
        [TestMethod]
        public void Deve_inserir_disciplina()
        {            
            //arrange
            var disciplina = Builder<Disciplina>.CreateNew().Build();
            //action
            repositorioDisciplina.Inserir(disciplina);

            //assert
            repositorioDisciplina.SelecionarPorId(disciplina.Id).Should().Be(disciplina);
        }

        [TestMethod]
        public void Deve_editar_disciplina()
        {
            //arrange
            var disciplinaId = Builder<Disciplina>.CreateNew().Persist().Id;            

            var disciplina = repositorioDisciplina.SelecionarPorId(disciplinaId);
            disciplina.Nome = "História";

            //action
            repositorioDisciplina.Editar(disciplina);

            //assert
            repositorioDisciplina.SelecionarPorId(disciplina.Id)
                .Should().Be(disciplina);
        }

        [TestMethod]
        public void Deve_excluir_disciplina()
        {
            //arrange
            var disciplina = Builder<Disciplina>.CreateNew().Persist();

            //action
            repositorioDisciplina.Excluir(disciplina);

            //assert
            repositorioDisciplina.SelecionarPorId(disciplina.Id).Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_todas_disciplinas()
        {
            //arrange
            var matematica = Builder<Disciplina>.CreateNew().Persist();
            var portugues = Builder<Disciplina>.CreateNew().Persist();

            //action
            var disciplinas = repositorioDisciplina.SelecionarTodos();

            //assert
            disciplinas.Should().ContainInOrder(matematica, portugues);
            disciplinas.Should().HaveCount(2);
        }


        [TestMethod]
        public void Deve_selecionar_disciplina_por_nome()
        {
            //arrange
            var matematica = Builder<Disciplina>.CreateNew().Persist();

            //action
            var disciplinasEncontrada = repositorioDisciplina.SelecionarPorNome(matematica.Nome);

            //assert
            disciplinasEncontrada.Should().Be(matematica);
        }

        [TestMethod]
        public void Deve_selecionar_disciplina_por_id()
        {
            //arrange
            var matematica = Builder<Disciplina>.CreateNew().Persist();

            //action
            var disciplinasEncontrada = repositorioDisciplina.SelecionarPorId(matematica.Id);

            //assert            
            disciplinasEncontrada.Should().Be(matematica);
        }

    }
}
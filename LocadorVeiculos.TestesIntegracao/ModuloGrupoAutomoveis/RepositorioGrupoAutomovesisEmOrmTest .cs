using FizzWare.NBuilder;
using FluentAssertions;
using LocadorAutomoveis.Dominio.ModuloGrupoAutomoveis;

namespace LocadorAutomoveis.TestesIntegracao.ModuloGrupoAutomoveis
{
    [TestClass]
    public class RepositorioGrupoAutomoveisEmSqlTest : TestesIntegracaoBase
    {
        [TestMethod]
        public void Deve_inserir_grupoAutomoveis()
        {            
            //arrange
            var grupo = Builder<GrupoAutomoveis>.CreateNew().Build();
            //action
            repositorioGrupoAutomoveis.Inserir(grupo);

            //assert
            repositorioGrupoAutomoveis.SelecionarPorId(grupo.Id).Should().Be(grupo);
        }

        [TestMethod]
        public void Deve_editar_GrupoAutomoveis()
        {
            //arrange
            var grupoId = Builder<GrupoAutomoveis>.CreateNew().Persist().Id;            

            var grupo = repositorioGrupoAutomoveis.SelecionarPorId(grupoId);
            grupo.Tipo = "Esportivo";

            //action
            repositorioGrupoAutomoveis.Editar(grupo);

            //assert
            repositorioGrupoAutomoveis.SelecionarPorId(grupo.Id)
                .Should().Be(grupo);
        }

        [TestMethod]
        public void Deve_excluir_grupoAutomoveis()
        {
            //arrange
            var grupo = Builder<GrupoAutomoveis>.CreateNew().Persist();

            //action
            repositorioGrupoAutomoveis.Excluir(grupo);

            //assert
            repositorioDisciplina.SelecionarPorId(grupo.Id).Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_todos_gruposAutomoveis()
        {
            //arrange
            var esportivo = Builder<GrupoAutomoveis>.CreateNew().Persist();
            var utilitario = Builder<GrupoAutomoveis>.CreateNew().Persist();

            //action
            var grupos = repositorioGrupoAutomoveis.SelecionarTodos();

            //assert
            grupos.Should().ContainInOrder(esportivo, utilitario);
            grupos.Should().HaveCount(2);
        }


        [TestMethod]
        public void Deve_selecionar_grupoAutomoveis_por_tipo()
        {
            //arrange
            var grupo = Builder<GrupoAutomoveis>.CreateNew().Persist();

            //action
            var grupoEncontrado = repositorioGrupoAutomoveis.SelecionarPorTipo(grupo.Tipo);

            //assert
            grupoEncontrado.Should().Be(grupo);
        }

        [TestMethod]
        public void Deve_selecionar_grupoAutomoveis_por_id()
        {
            //arrange
            var grupo = Builder<GrupoAutomoveis>.CreateNew().Persist();

            //action
            var grupoEncontrado = repositorioGrupoAutomoveis.SelecionarPorId(grupo.Id);

            //assert            
            grupoEncontrado.Should().Be(grupo);
        }

    }
}
using FizzWare.NBuilder;
using FluentAssertions;
using LocadorAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadorAutomoveis.Dominio.ModuloPlanoCobranca;

namespace LocadorAutomoveis.TestesIntegracao.ModuloPlanoCobranca
{
    [TestClass]
    public class RepositorioPlanoCobrancaEmSqlTest : TestesIntegracaoBase
    {
        [TestMethod]
        public void Deve_inserir_planoCobranca()
        {
            //arrange
            var grupo = Builder<GrupoAutomoveis>.CreateNew().Persist();

            var planoCobranca = Builder<PlanoCobranca>.CreateNew().Build();
            planoCobranca.Grupo = repositorioGrupoAutomoveis.SelecionarPorId(grupo.Id);

            //action
            repositorioPlanoCobranca.Inserir(planoCobranca);
            contextoPersistencia.GravarDados();

            //assert
            repositorioPlanoCobranca.SelecionarPorId(planoCobranca.Id, true).Should().Be(planoCobranca);
        }

        [TestMethod]
        public void Deve_editar_planoCobranca()
        {
            //arrange
            var grupo = Builder<GrupoAutomoveis>.CreateNew().Persist();

            var planoCobrancaInicial = Builder<PlanoCobranca>.CreateNew().Build();
            planoCobrancaInicial.Grupo = grupo;

            repositorioPlanoCobranca.Inserir(planoCobrancaInicial);
            contextoPersistencia.GravarDados();

            var planoCobrancaId = planoCobrancaInicial.Id;

            var planoCobranca = repositorioPlanoCobranca.SelecionarPorId(planoCobrancaId);
            planoCobranca.PrecoDiario = 100;

            //action
            repositorioPlanoCobranca.Editar(planoCobranca);
            contextoPersistencia.GravarDados();

            //assert
            repositorioPlanoCobranca.SelecionarPorId(planoCobranca.Id)
                .Should().Be(planoCobranca);
        }

        [TestMethod]
        public void Deve_excluir_planoCobranca()
        {
            //arrange
            var grupo = Builder<GrupoAutomoveis>.CreateNew().Persist();

            var planoCobranca = Builder<PlanoCobranca>.CreateNew().Build();
            planoCobranca.Grupo = grupo;

            repositorioPlanoCobranca.Inserir(planoCobranca);
            contextoPersistencia.GravarDados();

            //action
            repositorioPlanoCobranca.Excluir(planoCobranca);
            contextoPersistencia.GravarDados();

            //assert
            repositorioPlanoCobranca.SelecionarPorId(planoCobranca.Id).Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_todos_planoCobrancas()
        {
            //arrange
            var grupo = Builder<GrupoAutomoveis>.CreateNew().Persist();

            var planoCobranca = Builder<PlanoCobranca>.CreateNew().Build();
            planoCobranca.Grupo = grupo;

            var planoCobranca2 = Builder<PlanoCobranca>.CreateNew().Build();
            planoCobranca2.Grupo = grupo;

            repositorioPlanoCobranca.Inserir(planoCobranca);
            repositorioPlanoCobranca.Inserir(planoCobranca2);
            contextoPersistencia.GravarDados();

            //action
            var planoCobrancas = repositorioPlanoCobranca.SelecionarTodos(true);

            //assert
            planoCobrancas.Should().ContainInOrder(planoCobranca, planoCobranca2);
            planoCobrancas.Should().HaveCount(2);
        }


        [TestMethod]
        public void Deve_selecionar_planoCobranca_por_Tipo_e_Grupo()
        {
            //arrange
            var grupo = Builder<GrupoAutomoveis>.CreateNew().Persist();

            var planoCobranca = Builder<PlanoCobranca>.CreateNew().Build();
            planoCobranca.Grupo = grupo;
            planoCobranca.TipoPlano = TipoPlanoEnum.Controlado;

            repositorioPlanoCobranca.Inserir(planoCobranca);
            contextoPersistencia.GravarDados();

            //action
            var planoCobrancasEncontrado = repositorioPlanoCobranca.SelecionarPorGrupoTipo(planoCobranca.Grupo, planoCobranca.TipoPlano);

            //assert
            planoCobrancasEncontrado.Should().Be(planoCobranca);
        }

        [TestMethod]
        public void Deve_selecionar_planoCobranca_por_id()
        {
            //arrange
            var grupo = Builder<GrupoAutomoveis>.CreateNew().Persist();

            var planoCobranca = Builder<PlanoCobranca>.CreateNew().Build();
            planoCobranca.Grupo = grupo;

            repositorioPlanoCobranca.Inserir(planoCobranca);
            contextoPersistencia.GravarDados();

            //action
            var planoCobrancasEncontrada = repositorioPlanoCobranca.SelecionarPorId(planoCobranca.Id);

            //assert            
            planoCobrancasEncontrada.Should().Be(planoCobranca);
        }

    }
}
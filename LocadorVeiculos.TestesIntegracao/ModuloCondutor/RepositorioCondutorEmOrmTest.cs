using FizzWare.NBuilder;
using FluentAssertions;
using LocadorAutomoveis.Dominio.ModuloCondutor;

namespace LocadorAutomoveis.TestesIntegracao.ModuloCondutor
{
    public class RepositorioCondutorEmOrmTest : TestesIntegracaoBase
    {
        [TestMethod]
        public void Deve_inserir_condutor()
        {
            //arrange
            var condutor = Builder<Condutor>.CreateNew().Build();

            //action
            repositorioCondutor.Inserir(condutor);
            contextoPersistencia.GravarDados();

            //assert
            repositorioCondutor.SelecionarPorId(condutor.Id).Should().Be(condutor);
        }
    }
}

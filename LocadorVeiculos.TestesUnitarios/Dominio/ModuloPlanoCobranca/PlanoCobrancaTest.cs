using FluentAssertions;
using LocadorAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadorAutomoveis.Dominio.ModuloPlanoCobranca;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadorAutomoveisTestesUnitarios.Dominio.ModuloPlanoCobrança
{
    [TestClass]
    public class PlanoCobrancaTest
    {
        PlanoCobranca plano;

        public PlanoCobrancaTest()
        {
            GrupoAutomoveis grupo = new GrupoAutomoveis("Esportivo");
            plano = new PlanoCobranca(grupo, TipoPlanoEnum.Livre, 100, 0, 0);
        }
    }
}
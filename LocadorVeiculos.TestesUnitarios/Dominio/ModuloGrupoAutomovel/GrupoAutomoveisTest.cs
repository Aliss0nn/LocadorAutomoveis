using FluentAssertions;
using LocadorAutomoveis.Dominio.ModuloGrupoAutomoveis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadorAutomoveisTestesUnitarios.Dominio.ModuloGrupoAutomovel
{
    [TestClass]
    public class GrupoAutomoveisTest
    {
        GrupoAutomoveis grupo;
        public GrupoAutomoveisTest()
        {
            grupo = new GrupoAutomoveis("Esportivo");
        }
    }
}
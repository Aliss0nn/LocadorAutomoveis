using FluentAssertions;
using LocadorAutomoveis.Dominio.ModuloAutomovel;
using LocadorAutomoveis.Dominio.ModuloGrupoAutomoveis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadorAutomoveisTestesUnitarios.Dominio.ModuloAutomovel
{
    [TestClass]
    public class AutomovelTest
    {
        Automovel automovel;
        GrupoAutomoveis grupo;

        public AutomovelTest()
        {
            grupo = new GrupoAutomoveis("Esportivo");
            automovel = new Automovel(
                "Marca",
                "azul",
                "Modelo",
                2000,
                10,
                TipoCombustivelEnum.Gasolina,
                10,
                "abc-1234",
                new byte[] { Convert.ToByte(true) },
                grupo);
        }
    }
}
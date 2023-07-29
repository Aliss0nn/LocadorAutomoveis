using FluentAssertions;
using LocadorAutomoveis.Dominio.ModuloDisciplina;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadorAutomoveis.TestesUnitarios.Dominio
{
    [TestClass]
    public class DisciplinaTest
    {
        Disciplina matematica;   

        public DisciplinaTest()
        {
            matematica = new Disciplina("Matemática");
        }
    }
}
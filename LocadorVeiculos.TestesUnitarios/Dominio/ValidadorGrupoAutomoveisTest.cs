using FluentValidation.TestHelper;

using LocadorAutomoveis.Dominio.ModuloDisciplina;
using LocadorAutomoveis.Dominio.ModuloGrupoAutomoveis;
using System.Runtime.ConstrainedExecution;

namespace LocadorAutomoveis.TestesUnitarios.Dominio
{
    [TestClass]
    public class ValidadorGrupoAutomoveisTest
    {
        private GrupoAutomoveis grupo;
        private ValidadorGrupoAutomoveis validador;

        public ValidadorGrupoAutomoveisTest()
        {
            grupo = new GrupoAutomoveis();

            validador = new ValidadorGrupoAutomoveis();
        }

        [TestMethod]
        public void Tipo_grupoAutomoveis_nao_deve_ser_nulo_ou_vazio()
        {
            //action
            var resultado = validador.TestValidate(grupo);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Tipo);
        }

        [TestMethod]
        public void Tipo_grupoAutomoveis_deve_ter_no_minimo_5_caracteres()
        {
            //arrange
            grupo.Tipo = "abcd";

            //action
            var resultado = validador.TestValidate(grupo);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Tipo);
        }

        [TestMethod]
        public void Tipo_grupoAutomoveis_deve_ser_composto_por_letras_e_numeros()
        {
            //arrange
            grupo.Tipo = "Esportivo @";

            //action
            var resultado = validador.TestValidate(grupo);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Tipo)
                .WithErrorMessage("'Tipo' deve ser composto por letras e números.");
        }
    }
}

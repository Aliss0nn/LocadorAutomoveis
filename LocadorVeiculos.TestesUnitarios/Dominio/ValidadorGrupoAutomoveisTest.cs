using FluentValidation.TestHelper;
using LocadorAutomoveis.Dominio.ModuloGrupoAutomoveis;

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
        public void Nome_grupoAutomoveis_nao_deve_ser_nulo_ou_vazio()
        {
            //action
            var resultado = validador.TestValidate(grupo);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nome_grupoAutomoveis_deve_ter_no_minimo_5_caracteres()
        {
            //arrange
            grupo.Nome = "abcd";

            //action
            var resultado = validador.TestValidate(grupo);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nome_grupoAutomoveis_deve_ser_composto_por_letras_e_numeros()
        {
            //arrange
            grupo.Nome = "Esportivo @";

            //action
            var resultado = validador.TestValidate(grupo);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Nome)
                .WithErrorMessage("'Nome' deve ser composto por letras e números.");
        }
    }
}

using FluentValidation.TestHelper;
using LocadorAutomoveis.Dominio.ModuloCupom;

namespace LocadorAutomoveisTestesUnitarios.Dominio.ModuloCupom
{
    [TestClass]
    public class ValidadorCupomTest
    {
        private Cupom cupom;
        private ValidadorCupom validador;


        public ValidadorCupomTest()
        {
            cupom = new Cupom();

            validador = new ValidadorCupom();
        }

        [TestMethod]
        public void Nome_cupom_nao_deve_ser_nulo_ou_vazio()
        {
            //action
            var resultado = validador.TestValidate(cupom);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nome_cupom_deve_ter_no_minimo_3_caracteres()
        {
            //arrange
            cupom.Nome = "ab";

            //action
            var resultado = validador.TestValidate(cupom);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nome_cupom_deve_ser_composto_por_letras_e_numeros()
        {
            //arrange
            cupom.Nome = "cupom @";

            //action
            var resultado = validador.TestValidate(cupom);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Nome)
                .WithErrorMessage("'Nome' deve ser composto por letras e números.");
        }
    }

}

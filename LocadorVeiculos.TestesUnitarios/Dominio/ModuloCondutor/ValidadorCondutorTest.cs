using FluentValidation.TestHelper;
using LocadorAutomoveis.Dominio.ModuloCondutor;
using LocadorAutomoveis.Dominio.ModuloCupom;

namespace LocadorAutomoveisTestesUnitarios.Dominio.ModuloCondutor
{
    [TestClass]
    public class ValidadorCondutorTest
    {
        private Condutor condutor;
        private ValidadorCondutor validador;

        public ValidadorCondutorTest()
        {
            condutor = new Condutor();

            validador = new ValidadorCondutor();
        }

        [TestMethod]
        public void Nome_condutor_nao_deve_ser_nulo_ou_vazio()
        {
            //action
            var resultado = validador.TestValidate(condutor);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }
        [TestMethod]
        public void Email_condutor_nao_deve_ser_nulo_ou_vazio()
        {
            var resultado = validador.TestValidate(condutor);

            resultado.ShouldHaveValidationErrorFor(x => x.Email);
        }

        [TestMethod]
        public void Nome_condutor_deve_ter_no_minimo_5_caracteres()
        {
            //arrange
            condutor.Nome = "ab";

            //action
            var resultado = validador.TestValidate(condutor);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Email_condutor_deve_ter_no_minimo_5_caracteres()
        {
            condutor.Email = "aaa";

            var resultado = validador.TestValidate(condutor);

            resultado.ShouldHaveValidationErrorFor(x => x.Email);
        }

        [TestMethod]
        public void Nome_condutor_deve_ser_composto_por_letras_e_numeros()
        {
            //arrange
            condutor.Nome = "condutor @";

            //action
            var resultado = validador.TestValidate(condutor);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Nome)
                .WithErrorMessage("'Nome' deve ser composto por letras e números.");
        }

    }
}

using FluentValidation.TestHelper;

using LocadorAutomoveis.Dominio.ModuloAutomovel;
using System.Runtime.ConstrainedExecution;

namespace LocadorAutomoveisTestesUnitarios.Dominio.ModuloAutomovel
{
    [TestClass]
    public class ValidadorAutomovelTest
    {
        private Automovel automovel;
        private ValidadorAutomovel validador;

        public ValidadorAutomovelTest()
        {
            automovel = new Automovel();

            validador = new ValidadorAutomovel();
        }

        [TestMethod]
        public void Marca_automovel_nao_deve_ser_nulo_ou_vazio()
        {
            //action
            var resultado = validador.TestValidate(automovel);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Marca);
        }

        [TestMethod]
        public void Marca_automovel_deve_ter_no_minimo_3_caracteres()
        {
            //arrange
            automovel.Marca = "ab";

            //action
            var resultado = validador.TestValidate(automovel);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Marca);
        }

        [TestMethod]
        public void Modelo_automovel_nao_deve_ser_nulo_ou_vazio()
        {
            //action
            var resultado = validador.TestValidate(automovel);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Modelo);
        }

        [TestMethod]
        public void Modelo_automovel_deve_ter_no_minimo_3_caracteres()
        {
            //arrange
            automovel.Marca = "ab";

            //action
            var resultado = validador.TestValidate(automovel);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Modelo);
        }

        [TestMethod]
        public void Cor_automovel_nao_deve_ser_nulo_ou_vazio()
        {
            //action
            var resultado = validador.TestValidate(automovel);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Cor);
        }

        [TestMethod]
        public void Cor_automovel_deve_ter_no_minimo_3_caracteres()
        {
            //arrange
            automovel.Cor = "ab";

            //action
            var resultado = validador.TestValidate(automovel);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Cor);
        }

        [TestMethod]
        public void Quilometragem_automovel_nao_ser_negativa()
        {
            //arrange
            automovel.Quilometragem = -1;

            //action
            var resultado = validador.TestValidate(automovel);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Quilometragem);
        }

        [TestMethod]
        public void Ano_automovel_deve_ser_maior_que_zero()
        {
            //action
            var resultado = validador.TestValidate(automovel);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Ano);
        }

        [TestMethod]
        public void Capacidade_automovel_deve_ser_maior_que_zero()
        {
            //action
            var resultado = validador.TestValidate(automovel);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Capacidade);
        }

        [TestMethod]
        public void Placa_automovel_nao_deve_ser_nulo_ou_vazio()
        {
            //action
            var resultado = validador.TestValidate(automovel);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Placa);
        }

        [TestMethod]
        public void Placa_automovel_deve_ter_no_minimo_3_caracteres()
        {
            //arrange
            automovel.Placa = "ab";

            //action
            var resultado = validador.TestValidate(automovel);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Placa);
        }
    }
}

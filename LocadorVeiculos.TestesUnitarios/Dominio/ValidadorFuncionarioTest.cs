using FluentValidation.TestHelper;
using LocadorAutomoveis.Dominio.ModuloFuncionario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadorTestesUnitarios.Dominio
{
    [TestClass]
    public class ValidadorFuncionarioTest
    {
        private Funcionario funcionario;
        private ValidadorFuncionario validador;

        public ValidadorFuncionarioTest()
        {
            funcionario = new Funcionario();

            validador = new ValidadorFuncionario();
        }

        [TestMethod]
        public void Nome_funcionario_nao_deve_ser_nulo_ou_vazio()
        {
            //action
            var resultado = validador.TestValidate(funcionario);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nome_funcionario_deve_ter_no_minimo_5_caracteres()
        {
            //arrange
            funcionario.Nome = "abcd";

            //action
            var resultado = validador.TestValidate(funcionario);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nome_funcionario_deve_ser_composto_por_letras_e_numeros()
        {
            //arrange
            funcionario.Nome = "Alex @";

            //action
            var resultado = validador.TestValidate(funcionario);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Nome)
                .WithErrorMessage("'Nome' deve ser composto por letras e números.");
        }
    }
}

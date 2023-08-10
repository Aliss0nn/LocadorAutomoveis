using FluentValidation.TestHelper;
using LocadorAutomoveis.Dominio.ModuloClientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadorAutomoveisTestesUnitarios.Dominio.ModuloClientes
{
    [TestClass]
    public class ValidadorClientesTest
    {
        private Clientes cliente;
        private ValidadorClientes validador;

        public ValidadorClientesTest()
        {
            cliente = new Clientes();

            validador = new ValidadorClientes();
        }

        [TestMethod]
        public void Nome_cliente_nao_deve_ser_nulo_ou_vazio()
        {
            //action
            var resultado = validador.TestValidate(cliente);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.NomeCliente);
        }

        [TestMethod]
        public void Nome_cliente_deve_ter_no_minimo_5_caracteres()
        {
            //arrange
            cliente.NomeCliente = "abcd";

            //action
            var resultado = validador.TestValidate(cliente);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.NomeCliente);
        }

        [TestMethod]
        public void Nome_cliente_deve_ser_composto_por_letras_e_numeros()
        {
            //arrange
            cliente.NomeCliente = "Alex @";

            //action
            var resultado = validador.TestValidate(cliente);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.NomeCliente)
                .WithErrorMessage("'Nome Cliente' deve ser composto por letras e números.");
        }
    }
}

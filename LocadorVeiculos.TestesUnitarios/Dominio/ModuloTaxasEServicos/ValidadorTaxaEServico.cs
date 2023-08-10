using LocadorAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadorAutomoveis.Dominio.ModuloTaxasEServicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FluentValidation.TestHelper;

namespace LocadorAutomoveisTestesUnitarios.Dominio.ModuloTaxasEServiços
{
    [TestClass]
    public class ValidadorTaxaEServico
    {
        private TaxasEServico taxasEServico;
        private ValidadorTaxasServico validador;

        public ValidadorTaxaEServico()
        {
            taxasEServico = new TaxasEServico();

            validador = new ValidadorTaxasServico();
        }

        [TestMethod]
        public void Preco_TaxaEServico_nao_deve_ser_nulo_ou_vazio()
        {
            //action
            var resultado = validador.TestValidate(taxasEServico);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Preco);
        }
        public void PlanoDeCalculo_TaxaEServico_nao_deve_ser_nulo_ou_vazio()
        {
            //action
            var resultado = validador.TestValidate(taxasEServico);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.PlanoDeCalculo);
        }

        public void Nome_TaxaEServico_nao_deve_ser_nulo_ou_vazio()
        {
            //action
            var resultado = validador.TestValidate(taxasEServico);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nome_TaxaEServico_deve_ter_no_minimo_5_caracteres()
        {
            //arrange
            taxasEServico.Nome = "abcd";

            //action
            var resultado = validador.TestValidate(taxasEServico);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nome_TaxaEservico_deve_ser_composto_por_letras_e_numeros()
        {
            //arrange
            taxasEServico.Nome = "Limpeza do C4rro @";

            //action
            var resultado = validador.TestValidate(taxasEServico);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Nome)
                .WithErrorMessage("'Nome' deve ser composto por letras e números.");
        }
    }

}

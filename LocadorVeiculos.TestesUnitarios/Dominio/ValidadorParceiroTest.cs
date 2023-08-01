using FluentValidation.TestHelper;
using LocadorAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadorAutomoveis.Dominio.ModuloParceiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LocadorAutomoveisTestesUnitarios.Dominio
{
    [TestClass]

    public class ValidadorParceiroTest
    {
        private Parceiro parceiro;
        private ValidadorParceiro validador;

        public ValidadorParceiroTest()
        {
            parceiro = new Parceiro();

            validador = new ValidadorParceiro();
        }

        [TestMethod]
        public void Nome_Parceiro_nao_deve_ser_nulo_ou_vazio()
        {
            var resultado = validador.TestValidate(parceiro);

            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nome_Parceiro_deve_ter_no_minimo_5_caracteres()
        {
            //arrange
            parceiro.Nome = "aaaa";

            //action
            var resultado = validador.TestValidate(parceiro);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nome_Parceiro_deve_ser_composto_por_letras_e_numeros()
        {
            //arrange
            parceiro.Nome = "Posto Shell @";

            //action
            var resultado = validador.TestValidate(parceiro);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Nome)
                .WithErrorMessage("'Nome' deve ser composto por letras e números.");
        }
    }
}

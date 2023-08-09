using FluentValidation.TestHelper;

using LocadorAutomoveis.Dominio.ModuloPlanoCobranca;
using System.Runtime.ConstrainedExecution;

namespace LocadorAutomoveisTestesUnitarios.Dominio.ModuloPlanoCobrança
{
    [TestClass]
    public class ValidadorPlanoCobrancaTest
    {
        private PlanoCobranca plano;
        private ValidadorPlanoCobranca validador;

        public ValidadorPlanoCobrancaTest()
        {
            plano = new PlanoCobranca();

            validador = new ValidadorPlanoCobranca();
        }

        [TestMethod]
        public void Grupo_planoCobranca_nao_deve_ser_nulo()
        {
            //action
            var resultado = validador.TestValidate(plano);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Grupo);
        }

        [TestMethod]
        public void TipoPlano_planoCobranca_nao_deve_ser_nulo()
        {
            //action
            var resultado = validador.TestValidate(plano);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.TipoPlano);
        }

        [TestMethod]
        public void PrecoDiario_planoCobranca_nao_deve_ser_nulo()
        {
            //action
            var resultado = validador.TestValidate(plano);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.PrecoDiario);
        }

        [TestMethod]
        public void PrecoKm_planoCobranca_deve_ser_nulo_caso_tipoPlano_ser_livre()
        {
            //arrange
            plano.TipoPlano = TipoPlanoEnum.Livre;
            plano.PrecoKm = 1;

            //action
            var resultado = validador.TestValidate(plano);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.PrecoKm);
        }

        [TestMethod]
        [DataRow(TipoPlanoEnum.Diario)]
        [DataRow(TipoPlanoEnum.Controlado)]
        public void PrecoKm_planoCobranca_nao_deve_ser_nulo_caso_tipoPlano_ser_diario_ou_controlado(
            TipoPlanoEnum Tipo)
        {
            //arrange
            plano.TipoPlano = Tipo;

            //action
            var resultado = validador.TestValidate(plano);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.PrecoKm);
        }

        [TestMethod]
        [DataRow(TipoPlanoEnum.Diario)]
        [DataRow(TipoPlanoEnum.Livre)]
        public void KmLivre_planoCobranca_deve_ser_nulo_caso_tipoPlano_ser_diario_ou_livre(
            TipoPlanoEnum Tipo)
        {
            //arrange
            plano.TipoPlano = Tipo;
            plano.KmLivre = 1;

            //action
            var resultado = validador.TestValidate(plano);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.KmLivre);
        }

        [TestMethod]
        public void KmLivre_planoCobranca_nao_deve_ser_nulo_caso_tipoPlano_ser_controlado()
        {
            //arrange
            plano.TipoPlano = TipoPlanoEnum.Controlado;

            //action
            var resultado = validador.TestValidate(plano);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.KmLivre);
        }

    }
}

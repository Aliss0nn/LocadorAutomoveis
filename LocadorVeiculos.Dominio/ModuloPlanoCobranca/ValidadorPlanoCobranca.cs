namespace LocadorAutomoveis.Dominio.ModuloPlanoCobranca
{
    public class ValidadorPlanoCobranca : AbstractValidator<PlanoCobranca>, IValidadorPlanoCobranca
    {
        public ValidadorPlanoCobranca()
        {
            RuleFor(x => x.Grupo)
                .NotNull();

            RuleFor(x => x.PrecoDiario)
                .GreaterThan(0);

            When(x => x.TipoPlano == TipoPlanoEnum.Diario, () =>
            {
                RuleFor(x => x.PrecoKm)
                .GreaterThan(0);
            });

            When(x => x.TipoPlano == TipoPlanoEnum.Diario, () =>
            {
                RuleFor(x => x.KmLivre)
                .Equal(0);
            });

            When(x => x.TipoPlano == TipoPlanoEnum.Controlado, () =>
            {
                RuleFor(x => x.PrecoKm)
                .GreaterThan(0);
            });

            When(x => x.TipoPlano == TipoPlanoEnum.Controlado, () =>
            {
                RuleFor(x => x.KmLivre)
                .GreaterThan(0);
            });

            When(x => x.TipoPlano == TipoPlanoEnum.Livre, () =>
            {
                RuleFor(x => x.PrecoKm)
                 .Equal(0);
            });

            When(x => x.TipoPlano == TipoPlanoEnum.Livre, () =>
            {
                RuleFor(x => x.KmLivre)
                 .Equal(0);
            });
        }
    }
}
namespace LocadorAutomoveis.Dominio.ModuloPlanoCobranca
{
    public class ValidadorPlanoCobranca : AbstractValidator<PlanoCobranca>, IValidadorPlanoCobranca
    {
        public ValidadorPlanoCobranca()
        {
            RuleFor(x => x.Grupo)
                .NotNull();

            RuleFor(x => x.PrecoDiario)
                .NotNull()
                .GreaterThan(0);

            When(x => x.TipoPlano == TipoPlanoEnum.Diario, () =>
            {
                RuleFor(x => x.PrecoKm)
                .NotNull()
                .GreaterThan(0);

                RuleFor(x => x.KmLivre)
                .Null(); 
            });

            When(x => x.TipoPlano == TipoPlanoEnum.Controlado, () =>
            {
                RuleFor(x => x.PrecoKm)
                .NotNull()
                .GreaterThan(0);

                RuleFor(x => x.KmLivre)
                .NotNull()
                .GreaterThan(0);
            });

            When(x => x.TipoPlano == TipoPlanoEnum.Livre, () =>
            {
                RuleFor(x => x.PrecoKm)
                .Null();

                RuleFor(x => x.KmLivre)
                .Null();
            });
        }
    }
}
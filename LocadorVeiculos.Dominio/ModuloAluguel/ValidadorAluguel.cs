namespace LocadorAutomoveis.Dominio.ModuloAluguel
{
    public class ValidadorAluguel : AbstractValidator<Aluguel>, IValidadorAluguel
    {
        public ValidadorAluguel()
        {
            RuleFor(x => x.Funcionario)
                .NotNull();

            RuleFor(x => x.Grupo)
                .NotNull();

            RuleFor(x => x.Plano)
                .NotNull();

            RuleFor(x => x.Automovel)
                .NotNull();

            RuleFor(x => x.KmAutomovel)
                .GreaterThan(0);

            RuleFor(x => x.DataLocacao)
                .NotEqual(new DateTime());

            RuleFor(x => x.DataPrevisao)
                .GreaterThan(DateTime.Now);

            RuleFor(x => x.Condutor.Validade)
                .GreaterThanOrEqualTo(DateTime.Now);

            When(x => x.Cupom != null, () =>
            {
                RuleFor(x => x.Cupom.DataValidade)
                .GreaterThanOrEqualTo(DateTime.Now);
            });

            When(x => x.Fechado, () =>
            {
                RuleFor(x => x.DataDevolucao > x.DataLocacao).Equal(true);
            });

            When(x => x.Fechado, () =>
            {
                RuleFor(x => x.KmPercorrido)
                .GreaterThan(0);
            });
        }
    }
}
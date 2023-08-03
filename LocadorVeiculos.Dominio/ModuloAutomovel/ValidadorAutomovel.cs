namespace LocadorAutomoveis.Dominio.ModuloAutomovel
{
    public class ValidadorAutomovel : AbstractValidator<Automovel>, IValidadorAutomovel
    {
        public ValidadorAutomovel()
        {
            RuleFor(x => x.Marca)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3);

            RuleFor(x => x.Modelo)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3);

            RuleFor(x => x.Cor)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3);

            RuleFor(x => x.TipoCombustivel)
                .NotEqual(new TipoCombustivelEnum());

            RuleFor(x => x.Quilometragem)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.Ano)
                .NotNull();

            RuleFor(x => x.Capacidade)
                .NotNull();

            RuleFor(x => x.Placa)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3);
        }
    }
}
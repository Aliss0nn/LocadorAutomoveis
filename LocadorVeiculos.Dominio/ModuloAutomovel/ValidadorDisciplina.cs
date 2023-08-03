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
        }
    }
}
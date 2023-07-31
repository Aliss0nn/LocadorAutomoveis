namespace LocadorAutomoveis.Dominio.ModuloGrupoAutomoveis
{
    public class ValidadorGrupoAutomoveis : AbstractValidator<GrupoAutomoveis>, 
        IValidadorGrupoAutomoveis
    {
        public ValidadorGrupoAutomoveis()
        {
            RuleFor(x => x.Tipo)
                .NotEmpty()
                .NotNull()
                .MinimumLength(5)
                .NaoPodeCaracteresEspeciais();
        }
    }
}
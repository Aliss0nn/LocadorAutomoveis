namespace LocadorAutomoveis.Dominio.ModuloGrupoAutomoveis
{
    public class ValidadorGrupoAutomoveis : AbstractValidator<GrupoAutomoveis>, 
        IValidadorGrupoAutomoveis
    {
        public ValidadorGrupoAutomoveis()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .NotNull()
                .MinimumLength(5)
                .NaoPodeCaracteresEspeciais();
        }
    }
}
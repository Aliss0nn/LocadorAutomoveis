using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadorAutomoveis.Dominio.ModuloCupom
{
    public class ValidadorCupom : AbstractValidator<Cupom>, IValidadorCupom
    {
        public ValidadorCupom()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .NotNull()
                .MinimumLength(5)
                .NaoPodeCaracteresEspeciais();

            RuleFor(x => x.Valor)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.DataValidade)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Parceiro)
                .NotNull()
                .NotEmpty();

        }
    }
}

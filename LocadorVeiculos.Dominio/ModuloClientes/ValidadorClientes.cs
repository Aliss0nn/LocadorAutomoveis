using LocadorAutomoveis.Dominio.ModuloGrupoAutomoveis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadorAutomoveis.Dominio.ModuloClientes
{
    public class ValidadorClientes : AbstractValidator<Clientes>,
        IValidadorClientes
    {
        public ValidadorClientes()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .NotNull()
                .MinimumLength(5)
                .NaoPodeCaracteresEspeciais();
        }

      
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadorAutomoveis.Dominio.ModuloFuncionario
{
    public class ValidadorFuncionario :  AbstractValidator<Funcionario>, 
        IValidadorFuncionario
    {
        public ValidadorFuncionario()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .NotNull()
                .MinimumLength(5)
                .NaoPodeCaracteresEspeciais();
        }
    }
}

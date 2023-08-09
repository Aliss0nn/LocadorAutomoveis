using Org.BouncyCastle.Math.EC.Rfc7748;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadorAutomoveis.Dominio.ModuloCondutor
{
    public class ValidadorCondutor : AbstractValidator<Condutor>, IValidadorCondutor 
    {
        public ValidadorCondutor() 
        {
            RuleFor(x => x.Nome)
                .NotNull()
                .NotEmpty()
                .MinimumLength(5)
                .NaoPodeCaracteresEspeciais();

            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .MinimumLength(5)
                .NaoPodeCaracteresEspeciais();
           
            RuleFor(x => x.Cpf)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Cnh).
                NotNull()
                .NotEmpty();
           
            RuleFor(x => x.Telefone)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Validade)
                .NotNull()
                .NotEmpty();
            
            RuleFor(x => x.Clientes)
                .NotNull()
                .NotEmpty();           
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadorAutomoveis.Dominio.ModuloTaxasEServicos
{
    public class ValidadorTaxasServico : AbstractValidator<TaxasEServico>, IValidadorTaxasServico
    {
        public ValidadorTaxasServico()
        {
            RuleFor(x => x.Nome)
                .NotNull()
                .NotEmpty()
                .MinimumLength(5)
                .NaoPodeCaracteresEspeciais();

            RuleFor(x => x.Preco)
                .NotNull()
                .NotEmpty();
                
            RuleFor(x => x.PlanoDeCalculo)
                .NotNull()
                .NotEmpty();
        }
    }
}

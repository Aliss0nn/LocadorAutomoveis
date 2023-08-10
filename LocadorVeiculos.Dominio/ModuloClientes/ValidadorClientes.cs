using LocadorAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadorAutomoveis.Dominio.ModuloPlanoCobranca;
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
            RuleFor(x => x.NomeCliente)
                .NotEmpty()
                .NotNull()
                .MinimumLength(5)
                .NaoPodeCaracteresEspeciais();

            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .MinimumLength(5)
                .EmailAddress();

            RuleFor(x => x.Telefone)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Bairro)
               .NotEmpty()
               .NotNull()
               .MinimumLength(5)
               .NaoPodeCaracteresEspeciais();

            RuleFor(x => x.Rua)
               .NotEmpty()
               .NotNull()
               .MinimumLength(5)
               .NaoPodeCaracteresEspeciais();

            RuleFor(x => x.Estado)
               .NotEmpty()
               .NotNull()
               .MinimumLength(5)
               .NaoPodeCaracteresEspeciais();

            RuleFor(x => x.Cidade)
              .NotEmpty()
              .NotNull()
              .MinimumLength(5)
              .NaoPodeCaracteresEspeciais();

            RuleFor(x => x.Numero)
             .NotEmpty()
             .NotNull()
             .MinimumLength(5)
             .NaoPodeCaracteresEspeciais();

            When(x => x.TipoPessoa == "Fisica", () =>
            {
                RuleFor(x => x.Cpf)
               .NotNull()
               .NotEmpty()
               .MinimumLength(15)
               .MaximumLength(15);
            });

            When(x => x.TipoPessoa == "Juridica", () =>
            {  RuleFor(x => x.Cnpj).
                 NotNull()
                 .NotEmpty()
                 .MinimumLength(14)
                 .MaximumLength(14);

             });

            RuleFor(x => x.TipoPessoa)
                .NotNull()
                .NotEmpty();

        }


    }
}


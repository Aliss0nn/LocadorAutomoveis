using LocadorAutomoveis.Dominio.ModuloAutomovel;
using LocadorAutomoveis.Dominio.ModuloClientes;
using LocadorAutomoveis.Dominio.ModuloCupom;
using LocadorAutomoveis.Dominio.ModuloFuncionario;
using System.Numerics;
using System.Text.RegularExpressions;

namespace LocadorAutomoveis.Dominio.ModuloAluguel
{
    public class ValidadorAluguel : AbstractValidator<Aluguel>, IValidadorAluguel
    {
        public ValidadorAluguel()
        {
            RuleFor(x => x.Funcionario)
                .NotNull();

            RuleFor(x => x.Grupo)
                .NotNull();

            RuleFor(x => x.Plano)
                .NotNull();

            RuleFor(x => x.Automovel)
                .NotNull();

            RuleFor(x => x.Cupom)
                .NotNull();

            RuleFor(x => x.KmAutomovel)
                .GreaterThan(0);

            RuleFor(x => x.DataLocacao)
                .NotEqual(new DateTime());

            RuleFor(x => x.DataPrevisao)
                .NotEqual(new DateTime());

            RuleFor(x => x.Preco)
                .GreaterThan(0);

            When(x => x.Fechado, () =>
            {
                RuleFor(x => x.DataDevolucao)
                .NotEqual(new DateTime());
            });

            When(x => x.Fechado, () =>
            {
                RuleFor(x => x.KmPercorrido)
                .GreaterThan(0);
            });
        }
    }
}
using LocadorAutomoveis.Dominio.ModuloFuncionario;
using LocadorAutomoveis.Dominio.ModuloGrupoAutomoveis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadorAutomoveis.Infra.Orm.ModiuloFuncionario
{
    public class MapeadorFuncionario : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> funcionarioBuilder)
        {
            funcionarioBuilder.ToTable("TBFuncionario");

            funcionarioBuilder.Property(g => g.Id).IsRequired().ValueGeneratedNever();

            funcionarioBuilder.Property(g => g.Nome).HasColumnType("varchar(200)").IsRequired();

            funcionarioBuilder.Property (g => g.Salario).HasColumnType("varchar(200)").IsRequired();

            funcionarioBuilder.Property(g => g.DataAdmissao).HasColumnType("varchar(200)").IsRequired();
        }
    }
}

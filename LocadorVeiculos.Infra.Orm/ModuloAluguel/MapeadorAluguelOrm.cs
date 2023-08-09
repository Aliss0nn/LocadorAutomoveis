using LocadorAutomoveis.Dominio.ModuloAluguel;
using LocadorAutomoveis.Dominio.ModuloAutomovel;
using LocadorAutomoveis.Dominio.ModuloClientes;
using LocadorAutomoveis.Dominio.ModuloCupom;
using LocadorAutomoveis.Dominio.ModuloFuncionario;
using System.Numerics;
using System.Text.RegularExpressions;

namespace LocadorAutomoveis.Infra.Orm.ModuloAluguel
{
    public class MapeadorAluguelOrm : IEntityTypeConfiguration<Aluguel>
    {
        public void Configure(EntityTypeBuilder<Aluguel> aluguelBuilder)
        {
            aluguelBuilder.ToTable("TBAluguel");

            aluguelBuilder.Property(al => al.Id).IsRequired().ValueGeneratedNever();

            aluguelBuilder.HasOne(al => al.Funcionario)
               .WithMany()
               .IsRequired()
               .HasConstraintName("FK_TBAlugueis_TBFuncionarios")
               .OnDelete(DeleteBehavior.NoAction);

            aluguelBuilder.HasOne(al => al.Cliente)
               .WithMany()
               .IsRequired()
               .HasConstraintName("FK_TBAlugueis_TBClientes")
               .OnDelete(DeleteBehavior.NoAction);

            aluguelBuilder.HasOne(al => al.Grupo)
               .WithMany()
               .IsRequired()
               .HasConstraintName("FK_TBAlugueis_TBGrupoAutomoveis")
               .OnDelete(DeleteBehavior.NoAction);

            aluguelBuilder.HasOne(al => al.Plano)
               .WithMany()
               .IsRequired()
               .HasConstraintName("FK_TBAlugueis_TBPlanosCobranca")
               .OnDelete(DeleteBehavior.NoAction);

            aluguelBuilder.HasOne(al => al.Automovel)
               .WithMany()
               .IsRequired()
               .HasConstraintName("FK_TBAlugueis_TBAutomoveis")
               .OnDelete(DeleteBehavior.NoAction);

            aluguelBuilder.HasOne(al => al.Cupom)
               .WithMany()
               .HasConstraintName("FK_TBAlugueis_TBCupons")
               .OnDelete(DeleteBehavior.NoAction);

            aluguelBuilder.Property(al => al.KmAutomovel).IsRequired();

            aluguelBuilder.Property(al => al.DataLocacao).IsRequired();

            aluguelBuilder.Property(al => al.DataPrevisao).IsRequired();

            aluguelBuilder.Property(al => al.Preco).IsRequired();

            aluguelBuilder.Property(al => al.Fechado);

            aluguelBuilder.Property(al => al.DataDevolucao);

            aluguelBuilder.Property(al => al.KmPercorrido);

            aluguelBuilder.Property(al => al.NivelTanque);

            aluguelBuilder.HasMany(al => al.Taxas)
                .WithMany()
                .UsingEntity(x => x.ToTable("TBAluguel_TBTaxasEServico"));

        }
    }
}

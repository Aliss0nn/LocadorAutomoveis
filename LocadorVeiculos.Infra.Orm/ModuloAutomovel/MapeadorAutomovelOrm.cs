using LocadorAutomoveis.Dominio.ModuloAutomovel;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using System.Text.RegularExpressions;

namespace LocadorAutomoveis.Infra.Orm.ModuloAutomovel
{
    public class MapeadorAutomovelOrm : IEntityTypeConfiguration<Automovel>
    {
        public void Configure(EntityTypeBuilder<Automovel> automovelBuilder)
        {
            automovelBuilder.ToTable("TBAutomovel");

            automovelBuilder.Property(a => a.Id).IsRequired().ValueGeneratedNever();

            automovelBuilder.Property(a => a.Marca).HasColumnType("varchar(200)").IsRequired();

            automovelBuilder.Property(a => a.Cor).HasColumnType("varchar(200)").IsRequired();

            automovelBuilder.Property(a => a.Modelo).HasColumnType("varchar(200)").IsRequired();

            automovelBuilder.Property(a => a.Ano).IsRequired();

            automovelBuilder.Property(a => a.Quilometragem).IsRequired();

            automovelBuilder.Property(a => a.TipoCombustivel).IsRequired();

            automovelBuilder.Property(a => a.Capacidade).IsRequired();

            automovelBuilder.Property(a => a.Placa).HasColumnType("varchar(200)").IsRequired();

            automovelBuilder.Property(a => a.Imagem).IsRequired();

            automovelBuilder.HasOne(a => a.Grupo)
               .WithMany()
               .IsRequired()
               .HasConstraintName("FK_TBAutomoveis_TBGrupoAutomoveis")
               .OnDelete(DeleteBehavior.NoAction);

        }
    }
}

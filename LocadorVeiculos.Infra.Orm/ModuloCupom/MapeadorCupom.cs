using LocadorAutomoveis.Dominio.ModuloCupom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadorAutomoveis.Infra.Orm.ModuloCupom
{
    public class MapeadorCupom : IEntityTypeConfiguration<Cupom>
    {
        public void Configure(EntityTypeBuilder<Cupom> cupomBuilder)
        {
            cupomBuilder.ToTable("TBCupom");
            cupomBuilder.Property(x => x.Id).IsRequired(true).ValueGeneratedNever();
            cupomBuilder.Property(x => x.Nome).HasColumnType("varchar(200)").IsRequired();
            cupomBuilder.Property(x => x.DataValidade).IsRequired();

            cupomBuilder.HasOne(x => x.Parceiro)
                .WithMany(x => x.Cupons)
                .IsRequired()
                .HasConstraintName("FK_TBCupom_TBParceiro")
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

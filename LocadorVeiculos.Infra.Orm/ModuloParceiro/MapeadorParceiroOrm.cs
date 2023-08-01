using LocadorAutomoveis.Dominio.ModuloParceiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadorAutomoveis.Infra.Orm.ModuloParceiro
{
    public class MapeadorParceiroOrm : IEntityTypeConfiguration<Parceiro>
    {
        public void Configure(EntityTypeBuilder<Parceiro> parceiroBuilder)
        {
            parceiroBuilder.ToTable("TBParceiro");

            parceiroBuilder.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();

            parceiroBuilder.Property(p => p.Nome).HasColumnType("varchar(200)").IsRequired();
        }
    }
}

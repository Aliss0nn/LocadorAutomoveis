using LocadorAutomoveis.Dominio.ModuloTaxasEServicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadorAutomoveis.Infra.Orm.ModuloTaxasEServicos
{
    public class MapeadorTaxasEServicosOrm : IEntityTypeConfiguration<TaxasEServico>
    {
        public void Configure(EntityTypeBuilder<TaxasEServico> taxasServicoBuilder)
        {
            taxasServicoBuilder.ToTable("TBTaxasEServico");

            taxasServicoBuilder.Property(x => x.Id).IsRequired().ValueGeneratedNever();
            taxasServicoBuilder.Property(x => x.Preco).HasColumnType("decimal(18,0)").IsRequired();
            taxasServicoBuilder.Property(x => x.planoDeCalculo).HasConversion<int>().IsRequired();
        }
    }
}

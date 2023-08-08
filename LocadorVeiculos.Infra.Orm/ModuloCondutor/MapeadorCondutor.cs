using LocadorAutomoveis.Dominio.ModuloClientes;
using LocadorAutomoveis.Dominio.ModuloCondutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadorAutomoveis.Infra.Orm.ModuloCondutor
{
    public class MapeadorCondutor : IEntityTypeConfiguration<Condutor>
    {
        public void Configure(EntityTypeBuilder<Condutor> condutorBuilder)
        {
            condutorBuilder.ToTable("TBCondutor");
            condutorBuilder.Property(x => x.Id).IsRequired(true).ValueGeneratedNever();
            condutorBuilder.Property(x => x.Nome).HasColumnType("varchar(200)").IsRequired();
            condutorBuilder.Property(x => x.Email).HasColumnType("varchar(200)").IsRequired();
            condutorBuilder.Property(x => x.Cpf).IsRequired();
            condutorBuilder.Property(x => x.Telefone).IsRequired();
            condutorBuilder.Property(x => x.Cnh).IsRequired();
            condutorBuilder.Property(x => x.Validade).IsRequired();
            condutorBuilder.Property(x => x.ClienteEhCondutor).IsRequired();
            condutorBuilder.Property(x => x.Telefone).IsRequired();

            condutorBuilder.HasOne(x => x.Clientes)
                .WithMany(x => x.Condutores)
                .IsRequired()
                .HasConstraintName("FK_TBCondutor_TBClientes")
                .OnDelete(DeleteBehavior.NoAction);
        }
     
    }
}

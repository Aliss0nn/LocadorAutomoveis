using LocadorAutomoveis.Dominio.ModuloPlanoCobranca;

namespace LocadorAutomoveis.Infra.Orm.ModuloPlanoCobranca
{
    public class MapeadorPlanoCobrancaOrm : IEntityTypeConfiguration<PlanoCobranca>
    {
        public void Configure(EntityTypeBuilder<PlanoCobranca> planoBuilder)
        {
            planoBuilder.ToTable("TBPlanoCobranca");

            planoBuilder.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();

            planoBuilder.Property(p => p.TipoPlano).IsRequired();

            planoBuilder.Property(p => p.PrecoDiario).IsRequired();

            planoBuilder.Property(p => p.PrecoKm);

            planoBuilder.Property(p => p.KmLivre);

            planoBuilder.HasOne(p => p.Grupo)
               .WithMany()
               .IsRequired()
               .HasConstraintName("FK_TBPlanoCobranca_TBGrupoAutomoveis")
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

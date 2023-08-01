using LocadorAutomoveis.Dominio.ModuloGrupoAutomoveis;

namespace LocadorAutomoveis.Infra.Orm.ModuloGrupoAutomoveis
{
    public class MapeadorGrupoAutomoveisOrm : IEntityTypeConfiguration<GrupoAutomoveis>
    {
        public void Configure(EntityTypeBuilder<GrupoAutomoveis> grupoBuilder)
        {
            grupoBuilder.ToTable("TBGrupoAutomoveis");

            grupoBuilder.Property(g => g.Id).IsRequired().ValueGeneratedNever();

            grupoBuilder.Property(g => g.Nome).HasColumnType("varchar(200)").IsRequired();
        }
    }
}

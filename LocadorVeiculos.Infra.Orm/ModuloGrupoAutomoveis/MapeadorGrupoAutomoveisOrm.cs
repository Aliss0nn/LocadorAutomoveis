using LocadorAutomoveis.Dominio.ModuloGrupoAutomoveis;

namespace LocadorAutomoveis.Infra.Orm.ModuloGrupoAutomoveis
{
    public class MapeadorGrupoAutomoveisOrm : IEntityTypeConfiguration<GrupoAutomoveis>
    {
        public void Configure(EntityTypeBuilder<GrupoAutomoveis> grupoBuilder)
        {
            grupoBuilder.ToTable("TBGrupoAutomoveis");

            grupoBuilder.Property(g => g.Id).IsRequired().ValueGeneratedOnAdd();

            grupoBuilder.Property(g => g.Tipo).HasColumnType("varchar(200)").IsRequired();
        }
    }
}

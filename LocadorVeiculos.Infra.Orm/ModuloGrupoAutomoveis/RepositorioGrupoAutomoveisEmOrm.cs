using LocadorAutomoveis.Dominio.ModuloGrupoAutomoveis;

namespace LocadorAutomoveis.Infra.Orm.ModuloGrupoAutomoveis
{
    public class RepositorioGrupoAutomoveisEmOrm : 
        RepositorioBaseEmOrm<GrupoAutomoveis>, IRepositorioGrupoAutomoveis
    {
        public RepositorioGrupoAutomoveisEmOrm(LocadorAutomoveisDbContext dbContext) : 
            base(dbContext)
        {           
        }
      
        public GrupoAutomoveis SelecionarPorTipo(string tipo)
        {
            return registros.FirstOrDefault(x => x.Tipo == tipo);
        }

    }
}

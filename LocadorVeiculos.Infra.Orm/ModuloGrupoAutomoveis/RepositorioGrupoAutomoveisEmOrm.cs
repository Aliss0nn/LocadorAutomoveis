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
      
        public GrupoAutomoveis SelecionarPorNome(string nome)
        {
            return registros.FirstOrDefault(x => x.Nome == nome);
        }

    }
}

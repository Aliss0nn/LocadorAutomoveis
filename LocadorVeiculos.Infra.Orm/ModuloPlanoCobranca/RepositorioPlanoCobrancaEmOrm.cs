using LocadorAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadorAutomoveis.Dominio.ModuloPlanoCobranca;

namespace LocadorAutomoveis.Infra.Orm.ModuloPlanoCobranca
{
    public class RepositorioPlanoCobrancaEmOrm : RepositorioBaseEmOrm<PlanoCobranca>, IRepositorioPlanoCobranca
    {
        public RepositorioPlanoCobrancaEmOrm(LocadorAutomoveisDbContext dbContext) : base(dbContext)
        {           
        }

        public List<PlanoCobranca> SelecionarTodos(bool carregarGrupos = false)
        {
            if (!carregarGrupos)
                return registros.ToList();

            return registros
                .Include(x => x.Grupo)
                .ToList();
        }

        public PlanoCobranca SelecionarPorGrupoTipo(GrupoAutomoveis grupo, TipoPlanoEnum tipoPlano)
        {
            return registros
                .Include(x => x.Grupo)
                .FirstOrDefault(x => x.Grupo == grupo && x.TipoPlano == tipoPlano);
        }

        public PlanoCobranca SelecionarPorId(Guid id, bool carregarGrupo = false)
        {
            if(!carregarGrupo)
                return registros.FirstOrDefault(x => x.Id == id);

            return registros
                .Include(x => x.Grupo)
                .FirstOrDefault(x => x.Id == id);


        }

    }
}

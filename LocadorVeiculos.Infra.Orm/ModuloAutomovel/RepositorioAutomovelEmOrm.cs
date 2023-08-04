using LocadorAutomoveis.Dominio.ModuloAutomovel;
using LocadorAutomoveis.Dominio.ModuloGrupoAutomoveis;

namespace LocadorAutomoveis.Infra.Orm.ModuloAutomovel
{
    public class RepositorioAutomovelEmOrm : RepositorioBaseEmOrm<Automovel>, IRepositorioAutomovel
    {
        public RepositorioAutomovelEmOrm(LocadorAutomoveisDbContext dbContext) : base(dbContext)
        {           
        }

        public List<Automovel> SelecionarTodos(bool carregarGrupo = false)
        {
            if (!carregarGrupo)
                return registros.ToList();

                return registros
                    .Include(x => x.Grupo)
                    .ToList();
        }
      
        public Automovel SelecionarPorMarcaModelo(string marca, string modelo)
        {
            return registros.FirstOrDefault(x => x.Marca == marca && x.Modelo == x.Marca);
        }

        public List<Automovel> SelecionarTodosPorGrupo(GrupoAutomoveis grupo)
        {
            return registros
                .Include(x => x.Grupo)
                .Where(x => x.Grupo.Equals(grupo)).ToList();
        }

    }
}

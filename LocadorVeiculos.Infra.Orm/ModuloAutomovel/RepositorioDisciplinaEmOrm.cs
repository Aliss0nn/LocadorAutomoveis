using LocadorAutomoveis.Dominio.ModuloAutomovel;

namespace LocadorAutomoveis.Infra.Orm.ModuloDisciplina
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

    }
}

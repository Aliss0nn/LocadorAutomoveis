using LocadorAutomoveis.Dominio.ModuloAutomovel;

namespace LocadorAutomoveis.Infra.Orm.ModuloDisciplina
{
    public class RepositorioAutomovelEmOrm : RepositorioBaseEmOrm<Automovel>, IRepositorioAutomovel
    {
        public RepositorioAutomovelEmOrm(LocadorAutomoveisDbContext dbContext) : base(dbContext)
        {           
        }
      
        public Automovel SelecionarPorMarcaModelo(string marca, string modelo)
        {
            return registros.FirstOrDefault(x => x.Marca == marca && x.Modelo == x.Marca);
        }

    }
}

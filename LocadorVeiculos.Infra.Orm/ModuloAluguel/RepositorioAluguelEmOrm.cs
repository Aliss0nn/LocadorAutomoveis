using LocadorAutomoveis.Dominio.ModuloAluguel;
using LocadorAutomoveis.Dominio.ModuloAutomovel;

namespace LocadorAutomoveis.Infra.Orm.ModuloAluguel
{
    public class RepositorioAluguelEmOrm : RepositorioBaseEmOrm<Aluguel>, IRepositorioAluguel
    {
        public RepositorioAluguelEmOrm(LocadorAutomoveisDbContext dbContext) : base(dbContext)
        {
        }

        public List<Aluguel> SelecionarTodos(bool carregarObjetos = false)
        {
            if (!carregarObjetos)
                return registros.ToList();

            return registros
                .Include(x => x.Funcionario)
                .Include(x => x.Cliente)
                .Include(x => x.Grupo)
                .Include(x => x.Plano)
                .Include(x => x.Cupom)
                .Include(x => x.Taxas)
                .Include(x => x.Automovel)
                .ThenInclude(x => x.Grupo)
                .ToList();
        }

        public Aluguel SelecionarPorAutomovel(Automovel automovel)
        {
            return registros.FirstOrDefault(x => x.Automovel.Equals(automovel));
        }
    }
}

using LocadorAutomoveis.Dominio.ModuloCondutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadorAutomoveis.Infra.Orm.ModuloCondutor
{
    public class RepositorioCondutorEmOrm : RepositorioBaseEmOrm<Condutor>, IRepositorioCondutor
    {
        public RepositorioCondutorEmOrm(LocadorAutomoveisDbContext dbContext) : base(dbContext)
        {
        }

        public Condutor SelecionarPorNome(string nome)
        {
            return registros.FirstOrDefault(x => x.Nome == nome);
        }

        public List<Condutor> SelecionarTodos(bool incluirClientes = false)
        {
            if (incluirClientes)
                return registros.Include(x => x.Clientes).ToList();

            return registros.ToList();
        }
    }
}

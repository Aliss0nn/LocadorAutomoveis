using LocadorAutomoveis.Dominio.ModuloClientes;
using LocadorAutomoveis.Dominio.ModuloGrupoAutomoveis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadorAutomoveis.Infra.Orm.ModuloClientes
{
    public class RepositorioClientesEmOrm :
        RepositorioBaseEmOrm<Clientes>, IRepositorioClientes
    {
        public RepositorioClientesEmOrm(LocadorAutomoveisDbContext dbContext) :
            base(dbContext)
        {
        }

        public Clientes SelecionarPorNome(string nome)
        {
            return registros.FirstOrDefault(x => x.NomeCliente == nome);
        }

    }
}

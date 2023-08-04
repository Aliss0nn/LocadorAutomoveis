using LocadorAutomoveis.Dominio.ModuloTaxasEServicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadorAutomoveis.Infra.Orm.ModuloTaxasEServicos
{
    public class RepositorioTaxasEServicosOrm : RepositorioBaseEmOrm<TaxasEServico>, IRepositorioTaxasServico
    {
        public RepositorioTaxasEServicosOrm(LocadorAutomoveisDbContext dbContext) : base(dbContext)
        {
        }

        public TaxasEServico SelecionarPorNome(string nome)
        {
            return registros.FirstOrDefault(x => x.Nome == nome);
        }
    }
}

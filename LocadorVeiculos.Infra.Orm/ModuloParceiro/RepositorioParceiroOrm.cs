using LocadorAutomoveis.Dominio.ModuloParceiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadorAutomoveis.Infra.Orm.ModuloParceiro
{
    public class RepositorioParceiroOrm : RepositorioBaseEmOrm<Parceiro>, IRepositorioParceiro
    {
        public RepositorioParceiroOrm(LocadorAutomoveisDbContext dbContext) : base(dbContext)
        {
        }

        public Parceiro SelecionarPorNome(string nome)
        {
            throw new NotImplementedException();
        }
    }
}

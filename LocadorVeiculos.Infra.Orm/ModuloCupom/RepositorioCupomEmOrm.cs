using LocadorAutomoveis.Dominio.ModuloCupom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadorAutomoveis.Infra.Orm.ModuloCupom
{
    public class RepositorioCupomEmOrm : RepositorioBaseEmOrm<Cupom>, IRepositorioCupom
    {
        public RepositorioCupomEmOrm(LocadorAutomoveisDbContext dbContext) : base(dbContext)
        {

        }

        public Cupom SelecionarPorNome(string nome)
        {
           return registros.FirstOrDefault(x => x.Nome == nome);
        }
    }
}

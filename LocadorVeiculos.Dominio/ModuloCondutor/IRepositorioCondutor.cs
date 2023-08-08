using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadorAutomoveis.Dominio.ModuloCondutor
{
    public interface IRepositorioCondutor : IRepositorio<Condutor>
    {
        Condutor SelecionarPorNome(string nome);
        

        
    }
}

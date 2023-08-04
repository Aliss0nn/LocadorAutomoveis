using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadorAutomoveis.Dominio.ModuloClientes
{
    public interface IRepositorioClientes : IRepositorio<Clientes>
    {
        Clientes SelecionarPorNome(string nome);

    }
}

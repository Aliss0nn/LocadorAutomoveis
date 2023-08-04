using iText.Kernel.Geom;
using LocadorAutomoveis.Dominio.ModuloParceiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadorAutomoveis.Dominio.ModuloCupom
{
    public interface IRepositorioCupom : IRepositorio<Cupom>
    {
        Cupom SelecionarPorNome(string nome);

        List<Cupom> SelecionarTodos(bool incluirParceiros = false);
    }
}

using LocadorAutomoveis.Dominio.ModuloGrupoAutomoveis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadorAutomoveis.Dominio.ModuloTaxasEServicos
{
    public interface IRepositorioTaxasServico : IRepositorio<TaxasEServico>
    {
        TaxasEServico SelecionarPorNome(string nome);
    }
}

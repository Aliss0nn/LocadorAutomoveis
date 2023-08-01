using LocadorAutomoveis.Dominio.ModuloGrupoAutomoveis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadorAutomoveis.Dominio.ModuloParceiro
{
    public interface IRepositorioParceiro : IRepositorio<Parceiro>
    {
        Parceiro SelecionarPorNome(string nome);
    }
}

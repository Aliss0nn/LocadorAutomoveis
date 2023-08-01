using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadorAutomoveis.Dominio.ModuloTaxasEServicos
{
    public enum EnumPlanoDeCalculo
    {
        [Description(" ")]
        Nenhum = 0,

        [Description("Preço Fixo")]
        PrimeiraSerie = 1,

        [Description("Cobrança Diária")]
        SegundaSerie = 2
    }
}

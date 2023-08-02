using LocadorAutomoveis.Dominio.ModuloTaxasEServicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadorAutomoveisTestesUnitarios.Dominio
{
    [TestClass]
    public class TaxaServicoTest
    {
        TaxasEServico taxasEServico;

        public TaxaServicoTest()
        {
            taxasEServico = new TaxasEServico("Limpeza do Veículo",50,"Preço Fixo");
        }
    }
}

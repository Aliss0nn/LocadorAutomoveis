using LocadorAutomoveis.Dominio.ModuloParceiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadorAutomoveisTestesUnitarios.Dominio
{
    [TestClass]
    public class ParceiroTest
    {
        Parceiro parceiro;

        public ParceiroTest()
        {
            parceiro = new Parceiro("parceiro");
        }
    }
}

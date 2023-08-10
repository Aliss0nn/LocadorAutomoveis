using LocadorAutomoveis.Dominio.ModuloCupom;
using LocadorAutomoveis.Dominio.ModuloParceiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LocadorAutomoveisTestesUnitarios.Dominio.ModuloCupom
{
    [TestClass]
    public class CupomTest
    {
        Cupom cupom;
        Parceiro parceiro;

        public CupomTest()
        {
            parceiro = new Parceiro("Posto Shell");
            cupom = new Cupom("Desconto Shell", 50, DateTime.Today, parceiro);
        }
    }
}

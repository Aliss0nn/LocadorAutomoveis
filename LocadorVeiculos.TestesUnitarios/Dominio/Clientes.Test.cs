using iText.Kernel.Pdf.Canvas.Wmf;
using LocadorAutomoveis.Dominio.ModuloClientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace LocadorAutomoveisTestesUnitarios.Dominio
{
    [TestClass]
    public class ClienteTest
    {
        Clientes cliente;
        public ClienteTest()
        {
            cliente = new Clientes(new Guid,"Marcos", "11582178321","SC", "Alfredo Wagner", "Aguas Frias", "Jose Lino De Mello", "12", "48981827812","Joaomarcelo@gmail.com", "12818371281", "Jurídica");
        }

    }
}

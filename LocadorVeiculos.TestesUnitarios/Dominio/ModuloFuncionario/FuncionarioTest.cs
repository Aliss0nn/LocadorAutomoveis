using LocadorAutomoveis.Dominio.ModuloFuncionario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadorAutomoveisTestesUnitarios.Dominio.ModuloFuncionario
{
    [TestClass]
    public class FuncionarioTest
    {

        Funcionario funcionario;

        public FuncionarioTest()
        {
            funcionario = new Funcionario("Alex");
        }




    }
}

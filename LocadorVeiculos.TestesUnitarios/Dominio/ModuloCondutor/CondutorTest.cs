using LocadorAutomoveis.Dominio.ModuloClientes;
using LocadorAutomoveis.Dominio.ModuloCondutor;

namespace LocadorAutomoveisTestesUnitarios.Dominio.ModuloCondutor
{
    [TestClass]
    public class CondutorTest
    {
        Condutor condutor;
        Clientes clientes;

        public CondutorTest()
        {
            clientes = new Clientes("Mario", "Pessoa Fisica", "123456789", "Santa Catarina",
                "Lages", "Coral", "Rua Teste", "888", "mario@gmail.com", "4932243745", "");

            condutor = new Condutor(
                "Teste",
                "teste@gmail.com",
                "98765432123",
                "4932223898", "123456789123",
                DateTime.Today, condutor.ClienteEhCondutor, condutor.Clientes);
        }
    }
}

namespace LocadorAutomoveis.Dominio.ModuloFuncionario
{
    public interface IRepositorioFuncionario : IRepositorio<Funcionario>
    {
              Funcionario SelecionarPorNome(string nome);
    }
}

namespace LocadorAutomoveis.Dominio.ModuloCondutor
{
    public interface IRepositorioCondutor : IRepositorio<Condutor>
    {
        Condutor SelecionarPorNome(string nome);

        List<Condutor> SelecionarTodos(bool incluirClientes = false);
    }
}

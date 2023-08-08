namespace LocadorAutomoveis.Dominio.ModuloAluguel
{
    public interface IRepositorioAluguel : IRepositorio<Aluguel>
    {        
        Aluguel SelecionarTodos(bool carregarObjetos);
    }
}

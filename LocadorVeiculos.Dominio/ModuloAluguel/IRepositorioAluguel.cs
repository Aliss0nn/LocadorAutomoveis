using LocadorAutomoveis.Dominio.ModuloAutomovel;

namespace LocadorAutomoveis.Dominio.ModuloAluguel
{
    public interface IRepositorioAluguel : IRepositorio<Aluguel>
    {        
        List<Aluguel> SelecionarTodos(bool carregarObjetos = false);

        Aluguel SelecionarPorAutomovel(Automovel automovel);
    }
}

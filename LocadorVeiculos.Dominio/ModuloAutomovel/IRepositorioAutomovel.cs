namespace LocadorAutomoveis.Dominio.ModuloAutomovel
{
    public interface IRepositorioAutomovel : IRepositorio<Automovel>
    {        
        Automovel SelecionarPorMarcaModelo(string marca, string modelo);
    }
}

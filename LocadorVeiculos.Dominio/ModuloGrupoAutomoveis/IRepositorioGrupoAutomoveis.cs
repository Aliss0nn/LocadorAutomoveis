namespace LocadorAutomoveis.Dominio.ModuloGrupoAutomoveis
{
    public interface IRepositorioGrupoAutomoveis : IRepositorio<GrupoAutomoveis>
    {        
        GrupoAutomoveis SelecionarPorTipo(string tipo);
    }
}

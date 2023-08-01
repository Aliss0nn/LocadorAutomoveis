using LocadorAutomoveis.Dominio.ModuloGrupoAutomoveis;

namespace LocadorAutomoveis.Dominio.ModuloPlanoCobranca
{
    public interface IRepositorioPlanoCobranca : IRepositorio<PlanoCobranca>
    {        
        PlanoCobranca SelecionarPorGrupoTipo(GrupoAutomoveis grupo, TipoPlanoEnum tipoPlano);
        List<PlanoCobranca> SelecionarTodos(bool carregarGrupos = false);
    }
}

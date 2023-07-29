namespace LocadorAutomoveis.Dominio.ModuloDisciplina
{
    public interface IRepositorioDisciplina : IRepositorio<Disciplina>
    {        
        Disciplina SelecionarPorNome(string nome);
    }
}

using LocadorAutomoveis.Dominio.ModuloDisciplina;

namespace LocadorAutomoveis.Infra.Orm.ModuloDisciplina
{
    public class RepositorioDisciplinaEmOrm : RepositorioBaseEmOrm<Disciplina>, IRepositorioDisciplina
    {
        public RepositorioDisciplinaEmOrm(LocadorAutomoveisDbContext dbContext) : base(dbContext)
        {           
        }
      
        public Disciplina SelecionarPorNome(string nome)
        {
            return registros.FirstOrDefault(x => x.Nome == nome);
        }

    }
}

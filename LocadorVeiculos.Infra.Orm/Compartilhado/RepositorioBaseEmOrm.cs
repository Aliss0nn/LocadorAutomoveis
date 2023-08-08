using LocadorAutomoveis.Dominio;
using Microsoft.EntityFrameworkCore;

namespace LocadorAutomoveis.Infra.Orm.Compartilhado
{
    public class RepositorioBaseEmOrm<T> : IRepositorio<T>
        where T : EntidadeBase<T>
    {
        protected readonly LocadorAutomoveisDbContext dbContext;
        protected DbSet<T> registros;

        public RepositorioBaseEmOrm(LocadorAutomoveisDbContext dbContext)
        {
            this.dbContext = dbContext;
            registros = dbContext.Set<T>();
        }

        public void Inserir(T novoRegistro)
        {
            registros.Add(novoRegistro);

            
        }

        public void Editar(T registro)
        {
            registros.Update(registro);

           
        }

        public void Excluir(T registro)
        {
            registros.Remove(registro);

            
        }

        public bool Existe(T registro)
        {
            return registros.Contains(registro);
        }
      
        public T SelecionarPorId(Guid id)
        {
            return registros.Find(id);
        }

        public List<T> SelecionarTodos()
        {
           return registros.ToList();
        }
    }
}

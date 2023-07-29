using FizzWare.NBuilder;
using LocadorAutomoveis.Dominio.ModuloDisciplina;
using LocadorAutomoveis.Infra.Orm.Compartilhado;
using LocadorAutomoveis.Infra.Orm.ModuloDisciplina;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LocadorAutomoveis.TestesIntegracao.Compartilhado
{
    public class TestesIntegracaoBase
    {
        protected IRepositorioDisciplina repositorioDisciplina;

        public TestesIntegracaoBase()
        {

            var connectionString = ObterConnectionString();

            var optionsBuilder = new DbContextOptionsBuilder<LocadorAutomoveisDbContext>();

            optionsBuilder.UseSqlServer(connectionString);

            var dbContext = new LocadorAutomoveisDbContext(optionsBuilder.Options);

            var migracoesPendentes = dbContext.Database.GetPendingMigrations();

            if (migracoesPendentes.Count() > 0)
            {
                dbContext.Database.Migrate();
            }

            repositorioDisciplina = new RepositorioDisciplinaEmOrm(dbContext);

            LimparTabelas(dbContext);

            BuilderSetup.DisablePropertyNamingFor<Disciplina, int>(d => d.Id);

            BuilderSetup.SetCreatePersistenceMethod<Disciplina>(repositorioDisciplina.Inserir);

        }

        protected static void LimparTabelas(LocadorAutomoveisDbContext dbContext)
        {
           var disciplinas = dbContext.Set<Disciplina>();
           disciplinas.RemoveRange(disciplinas);
           dbContext.SaveChanges();
        }

        protected static string ObterConnectionString()
        {
            var configuracao = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuracao.GetConnectionString("SqlServer");
            return connectionString;
        }
    }
}
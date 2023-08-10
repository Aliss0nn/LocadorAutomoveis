using LocadorAutomoveis.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LocadorAutomoveis.ConsoleApp
{

    internal class Program
    {
        static void Main(string[] args)
        {
            var configuracao = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .Build();

            var connectionString = configuracao.GetConnectionString("SqlServer");

            var optionsBuilder = new DbContextOptionsBuilder<LocadorAutomoveisDbContext>();

            optionsBuilder.UseSqlServer(connectionString);

            var dbContext = new LocadorAutomoveisDbContext(optionsBuilder.Options);

            var migracoesPendentes = dbContext.Database.GetPendingMigrations();

            if (migracoesPendentes.Count() > 0)
            {
                dbContext.Database.Migrate();
            }
          
        }
    }
}
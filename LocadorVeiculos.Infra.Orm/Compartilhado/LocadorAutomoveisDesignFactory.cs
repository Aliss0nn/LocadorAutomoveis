using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace LocadorAutomoveis.Infra.Orm.Compartilhado
{
    internal class LocadorAutomoveisDesignFactory : IDesignTimeDbContextFactory<LocadorAutomoveisDbContext>
    {
        public LocadorAutomoveisDbContext CreateDbContext(string[] args)
        {            
            var configuracao = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            var connectionString = configuracao.GetConnectionString("SqlServer");

            var optionsBuilder = new DbContextOptionsBuilder<LocadorAutomoveisDbContext>();

            optionsBuilder.UseSqlServer(connectionString);

            return new LocadorAutomoveisDbContext(optionsBuilder.Options);
        }
    }
}

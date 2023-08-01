using LocadorAutomoveis.Dominio.ModuloDisciplina;

using LocadorAutomoveis.Infra.Orm.Compartilhado;
using LocadorAutomoveis.Infra.Orm.ModuloDisciplina;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

            //IRepositorioDisciplina repositorioDisciplina = new RepositorioDisciplinaEmOrm(dbContext);

            //GeradorMassaDados geradorMassa = new GeradorMassaDados(repositorioDisciplina);

            //geradorMassa.ConfigurarDisciplina();
        }
    }
}
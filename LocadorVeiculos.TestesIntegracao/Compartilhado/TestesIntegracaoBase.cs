using FizzWare.NBuilder;
using LocadorAutomoveis.Dominio;
using LocadorAutomoveis.Dominio.ModuloDisciplina;
using LocadorAutomoveis.Dominio.ModuloFuncionario;
using LocadorAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadorAutomoveis.Dominio.ModuloParceiro;
using LocadorAutomoveis.Infra.Orm.Compartilhado;
using LocadorAutomoveis.Infra.Orm.ModiuloFuncionario;
using LocadorAutomoveis.Infra.Orm.ModuloDisciplina;
using LocadorAutomoveis.Infra.Orm.ModuloGrupoAutomoveis;
using LocadorAutomoveis.Infra.Orm.ModuloParceiro;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LocadorAutomoveis.TestesIntegracao.Compartilhado
{
    public class TestesIntegracaoBase
    {
        protected IRepositorioDisciplina repositorioDisciplina;
        protected IRepositorioGrupoAutomoveis repositorioGrupoAutomoveis;
        protected IRepositorioFuncionario repositorioFuncionario;
        protected IRepositorioParceiro repositorioParceiro;
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

            LimparTabelas(dbContext);

            //Disciplina
            repositorioDisciplina = new RepositorioDisciplinaEmOrm(dbContext);

           // BuilderSetup.DisablePropertyNamingFor<Disciplina, int>(d => d.Id);

            BuilderSetup.SetCreatePersistenceMethod<Disciplina>(repositorioDisciplina.Inserir);

            //GrupoAutomoveis
            repositorioGrupoAutomoveis = new RepositorioGrupoAutomoveisEmOrm(dbContext);

       

            BuilderSetup.SetCreatePersistenceMethod<GrupoAutomoveis>(repositorioGrupoAutomoveis.Inserir);
            
            repositorioFuncionario = new RepositorioFuncionarioEmOrm(dbContext);

            BuilderSetup.SetCreatePersistenceMethod<Funcionario>(repositorioFuncionario.Inserir);

            repositorioParceiro = new RepositorioParceiroOrm(dbContext);

            BuilderSetup.SetCreatePersistenceMethod<Parceiro>(repositorioParceiro.Inserir);




        }

        protected static void LimparTabelas(LocadorAutomoveisDbContext dbContext)
        {
            LimparLista<Disciplina>(dbContext);
            LimparLista<GrupoAutomoveis>(dbContext);
            LimparLista<Parceiro>(dbContext);
            LimparLista<Funcionario>(dbContext);
        }

        private static void LimparLista<T>(LocadorAutomoveisDbContext dbContext)
        where T : EntidadeBase<T>
        {
            var registros = dbContext.Set<T>();
            registros.RemoveRange(registros);
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
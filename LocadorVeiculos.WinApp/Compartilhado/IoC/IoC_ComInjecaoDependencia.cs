using LocadorAutomoveis.Aplicacao.ModuloDisciplina;
using LocadorAutomoveis.Dominio.ModuloDisciplina;
using LocadorAutomoveis.Dominio;
using LocadorAutomoveis.Infra.Orm.ModuloDisciplina;
using LocadorAutomoveis.WinApp.ModuloDisciplina;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadorAutomoveis.Infra.Orm.Compartilhado;
using LocadorAutomoveis.WinApp.ModuloAutomovel;
using LocadorAutomoveis.Aplicacao.ModuloAutomovel;
using LocadorAutomoveis.Dominio.ModuloAutomovel;
using LocadorAutomoveis.Infra.Orm.ModuloAutomovel;
using LocadorAutomoveis.Dominio.ModuloClientes;
using LocadorAutomoveis.Infra.Orm.ModuloClientes;
using LocadorAutomoveis.Aplicacao.ModuloClientes;
using LocadorAutomoveis.WinApp.ModuloClientes;
using LocadorAutomoveis.Dominio.ModuloCupom;
using LocadorAutomoveis.Infra.Orm.ModuloCupom;
using LocadorAutomoveis.Aplicacao.ModuloCupom;
using LocadorAutomoveis.WinApp.ModuloCupom;
using LocadorAutomoveis.Dominio.ModuloFuncionario;
using LocadorAutomoveis.Infra.Orm.ModiuloFuncionario;
using LocadorAutomoveis.Aplicacao.ModuloFuncionario;
using LocadorAutomoveis.WinApp.ModuloFuncionario;
using LocadorAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadorAutomoveis.Infra.Orm.ModuloGrupoAutomoveis;
using LocadorAutomoveis.Aplicacao.ModuloGrupoAutomoveis;
using LocadorAutomoveis.WinApp.ModuloGrupoAutomoveis;
using LocadorAutomoveis.Dominio.ModuloParceiro;
using LocadorAutomoveis.Infra.Orm.ModuloParceiro;
using LocadorAutomoveis.Aplicacao.ModuloParceiro;
using LocadorAutomoveis.WinApp.ModuloParceiro;
using LocadorAutomoveis.Dominio.ModuloPlanoCobranca;
using LocadorAutomoveis.Infra.Orm.ModuloPlanoCobranca;
using LocadorAutomoveis.Aplicacao.ModuloPlanoCobranca;
using LocadorAutomoveis.Dominio.ModuloTaxasEServicos;
using LocadorAutomoveis.Infra.Orm.ModuloTaxasEServicos;
using LocadorAutomoveis.Aplicacao.ModuloTaxasEServicos;
using LocadorAutomoveis.WinApp.ModuloTaxasEServicos;

namespace LocadorAutomoveis.WinApp.Compartilhado.IoC
{
    public class IoC_ComInjecaoDependencia : Ioc
    {
        private ServiceProvider container;

        public IoC_ComInjecaoDependencia()
        {
            var configuracao = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .Build();

            var connectionString = configuracao.GetConnectionString("SqlServer");

            var servicos = new ServiceCollection();

            servicos.AddDbContext<IContextoPersistencia, LocadorAutomoveisDbContext>(optionsBuilder =>
            {
                optionsBuilder.UseSqlServer(connectionString);
            });

            servicos.AddTransient<ControladorDisciplina>();
            servicos.AddTransient<ServicoDisciplina>();
            servicos.AddTransient<IValidadorDisciplina, ValidadorDisciplina>();
            servicos.AddTransient<IRepositorioDisciplina, RepositorioDisciplinaEmOrm>();

            servicos.AddTransient<ControladorAutomovel>();
            servicos.AddTransient<ServicoAutomovel>();
            servicos.AddTransient<IValidadorAutomovel, ValidadorAutomovel>();
            servicos.AddTransient<IRepositorioAutomovel, RepositorioAutomovelEmOrm>();

            servicos.AddTransient<IRepositorioClientes, RepositorioClientesEmOrm>();
            servicos.AddTransient<IValidadorClientes,ValidadorClientes>();
            servicos.AddTransient<ServicoClientes>();
            servicos.AddTransient<ControladorClientes>();

            servicos.AddTransient<IRepositorioCupom, RepositorioCupomEmOrm>();
            servicos.AddTransient<IValidadorCupom,ValidadorCupom>();         
            servicos.AddTransient<ServicoCupom>();
            servicos.AddTransient<ControladorCupom>();

            servicos.AddTransient<IRepositorioFuncionario, RepositorioFuncionarioEmOrm>();
            servicos.AddTransient<IValidadorFuncionario,ValidadorFuncionario>();
            servicos.AddTransient<ServicoFuncionario>();
            servicos.AddTransient<ControladorFuncionario>();

            servicos.AddTransient<IRepositorioGrupoAutomoveis, RepositorioGrupoAutomoveisEmOrm>();
            servicos.AddTransient<IValidadorGrupoAutomoveis,ValidadorGrupoAutomoveis>();
            servicos.AddTransient<ServicoGrupoAutomoveis>();
            servicos.AddTransient<ControladorGrupoAutomoveis>();

            servicos.AddTransient<IRepositorioParceiro, RepositorioParceiroOrm>();           
            servicos.AddTransient<IValidadorParceiro,ValidadorParceiro>();
            servicos.AddTransient<ServicoParceiro>();
            servicos.AddTransient<ControladorParceiro>();

            servicos.AddTransient<IRepositorioPlanoCobranca, RepositorioPlanoCobrancaEmOrm>();
            servicos.AddTransient<IValidadorPlanoCobranca,ValidadorPlanoCobranca>();
            servicos.AddTransient<ServicoPlanoCobranca>();
            servicos.AddTransient<ControladorPlanoCobranca>();

            servicos.AddTransient<IRepositorioTaxasServico, RepositorioTaxasEServicosOrm>();
            servicos.AddTransient<IValidadorTaxasServico,ValidadorTaxasServico>();
            servicos.AddTransient<ServicoTaxasEServicos>();
            servicos.AddTransient<ControladorTaxaServico>();

            container = servicos.BuildServiceProvider();
        }

        public T Get<T>()
        {
            return container.GetService<T>();
        }
    }
}

using LocadorAutomoveis.Aplicacao.ModuloFuncionario;
using LocadorAutomoveis.Aplicacao.ModuloGrupoAutomoveis;
using LocadorAutomoveis.Aplicacao.ModuloParceiro;
using LocadorAutomoveis.Aplicacao.ModuloTaxasEServicos;
using LocadorAutomoveis.Aplicacao.ModuloPlanoCobranca;
using LocadorAutomoveis.Dominio.ModuloFuncionario;
using LocadorAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadorAutomoveis.Dominio.ModuloParceiro;
using LocadorAutomoveis.Dominio.ModuloTaxasEServicos;
using LocadorAutomoveis.Dominio.ModuloPlanoCobranca;
using LocadorAutomoveis.Infra.Orm.Compartilhado;
using LocadorAutomoveis.Infra.Orm.ModiuloFuncionario;
using LocadorAutomoveis.Infra.Orm.ModuloGrupoAutomoveis;
using LocadorAutomoveis.Infra.Orm.ModuloParceiro;
using LocadorAutomoveis.Infra.Orm.ModuloTaxasEServicos;
using LocadorAutomoveis.Infra.Orm.ModuloPlanoCobranca;
using LocadorAutomoveis.WinApp.ModuloFuncionario;
using LocadorAutomoveis.WinApp.ModuloGrupoAutomoveis;
using LocadorAutomoveis.WinApp.ModuloParceiro;
using LocadorAutomoveis.WinApp.ModuloTaxasEServicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using LocadorAutomoveis.Dominio.ModuloCupom;
using LocadorAutomoveis.Infra.Orm.ModuloCupom;
using LocadorAutomoveis.Aplicacao.ModuloCupom;
using LocadorAutomoveis.WinApp.ModuloCupom;
using LocadorAutomoveis.Dominio.ModuloClientes;
using LocadorAutomoveis.Infra.Orm.ModuloClientes;
using LocadorAutomoveis.Aplicacao.ModuloClientes;
using LocadorAutomoveis.WinApp.ModuloClientes;
using LocadorAutomoveis.Dominio.ModuloAutomovel;
using LocadorAutomoveis.Aplicacao.ModuloAutomovel;
using LocadorAutomoveis.Infra.Orm.ModuloAutomovel;
using LocadorAutomoveis.WinApp.ModuloAutomovel;

namespace LocadorAutomoveis.WinApp
{
    public partial class TelaPrincipalForm : Form
    {
        private Dictionary<string, ControladorBase> controladores;

        private ControladorBase controlador;

        public TelaPrincipalForm()
        {
            InitializeComponent();

            Instancia = this;

            labelRodape.Text = string.Empty;
            labelTipoCadastro.Text = string.Empty;

            controladores = new Dictionary<string, ControladorBase>();

            ConfigurarControladores();
        }

        private void ConfigurarControladores()
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

            IRepositorioGrupoAutomoveis repositorioGrupoAutomoveis = new RepositorioGrupoAutomoveisEmOrm(dbContext);

            ValidadorGrupoAutomoveis validadorGrupoAutomoveis = new ValidadorGrupoAutomoveis();

            ServicoGrupoAutomoveis servicoGrupoAutomoveis = new ServicoGrupoAutomoveis(repositorioGrupoAutomoveis, validadorGrupoAutomoveis,dbContext);

            controladores.Add("ControladorGrupoAutomoveis", new ControladorGrupoAutomoveis(repositorioGrupoAutomoveis, servicoGrupoAutomoveis));

            IRepositorioParceiro repositorioParceiro = new RepositorioParceiroOrm(dbContext);

            ValidadorParceiro validadorParceiro = new ValidadorParceiro();

            ServicoParceiro servicoParceiro = new ServicoParceiro(repositorioParceiro, validadorParceiro, dbContext);

            controladores.Add("ControladorParceiro", new ControladorParceiro(servicoParceiro, repositorioParceiro));

            // ControladorGrupoFuncionario

            IRepositorioFuncionario repositorioFuncionario = new RepositorioFuncionarioEmOrm(dbContext);

            ValidadorFuncionario validadorFuncionario = new ValidadorFuncionario();

            ServicoFuncionario servicoFuncionario = new ServicoFuncionario(repositorioFuncionario, validadorFuncionario, dbContext);

            controladores.Add("ControladorGrupoFuncionario", new ControladorFuncionario(repositorioFuncionario, servicoFuncionario));

            // Controlador Taxas e Serviços

            IRepositorioTaxasServico repositorioTaxasServico = new RepositorioTaxasEServicosOrm(dbContext);

            ValidadorTaxasServico validadorTaxaServico = new ValidadorTaxasServico();

            ServicoTaxasEServicos servicoTaxasEServicos = new ServicoTaxasEServicos(repositorioTaxasServico, validadorTaxaServico, dbContext);

            controladores.Add("ControladorTaxaServico", new ControladorTaxaServico(repositorioTaxasServico, servicoTaxasEServicos));

            // ControladorPlanoCobranca

            IRepositorioPlanoCobranca repositorioPlanoCobranca = new RepositorioPlanoCobrancaEmOrm(dbContext);

            ValidadorPlanoCobranca validadorPlanoCobranca = new ValidadorPlanoCobranca();

            ServicoPlanoCobranca servicoPlanoCobranca = new ServicoPlanoCobranca(repositorioPlanoCobranca, validadorPlanoCobranca   , dbContext);

            controladores.Add("ControladorPlanoCobranca", new ControladorPlanoCobranca(repositorioPlanoCobranca, repositorioGrupoAutomoveis, servicoPlanoCobranca));

            //ControladorCupom

            IRepositorioCupom repositorioCupom = new RepositorioCupomEmOrm(dbContext);

            ValidadorCupom validadorCupom = new ValidadorCupom();

            ServicoCupom servicoCupom = new ServicoCupom(repositorioCupom, validadorCupom, dbContext);

            controladores.Add("ControladorCupom", new ControladorCupom(servicoCupom, repositorioCupom, repositorioParceiro));

            IRepositorioClientes repositorioClientes = new RepositorioClientesEmOrm(dbContext);

            ValidadorClientes validadorClientes = new ValidadorClientes();

            ServicoClientes servicoClientes = new ServicoClientes(repositorioClientes, validadorClientes, dbContext);
            controladores.Add("ControladorGrupoClientes", new ControladorClientes(repositorioClientes, servicoClientes));

            //ControladorAutomovel

            IRepositorioAutomovel repositorioAutomovel = new RepositorioAutomovelEmOrm(dbContext);

            ValidadorAutomovel validadorAutomovel = new ValidadorAutomovel();

            ServicoAutomovel servicoAutomovel = new ServicoAutomovel(repositorioAutomovel, validadorAutomovel, dbContext);

            controladores.Add("ControladorAutomovel", new ControladorAutomovel(repositorioAutomovel, repositorioGrupoAutomoveis, servicoAutomovel));

        }

        public static TelaPrincipalForm Instancia
        {
            get;
            private set;
        }

        public void AtualizarRodape()
        {
            string mensagemRodape = controlador.ObterMensagemRodape();

            AtualizarRodape(mensagemRodape);
        }

        public void AtualizarRodape(string mensagem)
        {
            labelRodape.Text = mensagem;
        }

        private void gruposDeAutomóveisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(controladores["ControladorGrupoAutomoveis"]);
        }

        private void parceirosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(controladores["ControladorParceiro"]);
        }

        private void taxasEServiçosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(controladores["ControladorTaxaServico"]);
        }
        private void btnInserir_Click(object sender, EventArgs e)
        {
            controlador.Inserir();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            controlador.Editar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            controlador.Excluir();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            controlador.Excluir();
        }

        private void ConfigurarBotoes(ConfiguracaoToolboxBase configuracao)
        {
            btnInserir.Enabled = configuracao.InserirHabilitado;
            btnEditar.Enabled = configuracao.EditarHabilitado;
            btnExcluir.Enabled = configuracao.ExcluirHabilitado;
            btnFiltrar.Enabled = configuracao.FiltrarHabilitado;
        }

        private void ConfigurarTooltips(ConfiguracaoToolboxBase configuracao)
        {
            btnInserir.ToolTipText = configuracao.TooltipInserir;
            btnEditar.ToolTipText = configuracao.TooltipEditar;
            btnExcluir.ToolTipText = configuracao.TooltipExcluir;
            btnFiltrar.ToolTipText = configuracao.TooltipFiltrar;
        }

        private void ConfigurarTelaPrincipal(ControladorBase controlador)
        {
            this.controlador = controlador;

            ConfigurarToolbox();

            ConfigurarListagem();

            string mensagemRodape = controlador.ObterMensagemRodape();

            AtualizarRodape(mensagemRodape);
        }

        private void ConfigurarToolbox()
        {
            ConfiguracaoToolboxBase configuracao = controlador.ObtemConfiguracaoToolbox();

            if (configuracao != null)
            {
                toolbox.Enabled = true;

                labelTipoCadastro.Text = configuracao.TipoCadastro;

                ConfigurarTooltips(configuracao);

                ConfigurarBotoes(configuracao);
            }
        }

        private void ConfigurarListagem()
        {
            AtualizarRodape("");

            var listagemControl = controlador.ObtemListagem();

            panelRegistros.Controls.Clear();

            listagemControl.Dock = DockStyle.Fill;

            panelRegistros.Controls.Add(listagemControl);
        }

        private void funcionáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(controladores["ControladorGrupoFuncionario"]);
        }

        private void planosDeCobrançaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(controladores["ControladorPlanoCobranca"]);
        }

        private void cupomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(controladores["ControladorCupom"]);
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(controladores["ControladorGrupoClientes"]);
        }

        private void automóveisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(controladores["ControladorAutomovel"]);
        }
    }
}
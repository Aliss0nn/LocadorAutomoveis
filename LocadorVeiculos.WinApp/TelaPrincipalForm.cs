using LocadorAutomoveis.WinApp.Compartilhado.IoC;
using LocadorAutomoveis.WinApp.ModuloAutomovel;
using LocadorAutomoveis.WinApp.ModuloClientes;
using LocadorAutomoveis.WinApp.ModuloCupom;
using LocadorAutomoveis.WinApp.ModuloFuncionario;
using LocadorAutomoveis.WinApp.ModuloGrupoAutomoveis;
using LocadorAutomoveis.WinApp.ModuloParceiro;
using LocadorAutomoveis.WinApp.ModuloTaxasEServicos;

namespace LocadorAutomoveis.WinApp
{
    public partial class TelaPrincipalForm : Form
    {
        private Dictionary<string, ControladorBase> controladores;

        private ControladorBase controlador;

        private Ioc ioc;

        public TelaPrincipalForm()
        {
            InitializeComponent();

            Instancia = this;

            labelRodape.Text = string.Empty;
            labelTipoCadastro.Text = string.Empty;

            ioc = new IoC_ComInjecaoDependencia();          
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
            ConfigurarTelaPrincipal(ioc.Get<ControladorFuncionario>());
        }

        private void planosDeCobrançaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(ioc.Get<ControladorPlanoCobranca>());
        }

        private void cupomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(ioc.Get<ControladorCupom>());
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(ioc.Get<ControladorClientes>());
        }

        private void automóveisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(ioc.Get<ControladorAutomovel>());
        }
        private void gruposDeAutomóveisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(ioc.Get<ControladorGrupoAutomoveis>());
        }

        private void parceirosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(ioc.Get<ControladorParceiro>());
        }

        private void taxasEServiçosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(ioc.Get<ControladorTaxaServico>());
        }
    }
}
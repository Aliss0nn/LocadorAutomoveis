using LocadorAutomoveis.Dominio.ModuloGrupoAutomoveis;

using LocadorAutomoveis.WinApp.Compartilhado;


namespace LocadorAutomoveis.WinApp.ModuloGrupoAutomoveis
{
    public partial class TelaGrupoAutomoveisForm : Form
    {
        private GrupoAutomoveis grupo;

        public event GravarRegistroDelegate<GrupoAutomoveis> onGravarRegistro;

        public TelaGrupoAutomoveisForm()
        {
            InitializeComponent();
            this.ConfigurarDialog();
        }

        public GrupoAutomoveis ObterGrupoAutomoveis()
        {
            grupo.Id = Convert.ToInt32(txtId.Text);

            grupo.Nome = txtNome.Text;

            return grupo;
        }

        public void ConfigurarGrupoAutomoveis(GrupoAutomoveis grupo)
        {
            this.grupo = grupo;

            txtId.Text = grupo.Id.ToString();
            txtNome.Text = grupo.Nome;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            this.grupo = ObterGrupoAutomoveis();

            Result resultado = onGravarRegistro(grupo);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }
    }
}

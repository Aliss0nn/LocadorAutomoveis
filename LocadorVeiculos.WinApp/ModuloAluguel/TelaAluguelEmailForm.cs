namespace LocadorAutomoveis.WinApp.ModuloAluguel
{
    public partial class TelaAluguelEmailForm : Form
    {
        private string email;
        private string senha;
        public TelaAluguelEmailForm()
        {
            InitializeComponent();
            this.ConfigurarDialog();
        }

        public string ObterEmail()
        {
            return email;
        }

        public string ObterSenha()
        {
            return senha;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            email = txtEmail.Text;
            senha = txtSenha.Text;
        }
    }
}

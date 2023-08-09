using LocadorAutomoveis.Dominio.ModuloClientes;
using LocadorAutomoveis.Dominio.ModuloCondutor;
using LocadorAutomoveis.Dominio.ModuloCupom;
using LocadorAutomoveis.Dominio.ModuloParceiro;
using LocadorAutomoveis.WinApp.Compartilhado;

namespace LocadorAutomoveis.WinApp.ModuloCondutor
{
    public partial class TelaCondutorForm : Form
    {
        public Condutor condutor;
      
        public event GravarRegistroDelegate<Condutor> onGravarRegistro;

        public TelaCondutorForm(List<Clientes> clientes)
        {
            InitializeComponent();
            this.ConfigurarDialog();
            CarregarClientes(clientes);

        }
        public Condutor ObterCondutor()
        {
            condutor.ClienteEhCondutor = checkboxClienteCondutor.Checked;
            condutor.Nome = txtNome.Text;
            condutor.Email = txtEmail.Text;
            condutor.Cpf = Convert.ToInt32(maskCpf.Text);
            condutor.Cnh = Convert.ToInt32(maskCNH.Text);
            condutor.Telefone = maskTelefone.Text;
            condutor.Validade = dateTimeValidade.Value;
            condutor.Clientes = (Clientes)cmbClientes.SelectedItem;

            return condutor;
        }

        public void ConfigurarCondutor(Condutor condutor)
        {
            this.condutor = condutor;

            txtNome.Text = condutor.Nome;        
            txtEmail.Text = condutor.Email;
            maskCNH.Text = condutor.Cnh.ToString();
            maskCpf.Text = condutor.Cpf.ToString();
            maskTelefone.Text = condutor.Telefone;                
            cmbClientes.SelectedItem = condutor.Clientes;
            checkboxClienteCondutor.Checked = condutor.ClienteEhCondutor;

            if (condutor.Validade > new DateTime())
                dateTimeValidade.Value = condutor.Validade;
        }


        public void CarregarClientes(List<Clientes> clientes)
        {
            cmbClientes.Items.Clear();

            foreach (Clientes cliente in clientes)
            {
                cmbClientes.Items.Add(cliente);
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            this.condutor = ObterCondutor();

            Result resultado = onGravarRegistro(condutor);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }


    }
}

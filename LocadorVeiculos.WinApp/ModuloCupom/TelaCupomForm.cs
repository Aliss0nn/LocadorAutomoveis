using LocadorAutomoveis.Dominio.ModuloCupom;
using LocadorAutomoveis.Dominio.ModuloParceiro;
using LocadorAutomoveis.WinApp.Compartilhado;

namespace LocadorAutomoveis.WinApp.ModuloCupom
{
    public partial class TelaCupomForm : Form
    {
        public Cupom cupom;

        public event GravarRegistroDelegate<Cupom> onGravarRegistro;


        public TelaCupomForm(List<Parceiro> parceiros)
        {
            InitializeComponent();
            CarregarParceiros(parceiros);
            this.ConfigurarDialog();
        }

        public Cupom ObterCupom()
        {
            cupom.Nome = txtNome.Text;
            cupom.Valor = Convert.ToDecimal(txtValor.Text);
            cupom.DataValidade = DataValidadePicker.Value;
            cupom.Parceiro = (Parceiro)cmbParceiro.SelectedItem;

            return cupom;
        }

        public void ConfigurarCupom(Cupom cupom)
        {
            this.cupom = cupom;

            txtNome.Text = cupom.Nome;
            txtValor.Text = cupom.Valor.ToString();
            //DataValidadePicker.Text = cupom.DataValidade.ToString();
            cmbParceiro.SelectedItem = cupom.Parceiro;

            if (cupom.DataValidade > new DateTime())
                DataValidadePicker.Value = cupom.DataValidade;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            this.cupom = ObterCupom();

            Result resultado = onGravarRegistro(cupom);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        public void CarregarParceiros(List<Parceiro> parceiros)
        {
            cmbParceiro.Items.Clear();

            foreach (Parceiro parceiro in parceiros)
            {
                cmbParceiro.Items.Add(parceiro);
            }
        }
    }
}

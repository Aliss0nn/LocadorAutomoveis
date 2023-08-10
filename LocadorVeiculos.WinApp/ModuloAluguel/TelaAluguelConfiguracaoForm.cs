using LocadorAutomoveis.Dominio.ModuloAluguel;

namespace LocadorAutomoveis.WinApp.ModuloAluguel
{
    public partial class TelaAluguelConfiguracaoForm : Form
    {
        public TelaAluguelConfiguracaoForm()
        {
            InitializeComponent();
            this.ConfigurarDialog();
            CarregarPrecos();
        }

        private void CarregarPrecos()
        {
            Configuracao configuracao = Configuracao.Instancia;

            txtGasolina.Value = configuracao.GasolinaPreco;
            txtGas.Value = configuracao.GasPreco;
            txtDiesel.Value = configuracao.DieselPreco;
            txtAlcool.Value = configuracao.AlcoolPreco;
        }

        private void btnConfigurar_Click(object sender, EventArgs e)
        {
            Configuracao configuracao = Configuracao.Instancia;

            configuracao.GasolinaPreco = txtGasolina.Value;
            configuracao.GasPreco = txtGas.Value;
            configuracao.DieselPreco = txtDiesel.Value;
            configuracao.AlcoolPreco = txtAlcool.Value;
        }
    }
}

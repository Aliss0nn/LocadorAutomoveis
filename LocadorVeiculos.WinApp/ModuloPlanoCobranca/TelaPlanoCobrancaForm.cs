using LocadorAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadorAutomoveis.Dominio.ModuloPlanoCobranca;
using LocadorAutomoveis.WinApp.Compartilhado;

namespace LocadorAutomoveis.WinApp.ModuloPlanoCobranca
{
    public partial class TelaPlanoCobrancaForm : Form
    {
        private PlanoCobranca plano;
        private List<GrupoAutomoveis> grupos;

        public GravarRegistroDelegate<PlanoCobranca> onGravarRegistro;

        public TelaPlanoCobrancaForm(List<GrupoAutomoveis> grupos)
        {
            InitializeComponent();
            this.ConfigurarDialog();
            this.grupos = grupos;
            CarregarComboBox();
            AtualizarPrecos();
        }

        private void CarregarComboBox()
        {
            cmbTipo.Items.Add(TipoPlanoEnum.Diario);
            cmbTipo.Items.Add(TipoPlanoEnum.Controlado);
            cmbTipo.Items.Add(TipoPlanoEnum.Livre);

            cmbTipo.SelectedIndex = 0;

            foreach (GrupoAutomoveis grupo in grupos)
            {
                cmbGrupo.Items.Add(grupo);
            }
        }

        public PlanoCobranca ObterPlanoCobranca()
        {
            plano.Id = Convert.ToInt32(txtId.Text);
            plano.Grupo = (GrupoAutomoveis)cmbGrupo.SelectedItem;
            plano.TipoPlano = (TipoPlanoEnum)cmbTipo.SelectedItem;
            plano.PrecoDiario = txtPrecoDiario.Value;

            decimal PrecoKm;
            if (txtPrecoKm.Enabled)
                PrecoKm = txtPrecoKm.Value;

            decimal KmLivre;
            if (txtKmLivres.Enabled)
                KmLivre = txtKmLivres.Value;

            return plano;
        }

        public void ConfigurarPlanoCobranca(PlanoCobranca plano)
        {
            this.plano = plano;

            txtId.Text = plano.Id.ToString();
            cmbGrupo.SelectedItem = plano.Grupo;
            cmbTipo.SelectedItem = plano.TipoPlano;
            txtPrecoDiario.Value = plano.PrecoDiario;
            txtPrecoKm.Value = plano.PrecoKm;
            txtKmLivres.Value = plano.KmLivre;

            AtualizarPrecos();
        }

        private void AtualizarPrecos()
        {
            TipoPlanoEnum tipo = (TipoPlanoEnum)cmbTipo.SelectedItem;
            switch (tipo)
            {
                case TipoPlanoEnum.Diario:
                    txtPrecoKm.Enabled = true;
                    txtKmLivres.Enabled = false;
                    break;
                case TipoPlanoEnum.Controlado:
                    txtPrecoKm.Enabled = true;
                    txtKmLivres.Enabled = true;
                    break;
                case TipoPlanoEnum.Livre:
                    txtPrecoKm.Enabled = false;
                    txtKmLivres.Enabled = false;
                    break;
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            this.plano = ObterPlanoCobranca();

            Result resultado = onGravarRegistro(plano);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarPrecos();
        }
    }
}
using LocadorAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadorAutomoveis.Dominio.ModuloParceiro;
using LocadorAutomoveis.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadorAutomoveis.WinApp.ModuloParceiro
{
    public partial class TelaParceiroForm : Form
    {
        Parceiro parceiro;

        public event GravarRegistroDelegate<Parceiro> onGravarRegistro;

        public TelaParceiroForm()
        {
            InitializeComponent();
            this.ConfigurarDialog();
        }
        public Parceiro ObterParceiro()
        {
            parceiro.Id = Convert.ToInt32(txtId.Text);

            parceiro.Nome = txtNome.Text;

            return parceiro;
        }

        public void ConfigurarParceiro(Parceiro parceiro)
        {
            this.parceiro = parceiro;

            txtId.Text = parceiro.Id.ToString();
            txtNome.Text = parceiro.Nome;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            this.parceiro = ObterParceiro();

            Result resultado = onGravarRegistro(parceiro);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }
    }
}

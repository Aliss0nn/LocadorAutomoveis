using LocadorAutomoveis.Dominio.ModuloParceiro;
using LocadorAutomoveis.Dominio.ModuloTaxasEServicos;
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

namespace LocadorAutomoveis.WinApp.ModuloTaxasEServicos
{
    public partial class TelaTaxasServicoForm : Form
    {
        private TaxasEServico taxasEServico;

        public event GravarRegistroDelegate<TaxasEServico> onGravarRegistro;


        public TelaTaxasServicoForm()
        {
            InitializeComponent();
            this.ConfigurarDialog();
        }

        public TaxasEServico ObterTaxaServico()
        {
            taxasEServico.Nome = txtNome.Text;
            taxasEServico.Preco = Convert.ToDecimal(txtPreco.Text);
            taxasEServico.PlanoDeCalculo = grpBoxPlanos.Controls.OfType<RadioButton>().SingleOrDefault(x => x.Checked).Text;

            return taxasEServico;
        }

        public void ConfigurarTaxaServico(TaxasEServico taxasEServico)
        {
            this.taxasEServico = taxasEServico;

            txtNome.Text = taxasEServico.Nome;

            txtPreco.Text = taxasEServico.Preco.ToString();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            this.taxasEServico = ObterTaxaServico();

            Result resultado = onGravarRegistro(taxasEServico);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }
    }
}

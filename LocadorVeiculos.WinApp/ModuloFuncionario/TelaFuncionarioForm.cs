using iText.StyledXmlParser.Jsoup.Nodes;
using LocadorAutomoveis.Dominio.ModuloFuncionario;
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

namespace LocadorAutomoveis.WinApp.ModuloFuncionario
{
    public partial class TelaFuncionarioForm : Form
    {
        private Funcionario funcionario;

        public event GravarRegistroDelegate<Funcionario> onGravarRegistro;

        public TelaFuncionarioForm()
        {
            InitializeComponent();
            this.ConfigurarDialog();
        }

        public Funcionario ObterFuncionario()
        {
            funcionario.Nome = txt_Nome.Text;
            funcionario.Salario = Convert.ToInt32(txt_Salario.Text);
            funcionario.DataAdmissao = Convert.ToDateTime(txt_dataAdmissao.Text);
            return funcionario;
        }

        public void ConfigurarFuncionario(Funcionario funcionario)
        {
            this.funcionario = funcionario;

            txt_Nome.Text = funcionario.Nome;
            txt_Salario.Text = funcionario.Salario.ToString();
            txt_dataAdmissao.Text = funcionario.DataAdmissao.ToString();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            this.funcionario = ObterFuncionario();

            Result resultado = onGravarRegistro(funcionario);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

    }
}

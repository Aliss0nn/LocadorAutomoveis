using FluentResults;
using LocadorAutomoveis.WinApp.Compartilhado;
using LocadorAutomoveis.Dominio.ModuloDisciplina;
using System;
using System.Windows.Forms;

namespace LocadorAutomoveis.WinApp.ModuloDisciplina
{
    public partial class TelaDisciplinaForm : Form
    {
        private Disciplina disciplina;

        public event GravarRegistroDelegate<Disciplina> onGravarRegistro;

        public TelaDisciplinaForm()
        {
            InitializeComponent();
            this.ConfigurarDialog();
        }

        public Disciplina ObterDisciplina()
        {
            disciplina.Id = Convert.ToInt32(txtId.Text);
            disciplina.Nome = txtNome.Text;

            return disciplina;
        }

        public void ConfigurarDisciplina(Disciplina disciplina)
        {
            this.disciplina = disciplina;

            txtId.Text = disciplina.Id.ToString();
            txtNome.Text = disciplina.Nome;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            this.disciplina = ObterDisciplina();

            Result resultado = onGravarRegistro(disciplina);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }
    }
}

using LocadorAutomoveis.Dominio.ModuloAutomovel;
using LocadorAutomoveis.Dominio.ModuloDisciplina;
using LocadorAutomoveis.Dominio.ModuloGrupoAutomoveis;
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

namespace LocadorAutomoveis.WinApp.ModuloAutomovel
{
    public partial class TelaAutomovelForm : Form
    {
        private Automovel automovel;
        private List<GrupoAutomoveis> grupos;

        public GravarRegistroDelegate<Automovel> onGravarRegistro;
        public TelaAutomovelForm(List<GrupoAutomoveis> grupos)
        {
            InitializeComponent();
            this.ConfigurarDialog();
            this.grupos = grupos;
            ConfigurarComboBoxes();
        }

        private void ConfigurarComboBoxes()
        {
            cmbCombustivel.Items.Clear();
            cmbGrupo.Items.Clear();

            cmbCombustivel.Items.Add(TipoCombustivelEnum.Alcool);
            cmbCombustivel.Items.Add(TipoCombustivelEnum.Diesel);
            cmbCombustivel.Items.Add(TipoCombustivelEnum.Gas);
            cmbCombustivel.Items.Add(TipoCombustivelEnum.Gasolina);
            cmbCombustivel.SelectedIndex = 0;

            foreach (GrupoAutomoveis grupo in grupos)
            {
                cmbGrupo.Items.Add(grupo);
            }
        }

        public Automovel ObterAutomovel()
        {
            automovel.Marca = txtMarca.Text;
            automovel.Modelo = txtModelo.Text;
            automovel.Cor = txtCor.Text;
            automovel.Placa = txtPlaca.Text;
            automovel.Ano = (int)txtAno.Value;
            automovel.Quilometragem = (int)txtQuilometragem.Value;
            automovel.Capacidade = txtCapacidade.Value;
            automovel.Grupo = (GrupoAutomoveis)cmbGrupo.SelectedItem;
            automovel.TipoCombustivel = (TipoCombustivelEnum)cmbCombustivel.SelectedItem;

            automovel.Imagem = automovel.ConverterImagemParaArrayBytes(lbImagem.Image);

            return automovel;
        }

        public void ConfigurarAutomovel(Automovel automovel)
        {
            this.automovel = automovel;

            txtMarca.Text = automovel.Marca;
            txtModelo.Text = automovel.Modelo;
            txtCor.Text = automovel.Cor;
            txtPlaca.Text = automovel.Placa;

            if(automovel.Ano > 0)
            txtAno.Value = automovel.Ano;

            txtQuilometragem.Value = automovel.Quilometragem;

            if(automovel.Capacidade > 0)
            txtCapacidade.Value = automovel.Capacidade;

            cmbGrupo.SelectedItem = automovel.Grupo;
            cmbCombustivel.SelectedItem = automovel.TipoCombustivel;

            if(automovel.Imagem != null)
            lbImagem.Image = automovel.ConverterArrayBytesParaImagem();

            ConfigurarComboBoxes();
        }

        private void btnImagem_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
            {
                string caminho = folderBrowserDialog1.SelectedPath;
                try
                {
                    lbImagem.Image = Image.FromFile(caminho);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Arquivo inválido", "Cadastro de Imagem",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            this.automovel = ObterAutomovel();

            Result resultado = onGravarRegistro(automovel);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }
    }
}

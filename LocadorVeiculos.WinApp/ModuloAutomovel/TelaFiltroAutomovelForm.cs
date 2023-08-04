using FluentResults;
using LocadorAutomoveis.Dominio.ModuloGrupoAutomoveis;
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
    public partial class TelaFiltroAutomovelForm : Form
    {
        private GrupoAutomoveis grupo;
        private List<GrupoAutomoveis> grupos;
        public TelaFiltroAutomovelForm(List<GrupoAutomoveis> grupos)
        {
            InitializeComponent();
            this.ConfigurarDialog();
            this.grupos = grupos;
        }

        private void CarregarComboBoxes()
        {
            cmbGrupo.Items.Clear();

            foreach (GrupoAutomoveis grupo in grupos)
            {
                cmbGrupo.Items.Add(grupo);
            }
        }

        public GrupoAutomoveis ObterGrupo()
        {
            return (GrupoAutomoveis)cmbGrupo.SelectedItem;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (cmbGrupo.SelectedItem == null)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape("Selecione um Grupo");

                DialogResult = DialogResult.None;
            }
        }
    }
}

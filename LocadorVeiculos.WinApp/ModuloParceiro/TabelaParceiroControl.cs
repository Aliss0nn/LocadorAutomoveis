using LocadorAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadorAutomoveis.Dominio.ModuloParceiro;
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
    public partial class TabelaParceiroControl : UserControl
    {
        public TabelaParceiroControl()
        {
            InitializeComponent();

            gridParceiro.ConfigurarGridSomenteLeitura();
            gridParceiro.ConfigurarGridZebrado();
            gridParceiro.Columns.AddRange(ObterColunas());
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "Id", FillWeight=15F , Visible = false},

                new DataGridViewTextBoxColumn { Name = "Nome", HeaderText = "Nome", FillWeight=85F }
            };

            return colunas;
        }

        public Guid ObtemIdSelecionado()
        {
            return gridParceiro.SelecionarId();
        }

        public void AtualizarRegistros(List<Parceiro> parceiros)
        {
            gridParceiro.Rows.Clear();

            foreach (Parceiro parceiro in parceiros)
            {
                gridParceiro.Rows.Add(parceiro.Id, parceiro.Nome);
            }
        }
    }
}

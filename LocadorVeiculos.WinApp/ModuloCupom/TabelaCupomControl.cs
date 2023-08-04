using LocadorAutomoveis.Dominio.ModuloCupom;
using LocadorAutomoveis.Dominio.ModuloDisciplina;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadorAutomoveis.WinApp.ModuloCupom
{
    public partial class TabelaCupomControl : UserControl
    {
        public TabelaCupomControl()
        {
            InitializeComponent();
            gridCupom.ConfigurarGridSomenteLeitura();
            gridCupom.ConfigurarGridZebrado();
            gridCupom.Columns.AddRange(ObterColunas());
        }
        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                  new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "Id", FillWeight=15F, Visible = false  },

                  new DataGridViewTextBoxColumn { Name = "Nome", HeaderText = "Nome", FillWeight=85F },

                  new DataGridViewTextBoxColumn { Name = "Valor", HeaderText = "Valor", FillWeight=85F },

                  new DataGridViewTextBoxColumn { Name = "Data de Validade", HeaderText = "Data de Validade", FillWeight=85F },

                  new DataGridViewTextBoxColumn { Name = "Parceiro", HeaderText = "Parceiro", FillWeight=85F }

            };

            return colunas;
        }

        public Guid ObtemIdSelecionado()
        {
            return gridCupom.SelecionarId();
        }

        public void AtualizarRegistros(List<Cupom> cupons)
        {
            gridCupom.Rows.Clear();

            foreach (Cupom cupom in cupons)
            {
                gridCupom.Rows.Add(cupom.Id,cupom.Nome,cupom.Valor,cupom.DataValidade,cupom.Parceiro);
            }
        }
    }
}

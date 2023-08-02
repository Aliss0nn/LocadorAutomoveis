using LocadorAutomoveis.Dominio;
using LocadorAutomoveis.Dominio.ModuloTaxasEServicos;
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
    public partial class TabelaTaxaServicoControl : UserControl
    {
        public TabelaTaxaServicoControl()
        {
            InitializeComponent();
            gridTaxaServico.ConfigurarGridSomenteLeitura();
            gridTaxaServico.ConfigurarGridZebrado();
            gridTaxaServico.Columns.AddRange(ObterColunas());
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                 new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "Id", FillWeight=15F },
                           
                 new DataGridViewTextBoxColumn { Name = "Nome", HeaderText = "Nome", FillWeight=35F },

                 new DataGridViewTextBoxColumn { Name = "Preço", HeaderText = "Preço", FillWeight=25F },

                 new DataGridViewTextBoxColumn { Name = "Plano de Cobrança", HeaderText = "Plano de Cobrança", FillWeight=25F },
            };

            return colunas;
        }

        public Guid ObtemIdSelecionado()
        {
            return gridTaxaServico.SelecionarId();
        }

        public void AtualizarRegistros(List<TaxasEServico> taxasEServicos)
        {
            gridTaxaServico.Rows.Clear();

            foreach (var taxa in taxasEServicos)
            {
                gridTaxaServico.Rows.Add(taxa.Id, taxa.Nome, taxa.Preco, taxa.PlanoDeCalculo);
            }
        }
    }
}

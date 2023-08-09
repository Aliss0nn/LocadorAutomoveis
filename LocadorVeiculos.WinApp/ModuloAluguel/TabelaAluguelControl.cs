using LocadorAutomoveis.Dominio.ModuloAluguel;

namespace LocadorAutomoveis.WinApp.ModuloAluguel
{
    public partial class TabelaAluguelControl : UserControl
    {
        public TabelaAluguelControl()
        {
            InitializeComponent();
            grid.ConfigurarGridZebrado();
            grid.ConfigurarGridSomenteLeitura();
            grid.Columns.AddRange(ObterColunas());
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "Id", FillWeight=15F ,Visible = false},

                new DataGridViewTextBoxColumn { Name = "Veiculo", HeaderText = "Veículo", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "Plano", HeaderText = "Plano", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "DataLocacao", HeaderText = "Data Locação", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "DataPrevisao", HeaderText = "Data Prevista", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "DataDevolucao", HeaderText = "Data Devolução", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "Preco", HeaderText = "Preço R$", FillWeight=85F },
            };

            return colunas;
        }

        public Guid ObtemIdSelecionado()
        {
            return grid.SelecionarId();
        }

        public void AtualizarRegistros(List<Aluguel> alugueis)
        {
            grid.Rows.Clear();

            foreach (Aluguel aluguel in alugueis)
            {
                grid.Rows.Add(
                    aluguel.Id, 
                    aluguel.Automovel, 
                    aluguel.Plano, 
                    aluguel.DataLocacao.Date.ToString(),
                    aluguel.DataPrevisao.Date.ToString(),
                    aluguel.Fechado ? aluguel.DataDevolucao.Date.ToString() :
                    "Aluguel não concluído",
                    aluguel.Preco);
            }
        }
    }
}

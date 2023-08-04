using LocadorAutomoveis.Dominio.ModuloAutomovel;

namespace LocadorAutomoveis.WinApp.ModuloAutomovel
{
    public partial class TabelaAutomovelControl : UserControl
    {
        public TabelaAutomovelControl()
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
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "Id", FillWeight=15F, Visible = false },

                new DataGridViewTextBoxColumn { Name = "Placa", HeaderText = "Placa", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "Marca", HeaderText = "Marca", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "Cor", HeaderText = "Cor", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "Modelo", HeaderText = "Modelo", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "TipoCombustivel", HeaderText = "Combustível", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "Grupo", HeaderText = "Grupo", FillWeight=85F }

            };

            return colunas;
        }

        public Guid ObtemIdSelecionado()
        {
            return grid.SelecionarId();
        }

        public void AtualizarRegistros(List<Automovel> automoveis)
        {
            grid.Rows.Clear();

            foreach (Automovel automovel in automoveis)
            {
                grid.Rows.Add(
                    automovel.Id, 
                    automovel.Placa, 
                    automovel.Marca,
                    automovel.Cor,
                    automovel.Modelo,
                    automovel.TipoCombustivel,
                    automovel.Grupo);
            }
        }
    }
}

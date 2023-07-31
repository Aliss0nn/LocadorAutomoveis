using LocadorAutomoveis.Dominio.ModuloGrupoAutomoveis;

namespace LocadorAutomoveis.WinApp.ModuloGrupoAutomoveis
{
    public partial class TabelaGrupoAutomoveisControl : UserControl
    {
        public TabelaGrupoAutomoveisControl()
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
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "Id", FillWeight=15F },

                new DataGridViewTextBoxColumn { Name = "Nome", HeaderText = "Nome", FillWeight=85F }
            };

            return colunas;
        }

        public int ObtemIdSelecionado()
        {
            return grid.SelecionarId();
        }

        public void AtualizarRegistros(List<GrupoAutomoveis> grupos)
        {
            grid.Rows.Clear();

            foreach (GrupoAutomoveis grupo in grupos)
            {
                grid.Rows.Add(grupo.Id, grupo.Nome);
            }
        }
    }
}

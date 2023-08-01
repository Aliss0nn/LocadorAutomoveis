using LocadorAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadorAutomoveis.Dominio.ModuloPlanoCobranca;

namespace LocadorAutomoveis.WinApp.ModuloPlanoCobranca
{
    public partial class TabelaPlanoCobrancaControl : UserControl
    {
        public TabelaPlanoCobrancaControl()
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

                new DataGridViewTextBoxColumn { Name = "Grupo", HeaderText = "Grupo", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "TipoPlano", HeaderText = "Tipo", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "PrecoDiario", HeaderText = "Preço Diário R$", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "PrecoKm", HeaderText = "Preço Km R$", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "KmLivre", HeaderText = "Km Livres", FillWeight=85F },
            };

            return colunas;
        }

        public Guid ObtemIdSelecionado()
        {
            return grid.SelecionarId();
        }

        public void AtualizarRegistros(List<PlanoCobranca> planos)
        {
            grid.Rows.Clear();

            foreach (PlanoCobranca plano in planos)
            {
                grid.Rows.Add(
                    plano.Id, 
                    plano.Grupo,
                    plano.TipoPlano,
                    plano.PrecoDiario,
                    plano.TipoPlano == TipoPlanoEnum.Livre ? "Não Utilizado" : plano.PrecoKm,
                    plano.TipoPlano == TipoPlanoEnum.Controlado ? "Não Utilizado" : plano.KmLivre);
            }
        }
    }
}

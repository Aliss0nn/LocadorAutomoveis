using LocadorAutomoveis.Dominio.ModuloCondutor;
using LocadorAutomoveis.Dominio.ModuloCupom;

namespace LocadorAutomoveis.WinApp.ModuloCondutor
{
    public partial class TabelaCondutorControl : UserControl
    {
        public TabelaCondutorControl()
        {
            InitializeComponent();
            gridCondutores.ConfigurarGridSomenteLeitura();
            gridCondutores.ConfigurarGridZebrado();
            gridCondutores.Columns.AddRange(ObterColunas());
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                  new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "Id", FillWeight=15F, Visible = false  },

                  new DataGridViewTextBoxColumn { Name = "Nome do Condutor", HeaderText = "Nome do Condutor", FillWeight=85F },

                  new DataGridViewTextBoxColumn { Name = "Nome do Cliente", HeaderText = "Nome do Cliente", FillWeight=85F },

                  new DataGridViewTextBoxColumn { Name = "CPF", HeaderText = "CPF", FillWeight=85F },

                  new DataGridViewTextBoxColumn { Name = "CNH", HeaderText = "CNH", FillWeight=85F },

                  new DataGridViewTextBoxColumn { Name = "Validade", HeaderText = "Validade", FillWeight=85F }
            };

            return colunas;
        }

        public Guid ObtemIdSelecionado()
        {
            return gridCondutores.SelecionarId();
        }

        public void AtualizarRegistros(List<Condutor> condutores)
        {
            gridCondutores.Rows.Clear();

            foreach (Condutor condutor in condutores)
            {
                gridCondutores.Rows.Add(condutor.Nome,condutor.Clientes,condutor.Cpf,condutor.Cnh,condutor.Validade);
            }
        }
    }
}

using LocadorAutomoveis.Dominio.ModuloFuncionario;
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

namespace LocadorAutomoveis.WinApp.ModuloFuncionario
{
    public partial class TabelaFuncionarioControl : UserControl
    {
        public TabelaFuncionarioControl()
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

                new DataGridViewTextBoxColumn { Name = "Nome", HeaderText = "Nome", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "Salario", HeaderText = "Salario", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "DataAdmissao", HeaderText = "DataAdmissao", FillWeight=85F },
            };

            return colunas;
        }

        public Guid ObtemIdSelecionado()
        {
            return grid.SelecionarId();
        }

        public void AtualizarRegistros(List<Funcionario> funcionario)
        {
            grid.Rows.Clear();

            foreach (Funcionario Funcionario in funcionario)
            {
                grid.Rows.Add(Funcionario.Id, Funcionario.Nome, Funcionario.Salario, Funcionario.DataAdmissao);
            }
        }
    }
}
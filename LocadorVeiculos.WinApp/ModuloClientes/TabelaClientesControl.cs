using LocadorAutomoveis.Dominio.ModuloClientes;
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

namespace LocadorAutomoveis.WinApp.ModuloClientes
{
    public partial class TabelaClientesControl : UserControl
    {
        public TabelaClientesControl()
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

                new DataGridViewTextBoxColumn { Name = "Nome", HeaderText = "Nome", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "Telefone", HeaderText = "Telefone", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "Email", HeaderText = "Email", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "Cpf", HeaderText = "Cpf", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "Cnpj", HeaderText = "Cnpj", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "TipoPessoa", HeaderText = "TipoPessoa", FillWeight=85F },


            };

            return colunas;
        }

        public Guid ObtemIdSelecionado()
        {
            return grid.SelecionarId();
        }

        public void AtualizarRegistros(List<Clientes> clientees)
        {
            grid.Rows.Clear();

            foreach (Clientes clientes in clientees)
            {
                grid.Rows.Add(clientes.Id, clientes.NomeCliente, clientes.Telefone, clientes.Email
                    , clientes.TipoPessoa == "Fisica" ? clientes.Cpf : "Pessoa não é Fisica",
                    clientes.TipoPessoa == "Juridica" ? clientes.Cnpj : "Pessoa não é Juridica", clientes.TipoPessoa);
            }
        }
    }
}

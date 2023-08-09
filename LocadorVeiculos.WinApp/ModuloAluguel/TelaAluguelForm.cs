using LocadorAutomoveis.Dominio.ModuloAluguel;
using LocadorAutomoveis.Dominio.ModuloAutomovel;
using LocadorAutomoveis.Dominio.ModuloClientes;
using LocadorAutomoveis.Dominio.ModuloCondutor;
using LocadorAutomoveis.Dominio.ModuloCupom;
using LocadorAutomoveis.Dominio.ModuloFuncionario;
using LocadorAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadorAutomoveis.Dominio.ModuloPlanoCobranca;
using LocadorAutomoveis.Dominio.ModuloTaxasEServicos;
using LocadorAutomoveis.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadorAutomoveis.WinApp.ModuloAluguel
{
    public partial class TelaAluguelForm : Form
    {
        public GravarRegistroDelegate<Aluguel> onGravarRegistro;

        private List<Funcionario> funcionarios;
        private List<Clientes> clientes;
        private List<GrupoAutomoveis> grupoAutomoveis;
        private List<PlanoCobranca> planoCobrancas;
        private List<Automovel> automovels;
        private List<Cupom> cupoms;
        private List<TaxasEServico> taxasEServicos;
        private List<Condutor> condutors;

        public TelaAluguelForm(List<Funcionario> funcionarios, List<Clientes> clientes, List<GrupoAutomoveis> grupoAutomoveis, List<PlanoCobranca> planoCobrancas, List<Automovel> automovels, List<Cupom> cupoms, List<TaxasEServico> taxasEServicos, List<Condutor> condutors)
        {
            InitializeComponent();
            this.funcionarios = funcionarios;
            this.clientes = clientes;
            this.grupoAutomoveis = grupoAutomoveis;
            this.planoCobrancas = planoCobrancas;
            this.automovels = automovels;
            this.cupoms = cupoms;
            this.taxasEServicos = taxasEServicos;
            this.condutors = condutors;

            this.ConfigurarDialog();
        }

        public void ConfigurarAluguel(Aluguel aluguel)
        {
            throw new NotImplementedException();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {

        }
    }
}

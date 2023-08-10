using LocadorAutomoveis.Dominio.ModuloAluguel;
using LocadorAutomoveis.Dominio.ModuloAutomovel;
using LocadorAutomoveis.Dominio.ModuloClientes;
using LocadorAutomoveis.Dominio.ModuloCondutor;
using LocadorAutomoveis.Dominio.ModuloCupom;
using LocadorAutomoveis.Dominio.ModuloFuncionario;
using LocadorAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadorAutomoveis.Dominio.ModuloPlanoCobranca;
using LocadorAutomoveis.Dominio.ModuloTaxasEServicos;
using LocadorAutomoveis.Infra.Orm.Migrations;
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
    public partial class TelaAluguelDevolucaoForm : Form
    {
        private Aluguel aluguel;

        public GravarRegistroDelegate<Aluguel> onGravarRegistro;

        private List<Funcionario> funcionarios;
        private List<Clientes> clientes;
        private List<GrupoAutomoveis> grupoAutomoveis;
        private List<PlanoCobranca> planoCobrancas;
        private List<Automovel> automovels;
        private List<Cupom> cupoms;
        private List<TaxasEServico> taxasEServicos;
        private List<Condutor> condutors;

        public TelaAluguelDevolucaoForm(List<Funcionario> funcionarios, List<Clientes> clientes, List<GrupoAutomoveis> grupoAutomoveis, List<PlanoCobranca> planoCobrancas, List<Automovel> automovels, List<Cupom> cupoms, List<TaxasEServico> taxasEServicos, List<Condutor> condutors)
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
            carregarControls();
        }

        public void carregarControls()
        {
            foreach (var funcionario in funcionarios)
            {
                cmbFuncionario.Items.Add(funcionario);
            }

            foreach (var cliente in clientes)
            {
                cmbCliente.Items.Add(cliente);
            }

            foreach (var grupo in grupoAutomoveis)
            {
                cmbGrupo.Items.Add(grupo);
            }

            foreach (var plano in planoCobrancas)
            {
                cmbPlano.Items.Add(plano);
            }

            foreach (var automvoel in automovels)
            {
                cmbAutomovel.Items.Add(automovels);
            }

            foreach (var cupom in cupoms)
            {
                cmbCupom.Items.Add(cupom);
            }

            foreach (var condutor in condutors)
            {
                cmbCondutor.Items.Add(condutor);
            }

            cmbNivelTanque.Items.Add(NivelTanqueEnum.Vazio);
            cmbNivelTanque.Items.Add(NivelTanqueEnum.Quase_Vazio);
            cmbNivelTanque.Items.Add(NivelTanqueEnum.Meio_Cheio);
            cmbNivelTanque.Items.Add(NivelTanqueEnum.Quase_Cheio);
            cmbNivelTanque.Items.Add(NivelTanqueEnum.Cheio);

            cmbNivelTanque.SelectedIndex = 0;
        }

        private Aluguel ObterAluguel()
        {
            int kmPercorrido = (int)txtKmPercorrido.Value;
            DateTime dataDevolucao = txtDevolucao.Value.Date;
            NivelTanqueEnum nivelTanque = (NivelTanqueEnum)cmbNivelTanque.SelectedItem;

            aluguel.Taxas.AddRange(
                listExtras.CheckedItems.Cast<TaxasEServico>().ToList());

            aluguel.ConcluirAluguel(dataDevolucao, kmPercorrido, nivelTanque);

            aluguel.PrecoDevolucao();

            return aluguel;
        }


        public void ConfigurarAluguel(Aluguel aluguel)
        {
            this.aluguel = aluguel;

            cmbFuncionario.SelectedItem = aluguel.Funcionario;

            cmbCliente.SelectedItem = aluguel.Cliente;

            cmbCondutor.SelectedItem = aluguel.Condutor;

            cmbGrupo.SelectedItem = aluguel.Grupo;

            cmbPlano.SelectedItem = aluguel.Plano;

            cmbAutomovel.SelectedItem = aluguel.Automovel;

            cmbCupom.SelectedItem = aluguel.Cupom;

            foreach (var taxa in taxasEServicos)
            {
                if (aluguel.Taxas.Contains(taxa))
                    listTaxas.Items.Add(taxa);

                else
                    listExtras.Items.Add(taxa);
            }

            for (int i = 0; i < listTaxas.Items.Count; i++)
            {
                listTaxas.SetItemChecked(i, true);
            }

            txtLocacao.Value = aluguel.DataLocacao;

            txtPrevisao.Value = aluguel.DataPrevisao;

            txtKmAutomovel.Text = aluguel.Automovel.Quilometragem + "";
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            aluguel = ObterAluguel();

            Result resultado = onGravarRegistro(aluguel);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }
    }
}

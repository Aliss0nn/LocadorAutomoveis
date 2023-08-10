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

            foreach (var taxa in taxasEServicos)
            {
                listTaxas.Items.Add(taxa);
            }
        }

        private Aluguel ObterAluguel()
        {
            aluguel.Funcionario = (Funcionario)cmbFuncionario.SelectedItem;
            aluguel.Cliente = (Clientes)cmbCliente.SelectedItem;
            aluguel.Grupo = (GrupoAutomoveis)cmbGrupo.SelectedItem;
            aluguel.Plano = (PlanoCobranca)cmbPlano.SelectedItem;
            aluguel.Automovel = (Automovel)cmbAutomovel.SelectedItem;
            aluguel.Cupom = (Cupom)cmbCupom.SelectedItem;
            aluguel.Condutor = (Condutor)cmbCondutor.SelectedItem;

            aluguel.Taxas = listTaxas.CheckedItems.Cast<TaxasEServico>().ToList();

            aluguel.DataLocacao = txtLocacao.Value.Date;
            aluguel.DataPrevisao = txtPrevisao.Value.Date;

            aluguel.KmAutomovel = Convert.ToInt32(txtKmAutomovel.Text);

            aluguel.PrecoInicial();

            return aluguel;
        }


        public void ConfigurarAluguel(Aluguel aluguel)
        {
            this.aluguel = aluguel;
            cmbFuncionario.SelectedItem = aluguel.Funcionario;
            cmbCliente.SelectedItem = aluguel.Cliente;

            if (aluguel.Cliente != null)
            {
                AtualizarCondutores();
                cmbCondutor.SelectedItem = aluguel.Condutor;
            }

            cmbGrupo.SelectedItem = aluguel.Grupo;

            if (aluguel.Grupo != null)
            {
                AtualizarPlanos();
                AtualizarAutomoveis();
                cmbPlano.SelectedItem = aluguel.Plano;
                cmbAutomovel.SelectedItem = aluguel.Automovel;
            }

            cmbCupom.SelectedItem = aluguel.Cupom;

            if (aluguel.Taxas != null)
            {
                for (int i = 0; i < listTaxas.Items.Count; i++)
                {
                    TaxasEServico taxa = (TaxasEServico)listTaxas.Items[i];

                    if (aluguel.Taxas.Contains(taxa))
                        listTaxas.SetItemChecked(i, true);
                }
            }

            if (aluguel.DataLocacao != new DateTime())
                txtLocacao.Value = aluguel.DataLocacao;

            if (aluguel.DataPrevisao != new DateTime())
                txtPrevisao.Value = aluguel.DataPrevisao;

            if (aluguel.Automovel != null)
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

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarCondutores();
        }

        private void AtualizarCondutores()
        {
            cmbCondutor.Items.Clear();

            Clientes cliente = (Clientes)cmbCliente.SelectedItem;

            foreach (var condutor in condutors.FindAll(x => x.Clientes.Equals(cliente)))
            {
                cmbCondutor.Items.Add(condutor);
            }

            cmbCondutor.Enabled = true;
        }

        private void AtualizarPlanos()
        {
            cmbPlano.Items.Clear();

            GrupoAutomoveis grupo = (GrupoAutomoveis)cmbGrupo.SelectedItem;

            foreach (var plano in planoCobrancas.FindAll(x => x.Grupo.Equals(grupo)))
            {
                cmbPlano.Items.Add(plano);
            }

            cmbPlano.Enabled = true;
        }

        private void AtualizarAutomoveis()
        {
            cmbAutomovel.Items.Clear();

            GrupoAutomoveis grupo = (GrupoAutomoveis)cmbGrupo.SelectedItem;

            foreach (var automovel in automovels.FindAll(x => x.Grupo.Equals(grupo)))
            {
                cmbAutomovel.Items.Add(automovel);
            }

            cmbAutomovel.Enabled = true;
        }

        private void cmbGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarPlanos();
            AtualizarAutomoveis();
        }

        private void cmbAutomovel_SelectedIndexChanged(object sender, EventArgs e)
        {
            Automovel automovel = (Automovel)cmbAutomovel.SelectedItem;
            txtKmAutomovel.Text = automovel.Quilometragem + "";
        }
    }
}

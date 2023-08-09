using LocadorAutomoveis.Aplicacao.ModuloAluguel;
using LocadorAutomoveis.Dominio.ModuloAluguel;
using LocadorAutomoveis.Dominio.ModuloAutomovel;
using LocadorAutomoveis.Dominio.ModuloClientes;
using LocadorAutomoveis.Dominio.ModuloCupom;
using LocadorAutomoveis.Dominio.ModuloFuncionario;
using LocadorAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadorAutomoveis.Dominio.ModuloPlanoCobranca;
using LocadorAutomoveis.Dominio.ModuloTaxasEServicos;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadorAutomoveis.WinApp.ModuloAluguel
{
    public class ControladorAluguel : ControladorBase
    {
        private IRepositorioAluguel repositorioAluguel;
        private IRepositorioFuncionario repositorioFuncionario;
        private IRepositorioClientes repositorioCliente;
        private IRepositorioGrupoAutomoveis repositorioGrupoAutomoveis;
        private IRepositorioPlanoCobranca repositorioPlanoCobranca;
        private IRepositorioAutomovel repositorioAutomovel;
        private IRepositorioCupom repositorioCupom;
        private IRepositorioTaxasServico repositorioTaxasEServico;

        private TabelaAluguelControl tabelaAluguel;

        private ServicoAluguel servicoAluguel;

        public ControladorAluguel(
            IRepositorioAluguel repositorioAluguel,
            IRepositorioFuncionario repositorioFuncionario,
            IRepositorioClientes repositorioCliente,
            IRepositorioGrupoAutomoveis repositorioGrupoAutomoveis,
            IRepositorioPlanoCobranca repositorioPlanoCobranca,
            IRepositorioAutomovel repositorioAutomovel,
            IRepositorioCupom repositorioCupom,
            IRepositorioTaxasServico repositorioTaxasEServico,
            ServicoAluguel servicoAluguel)
        {
            this.repositorioAluguel = repositorioAluguel;
            this.repositorioFuncionario = repositorioFuncionario;
            this.repositorioCliente = repositorioCliente;
            this.repositorioGrupoAutomoveis = repositorioGrupoAutomoveis;
            this.repositorioPlanoCobranca = repositorioPlanoCobranca;
            this.repositorioAutomovel = repositorioAutomovel;
            this.repositorioCupom = repositorioCupom;
            this.repositorioTaxasEServico = repositorioTaxasEServico;
            this.servicoAluguel = servicoAluguel;
        }

        public override void Inserir()
        {
            TelaAluguelForm tela = new TelaAluguelForm(
                repositorioAluguel.SelecionarTodos(true),
                repositorioFuncionario.SelecionarTodos(),
                repositorioCliente.SelecionarTodos(),
                repositorioGrupoAutomoveis.SelecionarTodos(),
                repositorioPlanoCobranca.SelecionarTodos(true),
                repositorioAutomovel.SelecionarTodos(true),
                repositorioCupom.SelecionarTodos(true),
                repositorioTaxasEServico.SelecionarTodos());

            tela.onGravarRegistro += servicoAluguel.Inserir;

            tela.ConfigurarDisciplina(new Aluguel());

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarAlugueis();
            }            
        }

        public override void Editar()
        {
            Guid id = tabelaAluguel.ObtemIdSelecionado();

            Aluguel aluguelSelecionado = repositorioAluguel.SelecionarPorId(id);

            if (aluguelSelecionado == null)
            {
                MessageBox.Show("Selecione um aluguel primeiro",
                "Edição de Aluguéis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaAluguelForm tela = new TelaAluguelForm(
                repositorioAluguel.SelecionarTodos(true),
                repositorioFuncionario.SelecionarTodos(),
                repositorioCliente.SelecionarTodos(),
                repositorioGrupoAutomoveis.SelecionarTodos(),
                repositorioPlanoCobranca.SelecionarTodos(true),
                repositorioAutomovel.SelecionarTodos(true),
                repositorioCupom.SelecionarTodos(true),
                repositorioTaxasEServico.SelecionarTodos());

            tela.onGravarRegistro += servicoAluguel.Editar;

            tela.ConfigurarDisciplina(aluguelSelecionado);

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarAlugueis();                
            }
        }

        public override void Excluir()
        {
            Guid id = tabelaAluguel.ObtemIdSelecionado();

            Aluguel aluguelSelecionado = repositorioAluguel.SelecionarPorId(id);

            if (aluguelSelecionado == null)
            {
                MessageBox.Show("Selecione um aluguel primeiro",
                "Exclusão de Aluguéis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show("Deseja realmente excluir o aluguel?",
               "Exclusão de Aluguéis", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                Result resultado = servicoAluguel.Excluir(aluguelSelecionado);

                if (resultado.IsFailed)
                {
                    MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Aluguéis", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                CarregarAlugueis();
            }            
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxAluguel();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaAluguel == null)
                tabelaAluguel = new TabelaAluguelControl();

            CarregarAlugueis();

            return tabelaAluguel;
        }

        private void CarregarAlugueis()
        {
            List<Aluguel> alugueis = repositorioAluguel.SelecionarTodos(true);

            tabelaAluguel.AtualizarRegistros(alugueis);

            mensagemRodape = string.Format("Visualizando {0} alugu{1}", 
                alugueis.Count, alugueis.Count == 1 ? "el" : "éis");

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape);
        }
    }
}

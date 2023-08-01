using LocadorAutomoveis.Aplicacao.ModuloFuncionario;
using LocadorAutomoveis.Dominio.ModuloFuncionario;
using LocadorAutomoveis.WinApp.ModuloFuncionario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadorAutomoveis.WinApp.ModuloFuncionario
{
    public class ControladorFuncionario : ControladorBase
    {
        private IRepositorioFuncionario repositorioFuncionario;

        private TabelaFuncionarioControl tabelaFuncionario;

        private ServicoFuncionario servicoFuncionario;

        public ControladorFuncionario(
            IRepositorioFuncionario repositorioFuncionario,
            ServicoFuncionario servicoFuncionario)
        {
            this.repositorioFuncionario = repositorioFuncionario;
            this.servicoFuncionario = servicoFuncionario;
        }

        public override void Inserir()
        {
            TelaFuncionarioForm tela = new TelaFuncionarioForm();

            tela.onGravarRegistro += servicoFuncionario.Inserir;

            tela.ConfigurarFuncionario(new Funcionario());

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarFuncionarios();
            }
        }

        public override void Editar()
        {
            Guid id = tabelaFuncionario.ObtemIdSelecionado();

           Funcionario grupoSelecionado = repositorioFuncionario.SelecionarPorId(id);

            if (grupoSelecionado == null)
            {
                MessageBox.Show("Selecione um Funcionario primeiro",
                "Edição de Grupo de Automóveis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaFuncionarioForm tela = new TelaFuncionarioForm();

            tela.onGravarRegistro += servicoFuncionario.Editar;

            tela.ConfigurarFuncionario(grupoSelecionado);

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarFuncionarios();
            }
        }

        public override void Excluir()
        {
            Guid id = tabelaFuncionario.ObtemIdSelecionado();

           Funcionario grupoSelecionado = repositorioFuncionario.SelecionarPorId(id);

            if (grupoSelecionado == null)
            {
                MessageBox.Show("Selecione um Funcionario primeiro",
                "Exclusão de Grupo de Automóveis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show("Deseja realmente excluir o Funcionario?",
               "Exclusão de Funcionario", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                Result resultado = servicoFuncionario.Excluir(grupoSelecionado);

                if (resultado.IsFailed)
                {
                    MessageBox.Show(resultado.Errors[0].Message, "Exclusão Funcionário",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                CarregarFuncionarios();
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxFuncionario();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaFuncionario == null)
                tabelaFuncionario = new TabelaFuncionarioControl();

            CarregarFuncionarios();

            return tabelaFuncionario;
        }

        private void CarregarFuncionarios()
        {
            List<Funcionario> grupos = repositorioFuncionario.SelecionarTodos();

            tabelaFuncionario.AtualizarRegistros(grupos);

            mensagemRodape = string.Format("Visualizando {0} Funcionarios{1}", grupos.Count, grupos.Count == 1 ? "" : "s");

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape);
        }
    }
}

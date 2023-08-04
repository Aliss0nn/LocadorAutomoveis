using LocadorAutomoveis.Aplicacao.ModuloClientes;
using LocadorAutomoveis.Dominio.ModuloClientes;
using LocadorAutomoveis.WinApp.ModuloClientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadorAutomoveis.WinApp.ModuloClientes
{
    public class ControladorClientes : ControladorBase
    {
        private IRepositorioClientes repositorioClientes;

        private TabelaClientesControl tabelaClientes;

        private ServicoClientes servicoClientes;

        public ControladorClientes(
            IRepositorioClientes repositorioClientes,
            ServicoClientes servicoClientes)
        {
            this.repositorioClientes = repositorioClientes;
            this.servicoClientes = servicoClientes;
        }

        public override void Inserir()
        {
            TelaClientesForm tela = new TelaClientesForm();

            tela.onGravarRegistro += servicoClientes.Inserir;

            tela.ConfigurarClientes(new Clientes());

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarClientess();
            }
        }

        public override void Editar()
        {
            Guid id = tabelaClientes.ObtemIdSelecionado();

            Clientes clientesSelecionada = repositorioClientes.SelecionarPorId(id);

            if (clientesSelecionada == null)
            {
                MessageBox.Show("Selecione uma clientes primeiro",
                "Edição de Compromissos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaClientesForm tela = new TelaClientesForm();

            tela.onGravarRegistro += servicoClientes.Editar;

            tela.ConfigurarClientes(clientesSelecionada);

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarClientess();
            }
        }

        public override void Excluir()
        {
            Guid id = tabelaClientes.ObtemIdSelecionado();

            Clientes clientesSelecionada = repositorioClientes.SelecionarPorId(id);

            if (clientesSelecionada == null)
            {
                MessageBox.Show("Selecione uma clientes primeiro",
                "Exclusão de Clientess", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show("Deseja realmente excluir a clientes?",
               "Exclusão de Clientess", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                Result resultado = servicoClientes.Excluir(clientesSelecionada);

                if (resultado.IsFailed)
                {
                    MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Clientess",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                CarregarClientess();
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxClientes();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaClientes == null)
                tabelaClientes = new TabelaClientesControl();

            CarregarClientess();

            return tabelaClientes;
        }

        private void CarregarClientess()
        {
            List<Clientes> clientess = repositorioClientes.SelecionarTodos();

            tabelaClientes.AtualizarRegistros(clientess);

            mensagemRodape = string.Format("Visualizando {0} clientes{1}", clientess.Count, clientess.Count == 1 ? "" : "s");

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape);
        }
    }
}


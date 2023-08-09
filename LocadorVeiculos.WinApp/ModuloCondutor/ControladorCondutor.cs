using LocadorAutomoveis.Aplicacao.ModuloCondutor;
using LocadorAutomoveis.Dominio.ModuloClientes;
using LocadorAutomoveis.Dominio.ModuloCondutor;

namespace LocadorAutomoveis.WinApp.ModuloCondutor
{
    public class ControladorCondutor : ControladorBase
    {
        TabelaCondutorControl tabelaCondutor;
        IRepositorioClientes repositorioClientes;
        IRepositorioCondutor repositorioCondutor;
        ServicoCondutor servicoCondutor;

        public ControladorCondutor(IRepositorioClientes repositorioClientes,
            IRepositorioCondutor repositorioCondutor, 
            ServicoCondutor servicoCondutor)
        {
            this.repositorioClientes = repositorioClientes;
            this.repositorioCondutor = repositorioCondutor;
            this.servicoCondutor = servicoCondutor;
        }

        public override void Inserir()
        {
            List<Clientes> clientes = repositorioClientes.SelecionarTodos();

            TelaCondutorForm tela = new TelaCondutorForm(clientes);

            tela.onGravarRegistro += servicoCondutor.Inserir;

            tela.ConfigurarCondutor(new Condutor());

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarCondutores();
            }
        }

        public override void Editar()
        {
            Guid id = tabelaCondutor.ObtemIdSelecionado();

            Condutor condutorSelecionado = repositorioCondutor.SelecionarPorId(id);

            if (condutorSelecionado == null)
            {
                MessageBox.Show("Selecione um Condutor primeiro",
                "Edição de Condutores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            List<Clientes> clientes = repositorioClientes.SelecionarTodos();

            TelaCondutorForm tela = new TelaCondutorForm(clientes);

            tela.onGravarRegistro += servicoCondutor.Editar;

            tela.ConfigurarCondutor(condutorSelecionado);

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarCondutores();
            }
        }

        public override void Excluir()
        {
            Guid id = tabelaCondutor.ObtemIdSelecionado();

            Condutor condutorSelecionado = repositorioCondutor.SelecionarPorId(id);

            if (condutorSelecionado == null)
            {
                MessageBox.Show("Selecione um Condutor primeiro",
                "Exclusão de Condutores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show("Deseja realmente excluir o Condutor?",
               "Exclusão de Condutores", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                Result resultado = servicoCondutor.Excluir(condutorSelecionado);

                if (resultado.IsFailed)
                {
                    MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Condutores", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                CarregarCondutores();
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfigurarToolBoxCondutor();
        }

        public override UserControl ObtemListagem()
        {
            if(tabelaCondutor == null)
                tabelaCondutor = new TabelaCondutorControl();

            CarregarCondutores();

            return tabelaCondutor;
        }

        private void CarregarCondutores()
        {
            List<Condutor> condutores = repositorioCondutor.SelecionarTodos(incluirClientes : true);

            tabelaCondutor.AtualizarRegistros(condutores);

            mensagemRodape = string.Format("Visualizando {0} Condutores{1}", condutores.Count, condutores.Count == 1 ? "" : "s");

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape);
        }
    }
}

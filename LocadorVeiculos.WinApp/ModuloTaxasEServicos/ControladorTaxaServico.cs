using LocadorAutomoveis.Aplicacao.ModuloTaxasEServicos;
using LocadorAutomoveis.Dominio.ModuloTaxasEServicos;

namespace LocadorAutomoveis.WinApp.ModuloTaxasEServicos
{
    public class ControladorTaxaServico : ControladorBase
    {
        private IRepositorioTaxasServico repositorioTaxasServico;
        private TabelaTaxaServicoControl tabelaTaxaServico;
        private ServicoTaxasEServicos servicoTaxasEServicos;

        public ControladorTaxaServico(IRepositorioTaxasServico repositorioTaxasServico,
            ServicoTaxasEServicos servicoTaxasEServicos)
        {
            this.repositorioTaxasServico = repositorioTaxasServico;
            this.servicoTaxasEServicos = servicoTaxasEServicos;
        }

        public override void Inserir()
        {           
            TelaTaxasServicoForm telaTaxasServicoForm = new TelaTaxasServicoForm();

            telaTaxasServicoForm.onGravarRegistro += servicoTaxasEServicos.Inserir;

            telaTaxasServicoForm.ConfigurarTaxaServico(new TaxasEServico());

            DialogResult resultado = telaTaxasServicoForm.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarTaxaServico();
            }
        }      
        public override void Editar()
        {
            Guid id = tabelaTaxaServico.ObtemIdSelecionado();

            TaxasEServico taxasEServicoSelecionada = repositorioTaxasServico.SelecionarPorId(id);

            if (taxasEServicoSelecionada == null)
            {
                MessageBox.Show("Selecione uma Taxa ou Serviço primeiro",
               "Edição de Taxas e Serviços", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaTaxasServicoForm tela = new TelaTaxasServicoForm();

            tela.onGravarRegistro += servicoTaxasEServicos.Editar;

            tela.ConfigurarTaxaServico(taxasEServicoSelecionada);

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarTaxaServico();
            }
        }

        public override void Excluir()
        {
            Guid id = tabelaTaxaServico.ObtemIdSelecionado();

            TaxasEServico taxasEServicoSelecionada = repositorioTaxasServico.SelecionarPorId(id);

            if (taxasEServicoSelecionada == null)
            {
                MessageBox.Show("Selecione uma Taxa ou Serviço primeiro",
               "Exclusão de Taxas e Serviços", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show($"Deseja realmente excluir a {taxasEServicoSelecionada.Nome}?",
               "Exclusão de Taxas e Serviços", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                Result resultado = servicoTaxasEServicos.Excluir(taxasEServicoSelecionada);

                if (resultado.IsFailed)
                {
                    MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Taxas e Serviços",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                CarregarTaxaServico();
            }
        }
       
        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxTaxaServico();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaTaxaServico == null)
                tabelaTaxaServico = new TabelaTaxaServicoControl();

            CarregarTaxaServico();

            return tabelaTaxaServico;
        }
        private void CarregarTaxaServico()
        {
            List<TaxasEServico> taxasEServicos = repositorioTaxasServico.SelecionarTodos();

            tabelaTaxaServico.AtualizarRegistros(taxasEServicos);

            mensagemRodape = string.Format("Visualizando {0} Taxas ou Serviços{1}", taxasEServicos.Count, taxasEServicos.Count == 1 ? "" : "s");

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape);
        }
    }
}

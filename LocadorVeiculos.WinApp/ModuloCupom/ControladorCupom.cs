using LocadorAutomoveis.Aplicacao.ModuloCupom;
using LocadorAutomoveis.Dominio.ModuloCupom;
using LocadorAutomoveis.Dominio.ModuloParceiro;

namespace LocadorAutomoveis.WinApp.ModuloCupom
{
    public class ControladorCupom : ControladorBase
    {
        private ServicoCupom servicoCupom;
        private IRepositorioCupom repositorioCupom;
        private IRepositorioParceiro repositorioParceiro;
        private TabelaCupomControl tabelaCupom;

        public ControladorCupom(ServicoCupom servicoCupom,
            IRepositorioCupom repositorioCupom, 
            IRepositorioParceiro repositorioParceiro)
        {
            this.servicoCupom = servicoCupom;
            this.repositorioCupom = repositorioCupom;
            this.repositorioParceiro = repositorioParceiro;
        }

        public override void Inserir()
        {
            List<Parceiro> parceiros = repositorioParceiro.SelecionarTodos();

            TelaCupomForm tela = new TelaCupomForm(parceiros);

            tela.onGravarRegistro += servicoCupom.Inserir;

            tela.ConfigurarCupom(new Cupom());

             DialogResult resultado = tela.ShowDialog();

            if(resultado == DialogResult.OK)
            {
                CarregarCupons();
            }
        }

        public override void Editar()
        {
            Guid id = tabelaCupom.ObtemIdSelecionado();

            Cupom cupomSelecionada = repositorioCupom.SelecionarPorId(id);

            if (cupomSelecionada == null)
            {
                MessageBox.Show("Selecione um Cupom primeiro",
                "Edição de Cupons", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            List<Parceiro> parceiros = repositorioParceiro.SelecionarTodos();

            TelaCupomForm tela = new TelaCupomForm(parceiros);

            tela.onGravarRegistro += servicoCupom.Editar;

            tela.ConfigurarCupom(cupomSelecionada);

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarCupons();
            }
        }

        public override void Excluir()
        {
            Guid id = tabelaCupom.ObtemIdSelecionado();

            Cupom cupomSelecionada = repositorioCupom.SelecionarPorId(id);

            if (cupomSelecionada == null)
            {
                MessageBox.Show("Selecione um Cupom primeiro",
                "Exclusão de Cupons", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show("Deseja realmente excluir o Cupom?",
               "Exclusão de Cupons", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                Result resultado = servicoCupom.Excluir(cupomSelecionada);

                if (resultado.IsFailed)
                {
                    MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Cupons", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                CarregarCupons();
            }
        }
     
        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfigurarToolBoxCupom();
        }

        public override UserControl ObtemListagem()
        {
           if(tabelaCupom == null)
                tabelaCupom = new TabelaCupomControl();

            CarregarCupons();

            return tabelaCupom;
        }

        private void CarregarCupons()
        {
            List<Cupom> cupons = repositorioCupom.SelecionarTodos(incluirParceiros: true);

            tabelaCupom.AtualizarRegistros(cupons);

            mensagemRodape = string.Format("Visualizando {0} Cupons{1}", cupons.Count, cupons.Count == 1 ? "" : "s");

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape);
        }
    }
}

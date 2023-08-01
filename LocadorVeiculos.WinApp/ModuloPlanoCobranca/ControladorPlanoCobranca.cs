using LocadorAutomoveis.Aplicacao.ModuloPlanoCobranca;
using LocadorAutomoveis.Dominio.ModuloPlanoCobranca;
using LocadorAutomoveis.Dominio.ModuloGrupoAutomoveis;
using System.Collections.Generic;
using System.Windows.Forms;
using LocadorAutomoveis.WinApp.ModuloPlanoCobranca;

namespace LocadorAutomoveis.WinApp.ModuloGrupoAutomoveis
{
    public class ControladorPlanoCobranca : ControladorBase
    {
        private IRepositorioGrupoAutomoveis repositorioGrupoAutomoveis;

        private IRepositorioPlanoCobranca repositorioPlanoCobranca;

        private TabelaPlanoCobrancaControl tabelaPlanoCobranca;

        private ServicoPlanoCobranca servicoPlanoCobranca;

        public ControladorPlanoCobranca(
            IRepositorioPlanoCobranca repositorioPlanoCobranca,
            IRepositorioGrupoAutomoveis repositorioGrupoAutomoveis,
            ServicoPlanoCobranca servicoPlanoCobranca)
        {
            this.repositorioPlanoCobranca = repositorioPlanoCobranca;
            this.repositorioGrupoAutomoveis = repositorioGrupoAutomoveis;
            this.servicoPlanoCobranca = servicoPlanoCobranca;
        }

        public override void Inserir()
        {
            TelaPlanoCobrancaForm tela 
                = new TelaPlanoCobrancaForm(repositorioGrupoAutomoveis.SelecionarTodos());

            tela.onGravarRegistro += servicoPlanoCobranca.Inserir;

            tela.ConfigurarPlanoCobranca(new PlanoCobranca());

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarPlanosCobranca();
            }            
        }

        public override void Editar()
        {
            Guid id = tabelaPlanoCobranca.ObtemIdSelecionado();

            PlanoCobranca planoSelecionado = repositorioPlanoCobranca.SelecionarPorId(id);

            if (planoSelecionado == null)
            {
                MessageBox.Show("Selecione um plano de cobrança primeiro",
                "Edição de Plano de Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaPlanoCobrancaForm tela 
                = new TelaPlanoCobrancaForm(repositorioGrupoAutomoveis.SelecionarTodos());

            tela.onGravarRegistro += servicoPlanoCobranca.Editar;

            tela.ConfigurarPlanoCobranca(planoSelecionado);

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarPlanosCobranca();                
            }
        }

        public override void Excluir()
        {
            Guid id = tabelaPlanoCobranca.ObtemIdSelecionado();

            PlanoCobranca planoSelecionado = repositorioPlanoCobranca.SelecionarPorId(id);

            if (planoSelecionado == null)
            {
                MessageBox.Show("Selecione um plano de cobrança primeiro",
                "Exclusão de Plano de Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show("Deseja realmente excluir o plano de cobrança?",
               "Exclusão de Plano de Cobrança", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                Result resultado = servicoPlanoCobranca.Excluir(planoSelecionado);

                if (resultado.IsFailed)
                {
                    MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Plano de Cobrança", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                CarregarPlanosCobranca();
            }            
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxPlanoCobranca();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaPlanoCobranca == null)
                tabelaPlanoCobranca = new TabelaPlanoCobrancaControl();

            CarregarPlanosCobranca();

            return tabelaPlanoCobranca;
        }

        private void CarregarPlanosCobranca()
        {
            List<PlanoCobranca> grupos = repositorioPlanoCobranca.SelecionarTodos(true);

            tabelaPlanoCobranca.AtualizarRegistros(grupos);

            mensagemRodape = string.Format("Visualizando {0} plano{1} de cobrança", grupos.Count, grupos.Count == 1 ? "" : "s");

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape);
        }
    }
}

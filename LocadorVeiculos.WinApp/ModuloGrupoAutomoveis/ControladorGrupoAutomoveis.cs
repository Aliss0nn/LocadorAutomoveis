using LocadorAutomoveis.Aplicacao.ModuloGrupoAutomoveis;
using LocadorAutomoveis.Dominio.ModuloGrupoAutomoveis;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadorAutomoveis.WinApp.ModuloGrupoAutomoveis
{
    public class ControladorGrupoAutomoveis : ControladorBase
    {
        private IRepositorioGrupoAutomoveis repositorioGrupoAutomoveis;

        private TabelaGrupoAutomoveisControl tabelaGrupoAutomoveis;

        private ServicoGrupoAutomoveis servicoGrupoAutomoveis;

        public ControladorGrupoAutomoveis(
            IRepositorioGrupoAutomoveis repositorioGrupoAutomoveis,
            ServicoGrupoAutomoveis servicoGrupoAutomoveis)
        {
            this.repositorioGrupoAutomoveis = repositorioGrupoAutomoveis;
            this.servicoGrupoAutomoveis = servicoGrupoAutomoveis;
        }

        public override void Inserir()
        {
            TelaGrupoAutomoveisForm tela = new TelaGrupoAutomoveisForm();

            tela.onGravarRegistro += servicoGrupoAutomoveis.Inserir;

            tela.ConfigurarGrupoAutomoveis(new GrupoAutomoveis());

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarGruposAutomoveis();
            }            
        }

        public override void Editar()
        {
            int id = tabelaGrupoAutomoveis.ObtemIdSelecionado();

            GrupoAutomoveis grupoSelecionado = repositorioGrupoAutomoveis.SelecionarPorId(id);

            if (grupoSelecionado == null)
            {
                MessageBox.Show("Selecione um grupoAutomóveis primeiro",
                "Edição de Grupo de Automóveis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaGrupoAutomoveisForm tela = new TelaGrupoAutomoveisForm();

            tela.onGravarRegistro += servicoGrupoAutomoveis.Editar;

            tela.ConfigurarGrupoAutomoveis(grupoSelecionado);

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarGruposAutomoveis();                
            }
        }

        public override void Excluir()
        {
            int id = tabelaGrupoAutomoveis.ObtemIdSelecionado();

            GrupoAutomoveis grupoSelecionado = repositorioGrupoAutomoveis.SelecionarPorId(id);

            if (grupoSelecionado == null)
            {
                MessageBox.Show("Selecione um grupoAutomóveis primeiro",
                "Exclusão de Grupo de Automóveis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show("Deseja realmente excluir o grupoAutomóveis?",
               "Exclusão de Grupo de Automóveis", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                Result resultado = servicoGrupoAutomoveis.Excluir(grupoSelecionado);

                if (resultado.IsFailed)
                {
                    MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Grupo de Automóveis", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                CarregarGruposAutomoveis();
            }            
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxGrupoAutomoveis();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaGrupoAutomoveis == null)
                tabelaGrupoAutomoveis = new TabelaGrupoAutomoveisControl();

            CarregarGruposAutomoveis();

            return tabelaGrupoAutomoveis;
        }

        private void CarregarGruposAutomoveis()
        {
            List<GrupoAutomoveis> grupos = repositorioGrupoAutomoveis.SelecionarTodos();

            tabelaGrupoAutomoveis.AtualizarRegistros(grupos);

            mensagemRodape = string.Format("Visualizando {0} grupoAutomóveis{1}", grupos.Count, grupos.Count == 1 ? "" : "s");

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape);
        }
    }
}

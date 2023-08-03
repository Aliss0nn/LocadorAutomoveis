using LocadorAutomoveis.Aplicacao.ModuloAutomovel;
using LocadorAutomoveis.Dominio.ModuloAutomovel;
using LocadorAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadorAutomoveis.WinApp.ModuloAutomovel;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadorAutomoveis.WinApp.ModuloDisciplina
{
    public class ControladorAutomovel : ControladorBase
    {
        private IRepositorioAutomovel repositorioAutomovel;

        private IRepositorioGrupoAutomoveis repositorioGrupoAutomoveis;

        private TabelaAutomovelControl tabelaAutomovel;

        private ServicoAutomovel servicoAutomovel;

        public ControladorAutomovel(
            IRepositorioAutomovel repositorioAutomovel,
            IRepositorioGrupoAutomoveis repositorioGrupoAutomoveis,
            ServicoAutomovel servicoAutomovel)
        {
            this.repositorioAutomovel = repositorioAutomovel;
            this.repositorioGrupoAutomoveis = repositorioGrupoAutomoveis;
            this.servicoAutomovel = servicoAutomovel;
        }

        public override void Inserir()
        {
            TelaAutomovelForm tela = new TelaAutomovelForm(repositorioGrupoAutomoveis.SelecionarTodos());

            tela.onGravarRegistro += servicoAutomovel.Inserir;

            tela.ConfigurarAutomovel(new Automovel());

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarAutomoveis();
            }            
        }

        public override void Editar()
        {
            Guid id = tabelaAutomovel.ObtemIdSelecionado();

            Automovel automovelSelecionado = repositorioAutomovel.SelecionarPorId(id);

            if (automovelSelecionado == null)
            {
                MessageBox.Show("Selecione um automóvel primeiro",
                "Edição de Automóvies", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaAutomovelForm tela = new TelaAutomovelForm(repositorioGrupoAutomoveis.SelecionarTodos());

            tela.onGravarRegistro += servicoAutomovel.Editar;

            tela.ConfigurarAutomovel(automovelSelecionado);

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarAutomoveis();                
            }
        }

        public override void Excluir()
        {
            Guid id = tabelaAutomovel.ObtemIdSelecionado();

            Automovel automovelSelecionado = repositorioAutomovel.SelecionarPorId(id);

            if (automovelSelecionado == null)
            {
                MessageBox.Show("Selecione um automóvel primeiro",
                "Exclusão de Automóveis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show("Deseja realmente excluir o automóvel?",
               "Exclusão de Automóveis", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                Result resultado = servicoAutomovel.Excluir(automovelSelecionado);

                if (resultado.IsFailed)
                {
                    MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Automóveis", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                CarregarAutomoveis();
            }            
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxAutomovel();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaAutomovel == null)
                tabelaAutomovel = new TabelaAutomovelControl();

            CarregarAutomoveis();

            return tabelaAutomovel;
        }

        private void CarregarAutomoveis()
        {
            List<Automovel> automoveis = repositorioAutomovel.SelecionarTodos();

            tabelaAutomovel.AtualizarRegistros(automoveis);

            mensagemRodape = string.Format("Visualizando {0} automove{1}", automoveis.Count, automoveis.Count == 1 ? "l" : "is");

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape);
        }
    }
}

using LocadorAutomoveis.Aplicacao.ModuloAluguel;
using LocadorAutomoveis.Dominio.ModuloAluguel;
using LocadorAutomoveis.Dominio.ModuloAutomovel;
using LocadorAutomoveis.Dominio.ModuloClientes;
using LocadorAutomoveis.Dominio.ModuloCondutor;
using LocadorAutomoveis.Dominio.ModuloCupom;
using LocadorAutomoveis.Dominio.ModuloFuncionario;
using LocadorAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadorAutomoveis.Dominio.ModuloPlanoCobranca;
using LocadorAutomoveis.Dominio.ModuloTaxasEServicos;
using LocadorAutomoveis.Infra.Arquivos;
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
        private readonly IRepositorioCondutor repositorioCondutor;
        private TabelaAluguelControl tabelaAluguel;

        private ContextoDados contexto;

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
            IRepositorioCondutor repositorioCondutor,
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
            this.repositorioCondutor = repositorioCondutor;
            this.servicoAluguel = servicoAluguel;

            contexto = new ContextoDados();
        }

        public override void Inserir()
        {
            TelaAluguelForm tela = new TelaAluguelForm(
                repositorioFuncionario.SelecionarTodos(),
                repositorioCliente.SelecionarTodos(),
                repositorioGrupoAutomoveis.SelecionarTodos(),
                repositorioPlanoCobranca.SelecionarTodos(true),
                repositorioAutomovel.SelecionarTodos(true),
                repositorioCupom.SelecionarTodos(true),
                repositorioTaxasEServico.SelecionarTodos(),
                repositorioCondutor.SelecionarTodos(true));

            tela.onGravarRegistro += servicoAluguel.Inserir;

            tela.ConfigurarAluguel(new Aluguel());

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarAlugueis();
            }            
        }

        public override void Configurar()
        {
            contexto.CarregarDoArquivoJson();   

            TelaAluguelConfiguracaoForm tela = new TelaAluguelConfiguracaoForm();

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                contexto.GravarEmArquivoJson();
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

            if (aluguelSelecionado.Fechado)
            {
                MessageBox.Show("Selecione um aluguel em aberto",
                "Edição de Aluguéis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaAluguelForm tela = new TelaAluguelForm(
                repositorioFuncionario.SelecionarTodos(),
                repositorioCliente.SelecionarTodos(),
                repositorioGrupoAutomoveis.SelecionarTodos(),
                repositorioPlanoCobranca.SelecionarTodos(true),
                repositorioAutomovel.SelecionarTodos(true),
                repositorioCupom.SelecionarTodos(true),
                repositorioTaxasEServico.SelecionarTodos(),
                repositorioCondutor.SelecionarTodos(true));

            tela.onGravarRegistro += servicoAluguel.Editar;

            tela.ConfigurarAluguel(aluguelSelecionado);

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarAlugueis();                
            }
        }

        public override void Concluir()
        {
            Guid id = tabelaAluguel.ObtemIdSelecionado();

            Aluguel aluguelSelecionado = repositorioAluguel.SelecionarPorId(id);

            if (aluguelSelecionado == null)
            {
                MessageBox.Show("Selecione um aluguel primeiro",
                "Conclusão de Aluguéis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (aluguelSelecionado.Fechado)
            {
                MessageBox.Show("Selecione um aluguel em aberto",
                "Conclusão de Aluguéis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaAluguelDevolucaoForm tela = new TelaAluguelDevolucaoForm(
                repositorioFuncionario.SelecionarTodos(),
                repositorioCliente.SelecionarTodos(),
                repositorioGrupoAutomoveis.SelecionarTodos(),
                repositorioPlanoCobranca.SelecionarTodos(true),
                repositorioAutomovel.SelecionarTodos(true),
                repositorioCupom.SelecionarTodos(true),
                repositorioTaxasEServico.SelecionarTodos(),
                repositorioCondutor.SelecionarTodos(true));

            tela.onGravarRegistro += servicoAluguel.Editar;

            tela.ConfigurarAluguel(aluguelSelecionado);

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                TelaAluguelEmailForm telaEmail = new TelaAluguelEmailForm();

                DialogResult resultadoEmail = telaEmail.ShowDialog();

                if (resultadoEmail == DialogResult.OK)
                {
                    string email = telaEmail.ObterEmail();
                    string senha = telaEmail.ObterSenha();
                    try
                    {
                        PdfEmail.EnviarEmail(aluguelSelecionado, email, senha);
                        MessageBox.Show($"Email enviado para {aluguelSelecionado.Cliente.Email}",
                        "Conclusão de Aluguéis", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } 
                    catch(Exception ex)
                    {
                        MessageBox.Show("Falha ao enviar email",
                        "Conclusão de Aluguéis", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
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

            if (!aluguelSelecionado.Fechado)
            {
                MessageBox.Show("Selecione um aluguel fechado",
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

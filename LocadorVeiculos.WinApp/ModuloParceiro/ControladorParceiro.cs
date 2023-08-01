using LocadorAutomoveis.Aplicacao.ModuloParceiro;
using LocadorAutomoveis.Dominio.ModuloParceiro;
using LocadorAutomoveis.WinApp.ModuloGrupoAutomoveis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadorAutomoveis.WinApp.ModuloParceiro
{
    public class ControladorParceiro : ControladorBase
    {
        private ServicoParceiro servicoParceiro;
        private IRepositorioParceiro repositorioParceiro;
        private TabelaParceiroControl tabelaParceiro;

        public ControladorParceiro(ServicoParceiro servicoParceiro,
            IRepositorioParceiro repositorioParceiro)
        {
            this.servicoParceiro = servicoParceiro;
            this.repositorioParceiro = repositorioParceiro;  
        }

        public override void Inserir()
        {
            TelaParceiroForm telaParceiro = new TelaParceiroForm();

            telaParceiro.onGravarRegistro += servicoParceiro.Inserir;

            telaParceiro.ConfigurarParceiro(new Parceiro());

            DialogResult resultado = telaParceiro.ShowDialog();

            if(resultado == DialogResult.OK)
            {
                CarregarParceiros();
            }
        }

     
        public override void Editar()
        {
            Guid id = tabelaParceiro.ObtemIdSelecionado();

            Parceiro parceiroSelecionado = repositorioParceiro.SelecionarPorId(id);

            if(parceiroSelecionado == null)
            {
                MessageBox.Show("Selecione um Parceiro primeiro",
               "Edição de Parceiros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaParceiroForm tela = new TelaParceiroForm();

            tela.onGravarRegistro += servicoParceiro.Editar;

            tela.ConfigurarParceiro(parceiroSelecionado);

            DialogResult resultado = tela.ShowDialog();

            if(resultado == DialogResult.OK) 
            {
                CarregarParceiros();
            }
        }

        public override void Excluir()
        {
            Guid id = tabelaParceiro.ObtemIdSelecionado();

            Parceiro parceiroSelecionado = repositorioParceiro.SelecionarPorId(id);

            if (parceiroSelecionado == null)
            {
                MessageBox.Show("Selecione um Parceiro primeiro",
               "Exclusão de Parceiros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show("Deseja realmente excluir o Parceiro?",
               "Exclusão de Parceiro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if(opcaoEscolhida == DialogResult.OK )
            {
                Result resultado = servicoParceiro.Excluir(parceiroSelecionado);

                if (resultado.IsFailed)
                {
                    MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Parceiros",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                CarregarParceiros();
            }
        }
        
        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxParceiro();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaParceiro == null)
                tabelaParceiro = new TabelaParceiroControl();

            CarregarParceiros();

            return tabelaParceiro;
        }

        private void CarregarParceiros()
        {
            List<Parceiro> parceiros = repositorioParceiro.SelecionarTodos();

            tabelaParceiro.AtualizarRegistros(parceiros);
          
            mensagemRodape = string.Format("Visualizando {0} Parceiros{1}", parceiros.Count, parceiros.Count == 1 ? "" : "s");

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape);
        }
    }
}

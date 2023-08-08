using LocadorAutomoveis.Dominio;
using LocadorAutomoveis.Dominio.ModuloParceiro;
using LocadorAutomoveis.Dominio.ModuloPlanoCobranca;
using LocadorAutomoveis.Dominio.ModuloTaxasEServicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadorAutomoveis.Aplicacao.ModuloTaxasEServicos
{
    public class ServicoTaxasEServicos 
    {
       private IRepositorioTaxasServico repositorioTaxasServico;
       private IValidadorTaxasServico validadorTaxasServico;
        private IContextoPersistencia contextoPersistencia;

        public ServicoTaxasEServicos(IRepositorioTaxasServico repositorioTaxasServico,
            IValidadorTaxasServico validadorTaxasServico,IContextoPersistencia contextoPersistencia)
        {
            this.repositorioTaxasServico = repositorioTaxasServico;
            this.validadorTaxasServico = validadorTaxasServico;
            this.contextoPersistencia = contextoPersistencia;
        }

        public Result Inserir(TaxasEServico taxasEServico)
        {
            Log.Debug("Tentando inserir taxas e serviços...{@t}", taxasEServico);

            List<string> erros = ValidadorTaxaServico(taxasEServico);
            
            if (erros.Count() > 0)
            {
                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(erros);
            }

            try
            {
                repositorioTaxasServico.Inserir(taxasEServico);

                Log.Debug("Taxas e serviços {TaxasServicosId} inserido com sucesso", taxasEServico.Id);
                contextoPersistencia.GravarDados();

                return Result.Ok();
            }
            catch(Exception ex)
            {
                string msgErro = "Falha ao tentar inserir as Taxas e Serviços";

                Log.Error(ex, msgErro + "{@t}", taxasEServico);

                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(msgErro);
            }           
        }
        public Result Editar(TaxasEServico taxasEServico)
        {
            Log.Debug("Tentando Editar taxas e serviços...{@t}", taxasEServico);

            List<string> erros = ValidadorTaxaServico(taxasEServico);

            if (erros.Count() > 0)
            {
                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(erros);
            }

            try
            {
                repositorioTaxasServico.Editar(taxasEServico);

                Log.Debug("Taxas e serviços {TaxasServicosId} editado com sucesso", taxasEServico.Id);
                contextoPersistencia.GravarDados();

                return Result.Ok();
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar editar as Taxas e Serviços.";

                Log.Error(exc, msgErro + "{@t}", taxasEServico);

                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(TaxasEServico taxasEServico)
        {
            Log.Debug("Tentando excluir Taxas e Serviços...{@p}", taxasEServico);

            try
            {
                bool taxaServicoExiste = repositorioTaxasServico.Existe(taxasEServico);

                if (taxaServicoExiste == false)
                {
                    Log.Warning("Taxas e Serviços {TaxasEServicoId} não encontrado para excluir", taxasEServico.Id);

                    return Result.Fail("Taxas e Serviços não encontrado");
                }

                repositorioTaxasServico.Excluir(taxasEServico);

                Log.Debug("Taxas e Serviços {TaxasEServicoId} excluído com sucesso", taxasEServico.Id);

                contextoPersistencia.GravarDados();

                return Result.Ok();
            }
            catch (SqlException ex)
            {
                List<string> erros = new List<string>();

                string msgErro;

                msgErro = "Falha ao tentar excluir as Taxas e Serviços";

                erros.Add(msgErro);

                Log.Error(ex, msgErro + " {TaxasEServicoId}", taxasEServico.Id);

                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(erros);
            }
        }

        private List<string> ValidadorTaxaServico(TaxasEServico taxasEServico)
        {
            var resultadoValidacao = validadorTaxasServico.Validate(taxasEServico);

            List<string> erros = new List<string>();

            if (resultadoValidacao != null)
                erros.AddRange(resultadoValidacao.Errors.Select(x => x.ErrorMessage));

            if (NomeDuplicado(taxasEServico))
                erros.Add($"Este nome '{taxasEServico.Nome}' já está sendo utilizado");

            foreach (string erro in erros)
            {
                Log.Warning(erro);
            }

            return erros;
        }

        private bool NomeDuplicado(TaxasEServico taxasEServico)
        {
            TaxasEServico TaxasEservicoEncontrado = repositorioTaxasServico.SelecionarPorNome(taxasEServico.Nome);

            if (TaxasEservicoEncontrado != null &&
                TaxasEservicoEncontrado.Id != taxasEServico.Id &&
                TaxasEservicoEncontrado.Nome == taxasEServico.Nome)
            {
                return true;
            }

            return false;
        }
    }
}

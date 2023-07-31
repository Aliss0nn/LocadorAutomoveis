using LocadorAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadorAutomoveis.Dominio.ModuloParceiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LocadorAutomoveis.Aplicacao.ModuloParceiro
{
    public class ServicoParceiro
    {
        private IRepositorioParceiro repositorioParceiro;
        private IValidadorParceiro validadorParceiro;

        public ServicoParceiro(IRepositorioParceiro repositorioParceiro, 
            IValidadorParceiro validadorParceiro)
        {
            this.repositorioParceiro = repositorioParceiro;
            this.validadorParceiro = validadorParceiro;
        }
        public Result Inserir(Parceiro parceiro)
        {
            Log.Debug("Tentando inserir Parceiros...{@p}", parceiro);

            List<string> erros = ValidadorParceiro(parceiro);

            if (erros.Count() > 0)
                return Result.Fail(erros); //cenário 2

            try
            {
                repositorioParceiro.Inserir(parceiro);

                Log.Debug("Parceiro {ParceiroId} inserido com sucesso", parceiro.Id);

                return Result.Ok(); //cenário 1
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar inserir Parceiros.";

                Log.Error(exc, msgErro + "{@p}", parceiro);

                return Result.Fail(msgErro); //cenário 3
            }
        }

        public Result Editar(Parceiro parceiro)
        {
            Log.Debug("Tentando editar Parceiro...{@p}", parceiro);

            List<string> erros = ValidadorParceiro(parceiro);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            try
            {
                repositorioParceiro.Editar(parceiro);

                Log.Debug("Parceiro {ParceiroId} editado com sucesso", parceiro.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar editar Parceiro.";

                Log.Error(exc, msgErro + "{@p}", parceiro);

                return Result.Fail(msgErro);
            }
        }
        public Result Excluir(Parceiro parceiro)
        {
            Log.Debug("Tentando excluir Parceiro...{@p}", parceiro);

            try
            {
                bool parceiroExiste = repositorioParceiro.Existe(parceiro);

                if (parceiroExiste == false)
                {
                    Log.Warning("Parceiro {ParceiroId} não encontrado para excluir",
                        parceiro.Id);

                    return Result.Fail("Parceiro não encontrado");
                }

                repositorioParceiro.Excluir(parceiro);

                Log.Debug("Parceiro {ParceiroId} excluído com sucesso", parceiro.Id);

                return Result.Ok();
            }
            catch (SqlException ex)
            {
                List<string> erros = new List<string>();

                string msgErro;

                msgErro = "Falha ao tentar excluir Parceiro";

                erros.Add(msgErro);

                Log.Error(ex, msgErro + " {ParceiroId}", parceiro.Id);

                return Result.Fail(erros);
            }
        }

        private List<string> ValidadorParceiro(Parceiro parceiro)
        {
            var resultadoValidacao = validadorParceiro.Validate(parceiro);

            List<string> erros = new List<string>();

            if (resultadoValidacao != null)
                erros.AddRange(resultadoValidacao.Errors.Select(x => x.ErrorMessage));

            if (NomeDuplicado(parceiro))
                erros.Add($"Este nome '{parceiro.Nome}' já está sendo utilizado");

            foreach (string erro in erros)
            {
                Log.Warning(erro);
            }

            return erros;
        }

        private bool NomeDuplicado(Parceiro parceiro)
        {
            Parceiro parceiroEncontrado = repositorioParceiro.SelecionarPorNome(parceiro.Nome);

            if (parceiroEncontrado != null &&
                parceiroEncontrado.Id != parceiro.Id &&
                parceiroEncontrado.Nome == parceiro.Nome)
            {
                return true;
            }

            return false;
        }
    }
}

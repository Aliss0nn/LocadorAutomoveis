using LocadorAutomoveis.Dominio;
using LocadorAutomoveis.Dominio.ModuloParceiro;

namespace LocadorAutomoveis.Aplicacao.ModuloParceiro
{
    public class ServicoParceiro
    {
        private IRepositorioParceiro repositorioParceiro;
        private IValidadorParceiro validadorParceiro;
        private IContextoPersistencia contextoPersistencia;

        public ServicoParceiro(IRepositorioParceiro repositorioParceiro, 
            IValidadorParceiro validadorParceiro,
            IContextoPersistencia contextoPersistencia)
        {
            this.repositorioParceiro = repositorioParceiro;
            this.validadorParceiro = validadorParceiro;
            this.contextoPersistencia = contextoPersistencia;
        }
        public Result Inserir(Parceiro parceiro)
        {
            Log.Debug("Tentando inserir Parceiros...{@p}", parceiro);

            List<string> erros = ValidadorParceiro(parceiro);

            if (erros.Count() > 0)
            {
                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(erros);
            }

            try
            {
                repositorioParceiro.Inserir(parceiro);

                Log.Debug("Parceiro {ParceiroId} inserido com sucesso", parceiro.Id);

                contextoPersistencia.GravarDados();

                return Result.Ok(); 
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar inserir Parceiros.";

                Log.Error(exc, msgErro + "{@p}", parceiro);

                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(msgErro); 
            }
        }

        public Result Editar(Parceiro parceiro)
        {
            Log.Debug("Tentando editar Parceiro...{@p}", parceiro);

            List<string> erros = ValidadorParceiro(parceiro);

            if (erros.Count() > 0)
            {
                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(erros);
            }

            try
            {
                repositorioParceiro.Editar(parceiro);

                Log.Debug("Parceiro {ParceiroId} editado com sucesso", parceiro.Id);

                contextoPersistencia.GravarDados();

                return Result.Ok();
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar editar Parceiro.";

                Log.Error(exc, msgErro + "{@p}", parceiro);

                contextoPersistencia.DesfazerAlteracoes();

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

                contextoPersistencia.GravarDados();

                return Result.Ok();
            }
            catch (SqlException ex)
            {
                contextoPersistencia.DesfazerAlteracoes();

                List<string> erros = new List<string>();

                string msgErro = ObterMensagemErro(ex);             
            
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
        private static string ObterMensagemErro(Exception ex)
        {
            string msgErro;

            if (ex.Message.Contains("FK_TBCupom_TBParceiro"))
                msgErro = "Este Parceiro está relacionado com um Cupom e não pode ser excluído";
            else
                msgErro = "Este Parceiro não pode ser excluído";

            return msgErro;
        }
    }
}

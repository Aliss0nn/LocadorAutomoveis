using LocadorAutomoveis.Dominio;
using LocadorAutomoveis.Dominio.ModuloPlanoCobranca;

namespace LocadorAutomoveis.Aplicacao.ModuloPlanoCobranca
{
    public class ServicoPlanoCobranca
    {
        private IRepositorioPlanoCobranca repositorioPlanoCobranca;
        private IValidadorPlanoCobranca validadorPlanoCobranca;
        private IContextoPersistencia contextoPersistencia;

        public ServicoPlanoCobranca(
            IRepositorioPlanoCobranca repositorioPlanoCobranca,
            IValidadorPlanoCobranca validadorPlanoCobranca,
            IContextoPersistencia contextoPersistencia)
        {
            this.repositorioPlanoCobranca = repositorioPlanoCobranca;
            this.validadorPlanoCobranca = validadorPlanoCobranca;
            this.contextoPersistencia = contextoPersistencia;
        }

        public Result Inserir(PlanoCobranca planoCobranca)
        {
            Log.Debug("Tentando inserir plano de cobrança...{@p}", planoCobranca);

            List<string> erros = ValidarPlanoCobranca(planoCobranca);

            if (erros.Count() > 0)
            {
                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(erros);
            }
            try
            {
                repositorioPlanoCobranca.Inserir(planoCobranca);

                Log.Debug("Plano de cobrança {PlanoCobrancaId} inserido com sucesso", planoCobranca.Id);

                contextoPersistencia.GravarDados();

                return Result.Ok();
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar inserir plano de cobrança.";

                Log.Error(exc, msgErro + "{@p}", planoCobranca);

                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(msgErro);
            }
        }
        
        public Result Editar(PlanoCobranca planoCobranca)
        {
            Log.Debug("Tentando editar plano de cobrança...{@p}", planoCobranca);

            List<string> erros = ValidarPlanoCobranca(planoCobranca);

            if (erros.Count() > 0)
            {
                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(erros);
            }

            try
            {
                repositorioPlanoCobranca.Editar(planoCobranca);

                Log.Debug("Plano de Cobrança {PlanoCobrancaId} editado com sucesso", planoCobranca.Id);

                contextoPersistencia.GravarDados();

                return Result.Ok();
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar editar plano de cobrança.";

                Log.Error(exc, msgErro + "{@p}", planoCobranca);

                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(PlanoCobranca planoCobranca)
        {
            Log.Debug("Tentando excluir plano de cobrança...{@p}", planoCobranca);

            try
            {
                bool planoCobrancaExiste = repositorioPlanoCobranca.Existe(planoCobranca);

                if (planoCobrancaExiste == false)
                {
                    Log.Warning("Plano de cobrança {PlanoCobrancaId} não encontrado para excluir", planoCobranca.Id);

                    return Result.Fail("Plano de cobrança não encontrado");
                }

                repositorioPlanoCobranca.Excluir(planoCobranca);

                Log.Debug("Plano de Cobrança {PlanoCobrancaId} excluído com sucesso", planoCobranca.Id);

                contextoPersistencia.GravarDados();

                return Result.Ok();
            }
            catch (SqlException ex)
            {
                List<string> erros = new List<string>();
              
                string msgErro;

                msgErro = "Falha ao tentar excluir plano de cobrança";

                erros.Add(msgErro);

                Log.Error(ex, msgErro + " {PlanoCobrancaId}", planoCobranca.Id);

                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(erros);
            }
        }

        private List<string> ValidarPlanoCobranca(PlanoCobranca planoCobranca)
        {
            var resultadoValidacao = validadorPlanoCobranca.Validate(planoCobranca);

            List<string> erros = new List<string>();

            if (resultadoValidacao != null)
                erros.AddRange(resultadoValidacao.Errors.Select(x => x.ErrorMessage));

            if (PlanoDuplicado(planoCobranca))
                erros.Add($"Este grupo '{planoCobranca.Grupo}' já está usando o plano '{planoCobranca.TipoPlano}'");

            foreach (string erro in erros)
            {
                Log.Warning(erro);
            }

            return erros;
        }

        private bool PlanoDuplicado(PlanoCobranca planoCobranca)
        {
            PlanoCobranca planoCobrancaEncontrado = 
                repositorioPlanoCobranca.SelecionarPorGrupoTipo(planoCobranca.Grupo, planoCobranca.TipoPlano);

            if (planoCobrancaEncontrado != null &&
                planoCobrancaEncontrado.Id != planoCobranca.Id &&
                planoCobrancaEncontrado.Grupo == planoCobranca.Grupo &&
                planoCobrancaEncontrado.TipoPlano == planoCobranca.TipoPlano)
            {
                return true;
            }

            return false;
        }

    }
}

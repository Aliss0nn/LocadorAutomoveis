using LocadorAutomoveis.Dominio;
using LocadorAutomoveis.Dominio.ModuloCondutor;

namespace LocadorAutomoveis.Aplicacao.ModuloCondutor
{
    public class ServicoCondutor
    {
        private IRepositorioCondutor repositorioCondutor;
        private IValidadorCondutor validadorCondutor;
        private IContextoPersistencia contextoPersistencia;

        public ServicoCondutor(IRepositorioCondutor repositorioCupom,
            IValidadorCondutor validadorCupom, 
            IContextoPersistencia contextoPersistencia)
        {
            this.repositorioCondutor = repositorioCupom;
            this.validadorCondutor = validadorCupom;
            this.contextoPersistencia = contextoPersistencia;
        }
        public Result Inserir(Condutor condutor)
        {
            Log.Debug("Tentando inserir Condutores...{@c}", condutor);

            List<string> erros = ValidadorCondutor(condutor);

            if (erros.Count() > 0)
            {
                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(erros);
            }
            try
            {
                repositorioCondutor.Inserir(condutor);

                Log.Debug("Condutor {CondutorId} inserido com sucesso", condutor.Id);

                contextoPersistencia.GravarDados();

                return Result.Ok(); 
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar inserir Condutores.";

                Log.Error(exc, msgErro + "{@c}", condutor);

                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(msgErro);
            }
        }
        public Result Editar(Condutor condutor)
        {
            Log.Debug("Tentando editar Condutores...{@c}", condutor);

            List<string> erros = ValidadorCondutor(condutor);

            if (erros.Count() > 0)
            {
                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(erros);
            }

            try
            {
                repositorioCondutor.Editar(condutor);

                Log.Debug("Condutor {CondutorId} editado com sucesso", condutor.Id);

                contextoPersistencia.GravarDados();

                return Result.Ok();
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar editar Condutor.";

                Log.Error(exc, msgErro + "{@c}", condutor);

                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(msgErro);
            }
        }
        public Result Excluir(Condutor condutor)
        {
            Log.Debug("Tentando excluir Condutor...{@c}", condutor);

            try
            {
                bool parceiroExiste = repositorioCondutor.Existe(condutor);

                if (parceiroExiste == false)
                {
                    Log.Warning("Condutor {CondutorId} não encontrado para excluir",
                        condutor.Id);

                    return Result.Fail("Condutor não encontrado");
                }

                repositorioCondutor.Excluir(condutor);

                Log.Debug("Condutor {CondutorId} excluído com sucesso", condutor.Id);

                contextoPersistencia.GravarDados();

                return Result.Ok();
            }
            catch (SqlException ex)
            {
                contextoPersistencia.DesfazerAlteracoes();

                List<string> erros = new List<string>();

                string msgErro = ObterMensagemErro(ex);
               
                erros.Add(msgErro);

                Log.Error(ex, msgErro + " {CondutorId}", condutor.Id);

                return Result.Fail(erros);
            }
        }

        private List<string> ValidadorCondutor(Condutor condutor)
        {
            var resultadoValidacao = validadorCondutor.Validate(condutor);

            List<string> erros = new List<string>();

            if (resultadoValidacao != null)
                erros.AddRange(resultadoValidacao.Errors.Select(x => x.ErrorMessage));

            if (NomeDuplicado(condutor))
                erros.Add($"Este nome '{condutor.Nome}' já está sendo utilizado");

            foreach (string erro in erros)
            {
                Log.Warning(erro);
            }

            return erros;
        }

        private bool NomeDuplicado(Condutor condutor)
        {
            Condutor condutorEncontrado = repositorioCondutor.SelecionarPorNome(condutor.Nome);

            if (condutorEncontrado != null &&
                condutorEncontrado.Id != condutor.Id &&
                condutorEncontrado.Nome == condutor.Nome)
            {
                return true;
            }

            return false;
        }

        private static string ObterMensagemErro(Exception ex)
        {
            string msgErro;

            if (ex.Message.Contains("FK_TBAlugueis_TBCondutor"))
                msgErro = "Este Condutor está relacionado com um Aluguel e não pode ser excluído";
            else
                msgErro = "Este Condutor não pode ser excluído";

            return msgErro;
        }
    }
}

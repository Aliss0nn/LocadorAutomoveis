using LocadorAutomoveis.Dominio;
using LocadorAutomoveis.Dominio.ModuloAluguel;

namespace LocadorAutomoveis.Aplicacao.ModuloAluguel
{
    public class ServicoAluguel
    {
        private IRepositorioAluguel repositorioAluguel;
        private IValidadorAluguel validadorAluguel;
        private IContextoPersistencia contextoPersistencia;

        public ServicoAluguel(
            IRepositorioAluguel repositorioAluguel,
            IValidadorAluguel validadorAluguel, 
            IContextoPersistencia contextoPersistencia)
        {
            this.repositorioAluguel = repositorioAluguel;
            this.validadorAluguel = validadorAluguel;
            this.contextoPersistencia = contextoPersistencia;
        }

        public Result Inserir(Aluguel aluguel)
        {
            Log.Debug("Tentando inserir aluguel...{@a}", aluguel);

            List<string> erros = ValidarAluguel(aluguel);

            if (erros.Count() > 0)
            {
                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(erros);
            }

            try
            {
                repositorioAluguel.Inserir(aluguel);

                Log.Debug("Aluguel {AluguelId} inserido com sucesso", aluguel.Id);

                contextoPersistencia.GravarDados();

                return Result.Ok(); 
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar inserir aluguel.";

                Log.Error(exc, msgErro + "{@a}", aluguel);

                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(msgErro);
            }
        }
        
        public Result Editar(Aluguel aluguel)
        {
            Log.Debug("Tentando editar aluguel...{@a}", aluguel);

            List<string> erros = ValidarAluguel(aluguel);
           
            if (erros.Count() > 0)
            {
                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(erros);
            }

            try
            {
                repositorioAluguel.Editar(aluguel);

                Log.Debug("Aluguel {AluguelId} editado com sucesso", aluguel.Id);

                contextoPersistencia.GravarDados();

                return Result.Ok();
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar editar aluguel.";

                Log.Error(exc, msgErro + "{@a}", aluguel);

                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Aluguel aluguel)
        {
            Log.Debug("Tentando excluir aluguel...{@a}", aluguel);

            try
            {
                bool aluguelExiste = repositorioAluguel.Existe(aluguel);

                if (aluguelExiste == false)
                {
                    Log.Warning("Aluguel {AluguelId} não encontrado para excluir", aluguel.Id);

                    return Result.Fail("Aluguel não encontrado");
                }

                repositorioAluguel.Excluir(aluguel);

                Log.Debug("Aluguel {AluguelId} excluído com sucesso", aluguel.Id);

                contextoPersistencia.GravarDados();

                return Result.Ok();
            }
            catch (SqlException ex)
            {
                List<string> erros = new List<string>();
              
                string msgErro;

                msgErro = "Falha ao tentar excluir aluguel";

                erros.Add(msgErro);

                Log.Error(ex, msgErro + " {AluguelId}", aluguel.Id);

                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(erros);
            }
        }

        private List<string> ValidarAluguel(Aluguel aluguel)
        {
            var resultadoValidacao = validadorAluguel.Validate(aluguel);

            List<string> erros = new List<string>();

            if (resultadoValidacao != null)
                erros.AddRange(resultadoValidacao.Errors.Select(x => x.ErrorMessage));

            if (AutomovelDuplicado(aluguel))
                erros.Add($"O automóvel '{aluguel.Automovel}' já está utilizado");

            foreach (string erro in erros)
            {
                Log.Warning(erro);
            }

            return erros;
        }

        private bool AutomovelDuplicado(Aluguel aluguel)
        {
            Aluguel aluguelEncontrada = repositorioAluguel.SelecionarPorAutomovel(aluguel.Automovel);

            if (aluguelEncontrada != null &&
                aluguelEncontrada.Id != aluguel.Id &&
                aluguelEncontrada.Automovel == aluguel.Automovel)
            {
                return true;
            }

            return false;
        }

    }
}

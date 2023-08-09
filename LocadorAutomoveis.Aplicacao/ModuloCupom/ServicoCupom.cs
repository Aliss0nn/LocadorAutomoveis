using LocadorAutomoveis.Dominio;
using LocadorAutomoveis.Dominio.ModuloCupom;

namespace LocadorAutomoveis.Aplicacao.ModuloCupom
{
    public class ServicoCupom
    {
        private IRepositorioCupom repositorioCupom;
        private IValidadorCupom validadorCupom;
        private IContextoPersistencia contextoPersistencia;

        public ServicoCupom(IRepositorioCupom repositorioCupom,
            IValidadorCupom validadorCupom,
            IContextoPersistencia contextoPersistencia)
        {
            this.repositorioCupom = repositorioCupom;
            this.validadorCupom = validadorCupom;
            this.contextoPersistencia = contextoPersistencia;
        }

        public Result Inserir(Cupom cupom)
        {
            Log.Debug("Tentando inserir Cupons...{@c}", cupom);

            List<string> erros = ValidadorCupom(cupom);

            if (erros.Count() > 0)
            {
                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(erros);
            }
            try
            {
                repositorioCupom.Inserir(cupom);

                Log.Debug("Cupom {CupomId} inserido com sucesso", cupom.Id);

                contextoPersistencia.GravarDados();

                return Result.Ok(); 
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar inserir Cupons.";

                Log.Error(exc, msgErro + "{@c}", cupom);

                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(msgErro); 
            }
        }

        public Result Editar(Cupom cupom)
        {
            Log.Debug("Tentando editar Cupons...{@c}", cupom);

            List<string> erros = ValidadorCupom(cupom);

            if (erros.Count() > 0)
            {
                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(erros);
            }

            try
            {   
                repositorioCupom.Editar(cupom);

                Log.Debug("Cupom {CupomId} editado com sucesso", cupom.Id);

                contextoPersistencia.GravarDados();
                return Result.Ok();
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar editar Cupom.";

                Log.Error(exc, msgErro + "{@c}", cupom);

                contextoPersistencia.DesfazerAlteracoes();
                return Result.Fail(msgErro);
            }
        }
        public Result Excluir(Cupom cupom)
        {
            Log.Debug("Tentando excluir Cupom...{@c}", cupom);

            try
            {
                bool parceiroExiste = repositorioCupom.Existe(cupom);

                if (parceiroExiste == false)
                {
                    Log.Warning("Cupom {CupomId} não encontrado para excluir",
                        cupom.Id);

                    return Result.Fail("Cupom não encontrado");
                }

                repositorioCupom.Excluir(cupom);

                Log.Debug("Cupom {CupomId} excluído com sucesso", cupom.Id);

                contextoPersistencia.GravarDados();

                return Result.Ok();
            }
            catch (SqlException ex)
            {
                contextoPersistencia.DesfazerAlteracoes();

                List<string> erros = new List<string>();

                string msgErro;

                msgErro = "Falha ao tentar excluir Cupom";

                erros.Add(msgErro);

                Log.Error(ex, msgErro + " {CupomId}", cupom.Id);

                return Result.Fail(erros);
            }
        }

        private List<string> ValidadorCupom(Cupom cupom)
        {
            var resultadoValidacao = validadorCupom.Validate(cupom);

            List<string> erros = new List<string>();

            if (resultadoValidacao != null)
                erros.AddRange(resultadoValidacao.Errors.Select(x => x.ErrorMessage));

            if (NomeDuplicado(cupom))
                erros.Add($"Este nome '{cupom.Nome}' já está sendo utilizado");

            foreach (string erro in erros)
            {
                Log.Warning(erro);
            }

            return erros;
        }

        private bool NomeDuplicado(Cupom cupom)
        {
            Cupom cupomEncontrado = repositorioCupom.SelecionarPorNome(cupom.Nome);

            if (cupomEncontrado != null &&
                cupomEncontrado.Id != cupom.Id &&
                cupomEncontrado.Nome == cupom.Nome)
            {
                return true;
            }

            return false;
        }
    }
}


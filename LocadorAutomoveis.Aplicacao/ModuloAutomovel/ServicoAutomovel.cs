using LocadorAutomoveis.Dominio.ModuloAutomovel;

namespace LocadorAutomoveis.Aplicacao.ModuloAutomovel
{
    public class ServicoAutomovel
    {
        private IRepositorioAutomovel repositorioAutomovel;
        private IValidadorAutomovel validadorAutomovel;

        public ServicoAutomovel(
            IRepositorioAutomovel repositorioAutomovel,
            IValidadorAutomovel validadorAutomovel)
        {
            this.repositorioAutomovel = repositorioAutomovel;
            this.validadorAutomovel = validadorAutomovel;
        }

        public Result Inserir(Automovel automovel)
        {
            Log.Debug("Tentando inserir automóvel...{@a}", automovel);

            List<string> erros = ValidarAutomovel(automovel);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            try
            {
                repositorioAutomovel.Inserir(automovel);

                Log.Debug("Automóvel {AutomovelId} inserido com sucesso", automovel.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar inserir automóvel.";

                Log.Error(exc, msgErro + "{@a}", automovel);

                return Result.Fail(msgErro);
            }
        }
        
        public Result Editar(Automovel automovel)
        {
            Log.Debug("Tentando editar automóvel...{@a}", automovel);

            List<string> erros = ValidarAutomovel(automovel);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            try
            {
                repositorioAutomovel.Editar(automovel);

                Log.Debug("Automóvel {AutomovelId} editado com sucesso", automovel.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar editar automóvel.";

                Log.Error(exc, msgErro + "{@a}", automovel);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Automovel automovel)
        {
            Log.Debug("Tentando excluir automóvel...{@a}", automovel);

            try
            {
                bool automovelExiste = repositorioAutomovel.Existe(automovel);

                if (automovelExiste == false)
                {
                    Log.Warning("Automóvel {AutomovelId} não encontrado para excluir", automovel.Id);

                    return Result.Fail("Automóvel não encontrado");
                }

                repositorioAutomovel.Excluir(automovel);

                Log.Debug("Automóvel {AutomovelId} excluído com sucesso", automovel.Id);

                return Result.Ok();
            }
            catch (SqlException ex)
            {
                List<string> erros = new List<string>();
              
                string msgErro;

                msgErro = "Falha ao tentar excluir automóvel";

                erros.Add(msgErro);

                Log.Error(ex, msgErro + " {AutomovelId}", automovel.Id);

                return Result.Fail(erros);
            }
        }

        private List<string> ValidarAutomovel(Automovel automovel)
        {
            var resultadoValidacao = validadorAutomovel.Validate(automovel);

            List<string> erros = new List<string>();

            if (resultadoValidacao != null)
                erros.AddRange(resultadoValidacao.Errors.Select(x => x.ErrorMessage));

            if (ModeloDuplicado(automovel))
                erros.Add($"Este modelo '{automovel.Modelo}' da marca {automovel.Marca} já está sendo utilizado");

            foreach (string erro in erros)
            {
                Log.Warning(erro);
            }

            return erros;
        }

        private bool ModeloDuplicado(Automovel automovel)
        {
            Automovel automovelEncontrado = 
                repositorioAutomovel.SelecionarPorMarcaModelo(automovel.Marca, automovel.Modelo);

            if (automovelEncontrado != null &&
                automovelEncontrado.Id != automovel.Id &&
                automovelEncontrado.Marca == automovel.Marca &&
                automovelEncontrado.Modelo == automovel.Modelo)
            {
                return true;
            }

            return false;
        }

    }
}

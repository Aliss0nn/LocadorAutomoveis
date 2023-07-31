using LocadorAutomoveis.Dominio.ModuloFuncionario;
using LocadorAutomoveis.Dominio.ModuloDisciplina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LocadorAutomoveis.Aplicacao.ModuloFuncionario
{
    public class ServicoFuncionario
    {
        private IRepositorioFuncionario repositorioFuncionario;
        private IValidadorFuncionario validadorFuncionario;

        public ServicoFuncionario(
            IRepositorioFuncionario repositorioFuncionario,
            IValidadorFuncionario validadorFuncionario)
        {
            this.repositorioFuncionario = repositorioFuncionario;
            this.validadorFuncionario = validadorFuncionario;
        }

        public Result Inserir(Funcionario Funcionario)
        {
            Log.Debug("Tentando inserir Funcionario...{@d}", Funcionario);

            List<string> erros = ValidarFuncionario(Funcionario);

            if (erros.Count() > 0)
                return Result.Fail(erros); //cenário 2

            try
            {
                repositorioFuncionario.Inserir(Funcionario);

                Log.Debug("Funcionario {FuncionarioId} inserida com sucesso", Funcionario.Id);

                return Result.Ok(); //cenário 1
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar inserir Funcionario.";

                Log.Error(exc, msgErro + "{@d}", Funcionario);

                return Result.Fail(msgErro); //cenário 3
            }
        }

        public Result Editar(Funcionario Funcionario)
        {
            Log.Debug("Tentando editar Funcionario...{@d}", Funcionario);

            List<string> erros = ValidarFuncionario(Funcionario);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            try
            {
                repositorioFuncionario.Editar(Funcionario);

                Log.Debug("Funcionario {FuncionarioId} editada com sucesso", Funcionario.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar editar Funcionario.";

                Log.Error(exc, msgErro + "{@d}", Funcionario);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Funcionario Funcionario)
        {
            Log.Debug("Tentando excluir Funcionario...{@d}", Funcionario);

            try
            {
                bool FuncionarioExiste = repositorioFuncionario.Existe(Funcionario);

                if (FuncionarioExiste == false)
                {
                    Log.Warning("Funcionario {FuncionarioId} não encontrada para excluir", Funcionario.Id);

                    return Result.Fail("Funcionario não encontrada");
                }

                repositorioFuncionario.Excluir(Funcionario);

                Log.Debug("Funcionario {FuncionarioId} excluída com sucesso", Funcionario.Id);

                return Result.Ok();
            }
            catch (SqlException ex)
            {
                List<string> erros = new List<string>();

                string msgErro;

                msgErro = "Falha ao tentar excluir Funcionario";

                erros.Add(msgErro);

                Log.Error(ex, msgErro + " {FuncionarioId}", Funcionario.Id);

                return Result.Fail(erros);
            }
        }

        private List<string> ValidarFuncionario(Funcionario Funcionario)
        {
            var resultadoValidacao = validadorFuncionario.Validate(Funcionario);

            List<string> erros = new List<string>();

            if (resultadoValidacao != null)
                erros.AddRange(resultadoValidacao.Errors.Select(x => x.ErrorMessage));

            if (NomeDuplicado(Funcionario))
                erros.Add($"Este nome '{Funcionario.Nome}' já está sendo utilizado");

            foreach (string erro in erros)
            {
                Log.Warning(erro);
            }

            return erros;
        }

        private bool NomeDuplicado(Funcionario Funcionario)
        {
            Funcionario FuncionarioEncontrada = repositorioFuncionario.SelecionarPorNome(Funcionario.Nome);

            if (FuncionarioEncontrada != null &&
                FuncionarioEncontrada.Id != Funcionario.Id &&
                FuncionarioEncontrada.Nome == Funcionario.Nome)
            {
                return true;
            }

            return false;
        }
    }
}

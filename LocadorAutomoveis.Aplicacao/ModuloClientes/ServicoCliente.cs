using LocadorAutomoveis.Dominio.ModuloClientes;
using LocadorAutomoveis.Dominio.ModuloClientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadorAutomoveis.Aplicacao.ModuloClientes
{
    public class ServicoClientes
    {
        private IRepositorioClientes repositorioClientes;
        private IValidadorClientes validadorClientes;

        public ServicoClientes(
            IRepositorioClientes repositorioClientes,
            IValidadorClientes validadorClientes)
        {
            this.repositorioClientes = repositorioClientes;
            this.validadorClientes = validadorClientes;
        }

        public Result Inserir(Clientes clientes)
        {
            Log.Debug("Tentando inserir clientes...{@d}", clientes);

            List<string> erros = ValidarClientes(clientes);

            if (erros.Count() > 0)
                return Result.Fail(erros); //cenário 2

            try
            {
                repositorioClientes.Inserir(clientes);

                Log.Debug("Clientes {ClientesId} inserida com sucesso", clientes.Id);

                return Result.Ok(); //cenário 1
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar inserir clientes.";

                Log.Error(exc, msgErro + "{@d}", clientes);

                return Result.Fail(msgErro); //cenário 3
            }
        }

        public Result Editar(Clientes clientes)
        {
            Log.Debug("Tentando editar clientes...{@d}", clientes);

            List<string> erros = ValidarClientes(clientes);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            try
            {
                repositorioClientes.Editar(clientes);

                Log.Debug("Clientes {ClientesId} editada com sucesso", clientes.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar editar clientes.";

                Log.Error(exc, msgErro + "{@d}", clientes);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Clientes clientes)
        {
            Log.Debug("Tentando excluir clientes...{@d}", clientes);

            try
            {
                bool ClientesExiste = repositorioClientes.Existe(clientes);

                if (ClientesExiste == false)
                {
                    Log.Warning("Clientes {ClientesId} não encontrada para excluir", clientes.Id);

                    return Result.Fail("Clientes não encontrada");
                }

                repositorioClientes.Excluir(clientes);

                Log.Debug("Clientes {ClientesId} excluída com sucesso", clientes.Id);

                return Result.Ok();
            }
            catch (SqlException ex)
            {
                List<string> erros = new List<string>();

                string msgErro;

                msgErro = "Falha ao tentar excluir clientes";

                erros.Add(msgErro);

                Log.Error(ex, msgErro + " {ClientesId}", clientes.Id);

                return Result.Fail(erros);
            }
        }

        private List<string> ValidarClientes(Clientes clientes)
        {
            var resultadoValidacao = validadorClientes.Validate(clientes);

            List<string> erros = new List<string>();

            if (resultadoValidacao != null)
                erros.AddRange(resultadoValidacao.Errors.Select(x => x.ErrorMessage));

            if (NomeDuplicado(clientes))
                erros.Add($"Este nome '{clientes.NomeCliente}' já está sendo utilizado");

            foreach (string erro in erros)
            {
                Log.Warning(erro);
            }

            return erros;
        }

        private bool NomeDuplicado(Clientes clientes)
        {
            Clientes ClientesEncontrada = repositorioClientes.SelecionarPorNome(clientes.NomeCliente);

            if (ClientesEncontrada != null &&
                ClientesEncontrada.Id != clientes.Id &&
                ClientesEncontrada.NomeCliente == clientes.NomeCliente)
            {
                return true;
            }

            return false;
        }
    }
}

using LocadorAutomoveis.Dominio.ModuloAluguel;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace LocadorAutomoveis.Infra.Arquivos
{
    public  class ContextoDados
    {
        private const string NOME_ARQUIVO = "ModuloAluguel\\Configuracao.json";


        public ContextoDados()
        {
        }


        public void GravarEmArquivoJson()
        {
            JsonSerializerOptions config = ObterConfiguracoes();

            string registrosJson = JsonSerializer.Serialize(Configuracao.Instancia, config);

            File.WriteAllText(NOME_ARQUIVO, registrosJson);
        }

        public void CarregarDoArquivoJson()
        {
            JsonSerializerOptions config = ObterConfiguracoes();

            if (File.Exists(NOME_ARQUIVO))
            {
                string registrosJson = File.ReadAllText(NOME_ARQUIVO);

                if (registrosJson.Length > 0)
                {
                    Configuracao.instancia = JsonSerializer.Deserialize<Configuracao>(registrosJson, config);
                }
            }
        }

        private static JsonSerializerOptions ObterConfiguracoes()
        {
            JsonSerializerOptions opcoes = new JsonSerializerOptions();
            opcoes.IncludeFields = true;
            opcoes.WriteIndented = true;
            opcoes.ReferenceHandler = ReferenceHandler.Preserve;

            return opcoes;
        }
    }
}

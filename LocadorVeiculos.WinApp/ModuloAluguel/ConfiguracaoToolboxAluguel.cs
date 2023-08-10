namespace LocadorAutomoveis.WinApp.ModuloAluguel
{
    public class ConfiguracaoToolboxAluguel : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Aluguéis";

        public override string TooltipInserir => "Inserir novo Aluguel";

        public override string TooltipEditar => "Editar uma Alugeul existente";

        public override string TooltipExcluir => "Excluir um Aluguel existente";

        public override string TooltipConfigurar => "Configurar Preços";

        public override string TooltipConcluir => "Concluir um Aluguel existente";

        public override bool ConcluirHabilitado { get { return true; } }

        public override bool ConfigurarHabilitado { get { return true; } }
    }
}

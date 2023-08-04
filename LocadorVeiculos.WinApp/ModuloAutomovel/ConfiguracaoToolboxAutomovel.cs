namespace LocadorAutomoveis.WinApp.ModuloAutomovel
{
    public class ConfiguracaoToolboxAutomovel : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Automóveis";

        public override string TooltipInserir => "Inserir novo Automóvel";

        public override string TooltipEditar => "Editar um Automóvel existente";

        public override string TooltipExcluir => "Excluir um Automóvel existente";

        public override string TooltipFiltrar => "Filtrar por Grupo de Automóveis";

        public override bool FiltrarHabilitado { get { return true; } }
    }
}

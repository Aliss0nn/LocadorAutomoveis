namespace LocadorAutomoveis.WinApp
{
    public abstract class ConfiguracaoToolboxBase
    {
        #region tooltips dos botões
        public abstract string TipoCadastro { get; }

        public abstract string TooltipInserir { get; }

        public abstract string TooltipEditar { get; }

        public abstract string TooltipExcluir { get; }

        public virtual string TooltipFiltrar { get; }

        public virtual string TooltipConcluir { get; }

        public virtual string TooltipConfigurar { get; }

        #endregion

        #region estados dos botões
        public virtual bool InserirHabilitado { get { return true; } }

        public virtual bool EditarHabilitado { get { return true; } }

        public virtual bool ExcluirHabilitado { get { return true; } }

        public virtual bool FiltrarHabilitado { get { return false; } }

        public virtual bool ConcluirHabilitado { get { return false; } }

        public virtual bool ConfigurarHabilitado { get { return false; } }

        #endregion

    }
}
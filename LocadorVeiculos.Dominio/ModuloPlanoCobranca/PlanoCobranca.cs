using LocadorAutomoveis.Dominio.ModuloGrupoAutomoveis;

namespace LocadorAutomoveis.Dominio.ModuloPlanoCobranca
{
    public class PlanoCobranca : EntidadeBase<PlanoCobranca>
    {
        public PlanoCobranca()
        {
        }

        public PlanoCobranca(GrupoAutomoveis grupo, 
            TipoPlanoEnum tipoPlano, 
            decimal precoDiario, 
            decimal precoKm, 
            decimal kmLivre) : this()
        {
            Grupo = grupo;
            TipoPlano = tipoPlano;
            PrecoDiario = precoDiario;
            PrecoKm = precoKm;
            KmLivre = kmLivre;
        }

        public PlanoCobranca(int id, 
            GrupoAutomoveis grupo,
            TipoPlanoEnum tipoPlano,
            decimal precoDiario,
            decimal precoKm,
            decimal kmLivre) : this(grupo, tipoPlano, precoDiario, precoKm, kmLivre)
        {
            Id = id;
            Grupo = grupo;
            TipoPlano = tipoPlano;
            PrecoDiario = precoDiario;
            PrecoKm = precoKm;
            KmLivre = kmLivre;
        }

        public GrupoAutomoveis Grupo { get; set; }
        public TipoPlanoEnum TipoPlano { get; set; }
        public decimal PrecoDiario { get; set; }
        public decimal PrecoKm { get; set; }
        public decimal KmLivre { get; set; }



        public override string ToString()
        {
            return $"{TipoPlano}";
        }

        public override void Atualizar(PlanoCobranca plano)
        {
            Grupo = plano.Grupo;
            TipoPlano = plano.TipoPlano;
            PrecoDiario = plano.PrecoDiario;
            PrecoKm = plano.PrecoKm;
            KmLivre = plano.KmLivre;
        }

        public override bool Equals(object? obj)
        {
            return obj is PlanoCobranca plano &&
                   Id == plano.Id &&
                   Grupo.Equals(plano.Grupo) &&
                   TipoPlano == plano.TipoPlano &&
                   PrecoDiario == plano.PrecoDiario &&
                   PrecoKm == plano.PrecoKm &&
                   KmLivre == plano.KmLivre;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Grupo, TipoPlano, PrecoDiario, PrecoKm, KmLivre);
        }
    }
}
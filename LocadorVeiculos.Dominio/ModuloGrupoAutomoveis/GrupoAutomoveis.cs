namespace LocadorAutomoveis.Dominio.ModuloGrupoAutomoveis
{
    public class GrupoAutomoveis : EntidadeBase<GrupoAutomoveis>
    {
        public GrupoAutomoveis()
        {
        }

        public GrupoAutomoveis(string tipo) : this()
        {
            Tipo = tipo;
        }

        public GrupoAutomoveis(int id, string tipo) : this(tipo)        
        {
            Id = id;
        }

        public string Tipo { get; set; }

        public override string ToString()
        {
            return Tipo;
        }

        public override void Atualizar(GrupoAutomoveis grupo)
        {
            Tipo = grupo.Tipo;
        }

        public override bool Equals(object obj)
        {
            return obj is GrupoAutomoveis grupo &&
                   Id == grupo.Id &&
                   Tipo == grupo.Tipo;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Tipo);
        }       
    }
}
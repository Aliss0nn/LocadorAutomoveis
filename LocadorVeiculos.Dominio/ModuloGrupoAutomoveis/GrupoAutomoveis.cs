namespace LocadorAutomoveis.Dominio.ModuloGrupoAutomoveis
{
    public class GrupoAutomoveis : EntidadeBase<GrupoAutomoveis>
    {
        public GrupoAutomoveis()
        {
        }

        public GrupoAutomoveis(string nome) : this()
        {
            Nome = nome;
        }

        public GrupoAutomoveis(Guid id, string nome) : this(nome)        
        {
            Id = id;
        }

        public string Nome { get; set; }

        public override string ToString()
        {
            return Nome;
        }

        public override void Atualizar(GrupoAutomoveis grupo)
        {
            Nome = grupo.Nome;
        }

        public override bool Equals(object obj)
        {
            return obj is GrupoAutomoveis grupo &&
                   Id == grupo.Id &&
                   Nome == grupo.Nome;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Nome);
        }       
    }
}
namespace LocadorAutomoveis.Dominio.ModuloDisciplina
{
    public class Disciplina : EntidadeBase<Disciplina>
    {
        public Disciplina()
        {
        }

        public Disciplina(string nome) : this()
        {
            Nome = nome;
        }

        public Disciplina(Guid id, string nome) : this(nome)        
        {
            Id = id;
        }

        public string Nome { get; set; }

        public override string ToString()
        {
            return Nome;
        }

        public override void Atualizar(Disciplina disciplina)
        {
            Nome = disciplina.Nome;
        }

        public override bool Equals(object obj)
        {
            return obj is Disciplina disciplina &&
                   Id == disciplina.Id &&
                   Nome == disciplina.Nome;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Nome);
        }       
    }
}
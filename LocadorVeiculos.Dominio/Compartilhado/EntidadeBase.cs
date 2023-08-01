using SequentialGuid;

namespace LocadorAutomoveis.Dominio
{
    public abstract class EntidadeBase<T>
    {
        public Guid Id { get; set; }        

        public abstract void Atualizar(T registro);

        public EntidadeBase()
        {
            Id = SequentialGuidGenerator.Instance.NewGuid();
        }
    }
}
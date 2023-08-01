namespace LocadorAutomoveis.Dominio
{
    public abstract class EntidadeBase<T>
    {
        public Gint Id { get; set; }        

        public abstract void Atualizar(T registro);
    }
}
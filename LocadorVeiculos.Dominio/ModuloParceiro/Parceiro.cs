using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadorAutomoveis.Dominio.ModuloParceiro
{
    public class Parceiro : EntidadeBase<Parceiro>
    {
        public string Nome { get; set; }

        public override void Atualizar(Parceiro registro)
        {
           this.Nome = registro.Nome;
        }

        public override bool Equals(object? obj)
        {
            return obj is Parceiro parceiro &&
                   Id == parceiro.Id &&
                   Nome == parceiro.Nome;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Nome);
        }

        public Parceiro(Guid id, string nome) : this(nome)
        {
            Id = id;
        }

        public Parceiro()
        {

        }

        public Parceiro(string nome)
        {
            Nome = nome;
        }
        
        public override string ToString()
        {
            return Nome;
        }

    }
}

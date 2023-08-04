using LocadorAutomoveis.Dominio.ModuloParceiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadorAutomoveis.Dominio.ModuloCupom
{
    public class Cupom : EntidadeBase<Cupom>
    {
        public string Nome { get; set; } 
        public decimal Valor { get; set; }
        public DateTime DataValidade { get; set; }       
        public Parceiro Parceiro { get; set; }

        public Cupom()
        {

        }

        public Cupom(Guid id, string Nome, decimal Valor,DateTime dataValidade,Parceiro Parceiro) : this(Nome,Valor,dataValidade,Parceiro)
        {
            Id = id;
        }

        public Cupom(string nome, decimal valor, DateTime dataValidade, Parceiro parceiro)
        {
            Nome = nome;
            Valor = valor;
            DataValidade = dataValidade;
            Parceiro = parceiro;
        }

        public override void Atualizar(Cupom registro)
        {
            this.Nome = registro.Nome;
            this.Valor = registro.Valor;
            this.DataValidade = registro.DataValidade;
            this.Parceiro = registro.Parceiro;
        }

        public override bool Equals(object? obj)
        {
            return obj is Cupom cupom &&
                   Id.Equals(cupom.Id) &&
                   Nome == cupom.Nome &&
                   Valor == cupom.Valor &&
                   DataValidade == cupom.DataValidade &&
                   EqualityComparer<Parceiro>.Default.Equals(Parceiro, cupom.Parceiro);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Nome, Valor, DataValidade, Parceiro);
        }

        public override string? ToString()
        {
            return Nome;
        }
    }
}

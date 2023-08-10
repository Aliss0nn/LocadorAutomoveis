using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LocadorAutomoveis.Dominio.ModuloTaxasEServicos
{
    public class TaxasEServico : EntidadeBase<TaxasEServico>
    {
        public string Nome { get; set; }

        public decimal Preco { get; set; }

        //public EnumPlanoDeCalculo planoDeCalculo { get; set; }

        public string PlanoDeCalculo { get; set; }

        public TaxasEServico()
        {

        }

        public TaxasEServico(string nome, decimal preco, string planoDeCalculo)
        {
            Nome = nome;
            Preco = preco;
            this.PlanoDeCalculo = planoDeCalculo;
        }

        public TaxasEServico(Guid id, string nome,decimal preco,string planoDeCalculo) : this(nome,preco,planoDeCalculo)
        {
            Id = id;
        }

        public override string ToString()
        {
            return Nome;
        }

        public override void Atualizar(TaxasEServico registro)
        {
            this.Nome = registro.Nome;
            this.Preco = registro.Preco;
            this.PlanoDeCalculo = registro.PlanoDeCalculo;
        }

        public override bool Equals(object? obj)
        {
            return obj is TaxasEServico servico &&
                   Id == servico.Id &&
                   Nome == servico.Nome &&
                   Preco == servico.Preco &&
                   PlanoDeCalculo == servico.PlanoDeCalculo;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Nome, Preco, PlanoDeCalculo);
        }

        
    }
}

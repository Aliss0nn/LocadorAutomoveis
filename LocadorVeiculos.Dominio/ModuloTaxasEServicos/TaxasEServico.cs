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

        public EnumPlanoDeCalculo planoDeCalculo { get; set; }

        public TaxasEServico()
        {

        }

        public TaxasEServico(string nome, decimal preco, EnumPlanoDeCalculo planoDeCalculo)
        {
            Nome = nome;
            Preco = preco;
            this.planoDeCalculo = planoDeCalculo;
        }

        public TaxasEServico(int id, string nome,decimal preco,EnumPlanoDeCalculo planoDeCalculo) : this(nome,preco,planoDeCalculo)
        {
            Id = id;
        }

        public override void Atualizar(TaxasEServico registro)
        {
            this.Nome = registro.Nome;
            this.Preco = registro.Preco;
            this.planoDeCalculo = registro.planoDeCalculo;
        }

        public override bool Equals(object? obj)
        {
            return obj is TaxasEServico servico &&
                   Id == servico.Id &&
                   Nome == servico.Nome &&
                   Preco == servico.Preco &&
                   planoDeCalculo == servico.planoDeCalculo;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Nome, Preco, planoDeCalculo);
        }

        
    }
}

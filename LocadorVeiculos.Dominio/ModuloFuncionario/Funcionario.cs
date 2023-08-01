using LocadorAutomoveis.Dominio.ModuloGrupoAutomoveis;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadorAutomoveis.Dominio.ModuloFuncionario
{
    public class Funcionario : EntidadeBase<Funcionario>
    {
        public string Nome { get; set; }
        public decimal Salario { get; set; }
        public DateTime DataAdmissao { get; set; }

        public Funcionario()
        {
        }

        public Funcionario(string nome, DateTime dataAdmissao, int salario) : this()
        {
            Nome = nome;
            Salario = salario;
            DataAdmissao = dataAdmissao;


        }

        public Funcionario(int id, string nome, DateTime dataAdmissao) : this(nome, dataAdmissao, id)
        {
            Id = id;
        }
        public override string ToString()
        {
            return Nome;
        }

        public override void Atualizar(Funcionario grupo)
        {
            Nome = grupo.Nome;
        }

      

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Nome);
        }

        public override bool Equals(object? obj)
        {
            return obj is Funcionario funcionario &&
                   Id == funcionario.Id &&
                   Nome == funcionario.Nome &&
                   Salario == funcionario.Salario &&
                   DataAdmissao == funcionario.DataAdmissao;
        }
    }

   
}
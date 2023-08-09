using LocadorAutomoveis.Dominio.ModuloClientes;
using LocadorAutomoveis.Dominio.ModuloParceiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadorAutomoveis.Dominio.ModuloCondutor
{
    public class Condutor : EntidadeBase<Condutor>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Cnh { get; set; }
        public DateTime Validade { get; set; }
        public bool ClienteEhCondutor { get; set; }
        public Clientes Clientes { get; set; }

        public Condutor()
        {

        }

        public Condutor(Guid id, string Nome, string Email, string cpf, string telefone, string cnh, DateTime validade, bool clienteEhCondutor, Clientes clientes) : this(Nome,Email,cpf,telefone,cnh,validade,clienteEhCondutor,clientes)
        {
            Id = id;
        }

        public Condutor(string nome, string email, string cpf, string telefone, string cnh, DateTime validade, bool clienteEhCondutor, Clientes clientes)
        {
            Nome = nome;
            Email = email;
            Cpf = cpf;
            Telefone = telefone;
            Cnh = cnh;
            Validade = validade;
            ClienteEhCondutor = clienteEhCondutor;
            Clientes = clientes;
        }
        public override void Atualizar(Condutor registro)
        {
            this.Nome = registro.Nome;
            this.Cpf = registro.Cpf;
            this.Email = registro.Email;
            this.ClienteEhCondutor = registro.ClienteEhCondutor;
            this.Validade = registro.Validade;
            this.Clientes = registro.Clientes;
            this.Cnh = registro.Cnh;
            this.Telefone = registro.Telefone;
        }

        public override bool Equals(object? obj)
        {
            return obj is Condutor condutor &&
                   Id.Equals(condutor.Id) &&
                   Nome == condutor.Nome &&
                   Email == condutor.Email &&
                   Cpf == condutor.Cpf &&
                   Telefone == condutor.Telefone &&
                   Cnh == condutor.Cnh &&
                   Validade == condutor.Validade &&
                   ClienteEhCondutor == condutor.ClienteEhCondutor &&
                   EqualityComparer<Clientes>.Default.Equals(Clientes, condutor.Clientes);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(Nome);
            hash.Add(Email);
            hash.Add(Cpf);
            hash.Add(Telefone);
            hash.Add(Cnh);
            hash.Add(Validade);
            hash.Add(ClienteEhCondutor);
            hash.Add(Clientes);
            return hash.ToHashCode();
        }

        public override string? ToString()
        {
            return Nome;
        }
    }
}

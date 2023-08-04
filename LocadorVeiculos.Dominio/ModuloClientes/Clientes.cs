using iText.Kernel.Pdf.Canvas.Wmf;
using LocadorAutomoveis.Dominio.ModuloGrupoAutomoveis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace LocadorAutomoveis.Dominio.ModuloClientes
{
    public class Clientes : EntidadeBase<Clientes>
    {
       


        public Clientes(Guid id, string nomeCliente, string cpf, string estado, string cidade, string bairro, string rua, string numero, string telefone, string email, string cnpj)
        {
            Id = id;
            NomeCliente = nomeCliente;  
            Cpf = cpf;
            Estado = estado;
            Cidade = cidade;
            Bairro = bairro;
            Rua = rua;
            Numero = numero;
            Email = email;
            Telefone = telefone;
            Cnpj = cnpj;
        }

        public Clientes()
        {
        }

        public string Nome { get; set; }
        public string NomeCliente { get; set; }
        public string Cpf { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Cnpj { get; set; }

        public override string ToString()
        {
            return Nome;
        }

        public override void Atualizar(Clientes clientes)
        {

            this.Id = clientes.Id;
            this.NomeCliente = clientes.NomeCliente;
            this.Cpf = clientes.Cpf;
            this.Estado = clientes.Estado;
            this.Cidade = clientes.Cidade;
            this.Bairro = clientes.Bairro;
            this.Rua = clientes.Rua;
            this.Numero = clientes.Numero;
            this.Email = clientes.Email;
            this.Telefone = clientes.Telefone;
            this.Cnpj = clientes.Cnpj;
        }

        

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Nome, Cpf,Cidade,Estado,Email);
        }

        public override bool Equals(object? obj)
        {
            return obj is Clientes clientes &&
                   Id.Equals(clientes.Id) &&
                   Nome == clientes.Nome &&
                   NomeCliente == clientes.NomeCliente &&
                   Cpf == clientes.Cpf &&
                   Estado == clientes.Estado &&
                   Cidade == clientes.Cidade &&
                   Bairro == clientes.Bairro &&
                   Rua == clientes.Rua &&
                   Numero == clientes.Numero &&
                   Email == clientes.Email &&
                   Telefone == clientes.Telefone &&
                   Cnpj == clientes.Cnpj;
        }
    }




}


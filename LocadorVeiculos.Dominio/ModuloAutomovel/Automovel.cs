using LocadorAutomoveis.Dominio.ModuloGrupoAutomoveis;
using System.Drawing;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using System.Text.RegularExpressions;

namespace LocadorAutomoveis.Dominio.ModuloAutomovel
{
    public class Automovel : EntidadeBase<Automovel>
    {
        public Automovel()
        {
        }

        public Automovel(
            string marca, 
            string cor, 
            string modelo, 
            int ano,
            int quilometragem,
            TipoCombustivelEnum tipoCombustivel,
            decimal capacidade, 
            string placa,
            byte[] imagem,
            GrupoAutomoveis grupo) :this()
        {
            Marca = marca;
            Cor = cor;
            Modelo = modelo;
            Ano = ano;
            Quilometragem = quilometragem;
            TipoCombustivel = tipoCombustivel;
            Capacidade = capacidade;
            Placa = placa;
            Imagem = imagem;
            Grupo = grupo;
        }

        public Automovel(
            Guid id, 
            string marca, 
            string cor, 
            string modelo, 
            int ano,
            int quilometragem,
            TipoCombustivelEnum tipoCombustivel,
            decimal capacidade, 
            string placa,
            byte[] imagem,
            GrupoAutomoveis grupo) : this(
                marca, cor, modelo, ano, quilometragem, tipoCombustivel, capacidade, placa, imagem, grupo)
        {
            Id = id;
        }

        public string Marca { get; set; }
        public string Cor { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public int Quilometragem { get; set; }
        public TipoCombustivelEnum TipoCombustivel { get; set; }
        public decimal Capacidade { get; set; }
        public string Placa { get; set; }
        public byte[] Imagem { get; set; }
        public GrupoAutomoveis Grupo { get; set; }

        public byte[] ConverterImagemParaArrayBytes(Image imagem)
        {
            using (var imagemStream = new MemoryStream())
            {
                imagem.Save(imagemStream, System.Drawing.Imaging.ImageFormat.Png);

                return imagemStream.ToArray();
            }
        }

        public Image ConverterArrayBytesParaImagem()
        {
            return ConverterArrayBytesParaImagem(this.Imagem);
        }

        public Image ConverterArrayBytesParaImagem(byte[] imagemBytes)
        {
            using (var imagemStream = new MemoryStream(imagemBytes))
            {
                Image imagem = Image.FromStream(imagemStream);

                return imagem;
            }
        }

        public override string ToString()
        {
            return Modelo;
        }

        public override void Atualizar(Automovel automovel)
        {
            Marca = automovel.Marca;
            Cor = automovel.Cor;
            Modelo = automovel.Modelo;
            Ano = automovel.Ano;
            Quilometragem = automovel.Quilometragem;
            TipoCombustivel = automovel.TipoCombustivel;
            Capacidade = automovel.Capacidade;
            Placa = automovel.Placa;
            Imagem = automovel.Imagem;
            Grupo = automovel.Grupo;
        }

        public override bool Equals(object? obj)
        {
            return obj is Automovel automovel &&
                   Id.Equals(automovel.Id) &&
                   Marca == automovel.Marca &&
                   Cor == automovel.Cor &&
                   Modelo == automovel.Modelo &&
                   Ano == automovel.Ano &&
                   Quilometragem == automovel.Quilometragem &&
                   TipoCombustivel == automovel.TipoCombustivel &&
                   Capacidade == automovel.Capacidade &&
                   Placa == automovel.Placa &&
                   //Imagem.Equals(automovel.Imagem) &&
                   Grupo.Equals(automovel.Grupo);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(Marca);
            hash.Add(Cor);
            hash.Add(Modelo);
            hash.Add(Ano);
            hash.Add(Quilometragem);
            hash.Add(TipoCombustivel);
            hash.Add(Capacidade);
            hash.Add(Placa);
            hash.Add(Imagem);
            hash.Add(Grupo);
            return hash.ToHashCode();
        }
    }
}

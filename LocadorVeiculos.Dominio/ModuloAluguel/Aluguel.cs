using LocadorAutomoveis.Dominio.ModuloAutomovel;
using LocadorAutomoveis.Dominio.ModuloClientes;
using LocadorAutomoveis.Dominio.ModuloCondutor;
using LocadorAutomoveis.Dominio.ModuloCupom;
using LocadorAutomoveis.Dominio.ModuloFuncionario;
using LocadorAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadorAutomoveis.Dominio.ModuloPlanoCobranca;
using LocadorAutomoveis.Dominio.ModuloTaxasEServicos;
using System;
using System.Numerics;
using System.Text.RegularExpressions;

namespace LocadorAutomoveis.Dominio.ModuloAluguel
{
    public class Aluguel : EntidadeBase<Aluguel>
    {
        public Aluguel()
        {
        }

        public Aluguel(
            Funcionario funcionario, 
            Clientes cliente, 
            GrupoAutomoveis grupo, 
            PlanoCobranca plano,
            Automovel automovel, 
            Cupom cupom, 
            int kmAutomovel, 
            DateTime dataLocacao,
            DateTime dataPrevisao,
            List<TaxasEServico> taxas,
            Condutor condutor) :this()
        {
            Funcionario = funcionario;
            Cliente = cliente;
            Grupo = grupo;
            Plano = plano;
            Automovel = automovel;
            Cupom = cupom;
            KmAutomovel = kmAutomovel;
            DataLocacao = dataLocacao;
            DataPrevisao = dataPrevisao;
            Taxas = taxas;
            Condutor = condutor;
            DataDevolucao = DateTime.Now;
        }

        public Aluguel(
            Guid id,
            Funcionario funcionario,
            Clientes cliente,
            GrupoAutomoveis grupo,
            PlanoCobranca plano,
            Automovel automovel,
            Cupom cupom,
            int kmAutomovel,
            DateTime dataLocacao,
            DateTime dataPrevisao,
            List<TaxasEServico> taxas,
            Condutor condutor) : this(funcionario, 
                cliente, 
                grupo, 
                plano, 
                automovel, 
                cupom, 
                kmAutomovel, 
                dataLocacao, 
                dataPrevisao,
                taxas,
                condutor)
        {
            Id = id;
        }

        public Funcionario Funcionario { get; set; }
        public Clientes Cliente { get; set; }
        public GrupoAutomoveis Grupo { get; set; }
        public PlanoCobranca Plano { get; set; }
        public Automovel Automovel { get; set; }
        public Cupom Cupom { get; set; }
        public int KmAutomovel { get; set; }
        public DateTime DataLocacao { get; set; } 
        public DateTime DataPrevisao { get; set; } 
        public DateTime DataDevolucao { get; set; }
        public decimal Preco { get; set; }
        public int KmPercorrido { get; set; }
        public bool Fechado { get; set; }
        public NivelTanqueEnum NivelTanque { get; set; }
        public List<TaxasEServico> Taxas { get; set; }
        public Condutor Condutor { get; set; }

        public override string ToString()
        {
            return $"{Cliente} {DataLocacao.Date}";
        }

        public override void Atualizar(Aluguel aluguel)
        {
            Funcionario = aluguel.Funcionario;
            Cliente = aluguel.Cliente;
            Grupo = aluguel.Grupo;
            Plano = aluguel.Plano;
            Automovel = aluguel.Automovel;
            Cupom = aluguel.Cupom;
            KmAutomovel = aluguel.KmAutomovel;
            DataLocacao = aluguel.DataLocacao;
            DataPrevisao = aluguel.DataPrevisao;
            DataDevolucao = aluguel.DataDevolucao;
            Preco = aluguel.Preco;
            KmPercorrido = aluguel.KmPercorrido;
            Fechado = aluguel.Fechado;
            NivelTanque = aluguel.NivelTanque;
            Taxas = aluguel.Taxas;
            Condutor = aluguel.Condutor;
        }

        public void ConcluirAluguel(
            DateTime dataDevolucao, 
            int kmPercorrido, 
            NivelTanqueEnum nivelTanque)
        {
            DataDevolucao = dataDevolucao;
            KmPercorrido = kmPercorrido;
            Fechado = true;
            NivelTanque = nivelTanque;
        }

        public void PrecoInicial()
        {
            TimeSpan diferenca = DataPrevisao - DataLocacao;
            int dias = (int)diferenca.TotalDays;
            decimal valor = dias * Plano.PrecoDiario;
            
            foreach(TaxasEServico taxa in Taxas)
            {
                if (taxa.PlanoDeCalculo == "Preço Fixo")
                    valor += taxa.Preco;

                else
                    valor += taxa.Preco * dias;
            }

            if (Cupom != null)
                valor -= Cupom.Valor;

            Preco = valor;
        }

        public void PrecoDevolucao()
        {
            TimeSpan diferenca = DataDevolucao - DataLocacao;
            int dias = (int)diferenca.TotalDays;
            decimal valor = dias * Plano.PrecoDiario;

            if(Plano.TipoPlano == TipoPlanoEnum.Controlado)
            {
                decimal kmLivres = Plano.KmLivre * dias;
                decimal kmExtras = (KmPercorrido - KmAutomovel) - kmLivres;
                if (kmExtras > 0)
                    valor += kmExtras * Plano.PrecoKm;
            }

            if(Plano.TipoPlano == TipoPlanoEnum.Diario)
            {
                decimal kmExtras = (KmPercorrido - KmAutomovel);
                valor += kmExtras * Plano.PrecoKm;
            }

            foreach (TaxasEServico taxa in Taxas)
            {
                if (taxa.PlanoDeCalculo == "Preço Fixo")
                    valor += taxa.Preco;

                else
                    valor += taxa.Preco * dias;
            }

            switch (NivelTanque)
            {
                case NivelTanqueEnum.Vazio:
                    valor += Automovel.Capacidade * Configuracao.ObterValor(Automovel.TipoCombustivel);
                    break;
                case NivelTanqueEnum.Quase_Vazio:
                    valor += 0.75m * Automovel.Capacidade * Configuracao.ObterValor(Automovel.TipoCombustivel);
                    break;
                case NivelTanqueEnum.Meio_Cheio:
                    valor += 0.5m * Automovel.Capacidade * Configuracao.ObterValor(Automovel.TipoCombustivel);
                    break;
                case NivelTanqueEnum.Quase_Cheio:
                    valor += 0.25m * Automovel.Capacidade * Configuracao.ObterValor(Automovel.TipoCombustivel);
                    break;
            }

            if(DataDevolucao.Date > DataPrevisao.Date)
            {
                valor = valor * 1.1m;
                TimeSpan atrasoDiferenca = DataDevolucao.Date - DataPrevisao.Date;
                int diasAtraso = (int)atrasoDiferenca.TotalDays;
                valor += 50 * diasAtraso;
            }

            if (Cupom != null)
                valor -= Cupom.Valor;

            Preco = valor;
        }

        public override bool Equals(object? obj)
        {
            return obj is Aluguel aluguel &&
                   Id.Equals(aluguel.Id) &&
                   EqualityComparer<Funcionario>.Default.Equals(Funcionario, aluguel.Funcionario) &&
                   EqualityComparer<Clientes>.Default.Equals(Cliente, aluguel.Cliente) &&
                   EqualityComparer<GrupoAutomoveis>.Default.Equals(Grupo, aluguel.Grupo) &&
                   EqualityComparer<PlanoCobranca>.Default.Equals(Plano, aluguel.Plano) &&
                   EqualityComparer<Automovel>.Default.Equals(Automovel, aluguel.Automovel) &&
                   EqualityComparer<Cupom>.Default.Equals(Cupom, aluguel.Cupom) &&
                   KmAutomovel == aluguel.KmAutomovel &&
                   DataLocacao == aluguel.DataLocacao &&
                   DataPrevisao == aluguel.DataPrevisao &&
                   DataDevolucao == aluguel.DataDevolucao &&
                   Preco == aluguel.Preco &&
                   KmPercorrido == aluguel.KmPercorrido &&
                   Fechado == aluguel.Fechado &&
                   NivelTanque == aluguel.NivelTanque &&
                   EqualityComparer<List<TaxasEServico>>.Default.Equals(Taxas, aluguel.Taxas) &&
                   EqualityComparer<Condutor>.Default.Equals(Condutor, aluguel.Condutor);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(Funcionario);
            hash.Add(Cliente);
            hash.Add(Grupo);
            hash.Add(Plano);
            hash.Add(Automovel);
            hash.Add(Cupom);
            hash.Add(KmAutomovel);
            hash.Add(DataLocacao);
            hash.Add(DataPrevisao);
            hash.Add(DataDevolucao);
            hash.Add(Preco);
            hash.Add(KmPercorrido);
            hash.Add(Fechado);
            hash.Add(NivelTanque);
            hash.Add(Taxas);
            hash.Add(Condutor);
            return hash.ToHashCode();
        }
    }
}
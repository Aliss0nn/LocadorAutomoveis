using LocadorAutomoveis.Dominio.ModuloAutomovel;

namespace LocadorAutomoveis.Dominio.ModuloAluguel
{
    public class Configuracao
    {
        public decimal GasolinaPreco { get; set; }
        public decimal AlcoolPreco { get; set; }
        public decimal GasPreco { get; set; }
        public decimal DieselPreco { get; set; }

        public static Configuracao instancia;
        public static Configuracao Instancia { 
            get 
            { 
                if (instancia != null) 
                    return instancia; 
                instancia = new Configuracao(1, 1, 1, 1); 
                return instancia; 
            } 
        }
        public Configuracao()
        {
        }
        public Configuracao(decimal gasolinaPreco, decimal alcoolPreco, decimal gasPreco, decimal dieselPreco) { 
            GasolinaPreco = gasolinaPreco; 
            AlcoolPreco = alcoolPreco; 
            GasPreco = gasPreco; 
            DieselPreco = dieselPreco; 
        }
        public static decimal ObterValor(TipoCombustivelEnum tipoCombustivel) { 

            switch (tipoCombustivel) { 
                case TipoCombustivelEnum.Gasolina: 
                    return Instancia.GasolinaPreco; 
                case TipoCombustivelEnum.Gas: 
                    return Instancia.GasPreco; 
                case TipoCombustivelEnum.Alcool: 
                    return Instancia.AlcoolPreco; 
                case TipoCombustivelEnum.Diesel: 
                    return Instancia.DieselPreco; 
            } 
            return 0; 
        }


    }
}

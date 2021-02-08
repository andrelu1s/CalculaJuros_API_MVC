using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalculaJuros_API_MVC.Models
{
    public class JurosComposto
    {
        public static double taxaJuros = 0.01;
        public double ValorInicial { get; set; }
        public int QuantidadeMeses { get; set; }

        public JurosComposto(double valorInicial, int quantidadeMeses)
        {
            ValorInicial = valorInicial;
            QuantidadeMeses = quantidadeMeses;
        }

        public void paramValid()
        {
            if (ValorInicial < 0 || QuantidadeMeses < 0)
            {
                throw new Exception("Parametros inválidos");
            }
        }
    }
}
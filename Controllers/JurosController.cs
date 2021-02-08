using CalculaJuros_API_MVC.Models;
using System;
using System.Web.Mvc;

namespace CalculaJuros_API_MVC.Controllers
{
    public class JurosController : Controller
    {

        public ActionResult Index(decimal valorInicial = 0, int meses= 0)
        {
            ViewBag.Message = "Simulação de cálculo de juros";
            GetTaxaJurosAction();

            if (valorInicial > 0 && meses > 0)
            {
                ViewBag.Resultado = CalculaJuros(valorInicial, meses);
                ViewBag.ValInicial = valorInicial;
                ViewBag.Meses = meses;
            }

            return View();
        }
        /*
        public ActionResult Index(decimal valorInicial, int meses)
        {
            ViewBag.Resultado = CalculaJuros(valorInicial, meses);

            return View();
        }
        */
        public void GetTaxaJurosAction()
        {
            JurosController jurosCont = new JurosController();
            double retTaxaJuros = jurosCont.taxaJuros();
            ViewBag.TaxaJuros = jurosCont.taxaJuros().ToString();
            
        }

        [HttpGet]
        [Route("taxaJuros")]
        public double taxaJuros()
        {
            return JurosComposto.taxaJuros;
        }

        [HttpGet]
        [ValidateInput(false)]
        [Route("calculajuros/{valorInicial}/{meses}")]
        public string CalculaJuros(decimal valorInicial, int meses)
        {
            JurosComposto juroComposto = new JurosComposto(Convert.ToDouble(valorInicial), meses);
            juroComposto.paramValid();

            return Calcular(juroComposto);
        }

        public string Calcular(JurosComposto _jurosComposto)
        {
            double valorFinal = _jurosComposto.ValorInicial * Math.Pow(1 + JurosComposto.taxaJuros, _jurosComposto.QuantidadeMeses);
            valorFinal = Math.Truncate(100 * valorFinal) / 100;

            if (valorFinal > double.MaxValue)
            {
                throw new Exception("Erro no cálculo.");
            }


            return valorFinal.ToString("F");
        }

        [HttpGet]
        [Route("showmethecode")]
        public string ShowMeTheCode()
        {
            return "https://github.com/";
        }
    }
}

using Gestion_Del_Presupuesto.Models;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Gestion_Del_Presupuesto.Controllers
{
    public class UFViewModelController : Controller
    {
        private static readonly HttpClient client = new HttpClient();

        public IActionResult Index()
        {
            return View(new UFViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CalcularUF(UFViewModel model)
        {
            // Obtener el valor de la UF actual usando scraping
            model.MontoUF = await ObtenerValorUFAsync();

            if (ModelState.IsValid)
            {
                // Calcular el valor en UF según el tipo seleccionado (Real o Aproximada)
                decimal tasaConversion = model.TipoUF == "Real" ? model.MontoUF : model.MontoUF * 0.95M; // Ajuste para valor aproximado
                decimal montoConvertido = model.MontoCLP / tasaConversion;

                // Actualizar el modelo con la fecha y cantidad de estudiantes
                model.MontoUF = montoConvertido;
                model.Fecha = DateTime.Now;

                // Llamar a la vista de resultados y pasar el modelo actualizado
                return View("Resultado", model);
            }

            return View("Index", model);
        }

        // Método para obtener el valor de la UF actual usando scraping
        private async Task<decimal> ObtenerValorUFAsync()
        {
            try
            {
                // URL de la fuente confiable para la UF (puedes cambiarla según sea necesario)
                string url = "https://valoruf.cl/";
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var pageContents = await response.Content.ReadAsStringAsync();

                // Analizar el HTML usando HtmlAgilityPack
                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(pageContents);

                // Buscar el valor de la UF en el HTML
                var valorUFNode = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='value']");

                // Parsear el valor encontrado a decimal
                if (valorUFNode != null)
                {
                    string valorUF = valorUFNode.InnerText.Replace("$", "").Replace(".", "").Trim();
                    return decimal.Parse(valorUF);
                }
                return 0M;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener la UF: {ex.Message}");
                return 0M;
            }
        }

        public IActionResult Resultado()
        {
            return View();
        }
    }
}

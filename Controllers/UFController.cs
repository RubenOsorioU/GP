using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Gestion_Del_Presupuesto.Controllers
{
    public class UFController : Controller
    {
        private const string UfApiUrl = "https://www.mindicador.cl/api"; // URL de la API

        // Acción para renderizar la vista inicial
        public IActionResult Index()
        {
            return View();
        }

        // Acción para calcular valores UF
        [HttpPost]
        public async Task<IActionResult> CalcularUF(DateTime fechaInicio, DateTime fechaFin)
        {
            if (fechaInicio > fechaFin)
            {
                TempData["Error"] = "La fecha de inicio no puede ser mayor que la fecha de fin.";
                return View("Index");
            }

            try
            {
                var valoresUF = await ObtenerValoresUF(fechaInicio, fechaFin);

                if (valoresUF == null || !valoresUF.Any())
                {
                    TempData["Error"] = "No se encontraron valores de UF para las fechas seleccionadas.";
                    return View("Index");
                }

                var totalUF = valoresUF.Sum(uf => uf.Valor);

                ViewData["ValoresUF"] = valoresUF;
                ViewData["TotalUF"] = totalUF;

                return View("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al obtener los valores de la UF: " + ex.Message;
                return View("Index");
            }
        }

        private async Task<List<UFModel>> ObtenerValoresUF(DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var url = $"{UfApiUrl}/uf?fechaInicio={fechaInicio:yyyy-MM-dd}&fechaFin={fechaFin:yyyy-MM-dd}";
                    var response = await client.GetAsync(url);

                    if (!response.IsSuccessStatusCode)
                    {
                        var errorContent = await response.Content.ReadAsStringAsync();
                        throw new Exception($"Error en la API: {response.StatusCode} - {errorContent}");
                    }

                    var json = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Respuesta de la API: {json}"); // Log para depuración

                    return JsonConvert.DeserializeObject<List<UFModel>>(json);
                }
            }
            catch (Exception ex)
            {
                // Datos simulados para pruebas en caso de fallo de la API
                Console.WriteLine($"Error al obtener los datos de la API: {ex.Message}");
                return new List<UFModel>
                {
                    new UFModel { Fecha = fechaInicio, Valor = 30000m },
                    new UFModel { Fecha = fechaFin, Valor = 31000m }
                };
            }
        }
    }

    public class UFModel
    {
        public DateTime Fecha { get; set; }
        public decimal Valor { get; set; }
    }
}

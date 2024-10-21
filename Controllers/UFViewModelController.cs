using Gestion_Del_Presupuesto.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Gestion_Del_Presupuesto.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Gestion_Del_Presupuesto.Controllers
{
    public class UFViewModelController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UFViewModelController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(DateTime SelectedDate)
        {
            return View();
        }
        public async Task<IActionResult> BuscarUF(DateTime SelectedDate)
        {

            //string url = $"https://mindicador.cl/api/uf/{SelectedDate.Year.ToString()}-{SelectedDate.Month.ToString()}-{SelectedDate.Day.ToString()}}";
            string url = $"https://si3.bcentral.cl/SieteRestWS/SieteRestWS.ashx?user=Ruben1Ulloa@gmail.com&pass=Benchi12&function=GetSeries&timeseries=F073.UFF.PRE.Z.D&firstdate={SelectedDate.ToString("yyyy-MM-dd")}&lastdate={SelectedDate.ToString("yyyy-MM-dd")}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    IndicadorEconomico indicador = JsonConvert.DeserializeObject<IndicadorEconomico>(jsonResponse);
                    var valorUF = indicador.Series.Obs.FirstOrDefault()?.Value;
                    var fechaUF = indicador.Series.Obs.FirstOrDefault()?.IndexDateString;
                    ViewBag.ValorUF = valorUF;
                    ViewBag.FechaUF = fechaUF;
                   
                }
                else
                {
                    ViewBag.Error = "Error al obtener el valor de la UF";
                }
            }

            return View("index");
        }
    }
}



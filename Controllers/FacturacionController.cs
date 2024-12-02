using Gestion_Del_Presupuesto.Data;
using Gestion_Del_Presupuesto.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Gestion_Del_Presupuesto.Controllers
{
    public class FacturacionController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Usuario> _userManager; // Cambio para usar `Usuario` en lugar de `IdentityUser`.
        private readonly IHttpClientFactory _clientFactory;

        public FacturacionController(ApplicationDbContext context, UserManager<Usuario> userManager, IHttpClientFactory clientFactory)
        {
            _context = context;
            _userManager = userManager;
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            // Obtener el usuario autenticado
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                // Redirigir al usuario a la página de inicio de sesión si no está autenticado.
                return RedirectToAction("Login", "Account");
            }

            // Pasar información del usuario a la vista usando ViewBag
            ViewBag.NombreUsuario = user.UserName;
            ViewBag.EmailUsuario = user.Email;
            ViewBag.TelefonoUsuario = user.PhoneNumber;

            // Obtener las facturaciones y calcular los valores necesarios
            var facturaciones = await _context.Facturacion.Include(f => f.Convenios).ToListAsync();
            var netoUF = CalcularNetoUF(facturaciones);
            var valorUF = await ObtenerValorUFActual(DateTime.Now);
            var totalAPagar = CalcularTotalAPagar(netoUF, valorUF);

            // Pasar los valores calculados a la vista
            ViewBag.NetoUF = netoUF;
            ViewBag.TotalAPagar = totalAPagar;

            return View(facturaciones);
        }

        // Resto del controlador se mantiene igual, ajustando el UserManager al modelo `Usuario`

        // Métodos existentes como Details, Create, Edit, etc., no requieren modificaciones adicionales.

        // Calcular Neto UF
        private decimal CalcularNetoUF(List<FacturacionModel> facturaciones)
        {
            decimal netoUF = 0;

            foreach (var facturacion in facturaciones)
            {
                var subtotal = facturacion.NumeroTiempo * facturacion.NumeroAlumnos * facturacion.ValorUFMesPractica;
                facturacion.Subtotal = subtotal;
                netoUF += subtotal;
            }

            return netoUF;
        }

        // Calcular Total a Pagar
        private decimal CalcularTotalAPagar(decimal netoUF, decimal valorUF)
        {
            return netoUF * valorUF;
        }

        // Obtener Valor UF Actual
        public async Task<decimal> ObtenerValorUFActual(DateTime selectedDate)
        {
            var valores = await ObtenerValoresUF(selectedDate, selectedDate);
            return valores.FirstOrDefault();
        }

        // Método para obtener valores UF desde una API
        private async Task<List<decimal>> ObtenerValoresUF(DateTime fechaInicio, DateTime fechaFin)
        {
            string url = $"https://si3.bcentral.cl/SieteRestWS/SieteRestWS.ashx?user=Ruben1Ulloa@gmail.com&pass=Benchi12&function=GetSeries&timeseries=F073.UFF.PRE.Z.D&firstdate={fechaInicio:yyyy-MM-dd}&lastdate={fechaFin:yyyy-MM-dd}";

            var client = _clientFactory.CreateClient();
            try
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var indicador = JsonConvert.DeserializeObject<IndicadorEconomico>(jsonResponse);

                    if (indicador?.Series?.Obs != null && indicador.Series.Obs.Any())
                    {
                        return indicador.Series.Obs
                            .Select(obs => decimal.TryParse(obs.Value, out decimal value) ? value : 0)
                            .Where(value => value != 0)
                            .ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error al obtener valores UF: {ex.Message}");
            }

            return new List<decimal>();
        }
    }
}

using Gestion_Del_Presupuesto.Data;
using Gestion_Del_Presupuesto.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Net.Http;
using System.Text.Json;
using System.Linq;

public class FacturacionController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<Usuario> _userManager;

    public FacturacionController(ApplicationDbContext context, UserManager<Usuario> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    // GET: Index
    public async Task<IActionResult> Index(DateTime? FechaInicio, DateTime? FechaFin)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return RedirectToAction("Login", "Account");

        // Obtener lista de convenios y enviar a la vista
        ViewBag.Convenios = await _context.Convenios.ToListAsync();

        // Consulta para filtrar facturaciones por fecha
        var facturacionesQuery = _context.Facturacion
            .Include(f => f.Convenios)
            .Where(f => !f.Eliminado);

        if (FechaInicio.HasValue)
            facturacionesQuery = facturacionesQuery.Where(f => f.FechaInicio >= FechaInicio.Value);

        if (FechaFin.HasValue)
            facturacionesQuery = facturacionesQuery.Where(f => f.FechaTermino <= FechaFin.Value);

        var facturaciones = await facturacionesQuery.ToListAsync();

        // Calcular Subtotal
        foreach (var item in facturaciones)
        {
            item.Subtotal = item.NumeroTiempo * item.NumeroAlumnos * item.ValorUFMesPractica;
        }

        // Obtener valor UF del día
        var valorUF = await ObtenerValorUFActual(DateTime.Now);

        // Asignar valores a ViewBag
        ViewBag.RazonSocial = "Universidad Central";
        ViewBag.NombreUsuario = user.UserName ?? "Usuario Desconocido";
        ViewBag.RutConvenio = "70.995.200-5";
        ViewBag.DireccionConvenio = "Lord Cochrane 417, Santiago Centro";
        ViewBag.RolUsuario = "Administrador";
        ViewBag.EmailUsuario = user.Email ?? "Sin Email";
        ViewBag.SedeConvenio = "Santiago Centro";
        ViewBag.ValorUF = valorUF;
        ViewBag.NetoUF = 0;
        ViewBag.TotalAPagar = 0;

        return View(facturaciones);
    }

    // POST: Index (Calcular totales seleccionados)
    [HttpPost]
    public async Task<IActionResult> Index(DateTime? FechaUFDia)
    {
        decimal valorUF = 0;

        // Si no hay fecha seleccionada, usar la fecha de hoy
        DateTime fechaSeleccionada = FechaUFDia ?? DateTime.Now;

        // Obtener el valor UF desde la API
        valorUF = await ObtenerValorUFActual(fechaSeleccionada);

        // Inicializar la lista de facturaciones (evitar null)
        var facturaciones = await _context.Facturacion
            .Include(f => f.Convenios)
            .Where(f => !f.Eliminado)
            .ToListAsync();

        // Calcular Subtotal
        foreach (var item in facturaciones)
        {
            item.Subtotal = item.NumeroTiempo * item.NumeroAlumnos * item.ValorUFMesPractica;
        }

        // Asignar valores a ViewBag
        ViewBag.ValorUF = valorUF.ToString("N2", new CultureInfo("es-CL")); // Formato chileno
        ViewBag.FechaUFDia = fechaSeleccionada.ToString("yyyy-MM-dd");
        ViewBag.RazonSocial = "Universidad Central";
        ViewBag.NombreUsuario = "Administrador";
        ViewBag.RutConvenio = "70.995.200-5";
        ViewBag.DireccionConvenio = "Lord Cochrane 417, Santiago Centro";
        ViewBag.RolUsuario = "Administrador";
        ViewBag.EmailUsuario = "Sin Email";
        ViewBag.SedeConvenio = "Santiago Centro";
        ViewBag.NetoUF = 0;
        ViewBag.TotalAPagar = 0;

        // Devolver la vista con el modelo
        return View(facturaciones);
    }

    public async Task<decimal> ObtenerValorUFActual(DateTime selectedDate)
    {
        using (var client = new HttpClient())
        {
            var apiUrl = $"https://si3.bcentral.cl/SieteRestWS/SieteRestWS.ashx?" +
                         $"user=Ruben1Ulloa@gmail.com&pass=Benchi12&function=GetSeries" +
                         $"&timeseries=F073.UFF.PRE.Z.D&firstdate={selectedDate:yyyy-MM-dd}&lastdate={selectedDate:yyyy-MM-dd}";

            var response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var data = JsonSerializer.Deserialize<IndicadorEconomico>(jsonResponse, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                var valorUFString = data?.Series?.Obs?.FirstOrDefault()?.Value;  // Usar la propiedad 'Obs' correctamente

                if (!string.IsNullOrEmpty(valorUFString))
                {
                    if (decimal.TryParse(valorUFString, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out var valorUF))
                    {
                        return valorUF;
                    }
                }
            }

            return 0; // En caso de error
        }
    }

}

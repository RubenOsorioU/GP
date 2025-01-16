using Gestion_Del_Presupuesto.Data;
using Gestion_Del_Presupuesto.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Net.Http;
using System.Text.Json;

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
        // Obtener usuario actual
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return RedirectToAction("Login", "Account");

        // Obtener roles del usuario
        var roles = await _userManager.GetRolesAsync(user);
        ViewBag.RolUsuario = roles.FirstOrDefault() ?? "Sin Rol";

        // Obtener lista de convenios (con inicialización en caso de que no haya datos)
        ViewBag.Convenios = await _context.Convenios.ToListAsync() ?? new List<ConvenioModel>();

        // Consulta base de facturaciones
        var facturacionesQuery = _context.Facturacion
            .Include(f => f.Convenios)
            .Where(f => !f.Eliminado);

        // Filtrar por fechas
        if (FechaInicio.HasValue)
            facturacionesQuery = facturacionesQuery.Where(f => f.FechaInicio >= FechaInicio.Value);

        if (FechaFin.HasValue)
            facturacionesQuery = facturacionesQuery.Where(f => f.FechaTermino <= FechaFin.Value);

        var facturaciones = await facturacionesQuery.ToListAsync() ?? new List<FacturacionModel>();

        // Calcular subtotal
        foreach (var item in facturaciones)
        {
            item.Subtotal = (item.NumeroTiempo ?? 0) * (item.NumeroAlumnos ?? 0) * (item.ValorUFMesPractica ?? 0);
        }

        // Obtener detalles del primer convenio (manejo de valores nulos)
        var convenio = await _context.Convenios.FirstOrDefaultAsync();
        string direccionConvenio = convenio?.Direccion ?? "Sin Dirección";
        string rutConvenio = convenio?.Rut ?? "Sin RUT";
        string sedeConvenio = convenio?.Sede ?? "Santiago";

        // Obtener valor UF actual
        var valorUF = await ObtenerValorUFActual(DateTime.Now);

        // Asignar valores a ViewBag con validación para evitar nulos
        ViewBag.RazonSocial = "Universidad Central";
        ViewBag.NombreUsuario = user.UserName ?? "Usuario Desconocido";
        ViewBag.RutConvenio = rutConvenio;
        ViewBag.DireccionConvenio = direccionConvenio;
        ViewBag.EmailUsuario = user.Email ?? "Sin Email";
        ViewBag.SedeConvenio = sedeConvenio;
        ViewBag.ValorUF = valorUF > 0 ? valorUF : 0.00m;
        ViewBag.NetoUF = 0;
        ViewBag.TotalAPagar = 0;

        return View(facturaciones);
    }

    // POST: Index (Calcular totales seleccionados)
    [HttpPost]
    public async Task<IActionResult> Index(DateTime? FechaUFDia, List<FacturacionModel> facturacionesSeleccionadas)
    {
        // Obtener valor UF según la fecha seleccionada o usar la fecha actual
        DateTime fechaSeleccionada = FechaUFDia ?? DateTime.Now;
        var valorUF = await ObtenerValorUFActual(fechaSeleccionada);

        // Inicializar variables para totales
        decimal netoUF = 0;
        decimal totalAPagar = 0;

        // Procesar las facturaciones seleccionadas
        if (facturacionesSeleccionadas != null)
        {
            foreach (var seleccion in facturacionesSeleccionadas)
            {
                if (seleccion.FacturacionSeleccionada)
                {
                    netoUF += (seleccion.NumeroTiempo ?? 0) * (seleccion.NumeroAlumnos ?? 0) * (seleccion.ValorUFMesPractica ?? 0);
                }
            }
        }

        // Calcular el total a pagar en pesos según el valor UF
        totalAPagar = netoUF * valorUF;

        // Asignar valores a ViewBag con validaciones para evitar nulos
        ViewBag.ValorUF = valorUF.ToString("N2", new CultureInfo("es-CL"));
        ViewBag.FechaUFDia = fechaSeleccionada.ToString("yyyy-MM-dd");
        ViewBag.NetoUF = netoUF;
        ViewBag.TotalAPagar = totalAPagar;

        // Obtener usuario actual para mostrar su información
        var user = await _userManager.GetUserAsync(User);
        var roles = await _userManager.GetRolesAsync(user);
        ViewBag.RolUsuario = roles.FirstOrDefault() ?? "Sin Rol";
        ViewBag.NombreUsuario = user?.UserName ?? "Usuario Desconocido";
        ViewBag.EmailUsuario = user?.Email ?? "Sin Email";

        // Obtener detalles del convenio para mostrar en la tabla
        var convenio = await _context.Convenios.FirstOrDefaultAsync();
        ViewBag.RutConvenio = convenio?.Rut ?? "Sin RUT";
        ViewBag.DireccionConvenio = convenio?.Direccion ?? "Sin Dirección";
        ViewBag.SedeConvenio = convenio?.Sede ?? "Sin Sede";

        // Devolver las facturaciones para renderizar la tabla
        var facturaciones = await _context.Facturacion
            .Include(f => f.Convenios)
            .Where(f => !f.Eliminado)
            .ToListAsync() ?? new List<FacturacionModel>();

        return View(facturaciones);
    }

    // Método para obtener el valor UF actual
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

                var valorUFString = data?.Series?.Obs?.FirstOrDefault()?.Value;

                if (!string.IsNullOrEmpty(valorUFString) &&
                    decimal.TryParse(valorUFString, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out var valorUF))
                {
                    return valorUF;
                }
            }

            return 0; // En caso de error
        }
    }
    public IActionResult Create()
    {
        return View();
    }

    public IActionResult RegistroHistoricoFacturacion()
    {
        return View();
    }
}

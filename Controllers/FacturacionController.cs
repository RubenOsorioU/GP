using Gestion_Del_Presupuesto.Data;
using Gestion_Del_Presupuesto.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


public class FacturacionController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<Usuario> _userManager;

    public FacturacionController(ApplicationDbContext context, UserManager<Usuario> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index(int? convenioId, DateTime? FechaInicio, DateTime? FechaFin)
    {
        // Obtener el usuario actual
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return RedirectToAction("Login", "Account");
        }

        // Obtener roles y configurar ViewBag
        var roles = await _userManager.GetRolesAsync(user);
        var rolUsuario = roles.FirstOrDefault() ?? "Sin rol";

        ViewBag.NombreUsuario = user.UserName;
        ViewBag.EmailUsuario = user.Email;
        ViewBag.RolUsuario = rolUsuario;

        // Obtener lista de convenios para el filtro
        ViewBag.Convenios = await _context.Convenios.ToListAsync();

        // Opciones del select para facturación
        ViewBag.DocumentosFacturacion = new List<SelectListItem>
    {
        new SelectListItem { Value = "1", Text = "Pago por uso de campos clínicos (Uf/Estudiante/Mes o proporcional)" },
        new SelectListItem { Value = "2", Text = "Pago por apoyo a la docencia" }
    };

        // Manejo del convenio seleccionado
        ConvenioModel convenio = null;
        if (convenioId.HasValue)
        {
            convenio = await _context.Convenios.FirstOrDefaultAsync(c => c.Id_Convenio == convenioId.Value);
        }

        if (convenio != null)
        {
            ViewBag.RazonSocial = convenio.Nombre;
            ViewBag.RutConvenio = convenio.Rut;
            ViewBag.DireccionConvenio = convenio.Direccion;
            ViewBag.SedeConvenio = convenio.Sede;
        }
        else
        {
            ViewBag.RazonSocial = "Universidad Central";
            ViewBag.RutConvenio = "70.995.200-5";
            ViewBag.DireccionConvenio = "Lord Cochrane 417, Santiago Centro";
            ViewBag.SedeConvenio = "Santiago Centro";
        }

        // Obtener facturaciones filtradas por fecha
        var facturacionesQuery = _context.Facturacion
            .Include(f => f.Convenios) // Cargar relaciones necesarias
            .Where(f => !f.Eliminado); // Filtrar por facturaciones no eliminadas

        if (FechaInicio.HasValue)
        {
            facturacionesQuery = facturacionesQuery.Where(f => FechaInicio >= FechaInicio.Value);
        }

        if (FechaFin.HasValue)
        {
            facturacionesQuery = facturacionesQuery.Where(f => FechaFin <= FechaFin.Value);
        }

        var facturaciones = await facturacionesQuery.ToListAsync();

        // Calcular datos necesarios
        var netoUF = CalcularNetoUF(facturaciones, FechaInicio, FechaFin);
  //      var valorUF = await ObtenerValorUFActual(DateTime.Now);
 //       var totalAPagar = CalcularTotalAPagar(netoUF, valorUF);
//
        // Pasar datos calculados a ViewBag
        ViewBag.NetoUF = netoUF;
  //      ViewBag.ValorUFPromedio = valorUF;
 //       ViewBag.TotalAPagar = totalAPagar;

        return View(facturaciones); // Pasar la lista de facturaciones a la vista
    }


    private decimal CalcularNetoUF(List<FacturacionModel> facturaciones, DateTime? fechaInicio, DateTime? fechaFin)
    {
        decimal netoUF = 0;

        foreach (var facturacion in facturaciones)
        {
            // Validar si el rango de la facturación está dentro del período solicitado
            bool dentroDelRango = (!fechaInicio.HasValue || facturacion.FechaInicio >= fechaInicio.Value) &&
                                  (!fechaFin.HasValue || facturacion.FechaTermino <= fechaFin.Value);

            if (!dentroDelRango)
            {
                continue; // Omitir registros fuera del rango
            }

            // Cálculo del subtotal
            var numeroTiempo = facturacion.NumeroTiempo > 0 ? facturacion.NumeroTiempo : 0;
            var numeroAlumnos = facturacion.NumeroAlumnos > 0 ? facturacion.NumeroAlumnos : 0;
            var valorUF = facturacion.ValorUFMesPractica > 0 ? facturacion.ValorUFMesPractica : 0;

            var subtotal = numeroTiempo * numeroAlumnos * valorUF;
            facturacion.Subtotal = subtotal;
            netoUF += subtotal;
        }

        return netoUF;
    }



    private decimal CalcularTotalAPagar(decimal netoUF, decimal valorUF)
    {
        return netoUF * valorUF;
    }

    //public async Task<decimal> ObtenerValorUFActual(DateTime selectedDate)
    //{
    //    //    using (var client = new HttpClient())
    //    //    {
    //    //        // Base URL de la API (reemplázala con la URL real que estás usando en Postman)
    //    //        var baseUrl = "https://api.tuurl.com/indicadores/uf";
    //    //        var requestUrl = $"{baseUrl}?fecha={selectedDate:yyyy-MM-dd}";

    //    //        // Realizar la solicitud HTTP GET
    //    //        var response = await client.GetAsync(requestUrl);

    //    //        if (response.IsSuccessStatusCode)
    //    //        {
    //    //            // Leer el contenido de la respuesta como string
    //    //            var jsonResponse = await response.Content.ReadAsStringAsync();

    //    //            // Deserializar el JSON en el modelo
    //    //            var indicador = System.Text.Json.JsonSerializer.Deserialize<IndicadorEconomico>(jsonResponse);

    //    //            // Navegar en la estructura para obtener el valor de la UF
    //    //            var valorUF = indicador.Series.Obs.FirstOrDefault()?.Value;

    //    //            // Intentar convertir el valor a decimal
    //    //            if (decimal.TryParse(valorUF, out var ufDecimal))
    //    //            {
    //    //                return ufDecimal;
    //    //            }
    //    //        }

    //    //        // En caso de error, lanzar una excepción o devolver un valor predeterminado
    //    //        throw new Exception("No se pudo obtener el valor de la UF desde la API.");
    //    //    }
    //    return ;
    //}


    public IActionResult Create()
    {
        ViewData["ConvenioId"] = new SelectList(_context.Convenios, "Id_Convenio", "Nombre");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(FacturacionModel facturacion)
    {
        if (ModelState.IsValid)
        {
            _context.Add(facturacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["ConvenioId"] = new SelectList(_context.Convenios, "Id_Convenio", "Nombre", facturacion.ConvenioId);
        return View(facturacion);
    }
    public IActionResult RegistroHistoricoFacturacion()
    {
        return View();
    }
}

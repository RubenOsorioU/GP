using Gestion_Del_Presupuesto.Data;
using Gestion_Del_Presupuesto.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class FacturacionController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<Usuario> _userManager;

    public FacturacionController(ApplicationDbContext context, UserManager<Usuario> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index(int? convenioId)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return RedirectToAction("Login", "Account");
        }

        var roles = await _userManager.GetRolesAsync(user);
        var rolUsuario = roles.FirstOrDefault() ?? "Sin rol";

        ViewBag.NombreUsuario = user.UserName;
        ViewBag.EmailUsuario = user.Email;
        ViewBag.RolUsuario = rolUsuario;

        // Obtener la lista de convenios y pasarla a la vista
        ViewBag.Convenios = await _context.Convenios.ToListAsync();

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

        var facturaciones = await _context.Facturacion.Include(f => f.Convenios).ToListAsync();
        var netoUF = CalcularNetoUF(facturaciones);
        var valorUF = await ObtenerValorUFActual(DateTime.Now);
        var totalAPagar = CalcularTotalAPagar(netoUF, valorUF);

        ViewBag.NetoUF = netoUF;
        ViewBag.TotalAPagar = totalAPagar;

        return View(facturaciones);
    }


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

    private decimal CalcularTotalAPagar(decimal netoUF, decimal valorUF)
    {
        return netoUF * valorUF;
    }

    public async Task<decimal> ObtenerValorUFActual(DateTime selectedDate)
    {
        // Aquí puedes usar la lógica existente para obtener el valor UF actual.
        return 30m; // Valor UF simulado; aquí iría la llamada real a un servicio.
    }
}

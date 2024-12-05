using Gestion_Del_Presupuesto.Data;
using Gestion_Del_Presupuesto.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
public class FacturacionController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<Usuario> _userManager;

    public FacturacionController(ApplicationDbContext context, UserManager<Usuario> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    // Acción para listar facturaciones
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

        var facturaciones = await _context.Facturacion.Include(f => f.Convenios).Where(f => !f.Eliminado).ToListAsync();
        var netoUF = CalcularNetoUF(facturaciones);
        var valorUF = await ObtenerValorUFActual(DateTime.Now);
        var totalAPagar = CalcularTotalAPagar(netoUF, valorUF);

        ViewBag.NetoUF = netoUF;
        ViewBag.TotalAPagar = totalAPagar;

        return View(facturaciones);
    }

    // Acción para crear una nueva facturación
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

    // Método para mover una facturación a la papelera
    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var facturacion = await _context.Facturacion.FindAsync(id);
        if (facturacion != null)
        {
            facturacion.Eliminado = true; // Marcar la facturación como eliminada
            _context.Update(facturacion);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    // Método para mostrar la papelera de facturaciones
    public async Task<IActionResult> Papelera()
    {
        var facturacionesEliminadas = await _context.Facturacion.Where(f => f.Eliminado).ToListAsync();
        return View(facturacionesEliminadas);
    }

    // Método para restaurar una facturación desde la papelera
    [HttpPost]
    public async Task<IActionResult> Restore(int id)
    {
        var facturacion = await _context.Facturacion.FindAsync(id);
        if (facturacion != null)
        {
            facturacion.Eliminado = false; // Restaurar la facturación
            _context.Update(facturacion);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Papelera));
    }

    // Método para eliminar permanentemente una facturación
    [HttpPost]
    public async Task<IActionResult> DeletePermanent(int id)
    {
        var facturacion = await _context.Facturacion.FindAsync(id);
        if (facturacion != null)
        {
            _context.Facturacion.Remove(facturacion); // Eliminar permanentemente
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Papelera));
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

    public IActionResult RegistroHistoricoFacturacion()
    {
        return View();
    }
}

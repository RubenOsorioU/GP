using Gestion_Del_Presupuesto.Data;
using Gestion_Del_Presupuesto.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

[Authorize]
public class HistorialController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<Usuario> _userManager;

    public HistorialController(ApplicationDbContext context, UserManager<Usuario> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    // GET: Historial_Actividad para el usuario autenticado
    public async Task<IActionResult> Index()
    {
        // Obtener el usuario autenticado
        var user = await _userManager.GetUserAsync(User);

        if (user == null)
        {
            return RedirectToAction("Login", "Account");
        }

        // Filtrar el historial por el nombre del usuario autenticado
        var historial = await _context.Historial_Actividad
            .Where(h => h.NombreUsuario == user.UserName) // Filtra por nombre
            .OrderByDescending(h => h.Fecha)
            .ToListAsync();

        return View(historial);
    }
    public async Task RegistrarActividad(string accion, string detalles)
    {
        var user = await _userManager.GetUserAsync(User);

        if (user != null)
        {
            var actividad = new Historial_Actividad
            {
                NombreUsuario=user.UserName,
                Fecha = DateTime.Now,
                Detalles = detalles,
                Accion = accion,
            };

            _context.Historial_Actividad.Add(actividad);
            await _context.SaveChangesAsync();
        }
    }

    // GET: Confirmar eliminación
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var historial = await _context.Historial_Actividad
            .Include(h => h.Usuario)
            .FirstOrDefaultAsync(h => h.Id_Historial_Actividad == id);

        if (historial == null)
        {
            return NotFound();
        }

        var roles = historial.Usuario != null
            ? await _userManager.GetRolesAsync(historial.Usuario)
            : new List<string>();

        ViewData["Roles"] = roles;

        return View(historial);
    }

    // POST: Confirmar eliminación
    [HttpPost, ActionName("Delete")]
    [Authorize(Roles = "Admin")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var historial_Actividad = await _context.Historial_Actividad.FindAsync(id);
        if (historial_Actividad != null)
        {
            _context.Historial_Actividad.Remove(historial_Actividad);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }
}

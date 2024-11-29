using Gestion_Del_Presupuesto.Data;
using Gestion_Del_Presupuesto.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
[Authorize]
public class Historial_ActividadController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<Usuario> _userManager;

    public Historial_ActividadController(ApplicationDbContext context, UserManager<Usuario> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    // GET: Historial_Actividad
    public async Task<IActionResult> Index()
    {
        var historial = await _context.Historial_Actividad
            .Include(h => h.Usuario)
            .OrderByDescending(h => h.Fecha)
            .ToListAsync();

        return View(historial);
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

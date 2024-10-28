using Gestion_Del_Presupuesto.Data;
using Gestion_Del_Presupuesto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;

namespace Gestion_Del_Presupuesto.Controllers
{
    public class ConvenioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConvenioController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string Nombre, string Tipo, string Sede)
        {
            var conveniosQuery = _context.Convenios.Include(c => c.Retribuciones).AsQueryable();
            var convenios = await conveniosQuery.ToListAsync();
            if (!string.IsNullOrEmpty(Nombre))
            {
                conveniosQuery = conveniosQuery.Where(c => c.Nombre.Contains(Nombre));
            }

            if (!string.IsNullOrEmpty(Tipo))
            {
                conveniosQuery = conveniosQuery.Where(c => c.Tipo == Tipo);
            }

            if (!string.IsNullOrEmpty(Sede))
            {
                conveniosQuery = conveniosQuery.Where(c => c.Sede == Sede);
            }

            // Obtener valores únicos para los filtros
            ViewBag.NombresConvenios = await _context.Convenios.Select(c => c.Nombre).Distinct().ToListAsync();
            ViewBag.TiposConvenios = await _context.Convenios.Select(c => c.Tipo).Distinct().ToListAsync();
            ViewBag.Sedes = new List<string> { "Santiago", "Coquimbo", "Ambas" };
            return View(convenios);
        }

        // Crear un nuevo convenio (GET)
        public IActionResult Create()
        {
            ViewBag.Sedes = new List<string> { "Santiago", "Coquimbo", "Ambas" };
            ViewBag.TiposRetribucion = _context.Retribuciones.Select(r => r.Tipo_Retribucion).Distinct().ToList();
            return View();
        }

        // Crear un nuevo convenio (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ConvenioModel convenio, bool RenovacionAutomatica)
        {
            if (ModelState.IsValid)
            {
                convenio.Fecha_Inicio = DateTime.SpecifyKind(convenio.Fecha_Inicio, DateTimeKind.Utc);
                if (RenovacionAutomatica)
                {
                    convenio.Fecha_Termino = convenio.Fecha_Inicio.AddYears(1);
                }

                _context.Add(convenio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Sedes = new List<string> { "Santiago", "Coquimbo", "Ambas" };
            ViewBag.TiposRetribucion = _context.Retribuciones.Select(r => r.Tipo_Retribucion).Distinct().ToList();
            return View(convenio);
        }

        // Editar convenio (GET)
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var convenio = await _context.Convenios
                .Include(c => c.Retribuciones) // Incluye las retribuciones en la consulta
                .FirstOrDefaultAsync(m => m.Id_Convenio == id);

            if (convenio == null)
            {
                return NotFound();
            }

            return View(convenio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ConvenioModel convenio)
        {
            if (id != convenio.Id_Convenio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(convenio);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConvenioExists(convenio.Id_Convenio))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return View(convenio);
        }

        private bool ConvenioExists(int id)
        {
            return _context.Convenios.Any(e => e.Id_Convenio == id);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var convenio = await _context.Convenios
                .Include(c => c.Retribuciones) // Incluye las relaciones necesarias
                .FirstOrDefaultAsync(m => m.Id_Convenio == id);

            if (convenio == null)
            {
                return NotFound();
            }

            return View(convenio);
        }
        // Editar convenio (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ConvenioModel convenio, bool RenovacionAutomatica)
        {
            if (id != convenio.Id_Convenio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (RenovacionAutomatica)
                    {
                        convenio.Fecha_Termino = convenio.Fecha_Inicio.AddYears(1);
                    }

                    _context.Update(convenio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Convenios.Any(e => e.Id_Convenio == id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Sedes = new List<string> { "Santiago", "Coquimbo", "Ambas" };
            ViewBag.TiposRetribucion = _context.Retribuciones.Select(r => r.Tipo_Retribucion).Distinct().ToList();
            return View(convenio);
        }
        public IActionResult Delete(int id)
        {
            var convenio = _context.Convenios.Find(id);
            if (convenio != null)
            {
                _context.Convenios.Remove(convenio);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}

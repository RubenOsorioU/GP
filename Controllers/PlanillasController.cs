using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Collections.Generic;
using Gestion_Del_Presupuesto.Data;
using Gestion_Del_Presupuesto.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using CsvHelper;
using System.Globalization;

namespace Gestion_Del_Presupuesto.Controllers
{
    public class PlanillasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlanillasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Planillas
        public async Task<IActionResult> Index(string institucion, string servicio, string tipoPrograma,
            string nombreEstudiante, string runEstudiante, DateTime? fechaInicio, DateTime? fechaTermino)
        {
            var planillasQuery = _context.Planillas
                .Where(p => !p.Eliminado)
                .AsQueryable();

            // Aplicar filtros
            if (!string.IsNullOrWhiteSpace(institucion))
            {
                planillasQuery = planillasQuery.Where(p => p.Institucion.Contains(institucion));
            }

            if (!string.IsNullOrWhiteSpace(servicio))
            {
                planillasQuery = planillasQuery.Where(p => p.Servicio.Contains(servicio));
            }

            if (!string.IsNullOrWhiteSpace(tipoPrograma))
            {
                planillasQuery = planillasQuery.Where(p => p.TipoPrograma == tipoPrograma);
            }

            if (!string.IsNullOrWhiteSpace(nombreEstudiante))
            {
                planillasQuery = planillasQuery.Where(p => p.NombresApellidosEstudiante.Contains(nombreEstudiante));
            }

            if (!string.IsNullOrWhiteSpace(runEstudiante))
            {
                planillasQuery = planillasQuery.Where(p => p.RunEstudiante.Contains(runEstudiante));
            }

            if (fechaInicio.HasValue)
            {
                planillasQuery = planillasQuery.Where(p => p.FechaInicioPractica >= fechaInicio.Value);
            }

            if (fechaTermino.HasValue)
            {
                planillasQuery = planillasQuery.Where(p => p.FechaTerminoPractica <= fechaTermino.Value);
            }

            var planillas = await planillasQuery.ToListAsync();
            return View(planillas);
        }

        // GET: Planillas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planilla = await _context.Planillas
                .FirstOrDefaultAsync(m => m.Id_Planillas == id);

            if (planilla == null)
            {
                return NotFound();
            }

            return View(planilla);
        }

        // GET: Planillas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Planillas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PlanillasModel planilla)
        {
            if (ModelState.IsValid)
            {
                planilla.Eliminado = false; // Asegurar que no esté marcado como eliminado
                _context.Add(planilla);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(planilla);
        }

        // GET: Planillas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planilla = await _context.Planillas.FindAsync(id);
            if (planilla == null)
            {
                return NotFound();
            }
            return View(planilla);
        }

        // POST: Planillas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PlanillasModel planilla)
        {
            if (id != planilla.Id_Planillas)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(planilla);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlanillaExists(planilla.Id_Planillas))
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
            return View(planilla);
        }

        // Soft Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planilla = await _context.Planillas
                .FirstOrDefaultAsync(m => m.Id_Planillas == id);

            if (planilla == null)
            {
                return NotFound();
            }

            return View(planilla);
        }

        // Soft Delete Confirmation
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var planilla = await _context.Planillas.FindAsync(id);
            planilla.Eliminado = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Registro Histórico (Mostrar elementos eliminados)
        public async Task<IActionResult> RegistroHistoricoEstudiantes()
        {
            var planillasEliminadas = await _context.Planillas
                .Where(p => p.Eliminado)
                .ToListAsync();
            return View(planillasEliminadas);
        }

        // Restaurar Planilla
        public async Task<IActionResult> Restore(int id)
        {
            var planilla = await _context.Planillas.FindAsync(id);
            if (planilla != null)
            {
                planilla.Eliminado = false;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(RegistroHistoricoEstudiantes));
        }

        // Eliminar Permanentemente
        public async Task<IActionResult> DeletePermanent(int id)
        {
            var planilla = await _context.Planillas.FindAsync(id);
            if (planilla != null)
            {
                _context.Planillas.Remove(planilla);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(RegistroHistoricoEstudiantes));
        }

        // Subir Planillas desde CSV
        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                ViewBag.Message = "Selecciona un archivo válido.";
                return View();
            }

            // Validar la extensión del archivo
            var fileExtension = Path.GetExtension(file.FileName);
            if (fileExtension != ".csv")
            {
                ViewBag.Message = "Por favor, sube un archivo CSV válido.";
                return View();
            }

            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
            Directory.CreateDirectory(uploadsFolder);

            var filePath = Path.Combine(uploadsFolder, file.FileName);

            try
            {
                // Guardar el archivo en el servidor
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<PlanillasModel>().ToList();

                    // Validar si los registros son correctos antes de agregar
                    if (records.Any())
                    {
                        // Marcar como no eliminados al importar
                        records.ForEach(r => r.Eliminado = false);

                        _context.Planillas.AddRange(records);
                        await _context.SaveChangesAsync();

                        ViewBag.Message = "Archivo subido y procesado correctamente.";
                    }
                    else
                    {
                        ViewBag.Message = "El archivo CSV está vacío o no tiene registros válidos.";
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"Error procesando el archivo: {ex.Message}";
            }

            return RedirectToAction(nameof(Index));
        }

        private bool PlanillaExists(int id)
        {
            return _context.Planillas.Any(e => e.Id_Planillas == id && !e.Eliminado);
        }
    }
}

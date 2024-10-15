using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Collections.Generic;
using Gestion_Del_Presupuesto.Data;
using Gestion_Del_Presupuesto.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
        public async Task<IActionResult> Index()
        {
            var planillas = await _context.Planillas.ToListAsync();
            return View(planillas);
        }

        // GET: Planillas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planilla = await _context.Planillas.FirstOrDefaultAsync(m => m.Id_Planillas == id);
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
        public async Task<IActionResult> Create([Bind("Id_Planillas,Nombre_Planilla,Rut,Fecha_Inicio,Fecha_Termino,Institución,CuantasSemanas,ValorUfContrato,TotalCosto,Id_Estudiante")] PlanillasModel planilla)
        {
            if (ModelState.IsValid)
            {
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
        public async Task<IActionResult> Edit(int id, [Bind("Id_Planillas,Nombre_Planilla,Rut,Fecha_Inicio,Fecha_Termino,Institución,CuantasSemanas,ValorUfContrato,TotalCosto,Id_Estudiante")] PlanillasModel planilla)
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

        // GET: Planillas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planilla = await _context.Planillas.FirstOrDefaultAsync(m => m.Id_Planillas == id);
            if (planilla == null)
            {
                return NotFound();
            }

            return View(planilla);
        }

        // POST: Planillas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var planilla = await _context.Planillas.FindAsync(id);
            _context.Planillas.Remove(planilla);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlanillaExists(int id)
        {
            return _context.Planillas.Any(e => e.Id_Planillas == id);
        }

        // GET: Planillas/Upload
        public IActionResult Upload()
        {
            return View();
        }

        // POST: Planillas/Upload
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                ViewBag.Message = "Selecciona un archivo válido.";
                return View();
            }

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "uploads", file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Lógica para leer el archivo y agregar los datos a la tabla
            // Aquí puedes agregar código para leer el archivo Excel o CSV y guardar los datos

            ViewBag.Message = "Archivo subido y procesado correctamente.";
            return RedirectToAction(nameof(Index));
        }
    }
}

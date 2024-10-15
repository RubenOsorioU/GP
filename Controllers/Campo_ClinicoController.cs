using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gestion_Del_Presupuesto.Data;
using Gestion_Del_Presupuesto.Models;

namespace Gestion_Del_Presupuesto.Controllers
{
    public class Campo_ClinicoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Campo_ClinicoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Campo_Clinico/Index
        public async Task<IActionResult> Index()
        {
            // Muestra la lista de todos los campos clínicos en la base de datos
            return View(await _context.Campo_Clinicos.ToListAsync());
        }

        // GET: Campo_Clinico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campo_Clinico = await _context.Campo_Clinicos
                .FirstOrDefaultAsync(m => m.Id_Campo_Clinico == id);
            if (campo_Clinico == null)
            {
                return NotFound();
            }

            return View(campo_Clinico);
        }

        // GET: Campo_Clinico/Create
        public IActionResult Create()
        {
            // Muestra el formulario para crear un nuevo campo clínico
            return View();
        }

        // POST: Campo_Clinico/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nombre,Tipo,Sede")] Campo_Clinico campo_Clinico)
        {
            if (ModelState.IsValid)
            {
                // Agrega el nuevo campo clínico a la base de datos
                _context.Add(campo_Clinico);
                await _context.SaveChangesAsync();  // Guarda los cambios

                // Redirige a la vista Index después de crear el nuevo registro
                return RedirectToAction(nameof(Index));
            }

            // Si hay errores en el modelo, vuelve a la vista Create
            return View(campo_Clinico);
        }

        // GET: Campo_Clinico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campo_Clinico = await _context.Campo_Clinicos.FindAsync(id);
            if (campo_Clinico == null)
            {
                return NotFound();
            }
            return View(campo_Clinico);
        }

        // POST: Campo_Clinico/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nombre,Tipo,Sede")] Campo_Clinico campo_Clinico)
        {
            if (id != campo_Clinico.Id_Campo_Clinico)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Actualiza el campo clínico en la base de datos
                    _context.Update(campo_Clinico);
                    await _context.SaveChangesAsync();  // Guarda los cambios
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Campo_ClinicoExists(campo_Clinico.Id_Campo_Clinico))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));  // Redirige al index después de editar
            }
            return View(campo_Clinico);  // Si hay errores, muestra la vista de edición de nuevo
        }

        // GET: Campo_Clinico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campo_Clinico = await _context.Campo_Clinicos
                .FirstOrDefaultAsync(m => m.Id_Campo_Clinico == id);
            if (campo_Clinico == null)
            {
                return NotFound();
            }

            return View(campo_Clinico);
        }

        // POST: Campo_Clinico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var campo_Clinico = await _context.Campo_Clinicos.FindAsync(id);
            if (campo_Clinico != null)
            {
                _context.Campo_Clinicos.Remove(campo_Clinico);  // Elimina el registro de la base de datos
            }

            await _context.SaveChangesAsync();  // Guarda los cambios
            return RedirectToAction(nameof(Index));  // Redirige al index después de eliminar
        }

        private bool Campo_ClinicoExists(int id)
        {
            // Verifica si un campo clínico existe en la base de datos
            return _context.Campo_Clinicos.Any(e => e.Id_Campo_Clinico == id);
        }
    }
}

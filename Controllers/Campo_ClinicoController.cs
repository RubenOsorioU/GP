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

        // GET: Campo_Clinico
        public async Task<IActionResult> Index()
        {
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
            return View();
        }

        // POST: Campo_Clinico/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Campo_Clinico,Nombre,Ubicacion,Tipo")] Campo_Clinico campo_Clinico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(campo_Clinico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
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
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Campo_Clinico,Nombre,Ubicacion,Tipo")] Campo_Clinico campo_Clinico)
        {
            if (id != campo_Clinico.Id_Campo_Clinico)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(campo_Clinico);
                    await _context.SaveChangesAsync();
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
                return RedirectToAction(nameof(Index));
            }
            return View(campo_Clinico);
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
                _context.Campo_Clinicos.Remove(campo_Clinico);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Campo_ClinicoExists(int id)
        {
            return _context.Campo_Clinicos.Any(e => e.Id_Campo_Clinico == id);
        }
    }
}

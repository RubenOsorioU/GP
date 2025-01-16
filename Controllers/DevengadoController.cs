using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gestion_Del_Presupuesto.Models;
using Gestion_Del_Presupuesto.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gestion_Del_Presupuesto.Controllers
{
    public class DevengadoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DevengadoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var devengados = await _context.Devengados.Include(d => d.Convenio).ToListAsync();
            return View(devengados);
        }

        // GET: Devengado/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var devengado = await _context.Devengados
                .Include(d => d.Convenio)
                .FirstOrDefaultAsync(m => m.Id_Devengado == id);

            if (devengado == null)
            {
                return NotFound();
            }

            return View(devengado);
        }

        // GET: Devengado/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Devengado/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id_Devengado,Carrera,CentroCosto,Itempresupuestario,FechaInicio,FechaFin,CantidadTiempo,GastoTotalComprometidoMonto,CantEstudiantes,ValorUFDevengado,CostoUF,PagosRealizados,SaldoPendiente,Descripcion,TotalGastoDevengadoGeneradoporEstudiantes,ConvenioId")] Devengado devengado)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(devengado);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["ConvenioId"] = new SelectList(_context.Convenios, "Id", "Nombre", devengado.ConvenioId);
        //    return View(devengado);
        //}

        // GET: Devengado/Edit/
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var devengado = await _context.Devengados.FindAsync(id);
            if (devengado == null)
            {
                return NotFound();
            }
            ViewData["ConvenioId"] = new SelectList(_context.Convenios, "Id", "Nombre", devengado.ConvenioId);
            return View(devengado);
        }

        // POST: Devengado/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Devengado,Carrera,CentroCosto,Itempresupuestario,FechaInicio,FechaFin,CantidadTiempo,GastoTotalComprometidoMonto,CantEstudiantes,ValorUFDevengado,CostoUF,PagosRealizados,SaldoPendiente,Descripcion,TotalGastoDevengadoGeneradoporEstudiantes,ConvenioId")] Devengado devengado)
        {
            if (id != devengado.Id_Devengado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(devengado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DevengadoExists(devengado.Id_Devengado))
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
            ViewData["ConvenioId"] = new SelectList(_context.Convenios, "Id", "Nombre", devengado.ConvenioId);
            return View(devengado);
        }

        // GET: Devengado/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var devengado = await _context.Devengados
                .Include(d => d.Convenio)
                .FirstOrDefaultAsync(m => m.Id_Devengado == id);
            if (devengado == null)
            {
                return NotFound();
            }

            return View(devengado);
        }

        // POST: Devengado/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var devengado = await _context.Devengados.FindAsync(id);
            _context.Devengados.Remove(devengado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DevengadoExists(int id)
        {
            return _context.Devengados.Any(e => e.Id_Devengado == id);
        }
        [HttpPost]
        public async Task<IActionResult> CalcularDevengado(int id)
        {
            // Recuperar la instancia de Devengado desde la base de datos
            var devengado = await _context.Devengados.FindAsync(id);
            if (devengado == null)
            {
                return NotFound("Devengado no encontrado");
            }

            // Llamar al método CalcularDevengado
            var totalDevengado = devengado.CalcularDevengado();

            // Actualizar el valor en la base de datos (si es necesario)
            devengado.TotalGastoDevengadoGeneradoporEstudiantes = totalDevengado;
            _context.Update(devengado);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Filter(string convenioNombre, int? estudiantes, DateTime? fechaInicio, DateTime? fechaFin)
        {
            var query = _context.Devengados.Include(d => d.Convenio).AsQueryable();

            if (!string.IsNullOrEmpty(convenioNombre))
            {
                query = query.Where(d => d.Convenio.Nombre.Contains(convenioNombre));
            }
            if (estudiantes.HasValue)
            {
                query = query.Where(d => d.CantEstudiantes == estudiantes.Value);
            }
            if (fechaInicio.HasValue)
            {
                query = query.Where(d => d.FechaInicio >= fechaInicio.Value);
            }
            if (fechaFin.HasValue)
            {
                query = query.Where(d => d.FechaFin <= fechaFin.Value);
            }

            var viewModel = new DevengadoViewModel
            {
                FechaInicio = fechaInicio ?? DateTime.Now,
                FechaFin = fechaFin ?? DateTime.Now,
                Devengados = await query.ToListAsync()
            };

            ViewData["ConvenioNombre"] = convenioNombre;
            ViewData["Estudiantes"] = estudiantes;
            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> CalcularDevengadoFiltrado(string convenioNombre, int? estudiantes, DateTime? fechaInicio, DateTime? fechaFin)
        {
            var query = _context.Devengados.Include(d => d.Convenio).AsQueryable();

            // Aplicar filtros condicionales
            if (!string.IsNullOrEmpty(convenioNombre))
            {
                query = query.Where(d => d.Convenio.Nombre.Contains(convenioNombre));
            }
            if (estudiantes.HasValue)
            {
                query = query.Where(d => d.CantEstudiantes == estudiantes.Value);
            }
            if (fechaInicio.HasValue)
            {
                query = query.Where(d => d.FechaInicio >= fechaInicio.Value);
            }
            if (fechaFin.HasValue)
            {
                query = query.Where(d => d.FechaFin <= fechaFin.Value);
            }

            var devengadosFiltrados = await query.ToListAsync();

            // Realizar cálculo para los devengados filtrados
            foreach (var devengado in devengadosFiltrados)
            {
                devengado.TotalGastoDevengadoGeneradoporEstudiantes = devengado.CalcularDevengado();
                _context.Update(devengado);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("Filter", new { convenioNombre, estudiantes, fechaInicio, fechaFin });
        }

    }
}

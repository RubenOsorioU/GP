using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Gestion_Del_Presupuesto.Data;
using Gestion_Del_Presupuesto.Models;

namespace Gestion_Del_Presupuesto.Controllers
{
    public class DevengadosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DevengadosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(DateTime? fechaInicio, DateTime? fechaFin)
        {
            var viewModel = new DevengadoViewModel();

            // Filtrar los devengados según las fechas proporcionadas
            var devengadosQuery = _context.Devengados.AsQueryable();

            if (fechaInicio.HasValue)
            {
                devengadosQuery = devengadosQuery.Where(d => d.Fecha >= fechaInicio.Value);
                viewModel.FechaInicio = fechaInicio.Value;
            }

            if (fechaFin.HasValue)
            {
                devengadosQuery = devengadosQuery.Where(d => d.Fecha <= fechaFin.Value);
                viewModel.FechaFin = fechaFin.Value;
            }

            viewModel.Devengados = devengadosQuery.ToList();

            return View(viewModel);
        }
    }
}

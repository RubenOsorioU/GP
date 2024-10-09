using Gestion_Del_Presupuesto.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Gestion_Del_Presupuesto.Controllers
{
    public class DetalleGeneralController : Controller
    {
        private static List<DetalleGeneralModel> detalles = new List<DetalleGeneralModel>();

        // GET: DetalleGeneral/Index
        public IActionResult Index()
        {
            return View(detalles);
        }

        // GET: DetalleGeneral/Create
        public IActionResult Create()
        {
            ViewBag.InstitucionesPorTipo = GetInstitucionesPorTipo(); // Asegúrate de que esto esté correcto
            return View();
        }

        // POST: DetalleGeneral/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DetalleGeneralModel model)
        {
            if (ModelState.IsValid)
            {
                model.Id = detalles.Count + 1;
                detalles.Add(model);
                return RedirectToAction(nameof(Index));
            }

            // Asegúrate de que ViewBag.InstitucionesPorTipo no sea null
            ViewBag.InstitucionesPorTipo = GetInstitucionesPorTipo(); // Esto debe estar aquí también
            return View(model);
        }

        // Otros métodos (Edit, Delete, etc.)

        private Dictionary<string, List<string>> GetInstitucionesPorTipo()
        {
            return new Dictionary<string, List<string>>()
            {
                { "Hospitales_Clinicas", new List<string> { "Hospital Barros Luco", "Dipreca", "Hospital San Luis de Buin" } },
                { "Atencion primaria", new List<string> { "Corporacion de Buin", "Municipalidad de La Granja" } },
            };
        }
    }
}

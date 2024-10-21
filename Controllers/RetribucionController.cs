using Gestion_Del_Presupuesto.Data; // Asegúrate de incluir la directiva de espacio de nombres
using Gestion_Del_Presupuesto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Gestion_Del_Presupuesto.Controllers
{
    public class RetribucionController : Controller
    {
        // Declarar el campo privado para el contexto
        private readonly ApplicationDbContext _context;

        // Constructor con inyección de dependencias
        public RetribucionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RetribucionController
        public ActionResult Index()
        {
            return View();
        }

        // GET: RetribucionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RetribucionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RetribucionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RetribucionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RetribucionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RetribucionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RetribucionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // Acción para seleccionar retribuciones
        public IActionResult SeleccionarRetribuciones()
        {
            // Consultar la lista de retribuciones desde la base de datos
            var retribuciones = _context.Retribuciones.Select(r => new
            {
                Id_Retribucion = r.Id_Retribucion,
                Nombre = r.Nombre
            }).ToList();

            // Pasar la lista a ViewBag
            ViewBag.ProcesosRetribucion = retribuciones;

            return View();
        }
    }
}

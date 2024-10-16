﻿using Gestion_Del_Presupuesto.Data;
using Gestion_Del_Presupuesto.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Gestion_Del_Presupuesto.Controllers
{
    public class FacturacionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FacturacionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FacturacionController
        public ActionResult Index()
        {
            var facturaciones = _context.Facturacion.ToList();
            return View(facturaciones);
        }

        // GET: FacturacionController/Details/5
        public ActionResult Details(int id)
        {
            var facturacion = _context.Facturacion.Find(id);
            if (facturacion == null)
            {
                return NotFound();
            }
            return View(facturacion);
        }

        // GET: FacturacionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FacturacionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FacturacionModel facturacion)
        {
            if (ModelState.IsValid)
            {
                _context.Facturacion.Add(facturacion);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(facturacion);
        }

        // GET: FacturacionController/Edit/5
        public ActionResult Edit(int id)
        {
            var facturacion = _context.Facturacion.Find(id);
            if (facturacion == null)
            {
                return NotFound();
            }
            return View(facturacion);
        }

        // POST: FacturacionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FacturacionModel facturacion)
        {
            if (id != facturacion.Id_Facturacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(facturacion);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(facturacion);
        }

        // GET: FacturacionController/Delete/5
        public ActionResult Delete(int id)
        {
            var facturacion = _context.Facturacion.Find(id);
            if (facturacion == null)
            {
                return NotFound();
            }
            return View(facturacion);
        }

        // POST: FacturacionController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var facturacion = _context.Facturacion.Find(id);
            _context.Facturacion.Remove(facturacion);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
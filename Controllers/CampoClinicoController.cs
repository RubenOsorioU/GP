using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gestion_Del_Presupuesto.Data;
using Gestion_Del_Presupuesto.Models;
using System.Collections.Generic;

namespace Gestion_Del_Presupuesto.Controllers
{
    public class Campo_ClinicoController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Diccionario con campos clínicos y sus tipos por sede
        private static Dictionary<string, List<(string Campo, string Tipo)>> camposPorSede = new Dictionary<string, List<(string Campo, string Tipo)>>()
        {
            { "Santiago", new List<(string, string)>
                {
                    // HOSPITALES / CLÍNICAS
                    ("Hospital Barros Lucos", "HOSPITALES / CLÍNICAS"),
                    ("Dipreca", "HOSPITALES / CLÍNICAS"),
                    ("Hospital San Luis de Buin", "HOSPITALES / CLÍNICAS"),
                    ("INCANCER", "HOSPITALES / CLÍNICAS"),
                    ("Hospital San Borja Arriaran", "HOSPITALES / CLÍNICAS"),
                    ("Mutual de Seguridad", "HOSPITALES / CLÍNICAS"),
                    ("Clínica Cordillera", "HOSPITALES / CLÍNICAS"),
                    ("Capredena", "HOSPITALES / CLÍNICAS"),
                    ("Hospital Salvador", "HOSPITALES / CLÍNICAS"),
                    ("Hospital Luis Calvo Mackenna", "HOSPITALES / CLÍNICAS"),
                    ("Hospital Horwitz", "HOSPITALES / CLÍNICAS"),
                    ("Hospital El Peral", "HOSPITALES / CLÍNICAS"),
                    ("CESA Uandes (Hospital Parroquial San Bernardo)", "HOSPITALES / CLÍNICAS"),

                    // ATENCIÓN PRIMARIA
                    ("Corporación de Buin", "ATENCIÓN PRIMARIA"),
                    ("Municipalidad de La Granja", "ATENCIÓN PRIMARIA"),
                    ("Corporación de Lampa", "ATENCIÓN PRIMARIA"),
                    ("Corporación de Puente Alto", "ATENCIÓN PRIMARIA"),
                    ("Municipalidad La Pintana", "ATENCIÓN PRIMARIA"),
                    ("Corporación de Macul", "ATENCIÓN PRIMARIA"),
                    ("Municipalidad de Recoleta", "ATENCIÓN PRIMARIA"),
                    ("Corporación de Quinta Normal", "ATENCIÓN PRIMARIA"),
                    ("Corporación Pedro Aguirre Cerda", "ATENCIÓN PRIMARIA"),
                    ("Corporación San Bernardo", "ATENCIÓN PRIMARIA"),
                    ("Municipalidad de Cerro Navia", "ATENCIÓN PRIMARIA"),
                    ("Municipalidad de Independencia", "ATENCIÓN PRIMARIA"),
                    ("Municipalidad de Lo Espejo", "ATENCIÓN PRIMARIA"),
                    ("Municipalidad de Estación Central", "ATENCIÓN PRIMARIA"),
                    ("Municipalidad de Peñalolén", "ATENCIÓN PRIMARIA"),
                    ("Municipalidad de Quilicura", "ATENCIÓN PRIMARIA"),
                    ("Corporación de Deportes de Cerro Navia", "ATENCIÓN PRIMARIA"),

                    // HOGARES / CENTROS EDUCACIONALES
                    ("Fundación Cerro Navia Joven", "HOGARES / CENTROS EDUCACIONALES"),
                    ("ACALIS (Sociedad de Inversiones Atardeceres S.A.)", "HOGARES / CENTROS EDUCACIONALES"),
                    ("CONVATEC (Boston Medical Device de Chile S.A.)", "HOGARES / CENTROS EDUCACIONALES"),
                    ("Fundación Villa Padre Hurtado", "HOGARES / CENTROS EDUCACIONALES"),
                    ("Convenio Tripartita (colegios San Bernardo)", "HOGARES / CENTROS EDUCACIONALES"),
                    ("Paul Harris (Colegio Paul Harris)", "HOGARES / CENTROS EDUCACIONALES"),
                    ("Fundación BELEN (Pie Crescente Errazuriz)", "HOGARES / CENTROS EDUCACIONALES"),
                    ("Escuela Isabel González Cares", "HOGARES / CENTROS EDUCACIONALES"),
                    ("Escuela Bella Acuarela (Fundación Educacional Alegría y Alma)", "HOGARES / CENTROS EDUCACIONALES"),
                    ("Fundación Educacional San Francisco Pudahuel (PIE Ana Eugenia)", "HOGARES / CENTROS EDUCACIONALES"),
                    ("Corporación Molokai (3 colegios)", "HOGARES / CENTROS EDUCACIONALES"),
                    ("Corporación PIRAMIDE (5 colegios)", "HOGARES / CENTROS EDUCACIONALES"),
                    ("Pequeño COTOLENGO (Congregación Pequeña Obra de la Divina Providencia)", "HOGARES / CENTROS EDUCACIONALES"),

                    // LAB/IMAGEN/OFTALMOLOGÍA
                    ("REDLAB", "LAB/IMAGEN/OFTALMOLOGÍA"),
                    ("Clínica Visión Rancagua", "LAB/IMAGEN/OFTALMOLOGÍA"),
                    ("Instituto Oftalmológico Integral (IOI)", "LAB/IMAGEN/OFTALMOLOGÍA"),
                    ("Centro Médico Blanco", "LAB/IMAGEN/OFTALMOLOGÍA"),
                    ("FARR", "LAB/IMAGEN/OFTALMOLOGÍA"),

                    // CENTROS Y FUNDACIONES
                    ("SENAME", "CENTROS Y FUNDACIONES"),
                    ("Hogar de Cristo", "CENTROS Y FUNDACIONES"),
                    ("CEDET", "CENTROS Y FUNDACIONES"),
                    ("Centro de Adultos Mayores SPA, Capacito", "CENTROS Y FUNDACIONES"),
                    ("Centro de Desarrollo Infantil GOING UP", "CENTROS Y FUNDACIONES"),
                    ("Moviliza", "CENTROS Y FUNDACIONES"),
                    ("PRUFODIS", "CENTROS Y FUNDACIONES"),
                    ("CORFAPES", "CENTROS Y FUNDACIONES"),
                    ("FUNDACIÓN AGRUPATE", "CENTROS Y FUNDACIONES"),
                    ("Vicente Palotti", "CENTROS Y FUNDACIONES"),
                    ("CENTRO GIRASOL", "CENTROS Y FUNDACIONES"),
                    ("CETRAM", "CENTROS Y FUNDACIONES"),
                    ("Casa de Reposo Las Nieves", "CENTROS Y FUNDACIONES"),
                    ("Fundación Cristo Vive", "CENTROS Y FUNDACIONES"),
                    ("ONG Fraternidad LAS VIÑAS", "CENTROS Y FUNDACIONES"),
                    ("Corporación Alzheimer", "CENTROS Y FUNDACIONES"),
                    ("TEACAN SpA Cahuelche", "CENTROS Y FUNDACIONES"),
                    ("TO Kumelen", "CENTROS Y FUNDACIONES"),
                    ("Fundación CELEI", "CENTROS Y FUNDACIONES"),
                    ("Corporación Casa del Cerro", "CENTROS Y FUNDACIONES"),
                    ("Instituto Chileno de Psicoterapia Integrativa", "CENTROS Y FUNDACIONES"),
                    ("Arteduca", "CENTROS Y FUNDACIONES"),
                    ("Instituto Chileno de Terapia Familiar", "CENTROS Y FUNDACIONES"),
                    ("Fundación CESI", "CENTROS Y FUNDACIONES"),
                    ("Corporación Dolores Sopeña", "CENTROS Y FUNDACIONES"),
                    ("Fundación Mi Ángel Gabriel", "CENTROS Y FUNDACIONES"),
                    ("ONG Cidets", "CENTROS Y FUNDACIONES"),
                    ("Sociedad Protectora de Ciegos Santa Lucía", "CENTROS Y FUNDACIONES"),
                    ("ONG La Casona", "CENTROS Y FUNDACIONES"),
                    ("Centro Terapéutico Aurora", "CENTROS Y FUNDACIONES"),
                    ("Fundación Santa Gabriela", "CENTROS Y FUNDACIONES"),
                    ("Fundación LUZ", "CENTROS Y FUNDACIONES"),
                    ("Oportunidades Terapéuticas SpA", "CENTROS Y FUNDACIONES"),
                    ("La CALETA", "CENTROS Y FUNDACIONES"),
                    ("Centro Espacio Seguro SpA", "CENTROS Y FUNDACIONES"),

                    // CASINOS
                    ("Casona El Monte", "CASINOS"),
                    ("INTA", "CASINOS"),
                    ("Chile Pan", "CASINOS")
                }
            },

            { "La Serena", new List<(string, string)>
                {
                    // HOSPITALES / CLÍNICAS
                    ("Hospital Salvador", "HOSPITALES / CLÍNICAS"),
                    ("Hospital Luis Calvo Mackenna", "HOSPITALES / CLÍNICAS"),
                    ("Hospital Horwitz", "HOSPITALES / CLÍNICAS"),
                    ("Hospital El Peral", "HOSPITALES / CLÍNICAS"),
                    ("Clínica Cordillera", "HOSPITALES / CLÍNICAS"),
                    ("Capredena", "HOSPITALES / CLÍNICAS"),

                    // ATENCIÓN PRIMARIA
                    ("Corporación de Buin", "ATENCIÓN PRIMARIA"),
                    ("Municipalidad de La Granja", "ATENCIÓN PRIMARIA"),
                    ("Corporación de Lampa", "ATENCIÓN PRIMARIA"),
                    ("Corporación de Puente Alto", "ATENCIÓN PRIMARIA"),
                    ("Municipalidad La Pintana", "ATENCIÓN PRIMARIA"),
                    ("Corporación de Macul", "ATENCIÓN PRIMARIA"),
                    ("Municipalidad de Recoleta",                     "ATENCIÓN PRIMARIA"),
                    ("Corporación de Quinta Normal", "ATENCIÓN PRIMARIA"),
                    ("Corporación Pedro Aguirre Cerda", "ATENCIÓN PRIMARIA"),
                    ("Corporación San Bernardo", "ATENCIÓN PRIMARIA"),
                    ("Municipalidad de Cerro Navia", "ATENCIÓN PRIMARIA"),
                    ("Municipalidad de Independencia", "ATENCIÓN PRIMARIA"),
                    ("Municipalidad de Lo Espejo", "ATENCIÓN PRIMARIA"),
                    ("Municipalidad de Estación Central", "ATENCIÓN PRIMARIA"),
                    ("Municipalidad de Peñalolén", "ATENCIÓN PRIMARIA"),
                    ("Municipalidad de Quilicura", "ATENCIÓN PRIMARIA"),
                    ("Corporación de Deportes de Cerro Navia", "ATENCIÓN PRIMARIA"),

                    // HOGARES / CENTROS EDUCACIONALES
                    ("Fundación Cerro Navia Joven", "HOGARES / CENTROS EDUCACIONALES"),
                    ("ACALIS (Sociedad de Inversiones Atardeceres S.A.)", "HOGARES / CENTROS EDUCACIONALES"),
                    ("CONVATEC (Boston Medical Device de Chile S.A.)", "HOGARES / CENTROS EDUCACIONALES"),
                    ("Fundación Villa Padre Hurtado", "HOGARES / CENTROS EDUCACIONALES"),
                    ("Convenio Tripartita (colegios San Bernardo)", "HOGARES / CENTROS EDUCACIONALES"),
                    ("Paul Harris (Colegio Paul Harris)", "HOGARES / CENTROS EDUCACIONALES"),
                    ("Fundación BELEN (Pie Crescente Errazuriz)", "HOGARES / CENTROS EDUCACIONALES"),
                    ("Escuela Isabel González Cares", "HOGARES / CENTROS EDUCACIONALES"),
                    ("Escuela Bella Acuarela (Fundación Educacional Alegría y Alma)", "HOGARES / CENTROS EDUCACIONALES"),
                    ("Fundación Educacional San Francisco Pudahuel (PIE Ana Eugenia)", "HOGARES / CENTROS EDUCACIONALES"),
                    ("Corporación Molokai (3 colegios)", "HOGARES / CENTROS EDUCACIONALES"),
                    ("Corporación PIRAMIDE (5 colegios)", "HOGARES / CENTROS EDUCACIONALES"),
                    ("Pequeño COTOLENGO (Congregación Pequeña Obra de la Divina Providencia)", "HOGARES / CENTROS EDUCACIONALES"),

                    // LAB/IMAGEN/OFTALMOLOGÍA
                    ("REDLAB", "LAB/IMAGEN/OFTALMOLOGÍA"),
                    ("Clínica Visión Rancagua", "LAB/IMAGEN/OFTALMOLOGÍA"),
                    ("Instituto Oftalmológico Integral (IOI)", "LAB/IMAGEN/OFTALMOLOGÍA"),
                    ("Centro Médico Blanco", "LAB/IMAGEN/OFTALMOLOGÍA"),
                    ("FARR", "LAB/IMAGEN/OFTALMOLOGÍA")
                }
            }
        };

        public Campo_ClinicoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Campo_Clinico/Index
        public async Task<IActionResult> Index()
        {
            var camposClinicos = await _context.Campo_Clinicos
                .Include(c => c.Estudiantes)
                .Include(c => c.Convenios)
                .ToListAsync();

            return View(camposClinicos);
        }

        // GET: Campo_Clinico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campo_Clinico = await _context.Campo_Clinicos
                .Include(c => c.Estudiantes)
                .Include(c => c.Convenios)
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
            ViewBag.Sedes = camposPorSede.Keys.ToList();  // Enviar la lista de sedes
            ViewBag.CamposPorSede = camposPorSede;  // Enviar los campos clínicos agrupados por sede
            return View();
        }

        // POST: Campo_Clinico/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Campo_Clinico campo_Clinico)
        {
            if (ModelState.IsValid)
            {
                // Obtener el tipo de campo clínico basado en el nombre y la sede seleccionada
                if (camposPorSede.TryGetValue(campo_Clinico.Sede, out var camposEnSede))
                {
                    var campoInfo = camposEnSede.FirstOrDefault(c => c.Campo == campo_Clinico.Nombre);
                    if (campoInfo != default)
                    {
                        campo_Clinico.Tipo = campoInfo.Tipo;
                    }
                }

                _context.Add(campo_Clinico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Sedes = camposPorSede.Keys.Distinct().ToList();  // Volver a cargar las sedes si hay errores
            ViewBag.CamposPorSede = camposPorSede;  // Volver a cargar los campos por sede si hay errores
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

            ViewBag.Sedes = camposPorSede.Keys.ToList();  // Enviar la lista de sedes
            ViewBag.CamposPorSede = camposPorSede;  // Enviar los campos clínicos agrupados por sede
            return View(campo_Clinico);
        }

        // POST: Campo_Clinico/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Campo_Clinico campo_Clinico)
        {
            if (id != campo_Clinico.Id_Campo_Clinico)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Obtener el tipo de campo clínico basado en el nombre y la sede seleccionada
                    if (camposPorSede.TryGetValue(campo_Clinico.Sede, out var camposEnSede))
                    {
                        var campoInfo = camposEnSede.FirstOrDefault(c => c.Campo == campo_Clinico.Nombre);
                        if (campoInfo != default)
                        {
                            campo_Clinico.Tipo = campoInfo.Tipo;
                        }
                    }

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

            ViewBag.Sedes = camposPorSede.Keys.ToList();
            ViewBag.CamposPorSede = camposPorSede;
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
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool Campo_ClinicoExists(int id)
        {
            return _context.Campo_Clinicos.Any(e => e.Id_Campo_Clinico == id);
        }
    }
}


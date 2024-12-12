using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Gestion_Del_Presupuesto.Data;
using Gestion_Del_Presupuesto.Models;

namespace Gestion_Del_Presupuesto.Controllers
{
    public class EncuestaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public EncuestaController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Encuesta/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Encuesta/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EncuestaModel encuesta, IFormFile archivo)
        {
            if (ModelState.IsValid)
            {
                // Verifica si se subió un archivo
                if (archivo != null && archivo.Length > 0)
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", archivo.FileName);

                    // Guarda el archivo en el directorio uploads
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await archivo.CopyToAsync(stream);
                    }

                    // Guarda la ruta del archivo en el modelo
                    encuesta.ArchivoRuta = "/uploads/" + archivo.FileName;
                }

                // Establecer la fecha de la encuesta
                encuesta.Fecha = DateTime.Now;

                // Guardar la encuesta en la base de datos
                _context.Encuesta.Add(encuesta);
                await _context.SaveChangesAsync();

                return RedirectToAction("Success");
            }

            return View(encuesta);
        }

        // GET: Encuesta/Success
        public IActionResult Success()
        {
            return View();
        }

        // GET: Encuesta/Index
        public IActionResult Index()
        {
            var encuestas = _context.Encuesta.ToList();
            return View(encuestas);
        }

        // GET: Encuesta/Analisis
        public IActionResult Analisis()
        {
            // Obtener todas las encuestas
            var encuestas = _context.Encuesta.ToList();

            // Realizar el análisis agrupando por tipo de encuesta y calculando el promedio de puntuación
            var analisis = encuestas.GroupBy(e => e.Tipo)
                                    .Select(g => new
                                    {
                                        Tipo = g.Key,
                                        TotalEncuestas = g.Count(),
                                        PromedioPuntuacion = g.Average(e => e.Puntuacion) // Calculando el promedio de puntuaciones
                                    }).ToList();

            // Pasar los resultados al View para mostrar
            return View(analisis);
        }
    }
}

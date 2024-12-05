using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Gestion_Del_Presupuesto.Data;
using Gestion_Del_Presupuesto.Models;
namespace Gestion_Del_Presupuesto.Controllers
{
    public class EncuestaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EncuestaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EncuestaSatisfaccion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EncuestaSatisfaccion/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EncuestaModel encuesta)
        {
            if (ModelState.IsValid)
            {
                encuesta.Fecha = DateTime.Now;
                _context.Encuesta.Add(encuesta);
                await _context.SaveChangesAsync();
                return RedirectToAction("Success");
            }
            return View(encuesta);
        }

        // GET: EncuestaSatisfaccion/Success
        public IActionResult Success()
        {
            return View();
        }

        // GET: EncuestaSatisfaccion/Index
        public IActionResult Index()
        {
            var encuestas = _context.Encuesta.ToList();
            return View(encuestas);
        }
    }
}

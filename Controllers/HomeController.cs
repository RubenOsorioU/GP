using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Gestion_Del_Presupuesto.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Gestion_Del_Presupuesto.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            // Contar convenios por sede
            var totalConvenios = await _context.Convenios.CountAsync(c => !c.Eliminado);
            var conveniosSantiago = await _context.Convenios.CountAsync(c => !c.Eliminado && c.Sede == "Santiago");
            var conveniosCoquimbo = await _context.Convenios.CountAsync(c => !c.Eliminado && c.Sede == "Coquimbo");
            var conveniosAmbas = await _context.Convenios.CountAsync(c => !c.Eliminado && c.Sede == "Ambas");
            // Pasar los valores a la vista usando ViewBag
            ViewBag.TotalConvenios = totalConvenios;
            ViewBag.ConveniosSantiago = conveniosSantiago;
            ViewBag.ConveniosCoquimbo = conveniosCoquimbo;
            ViewBag.ConvenisAmbas = conveniosAmbas;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}

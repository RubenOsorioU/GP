using Gestion_Del_Presupuesto.Data;
using Gestion_Del_Presupuesto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_Del_Presupuesto.Controllers
{
    public class ConvenioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConvenioController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string Nombre, string Tipo, string Sede)
        {
            var conveniosQuery = _context.Convenios.Include(c => c.Retribuciones).AsQueryable();

            if (!string.IsNullOrEmpty(Nombre))
            {
                conveniosQuery = conveniosQuery.Where(c => c.Nombre.Contains(Nombre));
            }
            if (!string.IsNullOrEmpty(Tipo))
            {
                conveniosQuery = conveniosQuery.Where(c => c.Tipo == Tipo);
            }
            if (!string.IsNullOrEmpty(Sede))
            {
                conveniosQuery = conveniosQuery.Where(c => c.Sede == Sede);
            }

            ViewBag.NombresConvenios = await _context.Convenios.Select(c => c.Nombre).Distinct().ToListAsync();
            ViewBag.TiposConvenios = await _context.Convenios.Select(c => c.Tipo).Distinct().ToListAsync();
            ViewBag.Sedes = new List<string> { "Santiago", "Coquimbo", "Ambas" };

            return View(await conveniosQuery.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewBag.Sedes = new List<string> { "Santiago", "Coquimbo", "Ambas" };
            ViewBag.TiposRetribucion = _context.Retribuciones.Select(r => r.Tipo_Retribucion).Distinct().ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ConvenioModel convenio, bool RenovacionAutomatica)
        {
            if (ModelState.IsValid)
            {
                convenio.Fecha_Inicio = DateTime.SpecifyKind(convenio.Fecha_Inicio, DateTimeKind.Utc);
                if (RenovacionAutomatica)
                {
                    convenio.Fecha_Termino = convenio.Fecha_Inicio.AddYears(1);
                }

                _context.Add(convenio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Sedes = new List<string> { "Santiago", "Coquimbo", "Ambas" };
            ViewBag.TiposRetribucion = _context.Retribuciones.Select(r => r.Tipo_Retribucion).Distinct().ToList();
            return View(convenio);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                ViewData["ErrorMessage"] = $"No se encontró un convenio con el ID {id}.";
                return NotFound();
            }

            var convenio = await _context.Convenios
                .Include(c => c.CentrosDeSalud)
                .Include(c => c.Retribuciones)
                .FirstOrDefaultAsync(m => m.Id_Convenio == id);

            if (convenio == null)
            {
                ViewData["ErrorMessage"] = $"No se encontró un convenio con el lalalalala {id}.";
                return NotFound();
            }

            return View(convenio);
        }

        // Editar convenio (GET)
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var convenio = await _context.Convenios
                .Include(c => c.Retribuciones)
                .Include(c => c.CentrosDeSalud)
                .FirstOrDefaultAsync(m => m.Id_Convenio == id);

            if (convenio == null)
            {
                return NotFound();
            }

            ViewBag.Sedes = new List<string> { "Santiago", "Coquimbo", "Ambas" };
            ViewBag.TiposRetribucion = _context.Retribuciones.Select(r => r.Tipo_Retribucion).Distinct().ToList();
            return View(convenio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ConvenioModel convenio, bool RenovacionAutomatica)
        {
            if (id != convenio.Id_Convenio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (RenovacionAutomatica)
                    {
                        convenio.Fecha_Termino = convenio.Fecha_Inicio.AddYears(1);
                    }

                    _context.Update(convenio);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Convenios.Any(e => e.Id_Convenio == id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            ViewBag.Sedes = new List<string> { "Santiago", "Coquimbo", "Ambas" };
            ViewBag.TiposRetribucion = _context.Retribuciones.Select(r => r.Tipo_Retribucion).Distinct().ToList();
            return View(convenio);
        }

        private bool ConvenioExists(int id)
        {
            return _context.Convenios.Any(e => e.Id_Convenio == id);
        }

        public IActionResult Delete(int id)
        {
            var convenio = _context.Convenios.Find(id);
            if (convenio != null)
            {
                _context.Convenios.Remove(convenio);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> ObtenerValorUF(string fecha)
        {
            string valorUF = await BuscarUF(fecha);
            return Json(new { valorUF });
        }
        public async Task<string> BuscarUF(string fecha)
        {
            //string url = $"https://mindicador.cl/api/uf/{SelectedDate.Year.ToString()}-{SelectedDate.Month.ToString()}-{SelectedDate.Day.ToString()}}";
            string url = $"https://si3.bcentral.cl/SieteRestWS/SieteRestWS.ashx?user=Ruben1Ulloa@gmail.com&pass=Benchi12&function=GetSeries&timeseries=F073.UFF.PRE.Z.D&firstdate={fecha}&lastdate={fecha}";
            string valorUF = "";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    IndicadorEconomico indicador = JsonConvert.DeserializeObject<IndicadorEconomico>(jsonResponse);
                     valorUF = indicador.Series.Obs.FirstOrDefault()?.Value;
                    var fechaUF = indicador.Series.Obs.FirstOrDefault()?.IndexDateString;
                    
                }
                else
                {   
                    
                    ViewBag.Error = "Error al obtener el valor de la UF";
                }
            }
            return (valorUF);
        }
    }
}

using Gestion_Del_Presupuesto.Data;
using Gestion_Del_Presupuesto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
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

        // Método Index que muestra la tabla de convenios con filtros opcionales
        public async Task<IActionResult> Index(string nombre, string tipo, string sede)
        {
            var conveniosQuery = _context.Convenios.AsQueryable();

            // Aplicar filtros si se proporcionan
            if (!string.IsNullOrWhiteSpace(nombre))
                conveniosQuery = conveniosQuery.Where(c => c.Nombre.Contains(nombre));

            if (!string.IsNullOrWhiteSpace(tipo))
                conveniosQuery = conveniosQuery.Where(c => c.Tipo_Retribucion.Equals(tipo, System.StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrWhiteSpace(sede))
                conveniosQuery = conveniosQuery.Where(c => c.Sede.Equals(sede, System.StringComparison.OrdinalIgnoreCase));

            // Incluir relaciones necesarias y obtener datos para las vistas
            var convenios = await conveniosQuery.Include(c => c.Retribuciones).ToListAsync();
            ViewBag.NombresConvenios = await _context.Convenios.Select(c => c.Nombre).Distinct().ToListAsync();
            ViewBag.TiposConvenios = await _context.Convenios.Select(c => c.Tipo_Retribucion).Distinct().ToListAsync();
            ViewBag.Sedes = new List<string> { "Santiago", "Coquimbo", "Ambas" };

            return View(convenios);
        }

        // Método Create (GET)
        public IActionResult Create()
        {
            LoadViewData();
            return View();
        }

        // Método Create (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ConvenioModel convenios, bool renovacionAutomatica)
        {
            // Convertir las fechas a UTC
            convenios.Fecha_Inicio = DateTime.SpecifyKind(convenios.Fecha_Inicio, DateTimeKind.Utc);

            if (renovacionAutomatica)
            {
                convenios.Fecha_Termino = DateTime.SpecifyKind(convenios.Fecha_Inicio.AddYears(1), DateTimeKind.Utc);
            }
            else if (convenios.Fecha_Termino.HasValue)
            {
                convenios.Fecha_Termino = DateTime.SpecifyKind(convenios.Fecha_Termino.Value, DateTimeKind.Utc);
            }

            // Asignar las relaciones adecuadamente
            foreach (var retribucion in convenios.Retribuciones)
            {
                retribucion.FechaRetribucion = DateTime.SpecifyKind(retribucion.FechaRetribucion, DateTimeKind.Utc);
                retribucion.ConvenioId = convenios.Id_Convenio; // Usar la clave foránea correctamente
            }

            // Agregar el convenio a la base de datos
            _context.Add(convenios);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Método Details
        public async Task<IActionResult> Details(int? id)
        {
            var convenios = await _context.Convenios
                .Include(c => c.CentrosDeSalud)
                .Include(c => c.Retribuciones)
                .FirstOrDefaultAsync(m => m.Id_Convenio == id);

            if (id == null || convenios == null)
            {
                return NotFound();
            }

            return View(convenios);
        }

        // Método Edit (GET)
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var convenios = await _context.Convenios
                .Include(c => c.Retribuciones)
                .Include(c => c.CentrosDeSalud)
                .FirstOrDefaultAsync(m => m.Id_Convenio == id);

            if (convenios == null) return NotFound();

            LoadViewData();
            return View(convenios);
        }

        // Método Edit (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ConvenioModel convenios, bool renovacionAutomatica)
        {
            // Validaciones manuales
            if (id != convenios.Id_Convenio)
                return NotFound();

            if (string.IsNullOrWhiteSpace(convenios.Nombre) || string.IsNullOrWhiteSpace(convenios.Sede))
            {
                LoadViewData();
                ViewBag.ErrorMessage = "El nombre y la sede son campos obligatorios.";
                return View(convenios);
            }

            // Convertir las fechas a UTC
            convenios.Fecha_Inicio = DateTime.SpecifyKind(convenios.Fecha_Inicio, DateTimeKind.Utc);

            if (renovacionAutomatica)
            {
                convenios.Fecha_Termino = DateTime.SpecifyKind(convenios.Fecha_Inicio.AddYears(1), DateTimeKind.Utc);
            }
            else if (convenios.Fecha_Termino.HasValue)
            {
                convenios.Fecha_Termino = DateTime.SpecifyKind(convenios.Fecha_Termino.Value, DateTimeKind.Utc);
            }

            try
            {
                // Actualizar el convenio
                _context.Update(convenios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConvenioExists(id))
                    return NotFound();
                else
                    throw;
            }
        }

        // Método Delete
        public async Task<IActionResult> Delete(int id)
        {
            var convenios = await _context.Convenios.FindAsync(id);
            if (convenios != null)
            {
                _context.Convenios.Remove(convenios);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // Método para verificar si un convenio existe
        private bool ConvenioExists(int id)
        {
            return _context.Convenios.Any(e => e.Id_Convenio == id);
        }

        // Método auxiliar para cargar datos en ViewBag
        private void LoadViewData()
        {
            ViewBag.Sedes = new List<string> { "Santiago", "Coquimbo", "Ambas" };
            ViewBag.TiposRetribucion = new List<string>
            {
                "Pago por Uso de CC $$",
                "Pago Apoyo a la Docencia",
                "Pago en RRHH",
                "Capacitación",
                "Obras Menores",
                "Obras Mayores",
                "Otros Gastos x retribución"
            };
        }

        [HttpPost]
        public IActionResult ExportToExcel()
        {
            var convenios = _context.Convenios.Include(c => c.Retribuciones).Include(c => c.CentrosDeSalud).ToList();

            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Convenios");

                // Header row
                worksheet.Cells[1, 1].Value = "Nombre";
                worksheet.Cells[1, 2].Value = "Tipo";
                worksheet.Cells[1, 3].Value = "Sede";
                worksheet.Cells[1, 4].Value = "Teléfono";
                worksheet.Cells[1, 5].Value = "Rut";
                worksheet.Cells[1, 6].Value = "Dirección";
                worksheet.Cells[1, 7].Value = "Contacto Principal";
                worksheet.Cells[1, 8].Value = "Fecha de Inicio";
                worksheet.Cells[1, 9].Value = "Fecha de Término";
                worksheet.Cells[1, 10].Value = "Renovación Automática";
                worksheet.Cells[1, 11].Value = "Tipo Retribución";
                worksheet.Cells[1, 12].Value = "Valor UF Retribución";
                worksheet.Cells[1, 13].Value = "Cantidad Pesos Retribución";
                worksheet.Cells[1, 14].Value = "Periodo Retribución";
                worksheet.Cells[1, 15].Value = "Nombre Centro de Salud";
                worksheet.Cells[1, 16].Value = "Dirección Centro de Salud";
                worksheet.Cells[1, 17].Value = "Contacto Centro de Salud";

                int row = 2;
                foreach (var convenio in convenios)
                {
                    int currentRow = row;

                    foreach (var retribucion in convenio.Retribuciones)
                    {
                        worksheet.Cells[currentRow, 1].Value = convenio.Nombre;
                        worksheet.Cells[currentRow, 2].Value = convenio.Tipo_Retribucion;
                        worksheet.Cells[currentRow, 3].Value = convenio.Sede;
                        worksheet.Cells[currentRow, 4].Value = convenio.Telefono;
                        worksheet.Cells[currentRow, 5].Value = convenio.Rut;
                        worksheet.Cells[currentRow, 6].Value = convenio.Direccion;
                        worksheet.Cells[currentRow, 7].Value = convenio.ContactoPrincipal;
                        worksheet.Cells[currentRow, 8].Value = convenio.Fecha_Inicio.ToShortDateString();
                        worksheet.Cells[currentRow, 9].Value = convenio.Fecha_Termino?.ToShortDateString();
                        worksheet.Cells[currentRow, 10].Value = convenio.RenovacionAutomatica;

                        worksheet.Cells[currentRow, 11].Value = retribucion.Tipo_Retribucion;
                        worksheet.Cells[currentRow, 12].Value = retribucion.UFTotal;
                        worksheet.Cells[currentRow, 13].Value = retribucion.CantPesos;
                        worksheet.Cells[currentRow, 14].Value = retribucion.Periodo;

                        currentRow++;
                    }

                    if (!convenio.Retribuciones.Any())
                    {
                        worksheet.Cells[currentRow, 1].Value = convenio.Nombre;
                        worksheet.Cells[currentRow, 2].Value = convenio.Tipo_Retribucion;
                        worksheet.Cells[currentRow, 3].Value = convenio.Sede;
                        worksheet.Cells[currentRow, 4].Value = convenio.Telefono;
                        worksheet.Cells[currentRow, 5].Value = convenio.Rut;
                        worksheet.Cells[currentRow, 6].Value = convenio.Direccion;
                        worksheet.Cells[currentRow, 7].Value = convenio.ContactoPrincipal;
                        worksheet.Cells[currentRow, 8].Value = convenio.Fecha_Inicio.ToShortDateString();
                        worksheet.Cells[currentRow, 9].Value = convenio.Fecha_Termino?.ToShortDateString();
                        worksheet.Cells[currentRow, 10].Value = convenio.RenovacionAutomatica;

                        currentRow++;
                    }

                    foreach (var centro in convenio.CentrosDeSalud)
                    {
                        worksheet.Cells[row, 15].Value = centro.NombreCentro;
                        worksheet.Cells[row, 16].Value = centro.Direccion;
                        worksheet.Cells[row, 17].Value = centro.Contacto;
                        row++;
                    }

                    if (!convenio.CentrosDeSalud.Any())
                    {
                        row = currentRow;
                    }
                }

                var stream = new MemoryStream();
                package.SaveAs(stream);
                var content = stream.ToArray();

                return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Convenios.xlsx");
            }
        }
    }
}

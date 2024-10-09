using Gestion_Del_Presupuesto.Models; // Incluir el espacio de nombres para el modelo
using Microsoft.AspNetCore.Mvc;

namespace Gestion_Del_Presupuesto.Controllers
{
    public class FacturacionController : Controller
    {
        // GET: FacturacionController
        public ActionResult Index()
        {
            // Crear un único modelo con valores de ejemplo
            var modelo = new FacturacionModel
            {
                RazonSocial = "Universidad Central",
                RUT = "70.995.200-5",
                Giro = "Educación",
                Direccion = "Lord Cochrane 417, Santiago Centro",
                Telefono = "02-25826000",
                ReceptorDocumento = "Astrid Manríquez Cid",
                Cargo = "Coordinadora de Campos Clínicos",
                TelefonoReceptor = "(562) 2 582 6985",
                CorreoElectronico = "amanriquez.docenteexterno@ucentral.cl",
                Sede = "Santiago Centro",
                Carrera = "Enfermería",
                NivelFormacion = "Pregrado",
                Institucion = "Universidad Central",
                TiempoPractica = "6 meses",
                NumeroTiempo = 6,
                NumeroAlumnos = 25,
                ValorUF = 3.5M,
                Subtotal = 350.0M
            };

            return View(modelo); // Pasar el modelo a la vista
        }
    }
}

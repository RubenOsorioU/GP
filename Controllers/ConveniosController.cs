using Gestion_Del_Presupuesto.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Gestion_Del_Presupuesto.Controllers
{
    public class ConveniosController : Controller
    {
        private static List<ConveniosModel> convenios = new List<ConveniosModel>();

        // GET: DetalleGeneral/Index
        public IActionResult Index()
        {
            return View(convenios);
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
        public IActionResult Create(ConveniosModel model)
        {
            if (ModelState.IsValid)
            {
                model.Id_Convenio = convenios.Count + 1;
                convenios.Add(model);
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
        // Hospitales y Clínicas
        { "Hospitales_Clinicas", new List<string>
            {
                "Hospital Barros Luco",
                "Dipreca",
                "Hospital San Luis de Buin",
                "INCANCER",
                "Hospital San Borja Arriaran",
                "Mutual de Seguridad",
                "Clinica Cordillera",
                "Capredena",
                "Hospital Salvador",
                "Hospital Luis Calvo Mackenna",
                "Hospital Horwitz",
                "Hospital El Peral",
                "CESA Uandes (Hospital Parroquial San Bernardo)"
            }
        },

        // Atención Primaria
        { "Atencion_primaria", new List<string>
            {
                "Corporacion de Buin",
                "Municipalidad de La Granja",
                "Corporacion de Lampa",
                "Corporacion de Puente Alto",
                "Municipalidad La Pintana",
                "Corporacion de Macul",
                "Municipalidad de Recoleta",
                "Corporacion de Quinta Normal",
                "Corporacion Pedro Aguirre Cerda",
                "Corporacion San Bernardo",
                "Municipalidad de Cerro Navia",
                "Municipalidad de Independencia",
                "Municipalidad de Lo Espejo",
                "Municipalidad de Estacion Central",
                "Municipalidad de Peñalolen",
                "Municipalidad de Quilicura",
                "Corporacion de Deportes de Cerro Navia"
            }
        },

        // Hogares y Centros Educacionales
        { "Hogares_CEucacionales", new List<string>
            {
                "Fundacion Cerro Navia Joven",
                "ACALIS (Sociedad de Inversiones Atardeceres S.A)",
                "CONVATEC (Boston Medical Device de Chile S.A)",
                "Fundacion Villa Padre Hurtado",
                "Convenio Tripartita (colegios Sn Bdo)",
                "Paul Harris Corporación de Educación y Salud de las Condes: Colegio Paul Harris",
                "Fundacion BELEN (Pie Crescente Errazuriz)",
                "Escuela Isabel Gonzalez Cares",
                "Escuela Bella Acuarela (Fund.Educacional Alegria y Alma)",
                "Fundación Educ.San Francisco Pudahuel (PIE Ana Eugenia)",
                "Corporacion Molokai (3 colegios)",
                "Corporacion PIRAMIDE (5 colegios)",
                "Pequeño COTOLENGO (Congregacion pequeña obra de la Divina Providencia)"
            }
        },

        // Laboratorios / Imagen / Oftalmología
        { "LAB_IMAGEN_OFTA", new List<string>
            {
                "REDLAB",
                "Clinica Vision Rancagua",
                "Instituto Oftalmologico Integral (IOI)",
                "Centro Medico Blanco",
                "FARR"
            }
        },

        // Centros y Fundaciones
        { "Centros_Fundaciones", new List<string>
            {
                "SENAME",
                "Hogar de Cristo",
                "CEDET Sociedad de profesionales y Rehabilitación Ltda CEDET",
                "Centro de Adultos Mayores SPA, Capacito",
                "Centro de Desarrollo Infantil GOING UP",
                "Moviliza",
                "PRUFODIS",
                "CORFAPES Corporación de Familiares y Amigos de Pacientes Esquizofrenicos",
                "FUNDACIÓN AGRUPATE",
                "Vicente Palotti (F. Amanecer para la ayuda de niños y adolescentes con trs. Del desarrollo)",
                "CENTRO GIRASOL",
                "CETRAM Centro Trastornos Movimiento",
                "Casa de Reposo Las Nieves",
                "Fundación Cristo Vive",
                "ONG de Desa. Fratern. LAS VIÑAS",
                "Corporación Alzheimer",
                "TEACAN SpA Cahuelche",
                "(TO Kumelen) ocuparse a lo largo de la vida Ltda.",
                "Fundación CELEI",
                "Corporación Casa del Cerro",
                "lnstituto Chileno de Psicoterapia lntegrativa",
                "Arteduca",
                "Instituto Chileno de Terapia Familiar",
                "Fundación CESI",
                "Corporación Dolores Sopeña",
                "Fundacion Mi Angel Gabriel",
                "ONG Cidets",
                "Sociedad Protectora de Ciegos Santa Lucia",
                "ONG La Casona",
                "Centro Terapeutico Aurora",
                "Fundacion Santa Gabriela",
                "Fundacion LUZ",
                "Oportunidades Terapeuticas SpA",
                "La CALETA (Corp.Programa Poblacional de Servicios La Caleta)",
                "Centro Espacio Seguro SpA"
            }
        },

        // Casinos
        { "Casinos", new List<string>
            {
                "Casona El Monte",
                "INTA",
                "Chile Pan"
            }
        }
    };
        }

    }
}

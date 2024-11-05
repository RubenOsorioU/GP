using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gestion_Del_Presupuesto.Models
{
    public class ConvenioModel
    {
        [Key]
        public int Id_Convenio { get; set; }
        [Display(Name = "Nombre Institución")]
        public string Nombre { get; set; }

        [Display(Name = "Tipo Centro")]
        public string Tipo_Convenio { get; set; }

        public string Sede { get; set; }
        [Display(Name = "Fecha Inicio")]


        public DateTime Fecha_Inicio { get; set; } = DateTime.Now;

        [Display(Name = "Fecha Termino")]
        public DateTime? Fecha_Termino { get; set; } = DateTime.Now;

        [Display(Name = "Contacto Principal")]
        public string ContactoPrincipal { get; set; }

        public string Telefono { get; set; }
        public string Rut { get; set; }
        public string Direccion { get; set; }
        public bool RenovacionAutomatica { get; set; }
        public decimal ValorUF { get; set; }

        public int Id_Retribucion { get; set; }
        public int CentrosDeSaludId { get; set; }
        public List<RetribucionModel> Retribuciones { get; set; } = new List<RetribucionModel>();
        public List<CentroSaludModel> CentrosDeSalud { get; set; } = new List<CentroSaludModel>();
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace Gestion_Del_Presupuesto.Models
{
    public class UFViewModel
    {
        [Required]
        public decimal MontoCLP { get; set; }

        [Required]
        public decimal MontoUF { get; set; }

        [Required]
        public string TipoUF { get; set; } // Tipo de UF: Real o Aproximada

        // Propiedades adicionales para la fecha, hora y cantidad de estudiantes
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required]
        public int CantidadEstudiantes { get; set; }
    }
}

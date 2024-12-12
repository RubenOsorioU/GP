using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Gestion_Del_Presupuesto.Models
{
    public class EncuestaModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Tipo de Encuesta")]
        public string Tipo { get; set; } // "Estudiante a Campo Clínico" o "Campo Clínico a Estudiante"

        [Required]
        [Display(Name = "Archivo de Encuesta")]
        public string ArchivoRuta { get; set; } // Ruta del archivo subido

        [Required]
        [Display(Name = "Puntuación")]
        [Range(1, 5, ErrorMessage = "La puntuación debe estar entre 1 y 5.")]
        public int Puntuacion { get; set; } // Puntuación para la encuesta

        [Required]
        [Display(Name = "Fecha de Encuesta")]
        public DateTime Fecha { get; set; }
    }
}

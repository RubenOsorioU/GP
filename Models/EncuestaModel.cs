using System.ComponentModel.DataAnnotations;

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
        [Display(Name = "Comentarios")]
        [StringLength(1000, ErrorMessage = "Los comentarios no pueden exceder los 1000 caracteres.")]
        public string Comentarios { get; set; }

        [Required]
        [Display(Name = "Puntuación")]
        [Range(1, 5, ErrorMessage = "La puntuación debe estar entre 1 y 5.")]
        public int Puntuacion { get; set; }

        [Required]
        [Display(Name = "Fecha de Encuesta")]
        public DateTime Fecha { get; set; }
    }
}

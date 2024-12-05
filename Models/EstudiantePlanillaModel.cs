using System.ComponentModel.DataAnnotations.Schema;

namespace Gestion_Del_Presupuesto.Models
{
    public class EstudiantePlanillaModel
    {
        // Estas propiedades actuarán como clave primaria compuesta
        public int EstudianteId { get; set; }
        public int PlanillaId { get; set; }

        // Relaciones de navegación
        [ForeignKey("EstudianteId")]
        public Estudiante Estudiante { get; set; }

        [ForeignKey("PlanillaId")]
        public PlanillasModel Planilla { get; set; }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gestion_Del_Presupuesto.Models
{
    public class Estudiante
    {
        [Key]
        public int Id_Estudiante { get; set; }
        public string Nombre { get; set; }
        public string Carrera { get; set; }

        public int Id_Convenio { get; set; }

        

        // Relación muchos a muchos con Campo_Clinico
        public virtual ICollection<Campo_Clinico> Campo_Clinicos { get; set; }

        public virtual ICollection <ConveniosModel> Convenio { get; set; }

        public virtual PlanillasModel Planilla { get; set; }
    }
}

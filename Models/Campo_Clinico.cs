using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gestion_Del_Presupuesto.Models
{
    public class Campo_Clinico

    {
        [Key]
        public int Id_Campo_Clinico { get; set; }
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }
        public string Tipo { get; set; }

        // Relación muchos a muchos con Estudiante
        public virtual ICollection<Estudiante> Estudiantes { get; set; }

        // Relación con Convenio
        public virtual ICollection<Convenio> Convenios { get; set; }
    }
}

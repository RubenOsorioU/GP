using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gestion_Del_Presupuesto.Models
{
    public class Campo_Clinico

    {
        [Key]
        public int Id_Campo_Clinico { get; set; }
        public required string Nombre { get; set; }
        public required string Tipo { get; set; }

        public required string Sede { get; set; }

        // Relación muchos a muchos con Estudiante
        public virtual ICollection <Estudiante> Estudiantes { get; set; }

        // Relación con Convenio
        public virtual ICollection <ConveniosModel> Convenios { get; set; }
    }
}

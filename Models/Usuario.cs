using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gestion_Del_Presupuesto.Models
{
    public class Usuario
    {
        [Key]
        public int Id_Usuario { get; set; }  // Clave primaria de Usuario
        public string Nombre { get; set; }
        public string Contraseña { get; set; }
        public string Rol { get; set; }

        // Relación uno a muchos con Historial_Actividad
        public virtual ICollection<Historial_Actividad> Historial_Actividades { get; set; }  // Relación con Historial_Actividad
    }
}


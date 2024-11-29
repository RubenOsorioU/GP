using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gestion_Del_Presupuesto.Models
{
    public class Usuario : IdentityUser<int>
    {
        [Required]
        public string Rut { get; set; } // Si es necesario, puedes conservar este campo
        public virtual ICollection<Historial_Actividad> Historial_Actividades { get; set; } // Relación con Historial_Actividad
    }
}

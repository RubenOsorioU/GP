using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gestion_Del_Presupuesto.Models
{
    public class Usuario : IdentityUser<int>
    {
        [Required(ErrorMessage = "El RUT es requerido")]
        [RegularExpression(@"^\d{1,2}\.\d{3}\.\d{3}[-][0-9kK]{1}$", ErrorMessage = "El formato del RUT no es válido")]
        public string Rut { get; set; }
        public virtual ICollection<Historial_Actividad> Historial_Actividades { get; set; } 
    }
}

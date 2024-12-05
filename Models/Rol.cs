using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Gestion_Del_Presupuesto.Models
{
    public class Rol : IdentityRole<int> 
    {
        public string Descripcion { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}

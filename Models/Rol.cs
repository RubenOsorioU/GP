using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace Gestion_Del_Presupuesto.Models
{
    public class Rol
    {
        [Key]
        public int Id_Rol { get; set; }
        public string Nombre { get; set; }
       
        public string Permisos { get; set; }

        //Llaves foraneas

        public int Id_Usuario { get; set; }
    }
        
}

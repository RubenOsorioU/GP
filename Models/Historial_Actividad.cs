using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestion_Del_Presupuesto.Models
{
    public class Historial_Actividad
    {
        [Key]
        public int Id_Historial_Actividad { get; set; }  // Clave primaria de Historial_Actividad
        
        public string Accion { get; set; }
        public DateTime Fecha { get; set; }
        public string Detalles { get; set; }

       // Propiedad de navegación hacia Usuario
        [ForeignKey("UsuarioId")]
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}

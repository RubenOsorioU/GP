using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gestion_Del_Presupuesto.Models
{
    public class Retribucion
    {
        [Key]
        public int Id_Retribucion { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public float Valor { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }

        // Foreign Key
        public int Id_Convenio { get; set; }

        // Propiedades de navegación
        public virtual Convenio Convenio { get; set; }
        public virtual ICollection<Pago> Pagos { get; set; }

        // Relación uno a uno con Solicitud_Retribucion
        public int Id_Solicitud_Retribucion { get; set; }
        public virtual Solicitud_Retribucion Solicitud_Retribucion { get; set; }
    }
}

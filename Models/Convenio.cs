using Gestion_Del_Presupuesto.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Gestion_Del_Presupuesto.Models
{
    public class Convenio
    {
        [Key]
        public int Id_Convenio { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public string Institucion { get; set; }
        public string TipoConvenio { get; set; }
        public string Estado { get; set; }

        public int Id_Presupuesto { get; set; }
        public int Id_Institucion_Salud { get; set; }
        public int Id_Centro_Costo { get; set; }

        public virtual Consolidado_CentroCostoModel Presupuesto { get; set; }
        public virtual Institucion_Salud Institucion_Salud { get; set; }  

        public virtual ICollection<Retribucion> Retribuciones { get; set; }
        public virtual ICollection<Pago> Pagos { get; set; }
    }
}

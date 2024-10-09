using System;
using System.ComponentModel.DataAnnotations;

namespace Gestion_Del_Presupuesto.Models
{
    public class Devengado
    {
        [Key]
        public int Id_Devengado { get; set; }

        public DateTime Fecha { get; set; }

        [Required]
        public decimal Monto { get; set; }

        public string Descripcion { get; set; }

        // Propiedades adicionales para la vista
        
        // Relación con Convenio
        public int ConvenioId { get; set; }
        public virtual Convenio Convenio { get; set; }

        public decimal MontoComprometido { get; set; }
        public decimal PagosRealizados { get; set; }
        public decimal SaldoPendiente { get; set; }
        public IEnumerable<Devengado> Devengados { get; set; }
    }
}

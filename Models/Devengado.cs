using System;
using System.ComponentModel.DataAnnotations;

namespace Gestion_Del_Presupuesto.Models
{
    public class Devengado
    {
        [Key]
        public int Id_Devengado { get; set; }

        public DateTime Fecha { get; set; }

        public decimal GastoComprometido { get; set; }
        public decimal PagosRealizados { get; set; }
        public decimal SaldoPendiente { get; set; }

        public string Descripcion { get; set; }

        // Propiedades adicionales para la vista
        
        // Relación con Convenio
        public int ConvenioId { get; set; }
        public virtual ConveniosModel Convenio { get; set; }


        public IEnumerable<Devengado> Devengados { get; set; }
    }
}

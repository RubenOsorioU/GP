using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gestion_Del_Presupuesto.Models
{
    public class RetribucionModel
    {
        [Key]
        public int Id_Retribucion { get; set; }
        public string Tipo_Retribucion { get; set; }
        public decimal Monto { get; set; }

        public decimal UFTotal { get; set; }
        public int ConvenioId { get; set; }

        public DateTime FechaRetribucion { get; set; } = DateTime.Now;
        public ConvenioModel Convenios { get; set; }
        
    }
}

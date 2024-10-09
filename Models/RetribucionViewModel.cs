using System;

namespace Gestion_Del_Presupuesto.Models
{
    public class RetribucionViewModel
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }

        public string Seleccionados { get; set; }
    }
}

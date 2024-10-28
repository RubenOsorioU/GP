using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System;

namespace Gestion_Del_Presupuesto.Models
{
    public class PlanillasModel
    {
        [Key]
        public int Id_Planillas { get; set; }

        public string Nombre { get; set; }

        public int  Rut { get; set; }

        public DateTime Fecha_Inicio { get; set; } = DateTime.Now;

        public required DateTime Fecha_Termino { get; set; } = DateTime.Now;

        public string Institución { get; set; }

        public double CuantasSemanas {  get; set; }
        
        public int ValorUfContrato {  get; set; }
        
        public int  TotalCosto { get; set; }
        public int Id_Estudiante {  get; set; }

        public virtual Estudiante Estudiante { get; set; }


        
    }
}

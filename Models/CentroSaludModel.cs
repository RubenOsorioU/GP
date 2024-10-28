using System.ComponentModel.DataAnnotations;

namespace Gestion_Del_Presupuesto.Models
{
    public class CentroSaludModel
    {
        [Key]
        public int Id_CentroSalud { get; set; }
        public int Rut_CentrodeSalud { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Contacto { get; set; }
        public int ConvenioId { get; set; }
        public ConvenioModel Convenio { get; set; }
    }
}

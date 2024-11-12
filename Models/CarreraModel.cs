using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestion_Del_Presupuesto.Models
{
    public class CarreraModel
    {
        [Key]
        public int Id_Carrera { get; set; }
        public string Nombre_Carrera { get; set; }
        public string Coordinador { get; set; }

        public string Cantidad_Estudiantes { get; set; }

        [ForeignKey("ConvenioModel")]
        public int ConvenioId { get; set; }
        public virtual ICollection<ConvenioModel> Convenios { get; set; } = new List<ConvenioModel>();
        public List<RetribucionModel> Retribuciones { get; set; } = new List<RetribucionModel>();
        public List<CentroSaludModel> CentrosDeSalud { get; set; } = new List<CentroSaludModel>();
        public virtual ICollection<PlanillasModel> Planillas { get; set; } = new List<PlanillasModel>();

    }
}

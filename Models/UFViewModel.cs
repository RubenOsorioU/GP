using System;
using System.ComponentModel.DataAnnotations;

namespace Gestion_Del_Presupuesto.Models
{
    public class UFViewModel

    {
        [Key]
        public int Id_UF { get; set; }

        [Required]
        public int Dia { get; set; }   

        [Required]
        public double Ene {  get; set; }

        public double Feb { get; set; }
        public double Mar { get; set; }
        public double Abr { get; set; }
        public double May { get; set; }
        public double Jun { get; set; }
        public double Jul { get; set; }
        public double Ago { get; set; }

        public double Sep { get; set; }
        public double Oct { get; set; }

        public double Nov { get; set; }

        public double Dic { get; set; }

        public int SelectedYear { get; set; }
        public string SelectedMonth { get; set; }
        public DateTime SelectedDate { get; set; } 
        public decimal UFValueForDate { get; set; } 
        public decimal MontoUF { get; set; } 
        public decimal Resultado { get; set; } 
        public List<UFData> UFValues { get; set; }
    }

    public class UFData

    {
        [Key]
        public int Id_UFData { get; set; }
        public DateTime Date { get; set; }
        public decimal UFValue { get; set; }
    }

}

using System.ComponentModel.DataAnnotations;

namespace Gestion_Del_Presupuesto.Models
{
    public class UF2023
    {
        [Key]
        public int Id_UF_2023 { get; set; }
        [Required]
        public int Dia { get; set; }

        [Required]
        public decimal Ene { get; set; }

        [Required]
        public decimal Feb { get; set; }
        [Required]
        public decimal Mar { get; set; }
        [Required]
        public decimal Abr { get; set; }
        [Required]
        public decimal May { get; set; }
        [Required]
        public decimal Jun { get; set; }
        [Required]
        public decimal Jul { get; set; }
        [Required]
        public decimal Ago { get; set; }
        [Required]
        public decimal Sep { get; set; }
        [Required]
        public decimal Oct { get; set; }
        [Required]
        public decimal Nov { get; set; }
        [Required]
        public decimal Dic { get; set; }

        
    }
}

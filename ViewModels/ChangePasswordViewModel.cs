using System.ComponentModel.DataAnnotations;

namespace Gestion_Del_Presupuesto.Models
{
    public class ChangePasswordViewModels
    {
        [Required(ErrorMessage = "La contraseña actual es requerida.")]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "La nueva contraseña es requerida.")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "La {0} debe tener al menos {2} caracteres.", MinimumLength = 6)]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "La nueva contraseña y la confirmación no coinciden.")]
        public string ConfirmPassword { get; set; }
    }
}
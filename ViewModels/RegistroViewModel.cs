using System.ComponentModel.DataAnnotations;


namespace Gestion_Del_Presupuesto.ViewModels
{
    public class RegistroViewModel
    {
        [Required]
        [Display(Name = "Nombre de Usuario")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Rol")]
        public string Rol { get; set; } // El rol seleccionado
        [Required]
        [Display(Name = "RUT")]
        public string Rut { get; set; }
    }
    // Código de RegistroViewModel...
}


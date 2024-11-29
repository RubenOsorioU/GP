using Gestion_Del_Presupuesto.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using Gestion_Del_Presupuesto.ViewModels;

namespace Gestion_Del_Presupuesto.Controllers
{
    public class RegistroController : Controller
    {
        private readonly UserManager<IdentityUser<int>> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public RegistroController(UserManager<IdentityUser<int>> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: RegistroController
        public IActionResult Index()
        {
            return View();
        }

        // POST: RegistroController/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegistroViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            // Crear el usuario
            var user = new IdentityUser<int>
            {
                UserName = model.UserName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // Asignar el rol
                if (!string.IsNullOrEmpty(model.Rol) && await _roleManager.RoleExistsAsync(model.Rol))
                {
                    await _userManager.AddToRoleAsync(user, model.Rol);
                }

                // Generar y enviar correo de confirmación
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var confirmationLink = Url.Action("ConfirmEmail", "Registro", new { userId = user.Id, token }, Request.Scheme);
                EnviarCorreoVerificacion(model.Email, confirmationLink);

                return RedirectToAction("Index", "Home");
            }

            // Manejo de errores
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View("Index", model);
        }

        public async Task<IActionResult> ConfirmEmail(int userId, string token)
        {
            if (userId == 0 || string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Index", "Home");
            }

            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            return BadRequest("Error al confirmar el correo electrónico.");
        }

        private void EnviarCorreoVerificacion(string correoDestino, string linkVerificacion)
        {
            var fromAddress = new MailAddress("tucorreo@example.com", "Gestión de Campos Clínicos");
            var toAddress = new MailAddress(correoDestino);
            const string fromPassword = "tupassword";
            const string subject = "Confirma tu correo electrónico";
            string body = $"Por favor, confirma tu cuenta haciendo clic en el siguiente enlace: <a href='{linkVerificacion}'>Confirmar Correo</a>";

            var smtp = new SmtpClient
            {
                Host = "smtp.example.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            using var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };
            smtp.Send(message);
        }
    }
}

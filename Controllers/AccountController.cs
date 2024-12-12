using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using Gestion_Del_Presupuesto.Models;
using Gestion_Del_Presupuesto.ViewModels;

using Microsoft.AspNetCore.Authorization;

namespace Gestion_Del_Presupuesto.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<Usuario> _signInManager;
        private readonly UserManager<Usuario> _userManager;
        private readonly RoleManager<Rol> _roleManager;

        public AccountController(SignInManager<Usuario> signInManager,
                                 UserManager<Usuario> userManager,
                                 RoleManager<Rol> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: Registro de usuario
        public IActionResult Register()
        {
            return View();
        }

        // POST: Registro de usuario

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegistroViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new Usuario
            {
                UserName = model.UserName,
                Email = model.Email,
                Rut = model.Rut,
                EmailConfirmed = true // Inicialmente no confirmado
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // Asignar rol si es válido
                if (!string.IsNullOrEmpty(model.Rol) && await _roleManager.RoleExistsAsync(model.Rol))
                {
                    await _userManager.AddToRoleAsync(user, model.Rol);
                }

                // Generar el token de confirmación y enviar el correo de verificación
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var confirmationLink = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, token }, Request.Scheme);

                EnviarCorreoVerificacion(model.Email, confirmationLink);

                // Mensaje de éxito para el usuario
                TempData["SuccessMessage"] = "Registro exitoso. Por favor, verifica tu correo para confirmar la cuenta.";
                return RedirectToAction("Register");
            }

            // Manejo de errores
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            // Si hay errores, agregar un mensaje de error
            TempData["ErrorMessage"] = "Hubo un problema durante el registro. Por favor, revise los errores e intente nuevamente.";
            return View(model);
        }



        // GET: Confirmar correo electrónico
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(token))
            {
                return BadRequest("Error al confirmar el correo electrónico.");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"No se encontró el usuario con el ID '{userId}'.");
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                return View("EmailConfirmed");
            }

            return BadRequest("Error al confirmar el correo electrónico.");
        }

        // GET: Inicio de sesión
        public IActionResult Login()
        {
            return View();
        }

        // POST: Inicio de sesión
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Intentar encontrar al usuario por email
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Inicio de sesión inválido.");
                return View(model);
            }

            // Verificar si el correo está confirmado
            if (!user.EmailConfirmed)
            {
                ModelState.AddModelError(string.Empty, "Por favor, confirma tu correo electrónico antes de iniciar sesión.");
                return View(model);
            }

            // Intentar iniciar sesión con el UserName
            var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, model.Recordarme, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            if (result.IsLockedOut)
            {
                ModelState.AddModelError(string.Empty, "La cuenta está bloqueada. Intenta más tarde.");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Inicio de sesión inválido.");
            }

            return View(model);
        }

        public IActionResult ConfirmRegistration()

        {
            return View();
        }

        // POST: Cerrar sesión
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        // Método para enviar el correo de verificación
        private void EnviarCorreoVerificacion(string correoDestino, string linkVerificacion)
        {
            var fromAddress = new MailAddress("tucorreo@example.com", "Gestión de Campos Clínicos");
            var toAddress = new MailAddress(correoDestino);
            const string fromPassword = "tupassword"; // Usa un servicio de configuración segura para almacenar contraseñas
            const string subject = "Confirma tu correo electrónico";
            string body = $"Por favor, confirma tu cuenta haciendo clic en el siguiente enlace: <a href='{linkVerificacion}'>Confirmar Correo</a>";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",  // Cambia esto a tu servidor SMTP
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("Antoniopv7@gmail.com", "icrpkkrxyxmhdmst")
            };

            using var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };
            smtp.Send(message);
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound("No se encontró el usuario");
            }

            var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

            if (result.Succeeded)
            {
                await _signInManager.SignOutAsync();
                TempData["Message"] = "¡Contraseña cambiada exitosamente! Por favor, inicia sesión nuevamente.";
                return RedirectToAction(nameof(Login));
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }

    }
}

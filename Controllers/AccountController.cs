using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using Gestion_Del_Presupuesto.Models;
using Gestion_Del_Presupuesto.ViewModels;

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
                PhoneNumber = model.PhoneNumber,
                Rut = model.Rut // Suponiendo que tienes un campo RUT en tu ViewModel
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // Asignar rol si es válido
                if (!string.IsNullOrEmpty(model.Rol) && await _roleManager.RoleExistsAsync(model.Rol))
                {
                    await _userManager.AddToRoleAsync(user, model.Rol);
                }

                // Generar el token de confirmación
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var confirmationLink = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, token }, Request.Scheme);

                // Enviar correo
                EnviarCorreoVerificacion(model.Email, confirmationLink);

                return RedirectToAction("ConfirmRegistration");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }

        // GET: Confirmación del registro
        public IActionResult ConfirmRegistration()
        {
            return View();
        }

        // GET: Confirmar correo electrónico
        public async Task<IActionResult> ConfirmEmail(int userId, string token)
        {
            if (userId == 0 || string.IsNullOrEmpty(token))
            {
                return BadRequest("Error al confirmar el correo electrónico.");
            }

            var user = await _userManager.FindByIdAsync(userId.ToString());
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

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.Recordarme, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Inicio de sesión inválido.");
            return View(model);
        }

        // POST: Cerrar sesión
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        // GET: Cambiar contraseña
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        // POST: Cambiar contraseña
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
                return RedirectToAction("Login", "Account");
            }

            var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
            if (result.Succeeded)
            {
                await _signInManager.RefreshSignInAsync(user);
                ViewBag.Message = "La contraseña ha sido cambiada exitosamente.";
                return View();
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
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

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

public class UsuarioController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;

    public UsuarioController(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    // Crear un nuevo usuario
    [HttpPost]
    public async Task<IActionResult> CrearUsuario(string email, string password, string role)
    {
        if (await _userManager.FindByEmailAsync(email) != null)
        {
            return BadRequest($"El usuario con email {email} ya existe.");
        }

        var user = new IdentityUser { UserName = email, Email = email };
        var result = await _userManager.CreateAsync(user, password);

        if (!result.Succeeded)
        {
            return BadRequest($"Error al crear el usuario: {string.Join(", ", result.Errors.Select(e => e.Description))}");
        }

        if (!string.IsNullOrEmpty(role))
        {
            await _userManager.AddToRoleAsync(user, role);
        }

        return Ok($"Usuario {email} creado con éxito.");
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Gestion_Del_Presupuesto.Models;
using System.Threading.Tasks;
using System.Linq;

public class UsuarioController : Controller
{
    private readonly UserManager<IdentityUser<int>> _userManager;
    private readonly RoleManager<IdentityRole<int>> _roleManager;

    public UsuarioController(UserManager<IdentityUser<int>> userManager, RoleManager<IdentityRole<int>> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    // GET: Lista de usuarios
    public IActionResult Index()
    {
        var usuarios = _userManager.Users.ToList();
        return View(usuarios);
    }

    // Crear un nuevo usuario
    [HttpPost]
    public async Task<IActionResult> CrearUsuario(string nombre, string correo, string password, string confirmarPassword, string rut, string telefono, int idRol)
    {
        // Validar si el usuario ya existe
        if (await _userManager.FindByEmailAsync(correo) != null)
        {
            return BadRequest($"El usuario con email {correo} ya existe.");
        }

        // Validar si la contraseña y la confirmación coinciden
        if (password != confirmarPassword)
        {
            return BadRequest("Las contraseñas no coinciden.");
        }

        // Crear el usuario en Identity
        var identityUser = new IdentityUser<int>
        {
            UserName = correo,
            Email = correo
        };
        var result = await _userManager.CreateAsync(identityUser, password);

        if (!result.Succeeded)
        {
            return BadRequest($"Error al crear el usuario: {string.Join(", ", result.Errors.Select(e => e.Description))}");
        }

        // Asignar rol si es proporcionado
        var rol = await _roleManager.FindByIdAsync(idRol.ToString());
        if (rol != null)
        {
            await _userManager.AddToRoleAsync(identityUser, rol.Name); // Usar Name
        }

        return Ok($"Usuario {correo} creado con éxito.");
    }

    // Editar un usuario
    [HttpPost]
    public async Task<IActionResult> EditarUsuario(int id, string correo, int idRol)
    {
        var usuario = await _userManager.FindByIdAsync(id.ToString());
        if (usuario == null)
        {
            return NotFound("Usuario no encontrado.");
        }

        usuario.UserName = correo;
        usuario.Email = correo;

        var result = await _userManager.UpdateAsync(usuario);
        if (!result.Succeeded)
        {
            return BadRequest($"Error al actualizar el usuario: {string.Join(", ", result.Errors.Select(e => e.Description))}");
        }

        // Actualizar rol si es necesario
        var currentRoles = await _userManager.GetRolesAsync(usuario);
        if (currentRoles.Any())
        {
            await _userManager.RemoveFromRolesAsync(usuario, currentRoles);
        }

        var rol = await _roleManager.FindByIdAsync(idRol.ToString());
        if (rol != null)
        {
            await _userManager.AddToRoleAsync(usuario, rol.Name);
        }

        return Ok($"Usuario {correo} actualizado con éxito.");
    }

    // Eliminar un usuario
    [HttpPost]
    public async Task<IActionResult> EliminarUsuario(int id)
    {
        var usuario = await _userManager.FindByIdAsync(id.ToString());
        if (usuario == null)
        {
            return NotFound("Usuario no encontrado.");
        }

        var result = await _userManager.DeleteAsync(usuario);
        if (!result.Succeeded)
        {
            return BadRequest($"Error al eliminar el usuario: {string.Join(", ", result.Errors.Select(e => e.Description))}");
        }

        return Ok($"Usuario eliminado con éxito.");
    }
}

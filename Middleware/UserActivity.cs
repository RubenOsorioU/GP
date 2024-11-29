using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Gestion_Del_Presupuesto.Data;
using Gestion_Del_Presupuesto.Models;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Gestion_Del_Presupuesto.Middlewares
{
    public class UserActivity
    {
        private readonly RequestDelegate _next;

        public UserActivity(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IServiceProvider serviceProvider)
        {
            if (context.User.Identity.IsAuthenticated)
            {
                using (var scope = serviceProvider.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<Usuario>>();

                    // Obtener el ID del usuario autenticado
                    var userId = context.User.FindFirst("sub")?.Value;

                    if (int.TryParse(userId, out int id))
                    {
                        var usuario = await userManager.FindByIdAsync(id.ToString());

                        if (usuario != null)
                        {
                            // Obtener los roles del usuario
                            var roles = await userManager.GetRolesAsync(usuario);

                            // Crear un registro de actividad
                            var historial = new Historial_Actividad
                            {
                                UsuarioId = id,
                                Accion = $"{context.Request.Method} {context.Request.Path}", // Ejemplo: GET /Home/Index
                                Fecha = DateTime.UtcNow,
                                Detalles = $"Roles: {string.Join(", ", roles)}" // Agregar roles como detalles
                            };

                            // Guardar el registro en la base de datos
                            dbContext.Historial_Actividad.Add(historial);
                            await dbContext.SaveChangesAsync();
                        }
                    }
                }
            }

            // Pasar al siguiente middleware
            await _next(context);
        }
    }
}

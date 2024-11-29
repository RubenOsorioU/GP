using Microsoft.EntityFrameworkCore;
using Gestion_Del_Presupuesto.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Gestion_Del_Presupuesto.Models;
using Gestion_Del_Presupuesto.Middlewares;

var builder = WebApplication.CreateBuilder(args);

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", false);

// Configurar el servicio de DbContext para usar PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configurar Identity con soporte para roles usando los modelos `Usuario` y `Rol`
builder.Services.AddIdentity<Usuario, Rol>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();  // Esto es necesario para manejar la verificación de correos, restablecer contraseñas, etc.

// Configurar autenticación por cookies
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login"; // Página de inicio de sesión
    options.AccessDeniedPath = "/Home/AccessDenied"; // Página de acceso denegado
});

// Configurar autorización
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Direccion")); // Política para Dirección
    options.AddPolicy("UserOnly", policy => policy.RequireRole("User"));   // Política para User
});

// Agregar servicios para controladores y vistas
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();  // Necesario para las sesiones
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);  // Tiempo de inactividad
    options.Cookie.HttpOnly = true;                 // Seguridad
    options.Cookie.IsEssential = true;              // Cumplir con GDPR si es necesario
});

var app = builder.Build();

// Inicializar roles y usuario administrador
await InitializeRolesAndAdminAsync(app);

// Configurar el pipeline de solicitud HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseMiddleware<UserActivity>();
app.UseSession();          // Habilitar el uso de sesiones
app.UseAuthentication();   // Habilitar autenticación
app.UseAuthorization();    // Habilitar autorización

// Configurar las rutas predeterminadas de la aplicación
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

async Task InitializeRolesAndAdminAsync(IHost app)
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;

        try
        {
            // Crear roles iniciales
            await CrearRoles(services);

            // Crear usuario administrador inicial
            await CrearUsuarioAdmin(services);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al crear los roles o usuario admin: {ex.Message}");
        }
    }
}

// Método para crear roles
async Task CrearRoles(IServiceProvider serviceProvider)
{
    var roleManager = serviceProvider.GetRequiredService<RoleManager<Rol>>();

    var roles = new[]
    {
        new { Name = "Direccion", Descripcion = "Dirección de Campos Clínicos" },
        new { Name = "SubDireccion", Descripcion = "Subdirección de Campos Clínicos" },
        new { Name = "Coordinacion", Descripcion = "Coordinación de Campos Clínicos" },
        new { Name = "ApoyoAcademico", Descripcion = "Apoyo Académico" }
    };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role.Name))
        {
            var identityRole = new Rol
            {
                Name = role.Name,
                Descripcion = role.Descripcion // Asignar la descripción
            };

            var result = await roleManager.CreateAsync(identityRole);
            if (!result.Succeeded)
            {
                throw new Exception($"Error al crear el rol {role.Name}: {string.Join(", ", result.Errors.Select(e => e.Description))}");
            }
        }
    }
}

async Task CrearUsuarioAdmin(IServiceProvider serviceProvider)
{
    var userManager = serviceProvider.GetRequiredService<UserManager<Usuario>>();
    var roleManager = serviceProvider.GetRequiredService<RoleManager<Rol>>(); // Agregado para verificar existencia de roles
    var configuration = serviceProvider.GetRequiredService<IConfiguration>();

    string name = configuration["AdminUser:Name"];
    string email = configuration["AdminUser:Email"];
    string password = configuration["AdminUser:Password"];
    string role = "Direccion";
    string rut = configuration["AdminUser:Rut"]; // Agrega el RUT desde la configuración o un valor predeterminado

    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new Usuario
        {
            UserName = name,
            Email = email,
            EmailConfirmed = true,
            Rut = rut // Proporciona un valor para el RUT
        };

        var result = await userManager.CreateAsync(user, password);

        if (result.Succeeded)
        {
            if (await roleManager.RoleExistsAsync(role))
            {
                await userManager.AddToRoleAsync(user, role);
            }
            else
            {
                throw new Exception($"El rol '{role}' no existe. Asegúrate de que el rol esté creado.");
            }
        }
        else
        {
            throw new Exception($"Error al crear el usuario: {string.Join(", ", result.Errors.Select(e => e.Description))}");
        }
    }
}

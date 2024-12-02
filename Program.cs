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
    .AddDefaultTokenProviders();

// Configurar opciones de contraseña para Identity
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 8;
});

// Configurar autenticación por cookies
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Home/AccessDenied";
});

// Configurar autorización
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Direccion"));
    options.AddPolicy("UserOnly", policy => policy.RequireRole("User"));
});

// Registrar IHttpClientFactory
builder.Services.AddHttpClient(); // Necesario para HttpClient en FacturacionController

// Agregar servicios para controladores y vistas
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Inicializar roles y usuarios
await InitializeRolesAndUsersAsync(app);

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
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

// Configurar las rutas predeterminadas de la aplicación
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

// Método para inicializar roles y usuarios
async Task InitializeRolesAndUsersAsync(IHost app)
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

            // Crear usuarios adicionales
            await CrearOtrosUsuarios(services);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al crear los roles o usuarios: {ex.Message}");
        }
    }
}

// Método para crear roles iniciales
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
                Descripcion = role.Descripcion
            };

            var result = await roleManager.CreateAsync(identityRole);
            if (!result.Succeeded)
            {
                throw new Exception($"Error al crear el rol {role.Name}: {string.Join(", ", result.Errors.Select(e => e.Description))}");
            }
        }
    }
}

// Método para crear el usuario administrador
async Task CrearUsuarioAdmin(IServiceProvider serviceProvider)
{
    var userManager = serviceProvider.GetRequiredService<UserManager<Usuario>>();
    var roleManager = serviceProvider.GetRequiredService<RoleManager<Rol>>();
    var configuration = serviceProvider.GetRequiredService<IConfiguration>();

    string name = configuration["AdminUser:Name"];
    string email = configuration["AdminUser:Email"];
    string password = Environment.GetEnvironmentVariable("AdminUserPassword") ?? "Password123!";
    string role = "Direccion";
    string rut = configuration["AdminUser:Rut"];

    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new Usuario
        {
            UserName = name,
            Email = email,
            EmailConfirmed = true,
            Rut = rut
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

// Método para crear otros usuarios
async Task CrearOtrosUsuarios(IServiceProvider serviceProvider)
{
    var userManager = serviceProvider.GetRequiredService<UserManager<Usuario>>();
    var roleManager = serviceProvider.GetRequiredService<RoleManager<Rol>>();
    var configuration = serviceProvider.GetRequiredService<IConfiguration>();

    var usuarios = configuration.GetSection("Users").Get<List<dynamic>>();

    foreach (var usuario in usuarios)
    {
        if (await userManager.FindByEmailAsync(usuario.Email) == null)
        {
            var user = new Usuario
            {
                UserName = usuario.UserName,
                Email = usuario.Email,
                EmailConfirmed = true,
                Rut = usuario.Rut
            };

            var password = Environment.GetEnvironmentVariable("UserPassword") ?? "Password123!";
            var result = await userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                if (await roleManager.RoleExistsAsync(usuario.Role))
                {
                    await userManager.AddToRoleAsync(user, usuario.Role);
                }
                else
                {
                    throw new Exception($"El rol '{usuario.Role}' no existe. Asegúrate de que el rol esté creado.");
                }
            }
            else
            {
                throw new Exception($"Error al crear el usuario {usuario.UserName}: {string.Join(", ", result.Errors.Select(e => e.Description))}");
            }
        }
    }
}

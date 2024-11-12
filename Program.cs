using Microsoft.EntityFrameworkCore;
using Gestion_Del_Presupuesto.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", false);

// Configurar el servicio de DbContext para usar PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configurar Identity con soporte para roles
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Configurar autenticación por cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Index";         // Página de inicio de sesión
        options.AccessDeniedPath = "/Home/AccessDenied"; // Página de acceso denegado
    });

// Configurar autorización
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin")); // Política para Admin
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

// Inicialización de roles y usuario administrador
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    // Crear roles iniciales
    await CrearRoles(services);

    // Crear usuario administrador inicial
    await CrearUsuarioAdmin(services);
}

// Configurar el pipeline de solicitud HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();          // Habilitar el uso de sesiones
app.UseAuthentication();   // Habilitar autenticación
app.UseAuthorization();    // Habilitar autorización

// Configurar las rutas predeterminadas de la aplicación
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}"); // Cambiar Home por Login si es necesario

app.Run();

// Método para crear roles
async Task CrearRoles(IServiceProvider serviceProvider)
{
    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    string[] roles = { "Admin", "Manager", "User" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}

// Método para crear un usuario administrador
async Task CrearUsuarioAdmin(IServiceProvider serviceProvider)
{
    var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
    var email = "admin@example.com"; // Cambia este correo si es necesario
    var password = "Password123!";  // Cambia esta contraseña si es necesario

    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new IdentityUser { UserName = email, Email = email };
        var result = await userManager.CreateAsync(user, password);

        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user, "Admin");
        }
    }
}

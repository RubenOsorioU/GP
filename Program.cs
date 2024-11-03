using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Gestion_Del_Presupuesto.Data;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", false);

// Configurar el servicio de DbContext para usar PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configurar autenticaci�n por cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Index";  // La p�gina de inicio de sesi�n
        options.AccessDeniedPath = "/Home/AccessDenied";  // P�gina de acceso denegado
    });

// Configurar autorizaci�n
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin")); // Pol�tica para Admin
    options.AddPolicy("UserOnly", policy => policy.RequireRole("User")); // Pol�tica para User
});

// Agregar servicios para controladores y vistas
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();  // Necesario para las sesiones
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);  // Tiempo de inactividad
    options.Cookie.HttpOnly = true;  // Seguridad
    options.Cookie.IsEssential = true;  // Cumplir con GDPR si es necesario
});

var app = builder.Build();

// Configurar el pipeline de solicitud HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();  // Habilitar el uso de sesiones
app.UseAuthentication();  // Habilitar autenticaci�n
app.UseAuthorization();   // Habilitar autorizaci�n

// Configurar las rutas predeterminadas de la aplicaci�n
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");//Cambiar Home Por Login

app.Run();

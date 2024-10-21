using Microsoft.EntityFrameworkCore;
using Gestion_Del_Presupuesto.Models;
using Gestion_Del_Presupuesto.Controllers;

namespace Gestion_Del_Presupuesto.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // Definir las tablas para cada modelo
        public DbSet<Campo_Clinico> Campo_Clinicos { get; set; }
        public DbSet<ConveniosModel> Convenios { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Historial_Actividad> Historial_Actividad { get; set; }
        public DbSet<Institucion_Salud> InstitucionesSalud { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<PresupuestoModel> Presupuestos { get; set; }
        public DbSet<Retribucion> Retribuciones { get; set; }
        public DbSet<Solicitud_Retribucion> SolicitudesRetribucion { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Devengado> Devengados { get; set; }
        public DbSet<Costo> Costo { get; set; }
        public DbSet<FacturacionModel> Facturacion { get; set; }
        
        public DbSet<UF2023> UF2023 {  get; set; }
        public DbSet<UF2024> UF2024 {  get; set; }
        public DbSet<UFCombinedViewModel> UFViewModel { get; set; }

        public DbSet<PlanillasModel> Planillas { get; set; }
        // Configurar relaciones entre entidades
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar la relación muchos a uno entre Retribucion y Convenio
            modelBuilder.Entity<Retribucion>()
                .HasOne(r => r.Convenio)
                .WithMany(c => c.Retribuciones)
                .HasForeignKey(r => r.Id_Convenio)
                .OnDelete(DeleteBehavior.Cascade);

            // Configurar la relación uno a uno entre Retribucion y Solicitud_Retribucion
            modelBuilder.Entity<Retribucion>()
                .HasOne(r => r.Solicitud_Retribucion)
                .WithOne(s => s.Retribucion)  // <-- Asegúrate de que la propiedad `Retribucion` exista en `Solicitud_Retribucion`
                .HasForeignKey<Retribucion>(r => r.Id_Solicitud_Retribucion)
                .OnDelete(DeleteBehavior.Cascade);

            // Configurar la relación entre Usuario y Historial_Actividad
            modelBuilder.Entity<Historial_Actividad>()
                .HasOne(h => h.Usuario)
                .WithMany(u => u.Historial_Actividades)
                .HasForeignKey(h => h.Id_Usuario)
                .OnDelete(DeleteBehavior.Cascade);

            // Configurar la relación muchos a uno entre Pago y Retribucion
            modelBuilder.Entity<Pago>()
                .HasOne(p => p.Convenio)
                .WithMany(r => r.Pagos)
                .HasForeignKey(p => p.Id_Convenio)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Estudiante>()
                .HasOne(e => e.Planilla)
                .WithOne(p => p.Estudiante)
                .HasForeignKey<PlanillasModel>(p => p.Id_Estudiante)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Rol>()
               .HasMany(r => r.Usuarios)
               .WithOne(u => u.Rol)
               .HasForeignKey(u => u.Id_Rol)
               .OnDelete(DeleteBehavior.Cascade);


        }

    }
}

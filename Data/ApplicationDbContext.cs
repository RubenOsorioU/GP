using Microsoft.EntityFrameworkCore;
using Gestion_Del_Presupuesto.Models;
using Gestion_Del_Presupuesto.Controllers;

namespace Gestion_Del_Presupuesto.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // Definir las tablas para cada modelo

        public DbSet<ConvenioModel> Convenios { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Historial_Actividad> Historial_Actividad { get; set; }
        public DbSet<Institucion_Salud> InstitucionesSalud { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<PresupuestoModel> Presupuestos { get; set; }
        public DbSet<RetribucionModel> Retribuciones { get; set; }
        public DbSet<Solicitud_Retribucion> SolicitudesRetribucion { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Devengado> Devengados { get; set; }
        public DbSet<Costo> Costo { get; set; }
        public DbSet<FacturacionModel> Facturacion { get; set; }

        public DbSet<PlanillasModel> Planillas { get; set; }
        // Configurar relaciones entre entidades
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar la relación muchos a uno entre Retribucion y Convenio


            // Configurar la relación uno a uno entre Retribucion y Solicitud_Retribucion


            // Configurar la relación entre Usuario y Historial_Actividad
            modelBuilder.Entity<Historial_Actividad>()
                .HasOne(h => h.Usuario)
                .WithMany(u => u.Historial_Actividades)
                .HasForeignKey(h => h.Id_Usuario)
                .OnDelete(DeleteBehavior.Cascade);

            // Configurar la relación muchos a uno entre Pago y Retribucion


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

            modelBuilder.Entity<RetribucionModel>()
               .HasOne(r => r.Convenios)
               .WithMany(c => c.Retribuciones)
               .HasForeignKey(r => r.ConvenioId) // Asumiendo que `ConvenioId` es la clave externa en `RetribucionModel`
               .OnDelete(DeleteBehavior.Cascade);
        }

    }
}

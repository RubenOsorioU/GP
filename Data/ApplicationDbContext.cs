using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Gestion_Del_Presupuesto.Models;

namespace Gestion_Del_Presupuesto.Data
{
    public class ApplicationDbContext : IdentityDbContext<Usuario, Rol, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ConvenioModel> Convenios { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Historial_Actividad> Historial_Actividad { get; set; }
        public DbSet<Institucion_Salud> InstitucionesSalud { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<PresupuestoModel> Presupuestos { get; set; }
        public DbSet<RetribucionModel> Retribuciones { get; set; }
        public DbSet<Solicitud_Retribucion> SolicitudesRetribucion { get; set; }
        public DbSet<Devengado> Devengados { get; set; }
        public DbSet<Costo> Costo { get; set; }
        public DbSet<FacturacionModel> Facturacion { get; set; }
        public DbSet<CentroSaludModel> CentrosDeSalud { get; set; }
        public DbSet<ProvisionModel> Provision { get; set; }
        public DbSet<PlanillasModel> Planillas { get; set; }
        public DbSet<IndicadorEconomico> IndicadorEcono { get; set; }
        public DbSet<CarreraModel> Carreras { get; set; }
        public DbSet<SeriesData> SerieDatas { get; set; }
        public DbSet<ObsData> ObsDatas { get; set; }
        public DbSet<EncuestaModel> Encuesta { get; set; }
        public DbSet<EstudiantePlanillaModel> EstudiantePlanillas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Necesario para Identity

            // Relación Historial_Actividad → Usuario
            modelBuilder.Entity<Historial_Actividad>()
                .HasOne(h => h.Usuario)
                .WithMany(u => u.Historial_Actividades)
                .HasForeignKey(h => h.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación Estudiante → Planilla
            modelBuilder.Entity<EstudiantePlanillaModel>()
                    .HasKey(ep => new { ep.EstudianteId, ep.PlanillaId });

            modelBuilder.Entity<EstudiantePlanillaModel>()
                .HasOne(ep => ep.Estudiante)
                .WithMany(e => e.EstudiantePlanillas)
                .HasForeignKey(ep => ep.EstudianteId);

            modelBuilder.Entity<EstudiantePlanillaModel>()
                .HasOne(ep => ep.Planilla)
                .WithMany(p => p.EstudiantePlanillas)
                .HasForeignKey(ep => ep.PlanillaId);

            // Relación Estudiante → Carrera
            modelBuilder.Entity<Estudiante>()
                .HasOne(e => e.Carrera)
                .WithMany(c => c.Estudiantes)
                .HasForeignKey(e => e.CarreraId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación Estudiante → Convenio
            modelBuilder.Entity<Estudiante>()
                .HasOne(e => e.Convenio)
                .WithMany(c => c.Estudiantes)
                .HasForeignKey(e => e.Id_Convenio)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación PlanillasModel → Carrera
            modelBuilder.Entity<PlanillasModel>()
                .HasOne(p => p.Carrera)
                .WithMany(c => c.Planillas)
                .HasForeignKey(p => p.CarreraId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación PlanillasModel → FacturacionModel
            modelBuilder.Entity<PlanillasModel>()
                .HasOne(p => p.Facturacion)
                .WithMany(f => f.Planillas)
                .HasForeignKey(p => p.FacturacionId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación PlanillasModel → IndicadorEconomico
            modelBuilder.Entity<PlanillasModel>()
                .HasOne(p => p.Indicador)
                .WithMany()
                .HasForeignKey(p => p.Id_IndicadorEco)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación Devengado → Convenio
            modelBuilder.Entity<Devengado>()
                .HasOne(d => d.Convenio)
                .WithMany(c => c.Devengados)
                .HasForeignKey(d => d.ConvenioId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación FacturacionModel → Convenio
            modelBuilder.Entity<FacturacionModel>()
                .HasOne(f => f.Convenios)
                .WithMany(c => c.Facturacion)
                .HasForeignKey(f => f.ConvenioId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuración para propiedades DateTime y DateTime? en UTC
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var dateTimeProperties = entityType.ClrType.GetProperties()
                    .Where(p => p.PropertyType == typeof(DateTime) || p.PropertyType == typeof(DateTime?));

                foreach (var property in dateTimeProperties)
                {
                    if (property.PropertyType == typeof(DateTime))
                    {
                        modelBuilder.Entity(entityType.ClrType).Property(property.Name).HasConversion(
                            new ValueConverter<DateTime, DateTime>(
                                v => DateTime.SpecifyKind(v, DateTimeKind.Utc), // Convertir a UTC
                                v => v // Mantener el valor al leer
                            )
                        );
                    }
                    else if (property.PropertyType == typeof(DateTime?))
                    {
                        modelBuilder.Entity(entityType.ClrType).Property(property.Name).HasConversion(
                            new ValueConverter<DateTime?, DateTime?>(
                                v => v.HasValue ? DateTime.SpecifyKind(v.Value, DateTimeKind.Utc) : (DateTime?)null,
                                v => v
                            )
                        );
                    }
                }
            }
        }
    }
}

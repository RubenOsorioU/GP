﻿using Microsoft.EntityFrameworkCore;
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
        public DbSet<CentroSaludModel> CentrosDeSalud { get; set; }
        public DbSet <ProvisionModel> Provision { get; set; }

        public DbSet<PlanillasModel> Planillas { get; set; }
        public DbSet<IndicadorEconomico> IndicadorEcono{ get; set; }
        public DbSet<CarreraModel> Carreras { get; set; }
        public DbSet<SeriesData> SerieDatas { get; set; }
        public DbSet<ObsData> ObsDatas { get; set; }

        //  relaciones entre entidades
        public override int SaveChanges()
        {
            ConvertDatesToUtc();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ConvertDatesToUtc();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void ConvertDatesToUtc()
        {
            foreach (var entry in ChangeTracker.Entries()
                 .Where(e => e.Entity is ConvenioModel && (e.State == EntityState.Added || e.State == EntityState.Modified)))
            {
                var convenio = (ConvenioModel)entry.Entity;

                convenio.Fecha_Inicio = DateTime.SpecifyKind(convenio.Fecha_Inicio, DateTimeKind.Utc);
                if (convenio.Fecha_Termino.HasValue)
                {
                    convenio.Fecha_Termino = DateTime.SpecifyKind(convenio.Fecha_Termino.Value, DateTimeKind.Utc);
                }

                if (convenio.Retribuciones != null)
                {
                    foreach (var retribucion in convenio.Retribuciones)
                    {
                        retribucion.FechaRetribucion = DateTime.SpecifyKind(retribucion.FechaRetribucion, DateTimeKind.Utc);
                    }
                }
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ConvenioModel>()
                .HasOne(c => c.Carreras)
                .WithMany(ca => ca.Convenios)
                .HasForeignKey(c => c.Id_Carrera)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Historial_Actividad>()
                .HasOne(h => h.Usuarios)
                .WithMany(u => u.Historial_Actividades)
                .HasForeignKey(h => h.Id_Usuario)
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

            modelBuilder.Entity<CentroSaludModel>()
               .HasOne(c => c.Convenios)
               .WithMany(c => c.CentrosDeSalud)
               .HasForeignKey(c => c.ConvenioId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RetribucionModel>()
               .HasOne(r => r.Convenios)
               .WithMany(c => c.Retribuciones)
               .HasForeignKey(r => r.ConvenioId) 
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PlanillasModel>()
               .HasOne(p => p.Carrera)
               .WithMany(c => c.Planillas)
               .HasForeignKey(p => p.CarreraId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PlanillasModel>()
                .HasOne(p => p.Facturacion)
                .WithMany(f => f.Planillas)
                .HasForeignKey(p => p.FacturacionId)
                .OnDelete(DeleteBehavior.Cascade);


        }

    }
}

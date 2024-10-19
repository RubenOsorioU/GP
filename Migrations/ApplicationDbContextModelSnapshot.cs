﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Gestion_Del_Presupuesto.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Gestion_Del_Presupuesto.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Campo_ClinicoEstudiante", b =>
                {
                    b.Property<int>("Campo_ClinicosId_Campo_Clinico")
                        .HasColumnType("integer");

                    b.Property<int>("EstudiantesId_Estudiante")
                        .HasColumnType("integer");

                    b.HasKey("Campo_ClinicosId_Campo_Clinico", "EstudiantesId_Estudiante");

                    b.HasIndex("EstudiantesId_Estudiante");

                    b.ToTable("Campo_ClinicoEstudiante");
                });

            modelBuilder.Entity("ConveniosModelPlanillasModel", b =>
                {
                    b.Property<int>("ConveniosId_Convenio")
                        .HasColumnType("integer");

                    b.Property<int>("PlanillasId_Planillas")
                        .HasColumnType("integer");

                    b.HasKey("ConveniosId_Convenio", "PlanillasId_Planillas");

                    b.HasIndex("PlanillasId_Planillas");

                    b.ToTable("ConveniosModelPlanillasModel");
                });

            modelBuilder.Entity("EstudiantePlanillasModel", b =>
                {
                    b.Property<int>("EstudiantesId_Estudiante")
                        .HasColumnType("integer");

                    b.Property<int>("PlanillasId_Planillas")
                        .HasColumnType("integer");

                    b.HasKey("EstudiantesId_Estudiante", "PlanillasId_Planillas");

                    b.HasIndex("PlanillasId_Planillas");

                    b.ToTable("EstudiantePlanillasModel");
                });

            modelBuilder.Entity("Gestion_Del_Presupuesto.Models.Campo_Clinico", b =>
                {
                    b.Property<int>("Id_Campo_Clinico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id_Campo_Clinico"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Sede")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id_Campo_Clinico");

                    b.ToTable("Campo_Clinicos");
                });

            modelBuilder.Entity("Gestion_Del_Presupuesto.Models.ConveniosModel", b =>
                {
                    b.Property<int>("Id_Convenio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id_Convenio"));

                    b.Property<int?>("Campo_ClinicoId_Campo_Clinico")
                        .HasColumnType("integer");

                    b.Property<decimal?>("Capacitacion")
                        .HasColumnType("numeric");

                    b.Property<bool>("CapacitacionSelected")
                        .HasColumnType("boolean");

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ContratosInstituciones")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal?>("Deuda2024")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("DeudaAnteriores")
                        .HasColumnType("numeric");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("EstudianteId_Estudiante")
                        .HasColumnType("integer");

                    b.Property<decimal?>("Facturado2024")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("Facturado2025")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("FacturadoAnteriores")
                        .HasColumnType("numeric");

                    b.Property<int?>("Institucion_SaludId_Institucion_Salud")
                        .HasColumnType("integer");

                    b.Property<int?>("NumeroEstudiantes")
                        .HasColumnType("integer");

                    b.Property<decimal?>("ObrasMayores")
                        .HasColumnType("numeric");

                    b.Property<bool>("ObrasMayoresSelected")
                        .HasColumnType("boolean");

                    b.Property<decimal?>("ObrasMenores")
                        .HasColumnType("numeric");

                    b.Property<bool>("ObrasMenoresSelected")
                        .HasColumnType("boolean");

                    b.Property<decimal?>("OtrosGastosRetribucion")
                        .HasColumnType("numeric");

                    b.Property<bool>("OtrosGastosRetribucionSelected")
                        .HasColumnType("boolean");

                    b.Property<decimal?>("PagoApoyoDocencia")
                        .HasColumnType("numeric");

                    b.Property<bool>("PagoApoyoDocenciaSelected")
                        .HasColumnType("boolean");

                    b.Property<decimal?>("PagoRRHH")
                        .HasColumnType("numeric");

                    b.Property<bool>("PagoRRHHSelected")
                        .HasColumnType("boolean");

                    b.Property<decimal?>("PagoUsoCC")
                        .HasColumnType("numeric");

                    b.Property<bool>("PagoUsoCCSelected")
                        .HasColumnType("boolean");

                    b.Property<decimal?>("SaldoEstimadoPagar")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("TotalDeuda")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("TotalFacturado")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("TotalGastoEstimado")
                        .HasColumnType("numeric");

                    b.HasKey("Id_Convenio");

                    b.HasIndex("Campo_ClinicoId_Campo_Clinico");

                    b.HasIndex("EstudianteId_Estudiante");

                    b.HasIndex("Institucion_SaludId_Institucion_Salud");

                    b.ToTable("Convenios");
                });

            modelBuilder.Entity("Gestion_Del_Presupuesto.Models.Costo", b =>
                {
                    b.Property<int>("Id_Costo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id_Costo"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Id_Convenio")
                        .HasColumnType("integer");

                    b.Property<float>("Monto")
                        .HasColumnType("real");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id_Costo");

                    b.HasIndex("Id_Convenio");

                    b.ToTable("Costo");
                });

            modelBuilder.Entity("Gestion_Del_Presupuesto.Models.Devengado", b =>
                {
                    b.Property<int>("Id_Devengado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id_Devengado"));

                    b.Property<int>("ConvenioId")
                        .HasColumnType("integer");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("DevengadoId_Devengado")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("GastoComprometido")
                        .HasColumnType("numeric");

                    b.Property<decimal>("PagosRealizados")
                        .HasColumnType("numeric");

                    b.Property<decimal>("SaldoPendiente")
                        .HasColumnType("numeric");

                    b.HasKey("Id_Devengado");

                    b.HasIndex("ConvenioId");

                    b.HasIndex("DevengadoId_Devengado");

                    b.ToTable("Devengados");
                });

            modelBuilder.Entity("Gestion_Del_Presupuesto.Models.Estudiante", b =>
                {
                    b.Property<int>("Id_Estudiante")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id_Estudiante"));

                    b.Property<string>("Carrera")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Id_Convenio")
                        .HasColumnType("integer");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id_Estudiante");

                    b.ToTable("Estudiantes");
                });

            modelBuilder.Entity("Gestion_Del_Presupuesto.Models.FacturacionModel", b =>
                {
                    b.Property<int>("Id_Facturacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id_Facturacion"));

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Carrera")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CorreoElectronico")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Giro")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Institucion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NivelFormacion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("NumeroAlumnos")
                        .HasColumnType("integer");

                    b.Property<int>("NumeroTiempo")
                        .HasColumnType("integer");

                    b.Property<string>("RUT")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RazonSocial")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ReceptorDocumento")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Sede")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("numeric");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TelefonoReceptor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TiempoPractica")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("ValorUF")
                        .HasColumnType("numeric");

                    b.HasKey("Id_Facturacion");

                    b.ToTable("Facturacion");
                });

            modelBuilder.Entity("Gestion_Del_Presupuesto.Models.Historial_Actividad", b =>
                {
                    b.Property<int>("Id_Historial_Actividad")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id_Historial_Actividad"));

                    b.Property<string>("Accion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Id_Usuario")
                        .HasColumnType("integer");

                    b.HasKey("Id_Historial_Actividad");

                    b.HasIndex("Id_Usuario");

                    b.ToTable("Historial_Actividad");
                });

            modelBuilder.Entity("Gestion_Del_Presupuesto.Models.Institucion_Salud", b =>
                {
                    b.Property<int>("Id_Institucion_Salud")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id_Institucion_Salud"));

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id_Institucion_Salud");

                    b.ToTable("InstitucionesSalud");
                });

            modelBuilder.Entity("Gestion_Del_Presupuesto.Models.Pago", b =>
                {
                    b.Property<int>("Id_Pago")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id_Pago"));

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("FechaVencimiento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Id_Convenio")
                        .HasColumnType("integer");

                    b.Property<int>("Id_Retribucion")
                        .HasColumnType("integer");

                    b.Property<float>("Monto")
                        .HasColumnType("real");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RetribucionId_Retribucion")
                        .HasColumnType("integer");

                    b.HasKey("Id_Pago");

                    b.HasIndex("Id_Convenio");

                    b.HasIndex("RetribucionId_Retribucion");

                    b.ToTable("Pagos");
                });

            modelBuilder.Entity("Gestion_Del_Presupuesto.Models.PlanillasModel", b =>
                {
                    b.Property<int>("Id_Planillas")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id_Planillas"));

                    b.Property<double>("CuantasSemanas")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("Fecha_Inicio")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Fecha_Termino")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Id_Estudiante")
                        .HasColumnType("integer");

                    b.Property<string>("Institución")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nombre_Planilla")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Rut")
                        .HasColumnType("integer");

                    b.Property<int>("TotalCosto")
                        .HasColumnType("integer");

                    b.Property<int>("ValorUfContrato")
                        .HasColumnType("integer");

                    b.HasKey("Id_Planillas");

                    b.HasIndex("Id_Estudiante")
                        .IsUnique();

                    b.ToTable("Planillas");
                });

            modelBuilder.Entity("Gestion_Del_Presupuesto.Models.PresupuestoModel", b =>
                {
                    b.Property<int>("Id_PresupuestoXCentroCosto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id_PresupuestoXCentroCosto"));

                    b.Property<int>("Anio")
                        .HasColumnType("integer");

                    b.Property<decimal>("CapacitacionRetribucion")
                        .HasColumnType("numeric");

                    b.Property<string>("Carrera")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CentroCosto")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Convenio")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("CostoMM")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("DeudaAnioActual")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("DeudaMorosa")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("FacturadoAnioActual")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("FacturadoAniosAnteriores")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("FacturadoCorresponde2024")
                        .HasColumnType("numeric");

                    b.Property<List<string>>("FormasRetribucionSeleccionadas")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<decimal>("OtrosGastosRetribucion")
                        .HasColumnType("numeric");

                    b.Property<decimal>("PagoApoyoDocencia")
                        .HasColumnType("numeric");

                    b.Property<decimal>("RRHHRetribucion")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("SaldoEstimadoPagarAnioActual")
                        .HasColumnType("numeric");

                    b.Property<string>("Sede")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal?>("TotalDeuda")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("TotalFacturadoPagado")
                        .HasColumnType("numeric");

                    b.Property<decimal>("TotalGastoEstimado")
                        .HasColumnType("numeric");

                    b.HasKey("Id_PresupuestoXCentroCosto");

                    b.ToTable("Presupuestos");
                });

            modelBuilder.Entity("Gestion_Del_Presupuesto.Models.Retribucion", b =>
                {
                    b.Property<int>("Id_Retribucion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id_Retribucion"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Id_Convenio")
                        .HasColumnType("integer");

                    b.Property<int>("Id_Solicitud_Retribucion")
                        .HasColumnType("integer");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Valor")
                        .HasColumnType("real");

                    b.HasKey("Id_Retribucion");

                    b.HasIndex("Id_Convenio");

                    b.HasIndex("Id_Solicitud_Retribucion")
                        .IsUnique();

                    b.ToTable("Retribuciones");
                });

            modelBuilder.Entity("Gestion_Del_Presupuesto.Models.Rol", b =>
                {
                    b.Property<int>("Id_Rol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id_Rol"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Permisos")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id_Rol");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Gestion_Del_Presupuesto.Models.Solicitud_Retribucion", b =>
                {
                    b.Property<int>("Id_Solicitud_Retribucion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id_Solicitud_Retribucion"));

                    b.Property<int>("ConvenioId_Convenio")
                        .HasColumnType("integer");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Id_Convenio")
                        .HasColumnType("integer");

                    b.Property<string>("Solicitante")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id_Solicitud_Retribucion");

                    b.HasIndex("ConvenioId_Convenio");

                    b.ToTable("SolicitudesRetribucion");
                });

            modelBuilder.Entity("Gestion_Del_Presupuesto.Models.UFData", b =>
                {
                    b.Property<int>("Id_UFData")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id_UFData"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("UFValue")
                        .HasColumnType("numeric");

                    b.Property<int?>("UFViewModelId_UF")
                        .HasColumnType("integer");

                    b.HasKey("Id_UFData");

                    b.HasIndex("UFViewModelId_UF");

                    b.ToTable("UFData");
                });

            modelBuilder.Entity("Gestion_Del_Presupuesto.Models.UFViewModel", b =>
                {
                    b.Property<int>("Id_UF")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id_UF"));

                    b.Property<double>("Abr")
                        .HasColumnType("double precision");

                    b.Property<double>("Ago")
                        .HasColumnType("double precision");

                    b.Property<int>("Dia")
                        .HasColumnType("integer");

                    b.Property<double>("Dic")
                        .HasColumnType("double precision");

                    b.Property<double>("Ene")
                        .HasColumnType("double precision");

                    b.Property<double>("Feb")
                        .HasColumnType("double precision");

                    b.Property<double>("Jul")
                        .HasColumnType("double precision");

                    b.Property<double>("Jun")
                        .HasColumnType("double precision");

                    b.Property<double>("Mar")
                        .HasColumnType("double precision");

                    b.Property<double>("May")
                        .HasColumnType("double precision");

                    b.Property<decimal>("MontoUF")
                        .HasColumnType("numeric");

                    b.Property<double>("Nov")
                        .HasColumnType("double precision");

                    b.Property<double>("Oct")
                        .HasColumnType("double precision");

                    b.Property<decimal>("Resultado")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("SelectedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("SelectedMonth")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SelectedYear")
                        .HasColumnType("integer");

                    b.Property<double>("Sep")
                        .HasColumnType("double precision");

                    b.Property<decimal>("UFValueForDate")
                        .HasColumnType("numeric");

                    b.HasKey("Id_UF");

                    b.ToTable("UFViewModel");
                });

            modelBuilder.Entity("Gestion_Del_Presupuesto.Models.Usuario", b =>
                {
                    b.Property<int>("Id_Usuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id_Usuario"));

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Id_Rol")
                        .HasColumnType("integer");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id_Usuario");

                    b.HasIndex("Id_Rol");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Campo_ClinicoEstudiante", b =>
                {
                    b.HasOne("Gestion_Del_Presupuesto.Models.Campo_Clinico", null)
                        .WithMany()
                        .HasForeignKey("Campo_ClinicosId_Campo_Clinico")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gestion_Del_Presupuesto.Models.Estudiante", null)
                        .WithMany()
                        .HasForeignKey("EstudiantesId_Estudiante")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ConveniosModelPlanillasModel", b =>
                {
                    b.HasOne("Gestion_Del_Presupuesto.Models.ConveniosModel", null)
                        .WithMany()
                        .HasForeignKey("ConveniosId_Convenio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gestion_Del_Presupuesto.Models.PlanillasModel", null)
                        .WithMany()
                        .HasForeignKey("PlanillasId_Planillas")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EstudiantePlanillasModel", b =>
                {
                    b.HasOne("Gestion_Del_Presupuesto.Models.Estudiante", null)
                        .WithMany()
                        .HasForeignKey("EstudiantesId_Estudiante")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gestion_Del_Presupuesto.Models.PlanillasModel", null)
                        .WithMany()
                        .HasForeignKey("PlanillasId_Planillas")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Gestion_Del_Presupuesto.Models.ConveniosModel", b =>
                {
                    b.HasOne("Gestion_Del_Presupuesto.Models.Campo_Clinico", null)
                        .WithMany("Convenios")
                        .HasForeignKey("Campo_ClinicoId_Campo_Clinico");

                    b.HasOne("Gestion_Del_Presupuesto.Models.Estudiante", null)
                        .WithMany("Convenio")
                        .HasForeignKey("EstudianteId_Estudiante");

                    b.HasOne("Gestion_Del_Presupuesto.Models.Institucion_Salud", null)
                        .WithMany("Convenios")
                        .HasForeignKey("Institucion_SaludId_Institucion_Salud");
                });

            modelBuilder.Entity("Gestion_Del_Presupuesto.Models.Costo", b =>
                {
                    b.HasOne("Gestion_Del_Presupuesto.Models.ConveniosModel", "Convenio")
                        .WithMany()
                        .HasForeignKey("Id_Convenio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Convenio");
                });

            modelBuilder.Entity("Gestion_Del_Presupuesto.Models.Devengado", b =>
                {
                    b.HasOne("Gestion_Del_Presupuesto.Models.ConveniosModel", "Convenio")
                        .WithMany()
                        .HasForeignKey("ConvenioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gestion_Del_Presupuesto.Models.Devengado", null)
                        .WithMany("Devengados")
                        .HasForeignKey("DevengadoId_Devengado");

                    b.Navigation("Convenio");
                });

            modelBuilder.Entity("Gestion_Del_Presupuesto.Models.Historial_Actividad", b =>
                {
                    b.HasOne("Gestion_Del_Presupuesto.Models.Usuario", "Usuario")
                        .WithMany("Historial_Actividades")
                        .HasForeignKey("Id_Usuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Gestion_Del_Presupuesto.Models.Pago", b =>
                {
                    b.HasOne("Gestion_Del_Presupuesto.Models.Retribucion", "Convenio")
                        .WithMany("Pagos")
                        .HasForeignKey("Id_Convenio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gestion_Del_Presupuesto.Models.Retribucion", "Retribucion")
                        .WithMany()
                        .HasForeignKey("RetribucionId_Retribucion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Convenio");

                    b.Navigation("Retribucion");
                });

            modelBuilder.Entity("Gestion_Del_Presupuesto.Models.PlanillasModel", b =>
                {
                    b.HasOne("Gestion_Del_Presupuesto.Models.Estudiante", "Estudiante")
                        .WithOne("Planilla")
                        .HasForeignKey("Gestion_Del_Presupuesto.Models.PlanillasModel", "Id_Estudiante")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estudiante");
                });

            modelBuilder.Entity("Gestion_Del_Presupuesto.Models.Retribucion", b =>
                {
                    b.HasOne("Gestion_Del_Presupuesto.Models.ConveniosModel", "Convenio")
                        .WithMany("Retribuciones")
                        .HasForeignKey("Id_Convenio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gestion_Del_Presupuesto.Models.Solicitud_Retribucion", "Solicitud_Retribucion")
                        .WithOne("Retribucion")
                        .HasForeignKey("Gestion_Del_Presupuesto.Models.Retribucion", "Id_Solicitud_Retribucion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Convenio");

                    b.Navigation("Solicitud_Retribucion");
                });

            modelBuilder.Entity("Gestion_Del_Presupuesto.Models.Solicitud_Retribucion", b =>
                {
                    b.HasOne("Gestion_Del_Presupuesto.Models.ConveniosModel", "Convenio")
                        .WithMany()
                        .HasForeignKey("ConvenioId_Convenio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Convenio");
                });

            modelBuilder.Entity("Gestion_Del_Presupuesto.Models.UFData", b =>
                {
                    b.HasOne("Gestion_Del_Presupuesto.Models.UFViewModel", null)
                        .WithMany("UFValues")
                        .HasForeignKey("UFViewModelId_UF");
                });

            modelBuilder.Entity("Gestion_Del_Presupuesto.Models.Usuario", b =>
                {
                    b.HasOne("Gestion_Del_Presupuesto.Models.Rol", "Rol")
                        .WithMany("Usuarios")
                        .HasForeignKey("Id_Rol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("Gestion_Del_Presupuesto.Models.Campo_Clinico", b =>
                {
                    b.Navigation("Convenios");
                });

            modelBuilder.Entity("Gestion_Del_Presupuesto.Models.ConveniosModel", b =>
                {
                    b.Navigation("Retribuciones");
                });

            modelBuilder.Entity("Gestion_Del_Presupuesto.Models.Devengado", b =>
                {
                    b.Navigation("Devengados");
                });

            modelBuilder.Entity("Gestion_Del_Presupuesto.Models.Estudiante", b =>
                {
                    b.Navigation("Convenio");

                    b.Navigation("Planilla")
                        .IsRequired();
                });

            modelBuilder.Entity("Gestion_Del_Presupuesto.Models.Institucion_Salud", b =>
                {
                    b.Navigation("Convenios");
                });

            modelBuilder.Entity("Gestion_Del_Presupuesto.Models.Retribucion", b =>
                {
                    b.Navigation("Pagos");
                });

            modelBuilder.Entity("Gestion_Del_Presupuesto.Models.Rol", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("Gestion_Del_Presupuesto.Models.Solicitud_Retribucion", b =>
                {
                    b.Navigation("Retribucion")
                        .IsRequired();
                });

            modelBuilder.Entity("Gestion_Del_Presupuesto.Models.UFViewModel", b =>
                {
                    b.Navigation("UFValues");
                });

            modelBuilder.Entity("Gestion_Del_Presupuesto.Models.Usuario", b =>
                {
                    b.Navigation("Historial_Actividades");
                });
#pragma warning restore 612, 618
        }
    }
}

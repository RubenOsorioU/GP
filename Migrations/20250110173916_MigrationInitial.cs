﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Gestion_Del_Presupuesto.Migrations
{
    /// <inheritdoc />
    public partial class MigrationInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carreras",
                columns: table => new
                {
                    Id_Carrera = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Codigo = table.Column<string>(type: "text", nullable: false),
                    Facultad = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carreras", x => x.Id_Carrera);
                });

            migrationBuilder.CreateTable(
                name: "Encuesta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Tipo = table.Column<string>(type: "text", nullable: false),
                    ArchivoRuta = table.Column<string>(type: "text", nullable: false),
                    Puntuacion = table.Column<int>(type: "integer", nullable: false),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Encuesta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InstitucionesSalud",
                columns: table => new
                {
                    Id_Institucion_Salud = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Direccion = table.Column<string>(type: "text", nullable: false),
                    Telefono = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstitucionesSalud", x => x.Id_Institucion_Salud);
                });

            migrationBuilder.CreateTable(
                name: "Provision",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NombreSede = table.Column<string>(type: "text", nullable: false),
                    NombreCampoClinico = table.Column<string>(type: "text", nullable: false),
                    Numero = table.Column<int>(type: "integer", nullable: false),
                    TipoGasto = table.Column<string>(type: "text", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    Monto = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provision", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SerieDatas",
                columns: table => new
                {
                    Id_SeriesData = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DescripEsp = table.Column<string>(type: "text", nullable: false),
                    DescripIng = table.Column<string>(type: "text", nullable: false),
                    SeriesId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SerieDatas", x => x.Id_SeriesData);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Rut = table.Column<string>(type: "text", nullable: false),
                    RolId = table.Column<int>(type: "integer", nullable: true),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_AspNetRoles_RolId",
                        column: x => x.RolId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Convenios",
                columns: table => new
                {
                    Id_Convenio = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Tipo_Convenio = table.Column<string>(type: "text", nullable: true),
                    Sede = table.Column<string>(type: "text", nullable: false),
                    Fecha_Inicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Fecha_Termino = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ContactoPrincipal = table.Column<string>(type: "text", nullable: false),
                    Telefono = table.Column<string>(type: "text", nullable: false),
                    Rut = table.Column<string>(type: "text", nullable: false),
                    Direccion = table.Column<string>(type: "text", nullable: false),
                    RenovacionAutomatica = table.Column<bool>(type: "boolean", nullable: false),
                    Adendum = table.Column<bool>(type: "boolean", nullable: false),
                    FechaAdendum = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ObservacionAdendum = table.Column<string>(type: "text", nullable: true),
                    Version = table.Column<int>(type: "integer", nullable: false),
                    ValorUF = table.Column<decimal>(type: "numeric", nullable: false),
                    Eliminado = table.Column<bool>(type: "boolean", nullable: false),
                    Id_Retribucion = table.Column<int>(type: "integer", nullable: false),
                    CentrosDeSaludId = table.Column<int>(type: "integer", nullable: false),
                    Institucion_SaludId_Institucion_Salud = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Convenios", x => x.Id_Convenio);
                    table.ForeignKey(
                        name: "FK_Convenios_InstitucionesSalud_Institucion_SaludId_Institucio~",
                        column: x => x.Institucion_SaludId_Institucion_Salud,
                        principalTable: "InstitucionesSalud",
                        principalColumn: "Id_Institucion_Salud");
                });

            migrationBuilder.CreateTable(
                name: "IndicadorEcono",
                columns: table => new
                {
                    Id_IndicadorEco = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Codigo = table.Column<int>(type: "integer", nullable: false),
                    SelectedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    SeriesId_SeriesData = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndicadorEcono", x => x.Id_IndicadorEco);
                    table.ForeignKey(
                        name: "FK_IndicadorEcono_SerieDatas_SeriesId_SeriesData",
                        column: x => x.SeriesId_SeriesData,
                        principalTable: "SerieDatas",
                        principalColumn: "Id_SeriesData",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ObsDatas",
                columns: table => new
                {
                    IndexDateString = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    StatusCode = table.Column<string>(type: "text", nullable: false),
                    SeriesDataId_SeriesData = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObsDatas", x => x.IndexDateString);
                    table.ForeignKey(
                        name: "FK_ObsDatas_SerieDatas_SeriesDataId_SeriesData",
                        column: x => x.SeriesDataId_SeriesData,
                        principalTable: "SerieDatas",
                        principalColumn: "Id_SeriesData");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Historial_Actividad",
                columns: table => new
                {
                    Id_Historial_Actividad = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Accion = table.Column<string>(type: "text", nullable: false),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Detalles = table.Column<string>(type: "text", nullable: false),
                    UsuarioId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historial_Actividad", x => x.Id_Historial_Actividad);
                    table.ForeignKey(
                        name: "FK_Historial_Actividad_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Costo",
                columns: table => new
                {
                    Id_Costo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Monto = table.Column<float>(type: "real", nullable: false),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Tipo = table.Column<string>(type: "text", nullable: false),
                    Id_Convenio = table.Column<int>(type: "integer", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Costo", x => x.Id_Costo);
                    table.ForeignKey(
                        name: "FK_Costo_Convenios_Id_Convenio",
                        column: x => x.Id_Convenio,
                        principalTable: "Convenios",
                        principalColumn: "Id_Convenio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Devengados",
                columns: table => new
                {
                    Id_Devengado = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Carrera = table.Column<string>(type: "text", nullable: false),
                    CentroCosto = table.Column<string>(type: "text", nullable: false),
                    Itempresupuestario = table.Column<string>(type: "text", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    GastoTotalComprometidoMonto = table.Column<decimal>(type: "numeric", nullable: false),
                    CantEstudiantes = table.Column<int>(type: "integer", nullable: false),
                    ValorUFDevengado = table.Column<decimal>(type: "numeric", nullable: false),
                    SaldoPendiente = table.Column<decimal>(type: "numeric", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    TotalGastoDevengadoGeneradoporEstudiantes = table.Column<decimal>(type: "numeric", nullable: false),
                    ConvenioId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devengados", x => x.Id_Devengado);
                    table.ForeignKey(
                        name: "FK_Devengados_Convenios_ConvenioId",
                        column: x => x.ConvenioId,
                        principalTable: "Convenios",
                        principalColumn: "Id_Convenio",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    Id_Estudiante = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Rut_Estudiante = table.Column<string>(type: "text", nullable: false),
                    Nivel_Formacion = table.Column<int>(type: "integer", nullable: false),
                    CarreraId = table.Column<int>(type: "integer", nullable: false),
                    Id_Convenio = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.Id_Estudiante);
                    table.ForeignKey(
                        name: "FK_Estudiantes_Carreras_CarreraId",
                        column: x => x.CarreraId,
                        principalTable: "Carreras",
                        principalColumn: "Id_Carrera",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Estudiantes_Convenios_Id_Convenio",
                        column: x => x.Id_Convenio,
                        principalTable: "Convenios",
                        principalColumn: "Id_Convenio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Presupuestos",
                columns: table => new
                {
                    Id_PresupuestoXCentroCosto = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Carrera = table.Column<string>(type: "text", nullable: false),
                    Sede = table.Column<string>(type: "text", nullable: false),
                    Convenio = table.Column<string>(type: "text", nullable: false),
                    CentroCosto = table.Column<string>(type: "text", nullable: false),
                    CostoMM = table.Column<decimal>(type: "numeric", nullable: false),
                    RRHHRetribucion = table.Column<decimal>(type: "numeric", nullable: false),
                    CapacitacionRetribucion = table.Column<decimal>(type: "numeric", nullable: false),
                    PagoApoyoDocencia = table.Column<decimal>(type: "numeric", nullable: false),
                    OtrosGastosRetribucion = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalGastoEstimado = table.Column<decimal>(type: "numeric", nullable: false),
                    Anio = table.Column<int>(type: "integer", nullable: false),
                    DeudaMorosa = table.Column<decimal>(type: "numeric", nullable: true),
                    DeudaAnioActual = table.Column<decimal>(type: "numeric", nullable: true),
                    TotalDeuda = table.Column<decimal>(type: "numeric", nullable: true),
                    FacturadoAniosAnteriores = table.Column<decimal>(type: "numeric", nullable: true),
                    FacturadoAnioActual = table.Column<decimal>(type: "numeric", nullable: true),
                    FacturadoCorresponde2024 = table.Column<decimal>(type: "numeric", nullable: true),
                    TotalFacturadoPagado = table.Column<decimal>(type: "numeric", nullable: true),
                    SaldoEstimadoPagarAnioActual = table.Column<decimal>(type: "numeric", nullable: true),
                    ConvenioId = table.Column<int>(type: "integer", nullable: false),
                    ConveniosId_Convenio = table.Column<int>(type: "integer", nullable: true),
                    FormasRetribucionSeleccionadas = table.Column<List<string>>(type: "text[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presupuestos", x => x.Id_PresupuestoXCentroCosto);
                    table.ForeignKey(
                        name: "FK_Presupuestos_Convenios_ConveniosId_Convenio",
                        column: x => x.ConveniosId_Convenio,
                        principalTable: "Convenios",
                        principalColumn: "Id_Convenio");
                });

            migrationBuilder.CreateTable(
                name: "Retribuciones",
                columns: table => new
                {
                    Id_Retribucion = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Tipo_Retribucion = table.Column<string>(type: "text", nullable: false),
                    DetalleOtrosGastos = table.Column<string>(type: "text", nullable: true),
                    Monto = table.Column<decimal>(type: "numeric", nullable: false),
                    CantPesos = table.Column<decimal>(type: "numeric", nullable: false),
                    UFTotal = table.Column<decimal>(type: "numeric", nullable: false),
                    ConvenioId = table.Column<int>(type: "integer", nullable: false),
                    CarreraId = table.Column<int>(type: "integer", nullable: false),
                    Periodo = table.Column<string>(type: "text", nullable: true),
                    Tipo_Practica = table.Column<string>(type: "text", nullable: true),
                    FechaRetribucion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ConveniosId_Convenio = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Retribuciones", x => x.Id_Retribucion);
                    table.ForeignKey(
                        name: "FK_Retribuciones_Convenios_ConveniosId_Convenio",
                        column: x => x.ConveniosId_Convenio,
                        principalTable: "Convenios",
                        principalColumn: "Id_Convenio");
                });

            migrationBuilder.CreateTable(
                name: "Facturacion",
                columns: table => new
                {
                    Id_Facturacion = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RazonSocial = table.Column<string>(type: "text", nullable: false),
                    RUT = table.Column<string>(type: "text", nullable: false),
                    Giro = table.Column<string>(type: "text", nullable: false),
                    Direccion = table.Column<string>(type: "text", nullable: false),
                    Telefono = table.Column<string>(type: "text", nullable: false),
                    ReceptorDocumento = table.Column<string>(type: "text", nullable: false),
                    Cargo = table.Column<string>(type: "text", nullable: false),
                    TelefonoReceptor = table.Column<string>(type: "text", nullable: false),
                    CorreoElectronico = table.Column<string>(type: "text", nullable: false),
                    Sede = table.Column<string>(type: "text", nullable: false),
                    Carrera = table.Column<string>(type: "text", nullable: false),
                    NivelFormacion = table.Column<string>(type: "text", nullable: false),
                    TiempoPractica = table.Column<string>(type: "text", nullable: false),
                    NumeroTiempo = table.Column<int>(type: "integer", nullable: false),
                    NumeroAlumnos = table.Column<int>(type: "integer", nullable: false),
                    ValorUFMesPractica = table.Column<decimal>(type: "numeric", nullable: false),
                    FechaUFDia = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ValorUF = table.Column<decimal>(type: "numeric", nullable: false),
                    Subtotal = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalEstudiantes = table.Column<int>(type: "integer", nullable: true),
                    NetoUF = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalaPagar = table.Column<decimal>(type: "numeric", nullable: false),
                    Eliminado = table.Column<bool>(type: "boolean", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaTermino = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ConvenioId = table.Column<int>(type: "integer", nullable: false),
                    Id_IndicadorEco = table.Column<int>(type: "integer", nullable: false),
                    FacturacionSeleccionada = table.Column<bool>(type: "boolean", nullable: false),
                    CarrerasId_Carrera = table.Column<int>(type: "integer", nullable: true),
                    ObsvalorUFIndexDateString = table.Column<string>(type: "text", nullable: true),
                    IndicadorId_IndicadorEco = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturacion", x => x.Id_Facturacion);
                    table.ForeignKey(
                        name: "FK_Facturacion_Carreras_CarrerasId_Carrera",
                        column: x => x.CarrerasId_Carrera,
                        principalTable: "Carreras",
                        principalColumn: "Id_Carrera");
                    table.ForeignKey(
                        name: "FK_Facturacion_Convenios_ConvenioId",
                        column: x => x.ConvenioId,
                        principalTable: "Convenios",
                        principalColumn: "Id_Convenio",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Facturacion_IndicadorEcono_IndicadorId_IndicadorEco",
                        column: x => x.IndicadorId_IndicadorEco,
                        principalTable: "IndicadorEcono",
                        principalColumn: "Id_IndicadorEco");
                    table.ForeignKey(
                        name: "FK_Facturacion_ObsDatas_ObsvalorUFIndexDateString",
                        column: x => x.ObsvalorUFIndexDateString,
                        principalTable: "ObsDatas",
                        principalColumn: "IndexDateString");
                });

            migrationBuilder.CreateTable(
                name: "CentrosDeSalud",
                columns: table => new
                {
                    Id_CentroSalud = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Rut_CentrodeSalud = table.Column<int>(type: "integer", nullable: false),
                    NombreCentro = table.Column<string>(type: "text", nullable: false),
                    Direccion = table.Column<string>(type: "text", nullable: false),
                    Telefono_CentroAso = table.Column<string>(type: "text", nullable: false),
                    NombrecargocentroAso = table.Column<string>(type: "text", nullable: false),
                    CorreoPersonaCargo = table.Column<string>(type: "text", nullable: false),
                    ConvenioId = table.Column<int>(type: "integer", nullable: false),
                    ConveniosId_Convenio = table.Column<int>(type: "integer", nullable: true),
                    RetribucionesId_Retribucion = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentrosDeSalud", x => x.Id_CentroSalud);
                    table.ForeignKey(
                        name: "FK_CentrosDeSalud_Convenios_ConveniosId_Convenio",
                        column: x => x.ConveniosId_Convenio,
                        principalTable: "Convenios",
                        principalColumn: "Id_Convenio");
                    table.ForeignKey(
                        name: "FK_CentrosDeSalud_Retribuciones_RetribucionesId_Retribucion",
                        column: x => x.RetribucionesId_Retribucion,
                        principalTable: "Retribuciones",
                        principalColumn: "Id_Retribucion");
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    Id_Pago = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Monto = table.Column<float>(type: "real", nullable: false),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Estado = table.Column<string>(type: "text", nullable: false),
                    Id_Retribucion = table.Column<int>(type: "integer", nullable: false),
                    Id_Convenio = table.Column<int>(type: "integer", nullable: false),
                    RetribucionesId_Retribucion = table.Column<int>(type: "integer", nullable: false),
                    ConveniosId_Convenio = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.Id_Pago);
                    table.ForeignKey(
                        name: "FK_Pagos_Convenios_ConveniosId_Convenio",
                        column: x => x.ConveniosId_Convenio,
                        principalTable: "Convenios",
                        principalColumn: "Id_Convenio",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pagos_Retribuciones_RetribucionesId_Retribucion",
                        column: x => x.RetribucionesId_Retribucion,
                        principalTable: "Retribuciones",
                        principalColumn: "Id_Retribucion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SolicitudesRetribucion",
                columns: table => new
                {
                    Id_Solicitud_Retribucion = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Solicitante = table.Column<string>(type: "text", nullable: false),
                    Estado = table.Column<string>(type: "text", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    Id_Convenio = table.Column<int>(type: "integer", nullable: false),
                    ConvenioId_Convenio = table.Column<int>(type: "integer", nullable: false),
                    RetribucionId_Retribucion = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitudesRetribucion", x => x.Id_Solicitud_Retribucion);
                    table.ForeignKey(
                        name: "FK_SolicitudesRetribucion_Convenios_ConvenioId_Convenio",
                        column: x => x.ConvenioId_Convenio,
                        principalTable: "Convenios",
                        principalColumn: "Id_Convenio",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SolicitudesRetribucion_Retribuciones_RetribucionId_Retribuc~",
                        column: x => x.RetribucionId_Retribucion,
                        principalTable: "Retribuciones",
                        principalColumn: "Id_Retribucion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Planillas",
                columns: table => new
                {
                    Id_Planillas = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NombresApellidosEstudiante = table.Column<string>(type: "text", nullable: false),
                    RunEstudiante = table.Column<string>(type: "text", nullable: false),
                    FechaInicioPractica = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaTerminoPractica = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Institucion = table.Column<string>(type: "text", nullable: false),
                    Servicio = table.Column<string>(type: "text", nullable: false),
                    Area = table.Column<string>(type: "text", nullable: false),
                    Nivel = table.Column<string>(type: "text", nullable: false),
                    CodigoNivel = table.Column<string>(type: "text", nullable: false),
                    TipoPrograma = table.Column<string>(type: "text", nullable: false),
                    TipoSeccion = table.Column<string>(type: "text", nullable: false),
                    Seccion = table.Column<string>(type: "text", nullable: false),
                    InscritosSeccion = table.Column<int>(type: "integer", nullable: false),
                    TipoTurno = table.Column<string>(type: "text", nullable: false),
                    NumeroSemanas = table.Column<int>(type: "integer", nullable: false),
                    HorasMensuales = table.Column<double>(type: "double precision", nullable: false),
                    ValorUFMes = table.Column<double>(type: "double precision", nullable: false),
                    ValorUFSemana = table.Column<double>(type: "double precision", nullable: false),
                    ValorTotalUF = table.Column<double>(type: "double precision", nullable: false),
                    ValorPesos = table.Column<decimal>(type: "numeric", nullable: false),
                    MontoMensual = table.Column<decimal>(type: "numeric", nullable: false),
                    RunDocenteClinico = table.Column<string>(type: "text", nullable: false),
                    DVDocenteClinico = table.Column<string>(type: "text", nullable: false),
                    NombreDocenteClinico = table.Column<string>(type: "text", nullable: false),
                    CodigoCentroCosto = table.Column<string>(type: "text", nullable: false),
                    CodigoAsignatura = table.Column<string>(type: "text", nullable: false),
                    ItemPresupuestario = table.Column<string>(type: "text", nullable: false),
                    Cohorte = table.Column<string>(type: "text", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    CarreraId = table.Column<int>(type: "integer", nullable: false),
                    Eliminado = table.Column<bool>(type: "boolean", nullable: false),
                    FacturacionId = table.Column<int>(type: "integer", nullable: false),
                    DevengadoId_Devengado = table.Column<int>(type: "integer", nullable: false),
                    Id_IndicadorEco = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planillas", x => x.Id_Planillas);
                    table.ForeignKey(
                        name: "FK_Planillas_Carreras_CarreraId",
                        column: x => x.CarreraId,
                        principalTable: "Carreras",
                        principalColumn: "Id_Carrera",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Planillas_Devengados_DevengadoId_Devengado",
                        column: x => x.DevengadoId_Devengado,
                        principalTable: "Devengados",
                        principalColumn: "Id_Devengado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Planillas_Facturacion_FacturacionId",
                        column: x => x.FacturacionId,
                        principalTable: "Facturacion",
                        principalColumn: "Id_Facturacion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Planillas_IndicadorEcono_Id_IndicadorEco",
                        column: x => x.Id_IndicadorEco,
                        principalTable: "IndicadorEcono",
                        principalColumn: "Id_IndicadorEco",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EstudiantePlanillas",
                columns: table => new
                {
                    EstudianteId = table.Column<int>(type: "integer", nullable: false),
                    PlanillaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstudiantePlanillas", x => new { x.EstudianteId, x.PlanillaId });
                    table.ForeignKey(
                        name: "FK_EstudiantePlanillas_Estudiantes_EstudianteId",
                        column: x => x.EstudianteId,
                        principalTable: "Estudiantes",
                        principalColumn: "Id_Estudiante",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstudiantePlanillas_Planillas_PlanillaId",
                        column: x => x.PlanillaId,
                        principalTable: "Planillas",
                        principalColumn: "Id_Planillas",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RolId",
                table: "AspNetUsers",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CentrosDeSalud_ConveniosId_Convenio",
                table: "CentrosDeSalud",
                column: "ConveniosId_Convenio");

            migrationBuilder.CreateIndex(
                name: "IX_CentrosDeSalud_RetribucionesId_Retribucion",
                table: "CentrosDeSalud",
                column: "RetribucionesId_Retribucion");

            migrationBuilder.CreateIndex(
                name: "IX_Convenios_Institucion_SaludId_Institucion_Salud",
                table: "Convenios",
                column: "Institucion_SaludId_Institucion_Salud");

            migrationBuilder.CreateIndex(
                name: "IX_Costo_Id_Convenio",
                table: "Costo",
                column: "Id_Convenio");

            migrationBuilder.CreateIndex(
                name: "IX_Devengados_ConvenioId",
                table: "Devengados",
                column: "ConvenioId");

            migrationBuilder.CreateIndex(
                name: "IX_EstudiantePlanillas_PlanillaId",
                table: "EstudiantePlanillas",
                column: "PlanillaId");

            migrationBuilder.CreateIndex(
                name: "IX_Estudiantes_CarreraId",
                table: "Estudiantes",
                column: "CarreraId");

            migrationBuilder.CreateIndex(
                name: "IX_Estudiantes_Id_Convenio",
                table: "Estudiantes",
                column: "Id_Convenio");

            migrationBuilder.CreateIndex(
                name: "IX_Facturacion_CarrerasId_Carrera",
                table: "Facturacion",
                column: "CarrerasId_Carrera");

            migrationBuilder.CreateIndex(
                name: "IX_Facturacion_ConvenioId",
                table: "Facturacion",
                column: "ConvenioId");

            migrationBuilder.CreateIndex(
                name: "IX_Facturacion_IndicadorId_IndicadorEco",
                table: "Facturacion",
                column: "IndicadorId_IndicadorEco");

            migrationBuilder.CreateIndex(
                name: "IX_Facturacion_ObsvalorUFIndexDateString",
                table: "Facturacion",
                column: "ObsvalorUFIndexDateString");

            migrationBuilder.CreateIndex(
                name: "IX_Historial_Actividad_UsuarioId",
                table: "Historial_Actividad",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_IndicadorEcono_SeriesId_SeriesData",
                table: "IndicadorEcono",
                column: "SeriesId_SeriesData");

            migrationBuilder.CreateIndex(
                name: "IX_ObsDatas_SeriesDataId_SeriesData",
                table: "ObsDatas",
                column: "SeriesDataId_SeriesData");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_ConveniosId_Convenio",
                table: "Pagos",
                column: "ConveniosId_Convenio");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_RetribucionesId_Retribucion",
                table: "Pagos",
                column: "RetribucionesId_Retribucion");

            migrationBuilder.CreateIndex(
                name: "IX_Planillas_CarreraId",
                table: "Planillas",
                column: "CarreraId");

            migrationBuilder.CreateIndex(
                name: "IX_Planillas_DevengadoId_Devengado",
                table: "Planillas",
                column: "DevengadoId_Devengado");

            migrationBuilder.CreateIndex(
                name: "IX_Planillas_FacturacionId",
                table: "Planillas",
                column: "FacturacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Planillas_Id_IndicadorEco",
                table: "Planillas",
                column: "Id_IndicadorEco");

            migrationBuilder.CreateIndex(
                name: "IX_Presupuestos_ConveniosId_Convenio",
                table: "Presupuestos",
                column: "ConveniosId_Convenio");

            migrationBuilder.CreateIndex(
                name: "IX_Retribuciones_ConveniosId_Convenio",
                table: "Retribuciones",
                column: "ConveniosId_Convenio");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudesRetribucion_ConvenioId_Convenio",
                table: "SolicitudesRetribucion",
                column: "ConvenioId_Convenio");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudesRetribucion_RetribucionId_Retribucion",
                table: "SolicitudesRetribucion",
                column: "RetribucionId_Retribucion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CentrosDeSalud");

            migrationBuilder.DropTable(
                name: "Costo");

            migrationBuilder.DropTable(
                name: "Encuesta");

            migrationBuilder.DropTable(
                name: "EstudiantePlanillas");

            migrationBuilder.DropTable(
                name: "Historial_Actividad");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Presupuestos");

            migrationBuilder.DropTable(
                name: "Provision");

            migrationBuilder.DropTable(
                name: "SolicitudesRetribucion");

            migrationBuilder.DropTable(
                name: "Estudiantes");

            migrationBuilder.DropTable(
                name: "Planillas");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Retribuciones");

            migrationBuilder.DropTable(
                name: "Devengados");

            migrationBuilder.DropTable(
                name: "Facturacion");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Carreras");

            migrationBuilder.DropTable(
                name: "Convenios");

            migrationBuilder.DropTable(
                name: "IndicadorEcono");

            migrationBuilder.DropTable(
                name: "ObsDatas");

            migrationBuilder.DropTable(
                name: "InstitucionesSalud");

            migrationBuilder.DropTable(
                name: "SerieDatas");
        }
    }
}

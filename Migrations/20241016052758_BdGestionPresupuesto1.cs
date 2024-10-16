using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Gestion_Del_Presupuesto.Migrations
{
    /// <inheritdoc />
    public partial class BdGestionPresupuesto1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campo_Clinicos",
                columns: table => new
                {
                    Id_Campo_Clinico = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Tipo = table.Column<string>(type: "text", nullable: false),
                    Sede = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campo_Clinicos", x => x.Id_Campo_Clinico);
                });

            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    Id_Estudiante = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Carrera = table.Column<string>(type: "text", nullable: false),
                    Id_Convenio = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.Id_Estudiante);
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
                    Institucion = table.Column<string>(type: "text", nullable: false),
                    TiempoPractica = table.Column<string>(type: "text", nullable: false),
                    NumeroTiempo = table.Column<int>(type: "integer", nullable: false),
                    NumeroAlumnos = table.Column<int>(type: "integer", nullable: false),
                    ValorUF = table.Column<decimal>(type: "numeric", nullable: false),
                    Subtotal = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturacion", x => x.Id_Facturacion);
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
                    FormasRetribucionSeleccionadas = table.Column<List<string>>(type: "text[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presupuestos", x => x.Id_PresupuestoXCentroCosto);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Id_Rol = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Permisos = table.Column<string>(type: "text", nullable: false),
                    Id_Usuario = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id_Rol);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id_Usuario = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Contraseña = table.Column<string>(type: "text", nullable: false),
                    Rol = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id_Usuario);
                });

            migrationBuilder.CreateTable(
                name: "Campo_ClinicoEstudiante",
                columns: table => new
                {
                    Campo_ClinicosId_Campo_Clinico = table.Column<int>(type: "integer", nullable: false),
                    EstudiantesId_Estudiante = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campo_ClinicoEstudiante", x => new { x.Campo_ClinicosId_Campo_Clinico, x.EstudiantesId_Estudiante });
                    table.ForeignKey(
                        name: "FK_Campo_ClinicoEstudiante_Campo_Clinicos_Campo_ClinicosId_Cam~",
                        column: x => x.Campo_ClinicosId_Campo_Clinico,
                        principalTable: "Campo_Clinicos",
                        principalColumn: "Id_Campo_Clinico",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Campo_ClinicoEstudiante_Estudiantes_EstudiantesId_Estudiante",
                        column: x => x.EstudiantesId_Estudiante,
                        principalTable: "Estudiantes",
                        principalColumn: "Id_Estudiante",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Planillas",
                columns: table => new
                {
                    Id_Planillas = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre_Planilla = table.Column<string>(type: "text", nullable: false),
                    Rut = table.Column<int>(type: "integer", nullable: false),
                    Fecha_Inicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Fecha_Termino = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Institución = table.Column<string>(type: "text", nullable: false),
                    CuantasSemanas = table.Column<double>(type: "double precision", nullable: false),
                    ValorUfContrato = table.Column<int>(type: "integer", nullable: false),
                    TotalCosto = table.Column<int>(type: "integer", nullable: false),
                    Id_Estudiante = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planillas", x => x.Id_Planillas);
                    table.ForeignKey(
                        name: "FK_Planillas_Estudiantes_Id_Estudiante",
                        column: x => x.Id_Estudiante,
                        principalTable: "Estudiantes",
                        principalColumn: "Id_Estudiante",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Convenios",
                columns: table => new
                {
                    Id_Convenio = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ContratosInstituciones = table.Column<string>(type: "text", nullable: false),
                    Categoria = table.Column<string>(type: "text", nullable: false),
                    NumeroEstudiantes = table.Column<int>(type: "integer", nullable: true),
                    PagoUsoCC = table.Column<decimal>(type: "numeric", nullable: true),
                    PagoUsoCCSelected = table.Column<bool>(type: "boolean", nullable: false),
                    PagoApoyoDocencia = table.Column<decimal>(type: "numeric", nullable: true),
                    PagoApoyoDocenciaSelected = table.Column<bool>(type: "boolean", nullable: false),
                    PagoRRHH = table.Column<decimal>(type: "numeric", nullable: true),
                    PagoRRHHSelected = table.Column<bool>(type: "boolean", nullable: false),
                    Capacitacion = table.Column<decimal>(type: "numeric", nullable: true),
                    CapacitacionSelected = table.Column<bool>(type: "boolean", nullable: false),
                    ObrasMenores = table.Column<decimal>(type: "numeric", nullable: true),
                    ObrasMenoresSelected = table.Column<bool>(type: "boolean", nullable: false),
                    ObrasMayores = table.Column<decimal>(type: "numeric", nullable: true),
                    ObrasMayoresSelected = table.Column<bool>(type: "boolean", nullable: false),
                    OtrosGastosRetribucion = table.Column<decimal>(type: "numeric", nullable: true),
                    OtrosGastosRetribucionSelected = table.Column<bool>(type: "boolean", nullable: false),
                    TotalGastoEstimado = table.Column<decimal>(type: "numeric", nullable: true),
                    DeudaAnteriores = table.Column<decimal>(type: "numeric", nullable: true),
                    Deuda2024 = table.Column<decimal>(type: "numeric", nullable: true),
                    TotalDeuda = table.Column<decimal>(type: "numeric", nullable: true),
                    FacturadoAnteriores = table.Column<decimal>(type: "numeric", nullable: true),
                    Facturado2024 = table.Column<decimal>(type: "numeric", nullable: true),
                    Facturado2025 = table.Column<decimal>(type: "numeric", nullable: true),
                    TotalFacturado = table.Column<decimal>(type: "numeric", nullable: true),
                    SaldoEstimadoPagar = table.Column<decimal>(type: "numeric", nullable: true),
                    Estado = table.Column<string>(type: "text", nullable: false),
                    Campo_ClinicoId_Campo_Clinico = table.Column<int>(type: "integer", nullable: true),
                    EstudianteId_Estudiante = table.Column<int>(type: "integer", nullable: true),
                    Institucion_SaludId_Institucion_Salud = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Convenios", x => x.Id_Convenio);
                    table.ForeignKey(
                        name: "FK_Convenios_Campo_Clinicos_Campo_ClinicoId_Campo_Clinico",
                        column: x => x.Campo_ClinicoId_Campo_Clinico,
                        principalTable: "Campo_Clinicos",
                        principalColumn: "Id_Campo_Clinico");
                    table.ForeignKey(
                        name: "FK_Convenios_Estudiantes_EstudianteId_Estudiante",
                        column: x => x.EstudianteId_Estudiante,
                        principalTable: "Estudiantes",
                        principalColumn: "Id_Estudiante");
                    table.ForeignKey(
                        name: "FK_Convenios_InstitucionesSalud_Institucion_SaludId_Institucio~",
                        column: x => x.Institucion_SaludId_Institucion_Salud,
                        principalTable: "InstitucionesSalud",
                        principalColumn: "Id_Institucion_Salud");
                });

            migrationBuilder.CreateTable(
                name: "Historial_Actividad",
                columns: table => new
                {
                    Id_Historial_Actividad = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Accion = table.Column<string>(type: "text", nullable: false),
                    Id_Usuario = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historial_Actividad", x => x.Id_Historial_Actividad);
                    table.ForeignKey(
                        name: "FK_Historial_Actividad_Usuario_Id_Usuario",
                        column: x => x.Id_Usuario,
                        principalTable: "Usuario",
                        principalColumn: "Id_Usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EstudiantePlanillasModel",
                columns: table => new
                {
                    EstudiantesId_Estudiante = table.Column<int>(type: "integer", nullable: false),
                    PlanillasId_Planillas = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstudiantePlanillasModel", x => new { x.EstudiantesId_Estudiante, x.PlanillasId_Planillas });
                    table.ForeignKey(
                        name: "FK_EstudiantePlanillasModel_Estudiantes_EstudiantesId_Estudian~",
                        column: x => x.EstudiantesId_Estudiante,
                        principalTable: "Estudiantes",
                        principalColumn: "Id_Estudiante",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstudiantePlanillasModel_Planillas_PlanillasId_Planillas",
                        column: x => x.PlanillasId_Planillas,
                        principalTable: "Planillas",
                        principalColumn: "Id_Planillas",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConveniosModelPlanillasModel",
                columns: table => new
                {
                    ConveniosId_Convenio = table.Column<int>(type: "integer", nullable: false),
                    PlanillasId_Planillas = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConveniosModelPlanillasModel", x => new { x.ConveniosId_Convenio, x.PlanillasId_Planillas });
                    table.ForeignKey(
                        name: "FK_ConveniosModelPlanillasModel_Convenios_ConveniosId_Convenio",
                        column: x => x.ConveniosId_Convenio,
                        principalTable: "Convenios",
                        principalColumn: "Id_Convenio",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConveniosModelPlanillasModel_Planillas_PlanillasId_Planillas",
                        column: x => x.PlanillasId_Planillas,
                        principalTable: "Planillas",
                        principalColumn: "Id_Planillas",
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
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    GastoComprometido = table.Column<decimal>(type: "numeric", nullable: false),
                    PagosRealizados = table.Column<decimal>(type: "numeric", nullable: false),
                    SaldoPendiente = table.Column<decimal>(type: "numeric", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    ConvenioId = table.Column<int>(type: "integer", nullable: false),
                    DevengadoId_Devengado = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devengados", x => x.Id_Devengado);
                    table.ForeignKey(
                        name: "FK_Devengados_Convenios_ConvenioId",
                        column: x => x.ConvenioId,
                        principalTable: "Convenios",
                        principalColumn: "Id_Convenio",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Devengados_Devengados_DevengadoId_Devengado",
                        column: x => x.DevengadoId_Devengado,
                        principalTable: "Devengados",
                        principalColumn: "Id_Devengado");
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
                    ConvenioId_Convenio = table.Column<int>(type: "integer", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "Retribuciones",
                columns: table => new
                {
                    Id_Retribucion = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Tipo = table.Column<string>(type: "text", nullable: false),
                    Valor = table.Column<float>(type: "real", nullable: false),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    Id_Convenio = table.Column<int>(type: "integer", nullable: false),
                    Id_Solicitud_Retribucion = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Retribuciones", x => x.Id_Retribucion);
                    table.ForeignKey(
                        name: "FK_Retribuciones_Convenios_Id_Convenio",
                        column: x => x.Id_Convenio,
                        principalTable: "Convenios",
                        principalColumn: "Id_Convenio",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Retribuciones_SolicitudesRetribucion_Id_Solicitud_Retribuci~",
                        column: x => x.Id_Solicitud_Retribucion,
                        principalTable: "SolicitudesRetribucion",
                        principalColumn: "Id_Solicitud_Retribucion",
                        onDelete: ReferentialAction.Cascade);
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
                    RetribucionId_Retribucion = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.Id_Pago);
                    table.ForeignKey(
                        name: "FK_Pagos_Retribuciones_Id_Convenio",
                        column: x => x.Id_Convenio,
                        principalTable: "Retribuciones",
                        principalColumn: "Id_Retribucion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pagos_Retribuciones_RetribucionId_Retribucion",
                        column: x => x.RetribucionId_Retribucion,
                        principalTable: "Retribuciones",
                        principalColumn: "Id_Retribucion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Campo_ClinicoEstudiante_EstudiantesId_Estudiante",
                table: "Campo_ClinicoEstudiante",
                column: "EstudiantesId_Estudiante");

            migrationBuilder.CreateIndex(
                name: "IX_Convenios_Campo_ClinicoId_Campo_Clinico",
                table: "Convenios",
                column: "Campo_ClinicoId_Campo_Clinico");

            migrationBuilder.CreateIndex(
                name: "IX_Convenios_EstudianteId_Estudiante",
                table: "Convenios",
                column: "EstudianteId_Estudiante");

            migrationBuilder.CreateIndex(
                name: "IX_Convenios_Institucion_SaludId_Institucion_Salud",
                table: "Convenios",
                column: "Institucion_SaludId_Institucion_Salud");

            migrationBuilder.CreateIndex(
                name: "IX_ConveniosModelPlanillasModel_PlanillasId_Planillas",
                table: "ConveniosModelPlanillasModel",
                column: "PlanillasId_Planillas");

            migrationBuilder.CreateIndex(
                name: "IX_Costo_Id_Convenio",
                table: "Costo",
                column: "Id_Convenio");

            migrationBuilder.CreateIndex(
                name: "IX_Devengados_ConvenioId",
                table: "Devengados",
                column: "ConvenioId");

            migrationBuilder.CreateIndex(
                name: "IX_Devengados_DevengadoId_Devengado",
                table: "Devengados",
                column: "DevengadoId_Devengado");

            migrationBuilder.CreateIndex(
                name: "IX_EstudiantePlanillasModel_PlanillasId_Planillas",
                table: "EstudiantePlanillasModel",
                column: "PlanillasId_Planillas");

            migrationBuilder.CreateIndex(
                name: "IX_Historial_Actividad_Id_Usuario",
                table: "Historial_Actividad",
                column: "Id_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_Id_Convenio",
                table: "Pagos",
                column: "Id_Convenio");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_RetribucionId_Retribucion",
                table: "Pagos",
                column: "RetribucionId_Retribucion");

            migrationBuilder.CreateIndex(
                name: "IX_Planillas_Id_Estudiante",
                table: "Planillas",
                column: "Id_Estudiante",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Retribuciones_Id_Convenio",
                table: "Retribuciones",
                column: "Id_Convenio");

            migrationBuilder.CreateIndex(
                name: "IX_Retribuciones_Id_Solicitud_Retribucion",
                table: "Retribuciones",
                column: "Id_Solicitud_Retribucion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudesRetribucion_ConvenioId_Convenio",
                table: "SolicitudesRetribucion",
                column: "ConvenioId_Convenio");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Campo_ClinicoEstudiante");

            migrationBuilder.DropTable(
                name: "ConveniosModelPlanillasModel");

            migrationBuilder.DropTable(
                name: "Costo");

            migrationBuilder.DropTable(
                name: "Devengados");

            migrationBuilder.DropTable(
                name: "EstudiantePlanillasModel");

            migrationBuilder.DropTable(
                name: "Facturacion");

            migrationBuilder.DropTable(
                name: "Historial_Actividad");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Presupuestos");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "Planillas");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Retribuciones");

            migrationBuilder.DropTable(
                name: "SolicitudesRetribucion");

            migrationBuilder.DropTable(
                name: "Convenios");

            migrationBuilder.DropTable(
                name: "Campo_Clinicos");

            migrationBuilder.DropTable(
                name: "Estudiantes");

            migrationBuilder.DropTable(
                name: "InstitucionesSalud");
        }
    }
}

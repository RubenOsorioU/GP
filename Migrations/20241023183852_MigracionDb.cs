using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Gestion_Del_Presupuesto.Migrations
{
    /// <inheritdoc />
    public partial class MigracionDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Convenios_Campo_Clinicos_Campo_ClinicoId_Campo_Clinico",
                table: "Convenios");

            migrationBuilder.DropForeignKey(
                name: "FK_Pagos_Retribuciones_Id_Convenio",
                table: "Pagos");

            migrationBuilder.DropForeignKey(
                name: "FK_Retribuciones_Convenios_Id_Convenio",
                table: "Retribuciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Retribuciones_SolicitudesRetribucion_Id_Solicitud_Retribuci~",
                table: "Retribuciones");

            migrationBuilder.DropTable(
                name: "Campo_ClinicoEstudiante");

            migrationBuilder.DropTable(
                name: "ConveniosModelPlanillasModel");

            migrationBuilder.DropTable(
                name: "UFViewModel");

            migrationBuilder.DropTable(
                name: "Campo_Clinicos");

            migrationBuilder.DropTable(
                name: "UF2023");

            migrationBuilder.DropTable(
                name: "UF2024");

            migrationBuilder.DropIndex(
                name: "IX_Retribuciones_Id_Convenio",
                table: "Retribuciones");

            migrationBuilder.DropIndex(
                name: "IX_Retribuciones_Id_Solicitud_Retribucion",
                table: "Retribuciones");

            migrationBuilder.DropIndex(
                name: "IX_Pagos_Id_Convenio",
                table: "Pagos");

            migrationBuilder.DropIndex(
                name: "IX_Convenios_Campo_ClinicoId_Campo_Clinico",
                table: "Convenios");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Retribuciones");

            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "Retribuciones");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Retribuciones");

            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Retribuciones");

            migrationBuilder.DropColumn(
                name: "Campo_ClinicoId_Campo_Clinico",
                table: "Convenios");

            migrationBuilder.DropColumn(
                name: "Capacitacion",
                table: "Convenios");

            migrationBuilder.DropColumn(
                name: "CapacitacionSelected",
                table: "Convenios");

            migrationBuilder.DropColumn(
                name: "Deuda2024",
                table: "Convenios");

            migrationBuilder.DropColumn(
                name: "DeudaAnteriores",
                table: "Convenios");

            migrationBuilder.DropColumn(
                name: "Facturado2024",
                table: "Convenios");

            migrationBuilder.DropColumn(
                name: "Facturado2025",
                table: "Convenios");

            migrationBuilder.DropColumn(
                name: "FacturadoAnteriores",
                table: "Convenios");

            migrationBuilder.DropColumn(
                name: "NumeroEstudiantes",
                table: "Convenios");

            migrationBuilder.DropColumn(
                name: "ObrasMayores",
                table: "Convenios");

            migrationBuilder.DropColumn(
                name: "ObrasMayoresSelected",
                table: "Convenios");

            migrationBuilder.DropColumn(
                name: "ObrasMenores",
                table: "Convenios");

            migrationBuilder.DropColumn(
                name: "ObrasMenoresSelected",
                table: "Convenios");

            migrationBuilder.DropColumn(
                name: "OtrosGastosRetribucion",
                table: "Convenios");

            migrationBuilder.DropColumn(
                name: "OtrosGastosRetribucionSelected",
                table: "Convenios");

            migrationBuilder.DropColumn(
                name: "PagoApoyoDocencia",
                table: "Convenios");

            migrationBuilder.DropColumn(
                name: "PagoApoyoDocenciaSelected",
                table: "Convenios");

            migrationBuilder.DropColumn(
                name: "PagoRRHH",
                table: "Convenios");

            migrationBuilder.DropColumn(
                name: "PagoRRHHSelected",
                table: "Convenios");

            migrationBuilder.DropColumn(
                name: "PagoUsoCC",
                table: "Convenios");

            migrationBuilder.DropColumn(
                name: "PagoUsoCCSelected",
                table: "Convenios");

            migrationBuilder.DropColumn(
                name: "SaldoEstimadoPagar",
                table: "Convenios");

            migrationBuilder.DropColumn(
                name: "TotalDeuda",
                table: "Convenios");

            migrationBuilder.DropColumn(
                name: "TotalFacturado",
                table: "Convenios");

            migrationBuilder.DropColumn(
                name: "TotalGastoEstimado",
                table: "Convenios");

            migrationBuilder.RenameColumn(
                name: "Id_Solicitud_Retribucion",
                table: "Retribuciones",
                newName: "ConveniosId_Convenio");

            migrationBuilder.RenameColumn(
                name: "Id_Convenio",
                table: "Retribuciones",
                newName: "ConvenioId");

            migrationBuilder.RenameColumn(
                name: "Estado",
                table: "Convenios",
                newName: "Tipo");

            migrationBuilder.RenameColumn(
                name: "ContratosInstituciones",
                table: "Convenios",
                newName: "Sede");

            migrationBuilder.RenameColumn(
                name: "Categoria",
                table: "Convenios",
                newName: "Nombre");

            migrationBuilder.AddColumn<int>(
                name: "RetribucionId_Retribucion",
                table: "SolicitudesRetribucion",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Monto",
                table: "Retribuciones",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ConvenioId_Retribucion",
                table: "Pagos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ContactoPrincipal",
                table: "Convenios",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Convenios",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Duracion",
                table: "Convenios",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaInicio",
                table: "Convenios",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "CentroSaludModel",
                columns: table => new
                {
                    Id_CentroSalud = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Direccion = table.Column<string>(type: "text", nullable: false),
                    Contacto = table.Column<string>(type: "text", nullable: false),
                    ConvenioId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentroSaludModel", x => x.Id_CentroSalud);
                    table.ForeignKey(
                        name: "FK_CentroSaludModel_Convenios_ConvenioId",
                        column: x => x.ConvenioId,
                        principalTable: "Convenios",
                        principalColumn: "Id_Convenio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudesRetribucion_RetribucionId_Retribucion",
                table: "SolicitudesRetribucion",
                column: "RetribucionId_Retribucion");

            migrationBuilder.CreateIndex(
                name: "IX_Retribuciones_ConveniosId_Convenio",
                table: "Retribuciones",
                column: "ConveniosId_Convenio");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_ConvenioId_Retribucion",
                table: "Pagos",
                column: "ConvenioId_Retribucion");

            migrationBuilder.CreateIndex(
                name: "IX_CentroSaludModel_ConvenioId",
                table: "CentroSaludModel",
                column: "ConvenioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pagos_Retribuciones_ConvenioId_Retribucion",
                table: "Pagos",
                column: "ConvenioId_Retribucion",
                principalTable: "Retribuciones",
                principalColumn: "Id_Retribucion",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Retribuciones_Convenios_ConveniosId_Convenio",
                table: "Retribuciones",
                column: "ConveniosId_Convenio",
                principalTable: "Convenios",
                principalColumn: "Id_Convenio",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitudesRetribucion_Retribuciones_RetribucionId_Retribuc~",
                table: "SolicitudesRetribucion",
                column: "RetribucionId_Retribucion",
                principalTable: "Retribuciones",
                principalColumn: "Id_Retribucion",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pagos_Retribuciones_ConvenioId_Retribucion",
                table: "Pagos");

            migrationBuilder.DropForeignKey(
                name: "FK_Retribuciones_Convenios_ConveniosId_Convenio",
                table: "Retribuciones");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitudesRetribucion_Retribuciones_RetribucionId_Retribuc~",
                table: "SolicitudesRetribucion");

            migrationBuilder.DropTable(
                name: "CentroSaludModel");

            migrationBuilder.DropIndex(
                name: "IX_SolicitudesRetribucion_RetribucionId_Retribucion",
                table: "SolicitudesRetribucion");

            migrationBuilder.DropIndex(
                name: "IX_Retribuciones_ConveniosId_Convenio",
                table: "Retribuciones");

            migrationBuilder.DropIndex(
                name: "IX_Pagos_ConvenioId_Retribucion",
                table: "Pagos");

            migrationBuilder.DropColumn(
                name: "RetribucionId_Retribucion",
                table: "SolicitudesRetribucion");

            migrationBuilder.DropColumn(
                name: "Monto",
                table: "Retribuciones");

            migrationBuilder.DropColumn(
                name: "ConvenioId_Retribucion",
                table: "Pagos");

            migrationBuilder.DropColumn(
                name: "ContactoPrincipal",
                table: "Convenios");

            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Convenios");

            migrationBuilder.DropColumn(
                name: "Duracion",
                table: "Convenios");

            migrationBuilder.DropColumn(
                name: "FechaInicio",
                table: "Convenios");

            migrationBuilder.RenameColumn(
                name: "ConveniosId_Convenio",
                table: "Retribuciones",
                newName: "Id_Solicitud_Retribucion");

            migrationBuilder.RenameColumn(
                name: "ConvenioId",
                table: "Retribuciones",
                newName: "Id_Convenio");

            migrationBuilder.RenameColumn(
                name: "Tipo",
                table: "Convenios",
                newName: "Estado");

            migrationBuilder.RenameColumn(
                name: "Sede",
                table: "Convenios",
                newName: "ContratosInstituciones");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Convenios",
                newName: "Categoria");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Retribuciones",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "Retribuciones",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Retribuciones",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "Valor",
                table: "Retribuciones",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "Campo_ClinicoId_Campo_Clinico",
                table: "Convenios",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Capacitacion",
                table: "Convenios",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CapacitacionSelected",
                table: "Convenios",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Deuda2024",
                table: "Convenios",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DeudaAnteriores",
                table: "Convenios",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Facturado2024",
                table: "Convenios",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Facturado2025",
                table: "Convenios",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FacturadoAnteriores",
                table: "Convenios",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumeroEstudiantes",
                table: "Convenios",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ObrasMayores",
                table: "Convenios",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ObrasMayoresSelected",
                table: "Convenios",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "ObrasMenores",
                table: "Convenios",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ObrasMenoresSelected",
                table: "Convenios",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "OtrosGastosRetribucion",
                table: "Convenios",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "OtrosGastosRetribucionSelected",
                table: "Convenios",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "PagoApoyoDocencia",
                table: "Convenios",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PagoApoyoDocenciaSelected",
                table: "Convenios",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "PagoRRHH",
                table: "Convenios",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PagoRRHHSelected",
                table: "Convenios",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "PagoUsoCC",
                table: "Convenios",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PagoUsoCCSelected",
                table: "Convenios",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "SaldoEstimadoPagar",
                table: "Convenios",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalDeuda",
                table: "Convenios",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalFacturado",
                table: "Convenios",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalGastoEstimado",
                table: "Convenios",
                type: "numeric",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Campo_Clinicos",
                columns: table => new
                {
                    Id_Campo_Clinico = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Sede = table.Column<string>(type: "text", nullable: false),
                    Tipo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campo_Clinicos", x => x.Id_Campo_Clinico);
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
                name: "UF2023",
                columns: table => new
                {
                    Id_UF_2023 = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Abr = table.Column<decimal>(type: "numeric", nullable: false),
                    Ago = table.Column<decimal>(type: "numeric", nullable: false),
                    Dia = table.Column<int>(type: "integer", nullable: false),
                    Dic = table.Column<decimal>(type: "numeric", nullable: false),
                    Ene = table.Column<decimal>(type: "numeric", nullable: false),
                    Feb = table.Column<decimal>(type: "numeric", nullable: false),
                    Jul = table.Column<decimal>(type: "numeric", nullable: false),
                    Jun = table.Column<decimal>(type: "numeric", nullable: false),
                    Mar = table.Column<decimal>(type: "numeric", nullable: false),
                    May = table.Column<decimal>(type: "numeric", nullable: false),
                    Nov = table.Column<decimal>(type: "numeric", nullable: false),
                    Oct = table.Column<decimal>(type: "numeric", nullable: false),
                    Sep = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UF2023", x => x.Id_UF_2023);
                });

            migrationBuilder.CreateTable(
                name: "UF2024",
                columns: table => new
                {
                    Id_UF_2024 = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Abr = table.Column<decimal>(type: "numeric", nullable: false),
                    Ago = table.Column<decimal>(type: "numeric", nullable: false),
                    Dia = table.Column<int>(type: "integer", nullable: false),
                    Dic = table.Column<decimal>(type: "numeric", nullable: false),
                    Ene = table.Column<decimal>(type: "numeric", nullable: false),
                    Feb = table.Column<decimal>(type: "numeric", nullable: false),
                    Jul = table.Column<decimal>(type: "numeric", nullable: false),
                    Jun = table.Column<decimal>(type: "numeric", nullable: false),
                    Mar = table.Column<decimal>(type: "numeric", nullable: false),
                    May = table.Column<decimal>(type: "numeric", nullable: false),
                    Nov = table.Column<decimal>(type: "numeric", nullable: false),
                    Oct = table.Column<decimal>(type: "numeric", nullable: false),
                    Sep = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UF2024", x => x.Id_UF_2024);
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
                name: "UFViewModel",
                columns: table => new
                {
                    Id_ConbinedUF = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UF2023Id_UF_2023 = table.Column<int>(type: "integer", nullable: false),
                    UF2024Id_UF_2024 = table.Column<int>(type: "integer", nullable: false),
                    SelectedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UFViewModel", x => x.Id_ConbinedUF);
                    table.ForeignKey(
                        name: "FK_UFViewModel_UF2023_UF2023Id_UF_2023",
                        column: x => x.UF2023Id_UF_2023,
                        principalTable: "UF2023",
                        principalColumn: "Id_UF_2023",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UFViewModel_UF2024_UF2024Id_UF_2024",
                        column: x => x.UF2024Id_UF_2024,
                        principalTable: "UF2024",
                        principalColumn: "Id_UF_2024",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_Pagos_Id_Convenio",
                table: "Pagos",
                column: "Id_Convenio");

            migrationBuilder.CreateIndex(
                name: "IX_Convenios_Campo_ClinicoId_Campo_Clinico",
                table: "Convenios",
                column: "Campo_ClinicoId_Campo_Clinico");

            migrationBuilder.CreateIndex(
                name: "IX_Campo_ClinicoEstudiante_EstudiantesId_Estudiante",
                table: "Campo_ClinicoEstudiante",
                column: "EstudiantesId_Estudiante");

            migrationBuilder.CreateIndex(
                name: "IX_ConveniosModelPlanillasModel_PlanillasId_Planillas",
                table: "ConveniosModelPlanillasModel",
                column: "PlanillasId_Planillas");

            migrationBuilder.CreateIndex(
                name: "IX_UFViewModel_UF2023Id_UF_2023",
                table: "UFViewModel",
                column: "UF2023Id_UF_2023");

            migrationBuilder.CreateIndex(
                name: "IX_UFViewModel_UF2024Id_UF_2024",
                table: "UFViewModel",
                column: "UF2024Id_UF_2024");

            migrationBuilder.AddForeignKey(
                name: "FK_Convenios_Campo_Clinicos_Campo_ClinicoId_Campo_Clinico",
                table: "Convenios",
                column: "Campo_ClinicoId_Campo_Clinico",
                principalTable: "Campo_Clinicos",
                principalColumn: "Id_Campo_Clinico");

            migrationBuilder.AddForeignKey(
                name: "FK_Pagos_Retribuciones_Id_Convenio",
                table: "Pagos",
                column: "Id_Convenio",
                principalTable: "Retribuciones",
                principalColumn: "Id_Retribucion",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Retribuciones_Convenios_Id_Convenio",
                table: "Retribuciones",
                column: "Id_Convenio",
                principalTable: "Convenios",
                principalColumn: "Id_Convenio",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Retribuciones_SolicitudesRetribucion_Id_Solicitud_Retribuci~",
                table: "Retribuciones",
                column: "Id_Solicitud_Retribucion",
                principalTable: "SolicitudesRetribucion",
                principalColumn: "Id_Solicitud_Retribucion",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

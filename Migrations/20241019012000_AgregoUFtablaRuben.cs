using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Gestion_Del_Presupuesto.Migrations
{
    /// <inheritdoc />
    public partial class AgregoUFtablaRuben : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UFViewModel",
                columns: table => new
                {
                    Id_UF = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SelectedYear = table.Column<int>(type: "integer", nullable: false),
                    SelectedMonth = table.Column<string>(type: "text", nullable: false),
                    SelectedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UFValueForDate = table.Column<decimal>(type: "numeric", nullable: false),
                    MontoUF = table.Column<decimal>(type: "numeric", nullable: false),
                    Resultado = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UFViewModel", x => x.Id_UF);
                });

            migrationBuilder.CreateTable(
                name: "UFData",
                columns: table => new
                {
                    Id_UFData = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UFValue = table.Column<decimal>(type: "numeric", nullable: false),
                    UFViewModelId_UF = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UFData", x => x.Id_UFData);
                    table.ForeignKey(
                        name: "FK_UFData_UFViewModel_UFViewModelId_UF",
                        column: x => x.UFViewModelId_UF,
                        principalTable: "UFViewModel",
                        principalColumn: "Id_UF");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UFData_UFViewModelId_UF",
                table: "UFData",
                column: "UFViewModelId_UF");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UFData");

            migrationBuilder.DropTable(
                name: "UFViewModel");
        }
    }
}

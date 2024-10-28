using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestion_Del_Presupuesto.Migrations
{
    /// <inheritdoc />
    public partial class ArregloatributoConvenio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FechaInicio",
                table: "Convenios",
                newName: "Fecha_Inicio");

            migrationBuilder.RenameColumn(
                name: "Duracion",
                table: "Convenios",
                newName: "Duracion_meses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Fecha_Inicio",
                table: "Convenios",
                newName: "FechaInicio");

            migrationBuilder.RenameColumn(
                name: "Duracion_meses",
                table: "Convenios",
                newName: "Duracion");
        }
    }
}

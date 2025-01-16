using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestion_Del_Presupuesto.Migrations
{
    /// <inheritdoc />
    public partial class UsName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NombreUsuario",
                table: "Historial_Actividad",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NombreUsuario",
                table: "Historial_Actividad");
        }
    }
}

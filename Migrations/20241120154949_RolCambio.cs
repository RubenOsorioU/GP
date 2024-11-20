using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestion_Del_Presupuesto.Migrations
{
    /// <inheritdoc />
    public partial class RolCambio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Roles",
                newName: "NombreRol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NombreRol",
                table: "Roles",
                newName: "Nombre");
        }
    }
}

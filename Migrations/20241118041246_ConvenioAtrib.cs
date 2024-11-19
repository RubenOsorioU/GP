using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestion_Del_Presupuesto.Migrations
{
    /// <inheritdoc />
    public partial class ConvenioAtrib : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RolesId_Rol",
                table: "Historial_Actividad",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Adendumn",
                table: "Convenios",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Historial_Actividad_RolesId_Rol",
                table: "Historial_Actividad",
                column: "RolesId_Rol");

            migrationBuilder.AddForeignKey(
                name: "FK_Historial_Actividad_Roles_RolesId_Rol",
                table: "Historial_Actividad",
                column: "RolesId_Rol",
                principalTable: "Roles",
                principalColumn: "Id_Rol",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Historial_Actividad_Roles_RolesId_Rol",
                table: "Historial_Actividad");

            migrationBuilder.DropIndex(
                name: "IX_Historial_Actividad_RolesId_Rol",
                table: "Historial_Actividad");

            migrationBuilder.DropColumn(
                name: "RolesId_Rol",
                table: "Historial_Actividad");

            migrationBuilder.DropColumn(
                name: "Adendumn",
                table: "Convenios");
        }
    }
}

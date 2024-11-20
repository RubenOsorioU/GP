using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestion_Del_Presupuesto.Migrations
{
    /// <inheritdoc />
    public partial class RolCambio2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Roles_RolId_Rol",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_RolId_Rol",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "RolId_Rol",
                table: "Usuarios");

            migrationBuilder.AlterColumn<string>(
                name: "NombreRol",
                table: "Roles",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Id_Rol",
                table: "Usuarios",
                column: "Id_Rol",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Roles_Id_Rol",
                table: "Usuarios",
                column: "Id_Rol",
                principalTable: "Roles",
                principalColumn: "Id_Rol",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Roles_Id_Rol",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_Id_Rol",
                table: "Usuarios");

            migrationBuilder.AddColumn<int>(
                name: "RolId_Rol",
                table: "Usuarios",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "NombreRol",
                table: "Roles",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RolId_Rol",
                table: "Usuarios",
                column: "RolId_Rol");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Roles_RolId_Rol",
                table: "Usuarios",
                column: "RolId_Rol",
                principalTable: "Roles",
                principalColumn: "Id_Rol",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

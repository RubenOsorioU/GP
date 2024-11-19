using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestion_Del_Presupuesto.Migrations
{
    /// <inheritdoc />
    public partial class UsuarioAtributos2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConveniosId_Convenio",
                table: "Usuarios",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Rut",
                table: "Usuarios",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "Usuarios",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_ConveniosId_Convenio",
                table: "Usuarios",
                column: "ConveniosId_Convenio");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Convenios_ConveniosId_Convenio",
                table: "Usuarios",
                column: "ConveniosId_Convenio",
                principalTable: "Convenios",
                principalColumn: "Id_Convenio",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Convenios_ConveniosId_Convenio",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_ConveniosId_Convenio",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "ConveniosId_Convenio",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Rut",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Usuarios");
        }
    }
}

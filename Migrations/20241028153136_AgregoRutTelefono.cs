using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestion_Del_Presupuesto.Migrations
{
    /// <inheritdoc />
    public partial class AgregoRutTelefono : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "UFTotal",
                table: "Retribuciones",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Rut",
                table: "Convenios",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "Convenios",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UFTotal",
                table: "Retribuciones");

            migrationBuilder.DropColumn(
                name: "Rut",
                table: "Convenios");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Convenios");
        }
    }
}

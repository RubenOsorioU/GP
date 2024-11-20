using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Gestion_Del_Presupuesto.Migrations
{
    /// <inheritdoc />
    public partial class Addendum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Adendumn",
                table: "Convenios",
                newName: "Adendum");

            migrationBuilder.AddColumn<string>(
                name: "ConfirmarPassword",
                table: "Usuarios",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Correo",
                table: "Usuarios",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaAdendum",
                table: "Convenios",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ObservacionAdendum",
                table: "Convenios",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "Convenios",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Registro",
                columns: table => new
                {
                    Id_Registro = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id_Usuarios = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registro", x => x.Id_Registro);
                    table.ForeignKey(
                        name: "FK_Registro_Usuarios_Id_Usuarios",
                        column: x => x.Id_Usuarios,
                        principalTable: "Usuarios",
                        principalColumn: "Id_Usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Registro_Id_Usuarios",
                table: "Registro",
                column: "Id_Usuarios",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registro");

            migrationBuilder.DropColumn(
                name: "ConfirmarPassword",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Correo",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "FechaAdendum",
                table: "Convenios");

            migrationBuilder.DropColumn(
                name: "ObservacionAdendum",
                table: "Convenios");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Convenios");

            migrationBuilder.RenameColumn(
                name: "Adendum",
                table: "Convenios",
                newName: "Adendumn");
        }
    }
}

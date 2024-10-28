using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestion_Del_Presupuesto.Migrations
{
    /// <inheritdoc />
    public partial class AgregoActualizaciónPoraños : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duracion_meses",
                table: "Convenios");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha_Termino",
                table: "Convenios",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<bool>(
                name: "RenovacionAutomatica",
                table: "Convenios",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RenovacionAutomatica",
                table: "Convenios");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha_Termino",
                table: "Convenios",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Duracion_meses",
                table: "Convenios",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}

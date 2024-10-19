using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestion_Del_Presupuesto.Migrations
{
    /// <inheritdoc />
    public partial class AgregoTablas2024UFRuben : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Abr",
                table: "UFViewModel",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Ago",
                table: "UFViewModel",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Dia",
                table: "UFViewModel",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Dic",
                table: "UFViewModel",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Ene",
                table: "UFViewModel",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Feb",
                table: "UFViewModel",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Jul",
                table: "UFViewModel",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Jun",
                table: "UFViewModel",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Mar",
                table: "UFViewModel",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "May",
                table: "UFViewModel",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Nov",
                table: "UFViewModel",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Oct",
                table: "UFViewModel",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Sep",
                table: "UFViewModel",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Abr",
                table: "UFViewModel");

            migrationBuilder.DropColumn(
                name: "Ago",
                table: "UFViewModel");

            migrationBuilder.DropColumn(
                name: "Dia",
                table: "UFViewModel");

            migrationBuilder.DropColumn(
                name: "Dic",
                table: "UFViewModel");

            migrationBuilder.DropColumn(
                name: "Ene",
                table: "UFViewModel");

            migrationBuilder.DropColumn(
                name: "Feb",
                table: "UFViewModel");

            migrationBuilder.DropColumn(
                name: "Jul",
                table: "UFViewModel");

            migrationBuilder.DropColumn(
                name: "Jun",
                table: "UFViewModel");

            migrationBuilder.DropColumn(
                name: "Mar",
                table: "UFViewModel");

            migrationBuilder.DropColumn(
                name: "May",
                table: "UFViewModel");

            migrationBuilder.DropColumn(
                name: "Nov",
                table: "UFViewModel");

            migrationBuilder.DropColumn(
                name: "Oct",
                table: "UFViewModel");

            migrationBuilder.DropColumn(
                name: "Sep",
                table: "UFViewModel");
        }
    }
}

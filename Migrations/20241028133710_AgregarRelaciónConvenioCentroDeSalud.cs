using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestion_Del_Presupuesto.Migrations
{
    /// <inheritdoc />
    public partial class AgregarRelaciónConvenioCentroDeSalud : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Retribuciones_Convenios_ConveniosId_Convenio",
                table: "Retribuciones");

            migrationBuilder.DropIndex(
                name: "IX_Retribuciones_ConveniosId_Convenio",
                table: "Retribuciones");

            migrationBuilder.DropColumn(
                name: "ConveniosId_Convenio",
                table: "Retribuciones");

            migrationBuilder.CreateIndex(
                name: "IX_Retribuciones_ConvenioId",
                table: "Retribuciones",
                column: "ConvenioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Retribuciones_Convenios_ConvenioId",
                table: "Retribuciones",
                column: "ConvenioId",
                principalTable: "Convenios",
                principalColumn: "Id_Convenio",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Retribuciones_Convenios_ConvenioId",
                table: "Retribuciones");

            migrationBuilder.DropIndex(
                name: "IX_Retribuciones_ConvenioId",
                table: "Retribuciones");

            migrationBuilder.AddColumn<int>(
                name: "ConveniosId_Convenio",
                table: "Retribuciones",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Retribuciones_ConveniosId_Convenio",
                table: "Retribuciones",
                column: "ConveniosId_Convenio");

            migrationBuilder.AddForeignKey(
                name: "FK_Retribuciones_Convenios_ConveniosId_Convenio",
                table: "Retribuciones",
                column: "ConveniosId_Convenio",
                principalTable: "Convenios",
                principalColumn: "Id_Convenio",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

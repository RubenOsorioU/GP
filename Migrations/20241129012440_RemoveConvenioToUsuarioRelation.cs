using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestion_Del_Presupuesto.Migrations
{
    /// <inheritdoc />
    public partial class RemoveConvenioToUsuarioRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Convenios_ConveniosId_Convenio",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ConveniosId_Convenio",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ConveniosId_Convenio",
                table: "AspNetUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConveniosId_Convenio",
                table: "AspNetUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ConveniosId_Convenio",
                table: "AspNetUsers",
                column: "ConveniosId_Convenio");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Convenios_ConveniosId_Convenio",
                table: "AspNetUsers",
                column: "ConveniosId_Convenio",
                principalTable: "Convenios",
                principalColumn: "Id_Convenio",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

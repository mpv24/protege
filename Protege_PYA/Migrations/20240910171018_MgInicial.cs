using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Protege_PYA.Migrations
{
    /// <inheritdoc />
    public partial class MgInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Profesionales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Profesionales_UsuarioId",
                table: "Profesionales",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profesionales_Usuario_UsuarioId",
                table: "Profesionales",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profesionales_Usuario_UsuarioId",
                table: "Profesionales");

            migrationBuilder.DropIndex(
                name: "IX_Profesionales_UsuarioId",
                table: "Profesionales");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Profesionales");
        }
    }
}

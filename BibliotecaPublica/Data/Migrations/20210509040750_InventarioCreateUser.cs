using Microsoft.EntityFrameworkCore.Migrations;

namespace BibliotecaPublica.Data.Migrations
{
    public partial class InventarioCreateUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "EstaDisponible",
                table: "Inventarios",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "Inventarios",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inventarios_UsuarioId",
                table: "Inventarios",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventarios_AspNetUsers_UsuarioId",
                table: "Inventarios",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventarios_AspNetUsers_UsuarioId",
                table: "Inventarios");

            migrationBuilder.DropIndex(
                name: "IX_Inventarios_UsuarioId",
                table: "Inventarios");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Inventarios");

            migrationBuilder.AlterColumn<bool>(
                name: "EstaDisponible",
                table: "Inventarios",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}

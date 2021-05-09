using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BibliotecaPublica.Data.Migrations
{
    public partial class CrearInventario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LibroId = table.Column<int>(type: "int", nullable: false),
                    Archivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstaDisponible = table.Column<bool>(type: "bit", nullable: true),
                    Creado = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventarios_Libros_LibroId",
                        column: x => x.LibroId,
                        principalTable: "Libros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventarios_LibroId",
                table: "Inventarios",
                column: "LibroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventarios");
        }
    }
}

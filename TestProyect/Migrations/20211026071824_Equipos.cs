using Microsoft.EntityFrameworkCore.Migrations;

namespace TestProyect.Migrations
{
    public partial class Equipos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipos",
                columns: table => new
                {
                    IdEquipo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEquipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntrenadorEquiId = table.Column<int>(type: "int", nullable: true),
                    CategoriaEquId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipos", x => x.IdEquipo);
                    table.ForeignKey(
                        name: "FK_Equipos_Categorias_CategoriaEquId",
                        column: x => x.CategoriaEquId,
                        principalTable: "Categorias",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Equipos_Entrenadores_EntrenadorEquiId",
                        column: x => x.EntrenadorEquiId,
                        principalTable: "Entrenadores",
                        principalColumn: "IdEntrenador",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_CategoriaEquId",
                table: "Equipos",
                column: "CategoriaEquId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_EntrenadorEquiId",
                table: "Equipos",
                column: "EntrenadorEquiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipos");
        }
    }
}

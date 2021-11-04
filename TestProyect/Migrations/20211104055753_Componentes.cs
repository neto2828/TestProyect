using Microsoft.EntityFrameworkCore.Migrations;

namespace TestProyect.Migrations
{
    public partial class Componentes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Componentes",
                columns: table => new
                {
                    IdComponente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreComponente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntrenadorCompId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Componentes", x => x.IdComponente);
                    table.ForeignKey(
                        name: "FK_Componentes_Entrenadores_EntrenadorCompId",
                        column: x => x.EntrenadorCompId,
                        principalTable: "Entrenadores",
                        principalColumn: "IdEntrenador",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subcomponentes",
                columns: table => new
                {
                    IdSubcomponente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreSubcomponente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComponenteSubId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subcomponentes", x => x.IdSubcomponente);
                    table.ForeignKey(
                        name: "FK_Subcomponentes_Componentes_ComponenteSubId",
                        column: x => x.ComponenteSubId,
                        principalTable: "Componentes",
                        principalColumn: "IdComponente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Componentes_EntrenadorCompId",
                table: "Componentes",
                column: "EntrenadorCompId");

            migrationBuilder.CreateIndex(
                name: "IX_Subcomponentes_ComponenteSubId",
                table: "Subcomponentes",
                column: "ComponenteSubId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subcomponentes");

            migrationBuilder.DropTable(
                name: "Componentes");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace TestProyect.Migrations
{
    public partial class Posiciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posiciones",
                columns: table => new
                {
                    IdPosicion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePosicion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UbicacionPosicion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstatusPosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posiciones", x => x.IdPosicion);
                    table.ForeignKey(
                        name: "FK_Posiciones_Estatus_EstatusPosId",
                        column: x => x.EstatusPosId,
                        principalTable: "Estatus",
                        principalColumn: "IdEstatus",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posiciones_EstatusPosId",
                table: "Posiciones",
                column: "EstatusPosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posiciones");
        }
    }
}

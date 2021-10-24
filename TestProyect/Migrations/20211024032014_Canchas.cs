using Microsoft.EntityFrameworkCore.Migrations;

namespace TestProyect.Migrations
{
    public partial class Canchas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Canchas",
                columns: table => new
                {
                    IdCancha = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCancha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LatitudCancha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LongitudCancha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PoligonoCancha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstatusCanchaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Canchas", x => x.IdCancha);
                    table.ForeignKey(
                        name: "FK_Canchas_Estatus_EstatusCanchaId",
                        column: x => x.EstatusCanchaId,
                        principalTable: "Estatus",
                        principalColumn: "IdEstatus",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Canchas_EstatusCanchaId",
                table: "Canchas",
                column: "EstatusCanchaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Canchas");
        }
    }
}

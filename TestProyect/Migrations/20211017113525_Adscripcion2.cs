using Microsoft.EntityFrameworkCore.Migrations;

namespace TestProyect.Migrations
{
    public partial class Adscripcion2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adscripcion",
                columns: table => new
                {
                    IdAdscripcion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreAdscripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adscripcion", x => x.IdAdscripcion);
                    table.ForeignKey(
                        name: "FK_Adscripcion_Estatus_EstatusId",
                        column: x => x.EstatusId,
                        principalTable: "Estatus",
                        principalColumn: "IdEstatus",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adscripcion_EstatusId",
                table: "Adscripcion",
                column: "EstatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adscripcion");
        }
    }
}

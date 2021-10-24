using Microsoft.EntityFrameworkCore.Migrations;

namespace TestProyect.Migrations
{
    public partial class Entrenadores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entrenadores",
                columns: table => new
                {
                    IdEntrenador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatriculaEntrenador = table.Column<int>(type: "int", nullable: false),
                    NombreEntrenador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaternoEntrenador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaternoEntrenador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CasaEntrenador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CelularEntrenador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailEntrenador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordEntrenador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdscripcionEntId = table.Column<int>(type: "int", nullable: false),
                    EstatusEntId = table.Column<int>(type: "int", nullable: true),
                    CategoriaEntrenador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValidacionEntrenador = table.Column<bool>(type: "bit", nullable: false),
                    CambioPwEntrenador = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrenadores", x => x.IdEntrenador);
                    table.ForeignKey(
                        name: "FK_Entrenadores_Adscripcion_AdscripcionEntId",
                        column: x => x.AdscripcionEntId,
                        principalTable: "Adscripcion",
                        principalColumn: "IdAdscripcion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Entrenadores_Estatus_EstatusEntId",
                        column: x => x.EstatusEntId,
                        principalTable: "Estatus",
                        principalColumn: "IdEstatus",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entrenadores_AdscripcionEntId",
                table: "Entrenadores",
                column: "AdscripcionEntId");

            migrationBuilder.CreateIndex(
                name: "IX_Entrenadores_EstatusEntId",
                table: "Entrenadores",
                column: "EstatusEntId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entrenadores");
        }
    }
}

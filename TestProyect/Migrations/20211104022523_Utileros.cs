using Microsoft.EntityFrameworkCore.Migrations;

namespace TestProyect.Migrations
{
    public partial class Utileros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Utileros",
                columns: table => new
                {
                    IdUtilero = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatriculaUtilero = table.Column<int>(type: "int", nullable: false),
                    NombreUtilero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaternoUtilero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaternoUtilero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CasaUtilero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CelularUtilero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailUtilero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordUtilero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdscripcionUtiId = table.Column<int>(type: "int", nullable: false),
                    EstatusUtiId = table.Column<int>(type: "int", nullable: true),
                    CanchaUtilero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValidacionUtilero = table.Column<bool>(type: "bit", nullable: false),
                    CambioPwUtilero = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utileros", x => x.IdUtilero);
                    table.ForeignKey(
                        name: "FK_Utileros_Adscripcion_AdscripcionUtiId",
                        column: x => x.AdscripcionUtiId,
                        principalTable: "Adscripcion",
                        principalColumn: "IdAdscripcion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Utileros_Estatus_EstatusUtiId",
                        column: x => x.EstatusUtiId,
                        principalTable: "Estatus",
                        principalColumn: "IdEstatus",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Utileros_AdscripcionUtiId",
                table: "Utileros",
                column: "AdscripcionUtiId");

            migrationBuilder.CreateIndex(
                name: "IX_Utileros_EstatusUtiId",
                table: "Utileros",
                column: "EstatusUtiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Utileros");
        }
    }
}

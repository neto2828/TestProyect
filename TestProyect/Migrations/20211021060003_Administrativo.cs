using Microsoft.EntityFrameworkCore.Migrations;

namespace TestProyect.Migrations
{
    public partial class Administrativo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estatus",
                columns: table => new
                {
                    IdEstatus = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEstatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estatus", x => x.IdEstatus);
                });

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

            migrationBuilder.CreateTable(
                name: "Administrativos",
                columns: table => new
                {
                    IdAdministrativos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatriculaAdministrativo = table.Column<int>(type: "int", nullable: false),
                    NombreAdministrativo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaternoAdministrativo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaternoAdministrativo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CasaAdministrativo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CelularAdministrativo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAdministrativo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordAdministrativo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdscripcionAdminId = table.Column<int>(type: "int", nullable: false),
                    IdEstatus = table.Column<int>(type: "int", nullable: true),
                    ValidacionAdministrativo = table.Column<bool>(type: "bit", nullable: false),
                    CambioPwAdministrativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrativos", x => x.IdAdministrativos);
                    table.ForeignKey(
                        name: "FK_Administrativos_Adscripcion_AdscripcionAdminId",
                        column: x => x.AdscripcionAdminId,
                        principalTable: "Adscripcion",
                        principalColumn: "IdAdscripcion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Administrativos_Estatus_IdEstatus",
                        column: x => x.IdEstatus,
                        principalTable: "Estatus",
                        principalColumn: "IdEstatus",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Administrativos_AdscripcionAdminId",
                table: "Administrativos",
                column: "AdscripcionAdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Administrativos_IdEstatus",
                table: "Administrativos",
                column: "IdEstatus");

            migrationBuilder.CreateIndex(
                name: "IX_Adscripcion_EstatusId",
                table: "Adscripcion",
                column: "EstatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrativos");

            migrationBuilder.DropTable(
                name: "Adscripcion");

            migrationBuilder.DropTable(
                name: "Estatus");
        }
    }
}

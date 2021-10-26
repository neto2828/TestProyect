using Microsoft.EntityFrameworkCore.Migrations;

namespace TestProyect.Migrations
{
    public partial class Canchas : Migration
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

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCategoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstatusCatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.IdCategoria);
                    table.ForeignKey(
                        name: "FK_Categorias_Estatus_EstatusCatId",
                        column: x => x.EstatusCatId,
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

            migrationBuilder.CreateIndex(
                name: "IX_Canchas_EstatusCanchaId",
                table: "Canchas",
                column: "EstatusCanchaId");

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_EstatusCatId",
                table: "Categorias",
                column: "EstatusCatId");

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
                name: "Administrativos");

            migrationBuilder.DropTable(
                name: "Canchas");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Entrenadores");

            migrationBuilder.DropTable(
                name: "Adscripcion");

            migrationBuilder.DropTable(
                name: "Estatus");
        }
    }
}

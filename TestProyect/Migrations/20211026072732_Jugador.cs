using Microsoft.EntityFrameworkCore.Migrations;

namespace TestProyect.Migrations
{
    public partial class Jugador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jugadores",
                columns: table => new
                {
                    IdJugador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatriculaJugador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreJugador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaternoJugador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaternoJugador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EquipoJugId = table.Column<int>(type: "int", nullable: false),
                    EstaturaJugador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PesoJugador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NacimientoJugador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PosicionJugId = table.Column<int>(type: "int", nullable: true),
                    CasaJugador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CelularJugador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailJugador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordJugador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CalleJugador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoExtJugador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoIntJugador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CiudadJugador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoJugador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaisJugId = table.Column<int>(type: "int", nullable: true),
                    NacionalidadJugId = table.Column<int>(type: "int", nullable: true),
                    PiernaJugador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstatusJugaId = table.Column<int>(type: "int", nullable: false),
                    EstatusJugId = table.Column<int>(type: "int", nullable: true),
                    ValidacionJugador = table.Column<bool>(type: "bit", nullable: false),
                    CambioPwJugador = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jugadores", x => x.IdJugador);
                    table.ForeignKey(
                        name: "FK_Jugadores_Equipos_EquipoJugId",
                        column: x => x.EquipoJugId,
                        principalTable: "Equipos",
                        principalColumn: "IdEquipo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jugadores_Estatus_EstatusJugId",
                        column: x => x.EstatusJugId,
                        principalTable: "Estatus",
                        principalColumn: "IdEstatus",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Jugadores_Paises_NacionalidadJugId",
                        column: x => x.NacionalidadJugId,
                        principalTable: "Paises",
                        principalColumn: "IdPais",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Jugadores_Paises_PaisJugId",
                        column: x => x.PaisJugId,
                        principalTable: "Paises",
                        principalColumn: "IdPais",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Jugadores_Posiciones_PosicionJugId",
                        column: x => x.PosicionJugId,
                        principalTable: "Posiciones",
                        principalColumn: "IdPosicion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jugadores_EquipoJugId",
                table: "Jugadores",
                column: "EquipoJugId");

            migrationBuilder.CreateIndex(
                name: "IX_Jugadores_EstatusJugId",
                table: "Jugadores",
                column: "EstatusJugId");

            migrationBuilder.CreateIndex(
                name: "IX_Jugadores_NacionalidadJugId",
                table: "Jugadores",
                column: "NacionalidadJugId");

            migrationBuilder.CreateIndex(
                name: "IX_Jugadores_PaisJugId",
                table: "Jugadores",
                column: "PaisJugId");

            migrationBuilder.CreateIndex(
                name: "IX_Jugadores_PosicionJugId",
                table: "Jugadores",
                column: "PosicionJugId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jugadores");
        }
    }
}

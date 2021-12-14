using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestProyect.Migrations
{
    public partial class ActualizacionJugador : Migration
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
                name: "Paises",
                columns: table => new
                {
                    IdPais = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePais = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClasePais = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.IdPais);
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

            migrationBuilder.CreateTable(
                name: "Componentes",
                columns: table => new
                {
                    IdComponente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreComponente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IconoComponente = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    EstatusJugId = table.Column<int>(type: "int", nullable: true),
                    ValidacionJugador = table.Column<bool>(type: "bit", nullable: false),
                    CambioPwJugador = table.Column<bool>(type: "bit", nullable: false),
                    CamisetaJugador = table.Column<int>(type: "int", nullable: true),
                    CoordenadaX = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoordenadaY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitularJugador = table.Column<bool>(type: "bit", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Mesociclos",
                columns: table => new
                {
                    IdMesociclo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VolumenMesociclo = table.Column<int>(type: "int", nullable: false),
                    TurnoMesococlo = table.Column<int>(type: "int", nullable: false),
                    FechaMesococlo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ObservacionesMesococlo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MesocicloCanId = table.Column<int>(type: "int", nullable: false),
                    MesocicloEquId = table.Column<int>(type: "int", nullable: true),
                    MesocicloCompId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesociclos", x => x.IdMesociclo);
                    table.ForeignKey(
                        name: "FK_Mesociclos_Canchas_MesocicloCanId",
                        column: x => x.MesocicloCanId,
                        principalTable: "Canchas",
                        principalColumn: "IdCancha",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mesociclos_Componentes_MesocicloCompId",
                        column: x => x.MesocicloCompId,
                        principalTable: "Componentes",
                        principalColumn: "IdComponente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mesociclos_Equipos_MesocicloEquId",
                        column: x => x.MesocicloEquId,
                        principalTable: "Equipos",
                        principalColumn: "IdEquipo",
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
                name: "IX_Componentes_EntrenadorCompId",
                table: "Componentes",
                column: "EntrenadorCompId");

            migrationBuilder.CreateIndex(
                name: "IX_Entrenadores_AdscripcionEntId",
                table: "Entrenadores",
                column: "AdscripcionEntId");

            migrationBuilder.CreateIndex(
                name: "IX_Entrenadores_EstatusEntId",
                table: "Entrenadores",
                column: "EstatusEntId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_CategoriaEquId",
                table: "Equipos",
                column: "CategoriaEquId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_EntrenadorEquiId",
                table: "Equipos",
                column: "EntrenadorEquiId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Mesociclos_MesocicloCanId",
                table: "Mesociclos",
                column: "MesocicloCanId");

            migrationBuilder.CreateIndex(
                name: "IX_Mesociclos_MesocicloCompId",
                table: "Mesociclos",
                column: "MesocicloCompId");

            migrationBuilder.CreateIndex(
                name: "IX_Mesociclos_MesocicloEquId",
                table: "Mesociclos",
                column: "MesocicloEquId");

            migrationBuilder.CreateIndex(
                name: "IX_Posiciones_EstatusPosId",
                table: "Posiciones",
                column: "EstatusPosId");

            migrationBuilder.CreateIndex(
                name: "IX_Subcomponentes_ComponenteSubId",
                table: "Subcomponentes",
                column: "ComponenteSubId");

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
                name: "Administrativos");

            migrationBuilder.DropTable(
                name: "Jugadores");

            migrationBuilder.DropTable(
                name: "Mesociclos");

            migrationBuilder.DropTable(
                name: "Subcomponentes");

            migrationBuilder.DropTable(
                name: "Utileros");

            migrationBuilder.DropTable(
                name: "Paises");

            migrationBuilder.DropTable(
                name: "Posiciones");

            migrationBuilder.DropTable(
                name: "Canchas");

            migrationBuilder.DropTable(
                name: "Equipos");

            migrationBuilder.DropTable(
                name: "Componentes");

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

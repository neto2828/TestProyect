using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestProyect.Migrations
{
    public partial class Mesociclo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IconoComponente",
                table: "Componentes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mesociclos");

            migrationBuilder.DropColumn(
                name: "IconoComponente",
                table: "Componentes");
        }
    }
}

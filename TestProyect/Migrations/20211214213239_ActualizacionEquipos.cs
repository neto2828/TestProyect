using Microsoft.EntityFrameworkCore.Migrations;

namespace TestProyect.Migrations
{
    public partial class ActualizacionEquipos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EscudoEquipo",
                table: "Equipos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EscudoEquipo",
                table: "Equipos");
        }
    }
}

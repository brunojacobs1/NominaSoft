using Microsoft.EntityFrameworkCore.Migrations;

namespace NominaSoft.Infraestructure.EFCore.Migrations
{
    public partial class telefono : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "Empleado",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MontoPorReintegro",
                table: "ConceptoPago",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "MontoPorReintegro",
                table: "ConceptoPago");
        }
    }
}

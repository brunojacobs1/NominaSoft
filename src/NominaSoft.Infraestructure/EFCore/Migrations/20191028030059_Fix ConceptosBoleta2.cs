using Microsoft.EntityFrameworkCore.Migrations;

namespace NominaSoft.Infraestructure.EFCore.Migrations
{
    public partial class FixConceptosBoleta2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConceptoPago_BoletaPago_IdBoletaPago",
                table: "ConceptoPago");

            migrationBuilder.DropIndex(
                name: "IX_ConceptoPago_IdBoletaPago",
                table: "ConceptoPago");

            migrationBuilder.DropColumn(
                name: "IdBoletaPago",
                table: "ConceptoPago");

            migrationBuilder.AddColumn<int>(
                name: "ConceptosDePagoIdConceptosDePago",
                table: "BoletaPago",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoletaPago_ConceptosDePagoIdConceptosDePago",
                table: "BoletaPago",
                column: "ConceptosDePagoIdConceptosDePago");

            migrationBuilder.AddForeignKey(
                name: "FK_BoletaPago_ConceptoPago_ConceptosDePagoIdConceptosDePago",
                table: "BoletaPago",
                column: "ConceptosDePagoIdConceptosDePago",
                principalTable: "ConceptoPago",
                principalColumn: "IdConceptosDePago",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoletaPago_ConceptoPago_ConceptosDePagoIdConceptosDePago",
                table: "BoletaPago");

            migrationBuilder.DropIndex(
                name: "IX_BoletaPago_ConceptosDePagoIdConceptosDePago",
                table: "BoletaPago");

            migrationBuilder.DropColumn(
                name: "ConceptosDePagoIdConceptosDePago",
                table: "BoletaPago");

            migrationBuilder.AddColumn<int>(
                name: "IdBoletaPago",
                table: "ConceptoPago",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ConceptoPago_IdBoletaPago",
                table: "ConceptoPago",
                column: "IdBoletaPago",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ConceptoPago_BoletaPago_IdBoletaPago",
                table: "ConceptoPago",
                column: "IdBoletaPago",
                principalTable: "BoletaPago",
                principalColumn: "IdBoletaPago",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

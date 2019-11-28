using Microsoft.EntityFrameworkCore.Migrations;

namespace NominaSoft.Infraestructure.Migrations
{
    public partial class Refactorizacionpunto6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_ConceptoPago_Contrato_IdContrato",
            //    table: "ConceptoPago");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_ConceptoPago_PeriodoPago_IdPeriodoPago",
            //    table: "ConceptoPago");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Contrato_AFP_IdAFP",
            //    table: "Contrato");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Contrato_Empleado_IdEmpleado",
            //    table: "Contrato");

            //migrationBuilder.DropIndex(
            //    name: "IX_Contrato_IdAFP",
            //    table: "Contrato");

            //migrationBuilder.DropIndex(
            //    name: "IX_Contrato_IdEmpleado",
            //    table: "Contrato");

            //migrationBuilder.DropIndex(
            //    name: "IX_ConceptoPago_IdContrato",
            //    table: "ConceptoPago");

            //migrationBuilder.DropIndex(
            //    name: "IX_ConceptoPago_IdPeriodoPago",
            //    table: "ConceptoPago");

            //migrationBuilder.DropIndex(
            //    name: "IX_BoletaPago_IdConceptosDePago",
            //    table: "BoletaPago");

            //migrationBuilder.DropColumn(
            //    name: "IdAFP",
            //    table: "Contrato");

            //migrationBuilder.DropColumn(
            //    name: "IdEmpleado",
            //    table: "Contrato");

            //migrationBuilder.DropColumn(
            //    name: "IdContrato",
            //    table: "ConceptoPago");

            //migrationBuilder.DropColumn(
            //    name: "IdPeriodoPago",
            //    table: "ConceptoPago");

            //migrationBuilder.AddColumn<int>(
            //    name: "AFPIdAFP",
            //    table: "Contrato",
            //    nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "EmpleadoIdEmpleado",
            //    table: "Contrato",
            //    nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "ContratoIdContrato",
            //    table: "ConceptoPago",
            //    nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "PeriodoPagoIdPeriodoPago",
            //    table: "ConceptoPago",
            //    nullable: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Contrato_AFPIdAFP",
            //    table: "Contrato",
            //    column: "AFPIdAFP");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Contrato_EmpleadoIdEmpleado",
            //    table: "Contrato",
            //    column: "EmpleadoIdEmpleado");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ConceptoPago_ContratoIdContrato",
            //    table: "ConceptoPago",
            //    column: "ContratoIdContrato");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ConceptoPago_PeriodoPagoIdPeriodoPago",
            //    table: "ConceptoPago",
            //    column: "PeriodoPagoIdPeriodoPago");

            //migrationBuilder.CreateIndex(
            //    name: "IX_BoletaPago_IdConceptosDePago",
            //    table: "BoletaPago",
            //    column: "IdConceptosDePago");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ConceptoPago_Contrato_ContratoIdContrato",
            //    table: "ConceptoPago",
            //    column: "ContratoIdContrato",
            //    principalTable: "Contrato",
            //    principalColumn: "IdContrato",
            //    onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ConceptoPago_PeriodoPago_PeriodoPagoIdPeriodoPago",
            //    table: "ConceptoPago",
            //    column: "PeriodoPagoIdPeriodoPago",
            //    principalTable: "PeriodoPago",
            //    principalColumn: "IdPeriodoPago",
            //    onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Contrato_AFP_AFPIdAFP",
            //    table: "Contrato",
            //    column: "AFPIdAFP",
            //    principalTable: "AFP",
            //    principalColumn: "IdAFP",
            //    onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Contrato_Empleado_EmpleadoIdEmpleado",
            //    table: "Contrato",
            //    column: "EmpleadoIdEmpleado",
            //    principalTable: "Empleado",
            //    principalColumn: "IdEmpleado",
            //    onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConceptoPago_Contrato_ContratoIdContrato",
                table: "ConceptoPago");

            migrationBuilder.DropForeignKey(
                name: "FK_ConceptoPago_PeriodoPago_PeriodoPagoIdPeriodoPago",
                table: "ConceptoPago");

            migrationBuilder.DropForeignKey(
                name: "FK_Contrato_AFP_AFPIdAFP",
                table: "Contrato");

            migrationBuilder.DropForeignKey(
                name: "FK_Contrato_Empleado_EmpleadoIdEmpleado",
                table: "Contrato");

            migrationBuilder.DropIndex(
                name: "IX_Contrato_AFPIdAFP",
                table: "Contrato");

            migrationBuilder.DropIndex(
                name: "IX_Contrato_EmpleadoIdEmpleado",
                table: "Contrato");

            migrationBuilder.DropIndex(
                name: "IX_ConceptoPago_ContratoIdContrato",
                table: "ConceptoPago");

            migrationBuilder.DropIndex(
                name: "IX_ConceptoPago_PeriodoPagoIdPeriodoPago",
                table: "ConceptoPago");

            migrationBuilder.DropIndex(
                name: "IX_BoletaPago_IdConceptosDePago",
                table: "BoletaPago");

            migrationBuilder.DropColumn(
                name: "AFPIdAFP",
                table: "Contrato");

            migrationBuilder.DropColumn(
                name: "EmpleadoIdEmpleado",
                table: "Contrato");

            migrationBuilder.DropColumn(
                name: "ContratoIdContrato",
                table: "ConceptoPago");

            migrationBuilder.DropColumn(
                name: "PeriodoPagoIdPeriodoPago",
                table: "ConceptoPago");

            migrationBuilder.AddColumn<int>(
                name: "IdAFP",
                table: "Contrato",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdEmpleado",
                table: "Contrato",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdContrato",
                table: "ConceptoPago",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdPeriodoPago",
                table: "ConceptoPago",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_IdAFP",
                table: "Contrato",
                column: "IdAFP");

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_IdEmpleado",
                table: "Contrato",
                column: "IdEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_ConceptoPago_IdContrato",
                table: "ConceptoPago",
                column: "IdContrato");

            migrationBuilder.CreateIndex(
                name: "IX_ConceptoPago_IdPeriodoPago",
                table: "ConceptoPago",
                column: "IdPeriodoPago");

            migrationBuilder.CreateIndex(
                name: "IX_BoletaPago_IdConceptosDePago",
                table: "BoletaPago",
                column: "IdConceptosDePago",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ConceptoPago_Contrato_IdContrato",
                table: "ConceptoPago",
                column: "IdContrato",
                principalTable: "Contrato",
                principalColumn: "IdContrato",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConceptoPago_PeriodoPago_IdPeriodoPago",
                table: "ConceptoPago",
                column: "IdPeriodoPago",
                principalTable: "PeriodoPago",
                principalColumn: "IdPeriodoPago",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contrato_AFP_IdAFP",
                table: "Contrato",
                column: "IdAFP",
                principalTable: "AFP",
                principalColumn: "IdAFP",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contrato_Empleado_IdEmpleado",
                table: "Contrato",
                column: "IdEmpleado",
                principalTable: "Empleado",
                principalColumn: "IdEmpleado",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

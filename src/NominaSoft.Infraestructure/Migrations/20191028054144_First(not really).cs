using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NominaSoft.Infraestructure.Migrations
{
    public partial class Firstnotreally : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AFP",
                columns: table => new
                {
                    IdAFP = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreAFP = table.Column<string>(maxLength: 50, nullable: false),
                    PorcentajeDescuento = table.Column<double>(nullable: false),
                    Habilitado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AFP", x => x.IdAFP);
                });

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    IdEmpleado = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Grado = table.Column<int>(nullable: false),
                    EstadoCivil = table.Column<int>(nullable: false),
                    Dni = table.Column<string>(maxLength: 8, nullable: false),
                    Direccion = table.Column<string>(maxLength: 80, nullable: true),
                    NombreEmpleado = table.Column<string>(maxLength: 50, nullable: false),
                    Telefono = table.Column<string>(nullable: true),
                    Habilitado = table.Column<bool>(nullable: false),
                    FechaDeNacimiento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.IdEmpleado);
                });

            migrationBuilder.CreateTable(
                name: "PeriodoPago",
                columns: table => new
                {
                    IdPeriodoPago = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Esactivo = table.Column<bool>(nullable: false),
                    FechaFin = table.Column<DateTime>(nullable: false),
                    FechaInicio = table.Column<DateTime>(nullable: false),
                    Habilitado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodoPago", x => x.IdPeriodoPago);
                });

            migrationBuilder.CreateTable(
                name: "Contrato",
                columns: table => new
                {
                    IdContrato = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ValorHora = table.Column<int>(nullable: false),
                    TotalHorasSemanales = table.Column<int>(nullable: false),
                    EsAnulado = table.Column<bool>(nullable: false),
                    EsAsignacionFamiliar = table.Column<bool>(nullable: false),
                    Cargo = table.Column<string>(maxLength: 50, nullable: true),
                    FechaFin = table.Column<DateTime>(nullable: false),
                    FechaInicio = table.Column<DateTime>(nullable: false),
                    IdAFP = table.Column<int>(nullable: false),
                    IdEmpleado = table.Column<int>(nullable: false),
                    Habilitado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contrato", x => x.IdContrato);
                    table.ForeignKey(
                        name: "FK_Contrato_AFP_IdAFP",
                        column: x => x.IdAFP,
                        principalTable: "AFP",
                        principalColumn: "IdAFP",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contrato_Empleado_IdEmpleado",
                        column: x => x.IdEmpleado,
                        principalTable: "Empleado",
                        principalColumn: "IdEmpleado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConceptoPago",
                columns: table => new
                {
                    IdConceptosDePago = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MontoDeOtrosIngresos = table.Column<double>(nullable: false),
                    MontoPorHorasExtra = table.Column<double>(nullable: false),
                    MontoPorHorasAusentes = table.Column<double>(nullable: false),
                    MontoDeOtrosDescuentos = table.Column<double>(nullable: false),
                    MontoPorAdelantos = table.Column<double>(nullable: false),
                    MontoPorReintegro = table.Column<double>(nullable: false),
                    IdContrato = table.Column<int>(nullable: false),
                    IdPeriodoPago = table.Column<int>(nullable: false),
                    Habilitado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConceptoPago", x => x.IdConceptosDePago);
                    table.ForeignKey(
                        name: "FK_ConceptoPago_Contrato_IdContrato",
                        column: x => x.IdContrato,
                        principalTable: "Contrato",
                        principalColumn: "IdContrato",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConceptoPago_PeriodoPago_IdPeriodoPago",
                        column: x => x.IdPeriodoPago,
                        principalTable: "PeriodoPago",
                        principalColumn: "IdPeriodoPago",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BoletaPago",
                columns: table => new
                {
                    IdBoletaPago = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FechaPago = table.Column<DateTime>(nullable: false),
                    IdContrato = table.Column<int>(nullable: false),
                    IdPeriodoPago = table.Column<int>(nullable: false),
                    IdConceptosDePago = table.Column<int>(nullable: false),
                    Habilitado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoletaPago", x => x.IdBoletaPago);
                    table.ForeignKey(
                        name: "FK_BoletaPago_ConceptoPago_IdConceptosDePago",
                        column: x => x.IdConceptosDePago,
                        principalTable: "ConceptoPago",
                        principalColumn: "IdConceptosDePago",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoletaPago_Contrato_IdContrato",
                        column: x => x.IdContrato,
                        principalTable: "Contrato",
                        principalColumn: "IdContrato",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoletaPago_PeriodoPago_IdPeriodoPago",
                        column: x => x.IdPeriodoPago,
                        principalTable: "PeriodoPago",
                        principalColumn: "IdPeriodoPago",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoletaPago_IdConceptosDePago",
                table: "BoletaPago",
                column: "IdConceptosDePago",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoletaPago_IdContrato",
                table: "BoletaPago",
                column: "IdContrato");

            migrationBuilder.CreateIndex(
                name: "IX_BoletaPago_IdPeriodoPago",
                table: "BoletaPago",
                column: "IdPeriodoPago");

            migrationBuilder.CreateIndex(
                name: "IX_ConceptoPago_IdContrato",
                table: "ConceptoPago",
                column: "IdContrato");

            migrationBuilder.CreateIndex(
                name: "IX_ConceptoPago_IdPeriodoPago",
                table: "ConceptoPago",
                column: "IdPeriodoPago");

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_IdAFP",
                table: "Contrato",
                column: "IdAFP");

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_IdEmpleado",
                table: "Contrato",
                column: "IdEmpleado");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoletaPago");

            migrationBuilder.DropTable(
                name: "ConceptoPago");

            migrationBuilder.DropTable(
                name: "Contrato");

            migrationBuilder.DropTable(
                name: "PeriodoPago");

            migrationBuilder.DropTable(
                name: "AFP");

            migrationBuilder.DropTable(
                name: "Empleado");
        }
    }
}

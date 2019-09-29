using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NominaSoft.Core.Entities
{
    class BoletaPago
    {
        public int IdBoletaPago { get; set; }
        public DateTime FechaPago { get; set; }
        public Contrato Contrato { get; set; }
        public PeriodoPago PeriodoPago { get; set; }
        public ConceptosDeIngresos ConceptosDeIngresos { get; set; }
        public ConceptosDeDescuentos ConceptosDeDescuentos { get; set; }

        public int CalcularTotalHorasBoleta() => Contrato.CalcularTotalHorasSemanales() * PeriodoPago.CalcularTotalSemanas();
        public double CalcularSueldoBasico() => CalcularTotalHorasBoleta() * Contrato.ValorHora;
        public double CalcularSumatoriaDescuentos() => ConceptosDeDescuentos.MontoDeOtrosDescuentos +
                                                        ConceptosDeDescuentos.MontoPorAdelantos +
                                                        ConceptosDeDescuentos.MontoPorHorasAusentes;
        public double CalcularSumatoriaIngresos() => ConceptosDeIngresos.MontoPorHorasAusentes +
                                                        ConceptosDeIngresos.MontoDeOtrosIngresos +
                                                        ConceptosDeIngresos.MontoPorHorasExtra;
        public double CalcularTotalDescuentos() => CalcularSumatoriaDescuentos() + Contrato.CalcularDescuentoPorAfp();
        public double CalcularTotalIngresos() => CalcularSueldoBasico() + Contrato.CalcularAsignacionFamiliar() + CalcularSumatoriaIngresos();
        public double CalcularSueldoNeto() => CalcularTotalIngresos() + CalcularTotalDescuentos();
    }
}
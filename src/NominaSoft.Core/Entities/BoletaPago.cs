using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NominaSoft.Core.Entities
{
    public class BoletaPago
    {
        public int IdBoletaPago { get; set; }
        public DateTime FechaPago { get; set; }
        public Contrato Contrato { get; set; }
        public PeriodoPago PeriodoPago { get; set; }
        public ConceptosDePago ConceptosDePago { get; set; }

        public int CalcularTotalHorasBoleta() => Contrato.TotalHorasSemanales * PeriodoPago.CalcularTotalSemanas();

        public double CalcularSueldoBasico() => CalcularTotalHorasBoleta() * Contrato.ValorHora;

        public double CalcularDescuentoPorAfp() => CalcularSueldoBasico() * Contrato.AFP.PorcentajeDescuento;

        public double CalcularTotalDescuentos() => ConceptosDePago.CalcularSumatoriaDescuentos() + CalcularDescuentoPorAfp();
        
        public double CalcularTotalIngresos() => CalcularSueldoBasico() + Contrato.CalcularAsignacionFamiliar() + ConceptosDePago.CalcularSumatoriaIngresos();

        public double CalcularSueldoNeto() => CalcularTotalIngresos() + CalcularTotalDescuentos();
    }
}

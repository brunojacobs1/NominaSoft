using Core.Entities;
using NominaSoft.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NominaSoft.Core
{
    public class ConceptosDePago
    {
        public double MontoDeOtrosIngresos { get; set; }

        public double MontoPorHorasExtra { get; set; }

        public double MontoPorHorasAusentes { get; set; }

        public double MontoDeOtrosDescuentos { get; set; }

        public double MontoPorAdelantos { get; set; }

        public Contrato Contrato { get; set; }

        public PeriodoPago PeriodoPago { get; set; }

        public double CalcularSumatoriaDescuentos() => MontoDeOtrosDescuentos +
                                                        MontoPorAdelantos +
                                                        MontoPorHorasAusentes;

        public double CalcularSumatoriaIngresos() => MontoPorHorasAusentes +
                                                        MontoDeOtrosIngresos +
                                                        MontoPorHorasExtra;
    }
}

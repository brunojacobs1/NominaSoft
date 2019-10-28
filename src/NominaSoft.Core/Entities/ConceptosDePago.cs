using NominaSoft.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NominaSoft.Core.Entities
{
    public class ConceptosDePago
    {
        public int IdConceptosDePago { get; set; }
        public double MontoDeOtrosIngresos { get; set; }

        public double MontoPorHorasExtra { get; set; }

        public double MontoPorHorasAusentes { get; set; }

        public double MontoDeOtrosDescuentos { get; set; }

        public double MontoPorAdelantos { get; set; }

        public double MontoPorReintegro { get; set; }

        public int IdContrato { get; set; }
        public Contrato Contrato { get; set; }

        public int IdPeriodoPago { get; set; }
        public PeriodoPago PeriodoPago { get; set; }

        //public int IdBoletaPago { get; set; }
        //public BoletaPago BoletaPago { get; set; }
        public bool Habilitado { get; set; }

        public double CalcularSumatoriaDescuentos() => MontoDeOtrosDescuentos +
                                                        MontoPorAdelantos +
                                                        MontoPorHorasAusentes;

        public double CalcularSumatoriaIngresos() => MontoPorReintegro +
                                                        MontoDeOtrosIngresos +
                                                        MontoPorHorasExtra;
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using NominaSoft.Core.Entities;

namespace NominaSoft.UseCases
{
    public class Planilla
    {
        public ICollection<DatosPlanilla> DatosPlanillas { get; set; }

        public BoletaPago GenerarBoleta(PeriodoPago periodoPago, Contrato contrato, ConceptosDePago conceptosDePago)
        {
            BoletaPago boletaPago = new BoletaPago()
            {
                FechaPago = periodoPago.FechaFin,
                Contrato = contrato,
                IdPeriodoPago = periodoPago.IdPeriodoPago,
                PeriodoPago = periodoPago,
                ConceptosDePago = conceptosDePago
            };
            return boletaPago;
        }
    }
}

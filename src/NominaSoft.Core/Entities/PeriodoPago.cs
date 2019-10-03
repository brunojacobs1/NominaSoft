using System;
using System.Collections.Generic;
using System.Text;

namespace NominaSoft.Core.Entities
{
    public class PeriodoPago
    {
        public int PeriodoPagoID { get; set; }
        public bool Esactivo { get; set; }
        public DateTime FechaFin { get; set; }
        public DateTime FechaInicio { get; set; }

        public void DesactivarPeriodo() => Esactivo = false;

        public bool ActivarPeriodoPago(PeriodoPago _periodoAnterior)
        {
            if(_periodoAnterior.FechaFin <= FechaInicio)
            {
                _periodoAnterior.DesactivarPeriodo();
                Esactivo = true;
            }

            return Esactivo;
        }

        public int CalcularTotalSemanas() => (FechaFin - FechaInicio).Days / 7;
    }
}

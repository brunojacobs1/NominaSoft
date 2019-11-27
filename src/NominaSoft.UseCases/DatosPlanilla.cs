using System;
using System.Collections.Generic;
using System.Text;
using NominaSoft.Core.Entities;

namespace NominaSoft.UseCases
{
    public class DatosPlanilla
    {
        public Empleado Empleado { get; set; }
        public Contrato Contrato { get; set; }
        public Double TotalHoras { get; set; }
        public Double SueldoBasico { get; set; }
        public Double TotalIngresos { get; set; }
        public Double TotalDescuentos { get; set; }
        public Double SueldoNeto { get; set; }

        public DatosPlanilla(Contrato contrato, BoletaPago boletaPago)
        {
            Empleado = contrato.Empleado;
            Contrato = contrato;
            TotalHoras = boletaPago.CalcularTotalHorasBoleta();
            SueldoBasico = boletaPago.CalcularSueldoBasico();
            TotalIngresos = boletaPago.CalcularTotalIngresos();
            TotalDescuentos = boletaPago.CalcularTotalDescuentos();
            SueldoNeto = boletaPago.CalcularSueldoNeto();
        }
    }
}

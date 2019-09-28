using Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Contrato
    {
        public int IdContrato { get; set; }
        public bool EsAnulado { get; set; }
        public String Cargo { get; set; }
        public DateTime FechaFin { get; set; }
        public DateTime FechaInicio { get; set; }
        public bool EsAsignacionFamiliar { get; set; }
        public int TotalHoras { get; set; }
        public int ValorHora { get; set; }
        public Empleado Empleado { get; set; }
        public AFP AFP { get; set; }

        public const double SueldoMinimo = 930.00;

        public double CalcularAsignacionFamiliar() => EsAsignacionFamiliar ? SueldoMinimo * 0.1 : 0;

        public double CalcularDescuentoPorAfp() => throw new NotImplementedException();

        public float CalcularTotalHorasSemanales() => TotalHoras / ((FechaFin - FechaInicio).Days / 7);

        public bool VerificarFechaFin() => FechaFin.Month - FechaInicio.Month >= 3 &&
                                    FechaFin.Month - FechaInicio.Month <= 12;

        public bool VerificarFechaInicio(Contrato _contrato) => FechaInicio > _contrato.FechaFin;

        public bool VerificarTotalHora() => TotalHoras >= 8 && TotalHoras <= 40;

        public bool VerificarValorHora()
        {
            if(Empleado.Grado.Equals(GradoAcademico.Primaria) || Empleado.Grado.Equals(GradoAcademico.Secundaria))
                return ValorHora >= 5 && ValorHora <= 10;
            else
            {
                if (Empleado.Grado.Equals(GradoAcademico.Bachiller))
                    return ValorHora >= 11 && ValorHora <= 20;
                else
                {
                    if (Empleado.Grado.Equals(GradoAcademico.Profesional))
                        return ValorHora >= 21 && ValorHora <= 30;
                    else
                    {
                        if (Empleado.Grado.Equals(GradoAcademico.Magister))
                            return ValorHora >= 31 && ValorHora <= 40;
                        else
                            return ValorHora >= 41 && ValorHora <= 60;
                    }
                }
            }
        }
    }
}

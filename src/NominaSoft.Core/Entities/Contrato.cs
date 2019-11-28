using NominaSoft.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NominaSoft.Core.Entities
{
    public class Contrato
    {
        public int IdContrato { get; set; }
        public int ValorHora { get; set; }
        public int TotalHorasSemanales { get; set; }

        public bool EsAnulado { get; set; }
        public bool EsAsignacionFamiliar { get; set; }

        public String Cargo { get; set; }

        public DateTime FechaFin { get; set; }
        public DateTime FechaInicio { get; set; }

        public int IdAFP { get; set; }
        public AFP AFP { get; set; }

        public int IdEmpleado { get; set; }
        public Empleado Empleado { get; set; }

        public bool Habilitado { get; set; }

        public const double SueldoMinimo = 930.00;

        //public ICollection<BoletaPago> BoletasPago { get; set; }
        //public ICollection<ConceptosDePago> ConceptosDePago { get; set; }

        public double CalcularAsignacionFamiliar() => EsAsignacionFamiliar ? SueldoMinimo * 0.1 : 0;

        public bool VerificarFechaFin() {
            if (FechaFin.Year - FechaInicio.Year == 0)
            {
                if (FechaFin.Month - FechaInicio.Month >= 3 && FechaFin.Month - FechaInicio.Month <=12)
                    return true;
                else
                    return false;
            }
            else
            {
                if (((FechaFin.Year - FechaInicio.Year) * 12) + (FechaFin.Month - FechaInicio.Month) >= 3 &&
                    ((FechaFin.Year - FechaInicio.Year) * 12) + (FechaFin.Month - FechaInicio.Month) <= 12)
                    return true;
                else
                    return false;
                
            }
        } 
          
        public bool VerificarFechaInicio(Contrato _contrato)
        {
            if (_contrato != null)
                if (DateTime.Compare(FechaInicio, _contrato.FechaFin) > 0)
                    return true;

            return false;
        }
            
        public bool VerificarTotalHorasSemanales() => TotalHorasSemanales >= 8 && TotalHorasSemanales <= 40;

        public bool VerificarVigencia() => (FechaFin >= DateTime.Today) && !EsAnulado;

        public bool VerificarValorHora()
        {
            switch (Empleado.Grado)
            {
                case (int)GradoAcademico.Primaria: case (int)GradoAcademico.Secundaria:
                    return ValorHora >= 5 && ValorHora <= 10;
                case (int)GradoAcademico.Bachiller:
                    return ValorHora >= 11 && ValorHora <= 20;
                case (int)GradoAcademico.Profesional:
                    return ValorHora >= 21 && ValorHora <= 30;
                case (int)GradoAcademico.Magister:
                    return ValorHora >= 31 && ValorHora <= 40;
                default:
                    return ValorHora >= 41 && ValorHora <= 60;
            }

        }
    }
}

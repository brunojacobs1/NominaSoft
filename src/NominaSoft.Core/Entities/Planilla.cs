using System;
using System.Collections.Generic;
using System.Text;

namespace NominaSoft.Core.Entities
{
    public class Planilla
    {
        public Empleado Empleado { get; set; }
        public Contrato Contrato { get; set; }
        public Double TotalHoras { get; set; }
        public Double SueldoBasico { get; set; }
        public Double TotalIngresos { get; set; }
        public Double TotalDescuentos { get; set; }
        public Double SueldoNeto { get; set; }
    }
}

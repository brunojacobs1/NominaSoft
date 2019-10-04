using Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }
        public int Grado { get; set; }
        public int EstadoCivil { get; set; }

        public String Dni { get; set; }
        public String Direccion { get; set; }
        public String NombreEmpleado { get; set; }

        public DateTime FechaDeNacimiento { get; set; }
    }
}

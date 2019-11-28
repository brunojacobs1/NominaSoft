using NominaSoft.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NominaSoft.UI.ViewModels
{
    public class ViewModelGestionarContrato
    {
        public Empleado Empleado { get; set; }
        public Contrato Contrato { get; set; }
        public IEnumerable<Contrato> Contratos { get; set; }
        public IEnumerable<AFP> AFPs { get; set; }
        public int EmpleadoNoEncontrado { get; set; }
        public int ContratoCreado { get; set; }
        public int ErrorDatosContrato { get; set; }
        public String MensajeError { get; set; }
        public int ModificacionesContrato { get; set; }
        public int ContratoAnulado { get; set; }
    }
}

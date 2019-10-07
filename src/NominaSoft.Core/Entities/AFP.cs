using System;
using System.Collections.Generic;
using System.Text;

namespace NominaSoft.Core.Entities
{
    public class AFP
    {
        public int IdAFP { get; set; }

        public String NombreAFP { get; set; }

        public double PorcentajeDescuento { get; set; }

        public bool Habilitado { get; set; }

        public ICollection<Contrato> Contratos { get; set; }
    }
}

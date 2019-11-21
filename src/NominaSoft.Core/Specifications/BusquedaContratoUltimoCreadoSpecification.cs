using NominaSoft.Core.Entities;
using NominaSoft.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NominaSoft.Core.Specifications
{
    public class BusquedaContratoUltimoCreadoSpecification : BaseSpecification<Contrato>
    {
        public BusquedaContratoUltimoCreadoSpecification(int idEmpleado)
            : base (c => c.IdEmpleado == idEmpleado, c => c.IdContrato)
        {
        }
    }
}

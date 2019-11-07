using NominaSoft.Core.Entities;
using NominaSoft.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NominaSoft.Core.Specifications
{
    public class BusquedaContratoUltimoCreadoSpecification : BaseSpecification<Contrato>
    {
        public BusquedaContratoUltimoCreadoSpecification()
            : base (c => c.FechaInicio)
        {
        }
    }
}

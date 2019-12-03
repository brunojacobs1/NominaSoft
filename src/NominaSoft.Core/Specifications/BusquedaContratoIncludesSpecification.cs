using NominaSoft.Core.Entities;
using NominaSoft.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace NominaSoft.Core.Specifications
{
    public class BusquedaContratoIncludesSpecification : BaseSpecification<Contrato>
    {
        public BusquedaContratoIncludesSpecification(int id)
            : base(c => c.IdContrato == id)
        {
            AddInclude(c => c.Empleado);
            AddInclude(c => c.AFP);
        }
    }
}

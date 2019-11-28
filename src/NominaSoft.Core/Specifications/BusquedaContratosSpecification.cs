using NominaSoft.Core.Entities;
using NominaSoft.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace NominaSoft.Core.Specifications
{
    public class BusquedaContratosSpecification : BaseSpecification<Contrato>
    {
        public BusquedaContratosSpecification(string dni)
            : base(c => c.Empleado.Dni == dni)
        {
            AddInclude(c => c.Empleado);
            AddInclude(c => c.AFP);
        }
    }
}

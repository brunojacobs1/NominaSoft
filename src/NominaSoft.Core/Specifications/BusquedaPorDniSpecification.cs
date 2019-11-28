using NominaSoft.Core.Entities;
using NominaSoft.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace NominaSoft.Core.Specifications
{
    public class BusquedaPorDniSpecification : BaseSpecification<Empleado>
    {
        public BusquedaPorDniSpecification(string dni)
            : base(e => e.Dni == dni)
        {
            //AddInclude(e => e.Contratos);
        }
    }
}

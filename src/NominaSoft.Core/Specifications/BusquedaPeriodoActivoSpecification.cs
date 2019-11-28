using NominaSoft.Core.Entities;
using NominaSoft.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NominaSoft.Core.Specifications
{
    public class BusquedaPeriodoActivoSpecification : BaseSpecification<PeriodoPago>
    {
        public BusquedaPeriodoActivoSpecification()
            : base(pp => pp.Esactivo == true)
        {
            //AddInclude(pp => pp.BoletasPago);
            //AddInclude(pp => pp.ConceptosPago);
        }
    }
}

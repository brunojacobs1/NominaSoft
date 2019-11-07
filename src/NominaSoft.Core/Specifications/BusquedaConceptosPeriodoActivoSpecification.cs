using NominaSoft.Core.Entities;
using NominaSoft.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NominaSoft.Core.Specifications
{
    public class BusquedaConceptosPeriodoActivoSpecification : BaseSpecification<ConceptosDePago>
    {
        public BusquedaConceptosPeriodoActivoSpecification()
            : base(cp => cp.PeriodoPago.Esactivo == true)
        {
            AddInclude(cp => cp.Contrato);
        }
    }
}

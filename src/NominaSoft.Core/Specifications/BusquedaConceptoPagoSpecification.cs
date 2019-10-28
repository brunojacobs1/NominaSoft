using NominaSoft.Core.Entities;
using NominaSoft.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NominaSoft.Core.Specifications
{
    public class BusquedaConceptoPagoSpecification : BaseSpecification<ConceptosDePago>
    {
        public BusquedaConceptoPagoSpecification(int idContrato, int idPeriodoPago)
            : base(cp => cp.IdContrato == idContrato && cp.IdPeriodoPago == idPeriodoPago)
        {
            AddInclude(cp => cp.Contrato);
            AddInclude(cp => cp.PeriodoPago);
            AddInclude(cp => cp.BoletaPago);
        }
    }
}

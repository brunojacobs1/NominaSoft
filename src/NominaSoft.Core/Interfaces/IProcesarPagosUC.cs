using NominaSoft.Core.DataTransferObjects;
using NominaSoft.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NominaSoft.Core.Interfaces
{
    public interface IProcesarPagosUC
    {
        void Setup(IRepository<AFP> repositoryAFP,
                                IRepository<Contrato> repositoryContrato,
                                IRepository<Empleado> repositoryEmpleado,
                                IRepository<BoletaPago> repositoryBoletaPago,
                                IRepository<PeriodoPago> repositoryPeriodoPago,
                                IRepository<ConceptosDePago> repositoryConceptosDePago);

        ProcesarPagosDTO ProcesarPagos();
        ProcesarPagosDTO VerificarProcesado();
    }
}

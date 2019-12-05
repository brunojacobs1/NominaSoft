using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NominaSoft.Core.Entities;
using NominaSoft.Core.Interfaces;
using NominaSoft.Core.Specifications;
using NominaSoft.Core.DataTransferObjects;

namespace NominaSoft.UI.Controllers
{
    public class ProcesarPagosController : Controller
    {
        private readonly IProcesarPagosUC _useCasesProcesarPagos;

        public ProcesarPagosController(IRepository<AFP> repositoryAFP,
                                        IRepository<Contrato> repositoryContrato,
                                        IRepository<Empleado> repositoryEmpleado,
                                        IRepository<BoletaPago> repositoryBoletaPago,
                                        IRepository<PeriodoPago> repositoryPeriodoPago,
                                        IRepository<ConceptosDePago> repositoryConceptosDePago,
                                        IProcesarPagosUC useCasesProcesarPagos)
        {
            _useCasesProcesarPagos = useCasesProcesarPagos;
            _useCasesProcesarPagos.Setup(repositoryAFP, repositoryContrato, repositoryEmpleado, repositoryBoletaPago, repositoryPeriodoPago, repositoryConceptosDePago);
        }

        [HttpGet]
        public IActionResult ProcesarPagos()
            => View(_useCasesProcesarPagos.ProcesarPagos());

        [HttpPost]
        public ViewResult VerificarProcesado()
            => View("ProcesarPagos", _useCasesProcesarPagos.VerificarProcesado());
    }
}
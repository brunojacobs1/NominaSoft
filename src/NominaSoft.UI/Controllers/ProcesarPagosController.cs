using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NominaSoft.Core.Entities;
using NominaSoft.Core.Interfaces;
using NominaSoft.Core.Specifications;
using NominaSoft.UI.ViewModels;

namespace NominaSoft.UI.Controllers
{
    public class ProcesarPagosController : Controller
    {
        private readonly IRepository<PeriodoPago> _repositoryPeriodoPago;

        public ProcesarPagosController(IRepository<PeriodoPago> repositoryPeriodoPago)
        {
            _repositoryPeriodoPago = repositoryPeriodoPago;
        }
        //public IActionResult ProcesarPagos()
        //{
        //    return View();
        //}

        [HttpGet]
        public IActionResult ProcesarPagos()
        {
            ViewModelProcesarPagos viewModelProcesarPagos = new ViewModelProcesarPagos();
            viewModelProcesarPagos.PeriodoPago = _repositoryPeriodoPago.Get(new BusquedaPeriodoActivoSpecification());
            return View(viewModelProcesarPagos);
        }

        [HttpPost]
        public ViewResult VerificarProcesado(ViewModelProcesarPagos viewModelProcesarPagos)
        {

            viewModelProcesarPagos.PeriodoPago = _repositoryPeriodoPago.Get(new BusquedaPeriodoActivoSpecification());
            if(viewModelProcesarPagos.PeriodoPago != null)
            {
                viewModelProcesarPagos.PeriodoPago.BoletasPago = _repositoryPeriodoPago.get(new B);
                foreach (BoletaPago BoletaPago in viewModelProcesarPagos.PeriodoPago.BoletasPago.ToList())
                {
                    if (!BoletaPago.Contrato.VerificarVigencia())
                    {
                        //necesito una lista de contratos
                    }
                }
            }

            return View("~/Views/ProcesarPagos/ProcesarPagos.cshtml",viewModelProcesarPagos);
        }

    }
}

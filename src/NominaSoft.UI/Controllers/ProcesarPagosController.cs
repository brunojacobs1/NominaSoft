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
        private readonly IRepository<Contrato> _repositoryContrato;
        private readonly IRepository<BoletaPago> _repositoryBoletaPago;
        private readonly IRepository<ConceptosDePago> _repositoryConceptoPago;

        public ProcesarPagosController(IRepository<PeriodoPago> repositoryPeriodoPago,
                                       IRepository<Contrato> repositoryContrato,
                                       IRepository<BoletaPago> repositoryBoletaPago,
                                       IRepository<ConceptosDePago> repositoryConceptoPago)
        {
            _repositoryPeriodoPago = repositoryPeriodoPago;
            _repositoryContrato = repositoryContrato;
            _repositoryBoletaPago = repositoryBoletaPago;
            _repositoryConceptoPago = repositoryConceptoPago;
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

            if (viewModelProcesarPagos.PeriodoPago == null)
                viewModelProcesarPagos.PeriodoActivo = 1;

            return View(viewModelProcesarPagos);
        }

        [HttpPost]
        public ViewResult VerificarProcesado()
        {

            ViewModelProcesarPagos viewModelProcesarPagos = new ViewModelProcesarPagos() {
                PeriodoPago = _repositoryPeriodoPago.Get(new BusquedaPeriodoActivoSpecification()),
                Contratos = _repositoryContrato.List()
            };
            //R01
            if(viewModelProcesarPagos.PeriodoPago != null)
            {
                if (DateTime.Now >= viewModelProcesarPagos.PeriodoPago.FechaFin)
                {
                    if (viewModelProcesarPagos.Contratos != null)
                    {
                        foreach (Contrato contrato in viewModelProcesarPagos.Contratos)
                        {
                            if (contrato.VerificarVigencia())
                            {
                                //ConceptosDePago conceptosDePago = _repositoryConceptoPago.Get();
                                /*ConceptosDePago conceptos = new ConceptosDePago()
                                {
                                    IdConceptosDePago = 2,
                                    MontoDeOtrosDescuentos = 0,
                                    MontoDeOtrosIngresos = 0,
                                    MontoPorAdelantos = 0,
                                    MontoPorHorasAusentes = 0,
                                    MontoPorHorasExtra = 0,
                                    MontoPorReintegro = 0
                                };*/
                                BoletaPago boletaPago = new BoletaPago()
                                {
                                    FechaPago = viewModelProcesarPagos.PeriodoPago.FechaFin,
                                    Contrato = contrato,
                                    IdPeriodoPago = viewModelProcesarPagos.PeriodoPago.IdPeriodoPago,
                                    PeriodoPago = viewModelProcesarPagos.PeriodoPago,
                                    //ConceptosDePago = conceptos
                                };
                                _repositoryBoletaPago.Add(boletaPago);
                                Planilla planilla = new Planilla()
                                {
                                    Empleado = contrato.Empleado,
                                    Contrato = contrato,
                                    TotalHoras = boletaPago.CalcularTotalHorasBoleta(),
                                    SueldoBasico = boletaPago.CalcularSueldoBasico(),
                                    TotalIngresos = boletaPago.CalcularTotalIngresos(),
                                    TotalDescuentos = boletaPago.CalcularTotalDescuentos(),
                                    SueldoNeto = boletaPago.CalcularSueldoNeto()
                                };
                                viewModelProcesarPagos.Planillas.Add(planilla);
                            }
                        }
                    }
                    else
                    {
                        viewModelProcesarPagos.ContratosVigentes = 1;
                        return View("~/Views/ProcesarPagos/ProcesarPagos.cshtml", viewModelProcesarPagos);
                    }
                }
                else
                {
                    viewModelProcesarPagos.ProcesarPagos = 1;
                    return View("~/Views/ProcesarPagos/ProcesarPagos.cshtml", viewModelProcesarPagos);
                }
            }
            else
            {
                viewModelProcesarPagos.PeriodoActivo = 1;
                return View("~/Views/ProcesarPagos/ProcesarPagos.cshtml", viewModelProcesarPagos);
            }

            return View("~/Views/ProcesarPagos/ProcesarPagos.cshtml",viewModelProcesarPagos);
        }

    }
}

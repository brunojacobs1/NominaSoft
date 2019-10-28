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
        private readonly IRepository<AFP> _repositoryAfp;
        private readonly IRepository<Empleado> _repositoryEmpleado;

        public ProcesarPagosController(IRepository<PeriodoPago> repositoryPeriodoPago,
                                       IRepository<Contrato> repositoryContrato,
                                       IRepository<BoletaPago> repositoryBoletaPago,
                                       IRepository<ConceptosDePago> repositoryConceptoPago,
                                       IRepository<AFP> repositoryAfp,
                                       IRepository<Empleado> repositoryEmpleado)
        {
            _repositoryPeriodoPago = repositoryPeriodoPago;
            _repositoryContrato = repositoryContrato;
            _repositoryBoletaPago = repositoryBoletaPago;
            _repositoryConceptoPago = repositoryConceptoPago;
            _repositoryAfp = repositoryAfp;
            _repositoryEmpleado = repositoryEmpleado;
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
                Contratos = _repositoryContrato.List(),
                Planilla = new Planilla()
                {
                    DatosPlanillas = new List<DatosPlanilla>()
                }
            };
            //R01
            if(viewModelProcesarPagos.PeriodoPago != null)
            {
                if (DateTime.Now >= viewModelProcesarPagos.PeriodoPago.FechaFin)
                {
                    if (viewModelProcesarPagos.Contratos != null)
                    {
                        BoletaPago boletaPago;
                        foreach (Contrato contrato in viewModelProcesarPagos.Contratos)
                        {
                            if (!contrato.VerificarVigencia())
                            {
                                contrato.AFP = _repositoryAfp.GetById(contrato.IdAFP);

                                contrato.Empleado = _repositoryEmpleado.GetById(contrato.IdEmpleado);
                                
                                ConceptosDePago conceptosDePago = _repositoryConceptoPago.Get(new BusquedaConceptoPagoSpecification(contrato.IdContrato, viewModelProcesarPagos.PeriodoPago.IdPeriodoPago));
                                boletaPago = viewModelProcesarPagos.Planilla.GenerarBoleta(viewModelProcesarPagos.PeriodoPago, contrato, conceptosDePago);
                                _repositoryBoletaPago.Add(boletaPago);

                                DatosPlanilla datosPlanilla = new DatosPlanilla()
                                {
                                    Empleado = contrato.Empleado,
                                    Contrato = contrato,
                                    TotalHoras = boletaPago.CalcularTotalHorasBoleta(),
                                    SueldoBasico = boletaPago.CalcularSueldoBasico(),
                                    TotalIngresos = boletaPago.CalcularTotalIngresos(),
                                    TotalDescuentos = boletaPago.CalcularTotalDescuentos(),
                                    SueldoNeto = boletaPago.CalcularSueldoNeto()
                                };
                                viewModelProcesarPagos.Planilla.DatosPlanillas.Add(datosPlanilla);
                            }
                        }
                        viewModelProcesarPagos.PagosProcesados = 1;
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

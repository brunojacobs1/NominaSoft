using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NominaSoft.Core.Entities;
using NominaSoft.Core.Interfaces;
using NominaSoft.Core.Specifications;
using NominaSoft.Core.DataTransferObjects;
using NominaSoft.Core.Holders;

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
            ProcesarPagosDTO procesarPagosDTO = new ProcesarPagosDTO
            {
                PeriodoPago = _repositoryPeriodoPago.Get(new BusquedaPeriodoActivoSpecification())
            };
            
            if (procesarPagosDTO.PeriodoPago == null)
                procesarPagosDTO.PeriodoActivo = 1;
                
            return View(procesarPagosDTO);
        }

        [HttpPost]
        public ViewResult VerificarProcesado()
        {
            IEnumerable<ConceptosDePago> conceptosDePagos;

            ICollection<Contrato> contratos = new List<Contrato>();

            ProcesarPagosDTO procesarPagosDTO = new ProcesarPagosDTO() {
                PeriodoPago = _repositoryPeriodoPago.Get(new BusquedaPeriodoActivoSpecification()),
                Planilla = new Planilla()
                {
                    DatosPlanillas = new List<DatosPlanilla>()
                }
            };

            if(procesarPagosDTO.PeriodoPago != null)
            {
                conceptosDePagos = _repositoryConceptoPago.List(new BusquedaConceptosPeriodoActivoSpecification());

                foreach (ConceptosDePago concepto in conceptosDePagos)
                {
                    contratos.Add(concepto.Contrato);
                }
                procesarPagosDTO.Contratos = contratos;

                if (DateTime.Now >= procesarPagosDTO.PeriodoPago.FechaFin)
                {
                    if (procesarPagosDTO.Contratos.Count() != 0)
                    {   
                        BoletaPago boletaPago;
                        foreach (Contrato contrato in procesarPagosDTO.Contratos)
                        {
                            if (contrato.VerificarVigencia())
                            {
                                contrato.AFP = _repositoryAfp.GetById(contrato.AFP.IdAFP);

                                contrato.Empleado = _repositoryEmpleado.GetById(contrato.Empleado.IdEmpleado);
                                
                                ConceptosDePago conceptosDePago = _repositoryConceptoPago.Get(new BusquedaConceptoPagoSpecification(contrato.IdContrato, procesarPagosDTO.PeriodoPago.IdPeriodoPago));
                                boletaPago = procesarPagosDTO.Planilla.GenerarBoleta(procesarPagosDTO.PeriodoPago, contrato, conceptosDePago);
                                _repositoryBoletaPago.Add(boletaPago);

                                DatosPlanilla datosPlanilla = new DatosPlanilla(contrato, boletaPago);
                                
                                procesarPagosDTO.Planilla.DatosPlanillas.Add(datosPlanilla);
                            }
                        }
                        procesarPagosDTO.PagosProcesados = 1;
                    }
                    else
                    {
                        procesarPagosDTO.ContratosVigentes = 1;
                        return View("~/Views/ProcesarPagos/ProcesarPagos.cshtml", procesarPagosDTO);
                    }
                }
                else
                {
                    procesarPagosDTO.ProcesarPagos = 1;
                    return View("~/Views/ProcesarPagos/ProcesarPagos.cshtml", procesarPagosDTO);
                }
            }
            else
            {
                procesarPagosDTO.PeriodoActivo = 1;
                return View("~/Views/ProcesarPagos/ProcesarPagos.cshtml", procesarPagosDTO);
            }
            return View("~/Views/ProcesarPagos/ProcesarPagos.cshtml",procesarPagosDTO);
        }
    }
}

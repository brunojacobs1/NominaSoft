using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NominaSoft.Core.Entities;
using NominaSoft.Core.Interfaces;
using NominaSoft.Core.UseCases;
using NominaSoft.Core.Specifications;
using NominaSoft.UI.ViewModels;

namespace NominaSoft.UI.Controllers
{
    public class GestionarContratoController : Controller
    {
        private readonly GestionarContratoUseCases _useCasesGestionarContrato;

        public GestionarContratoController(GestionarContratoUseCases useCasesGestionarContrato)
        {
            _useCasesGestionarContrato = useCasesGestionarContrato;
        }

        [Route("GestionarContrato")]
        [HttpGet]
        public IActionResult GestionarContrato() => View(new ViewModelGestionarContrato());

        [Route("GestionarContrato/Empleado")]
        [HttpGet]
        public IActionResult BuscarEmpleado(String dni)
        {
            try
            {
                ViewModelGestionarContrato viewModelGestionarContrato = new ViewModelGestionarContrato
                {
                    Empleado = _useCasesGestionarContrato._repositoryEmpleado.Get(new BusquedaPorDniSpecification(dni)),
                    Contratos = _useCasesGestionarContrato._repositoryContrato.List(new BusquedaContratosSpecification(dni))
                };

                if (viewModelGestionarContrato.Empleado != null)
                {
                    viewModelGestionarContrato.AFPs = _useCasesGestionarContrato._repositoryAFP.List();
                    viewModelGestionarContrato.Contrato = _useCasesGestionarContrato.RetornarContratoVigente(viewModelGestionarContrato.Contratos);
                }
                else
                    viewModelGestionarContrato.EmpleadoNoEncontrado = 1;

                return View("~/Views/GestionarContrato/GestionarContrato.cshtml", viewModelGestionarContrato);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public IActionResult CrearContrato(ViewModelGestionarContrato viewModelGestionarContrato, int empleadoId)
        {
            try
            {
                Contrato contrato = new Contrato()
                {
                    Empleado = _useCasesGestionarContrato._repositoryEmpleado.GetById(empleadoId),
                    FechaInicio = viewModelGestionarContrato.Contrato.FechaInicio,
                    FechaFin = viewModelGestionarContrato.Contrato.FechaFin,
                    Cargo = viewModelGestionarContrato.Contrato.Cargo,
                    EsAsignacionFamiliar = viewModelGestionarContrato.Contrato.EsAsignacionFamiliar,
                    ValorHora = viewModelGestionarContrato.Contrato.ValorHora,
                    TotalHorasSemanales = viewModelGestionarContrato.Contrato.TotalHorasSemanales,
                    EsAnulado = false,
                    AFP = _useCasesGestionarContrato.RetornarAFPValida(viewModelGestionarContrato.Contrato.AFP.IdAFP)
                };

                viewModelGestionarContrato = new ViewModelGestionarContrato();

                viewModelGestionarContrato.MensajeError += _useCasesGestionarContrato.RetornarMensajeError(contrato, empleadoId);

                if (!String.IsNullOrEmpty(viewModelGestionarContrato.MensajeError))
                {
                    viewModelGestionarContrato.ErrorDatosContrato = 1;
                    return View("~/Views/GestionarContrato/GestionarContrato.cshtml", viewModelGestionarContrato);
                }

                _useCasesGestionarContrato._repositoryContrato.Add(contrato);
                return View("~/Views/GestionarContrato/GestionarContrato.cshtml", new ViewModelGestionarContrato{ ContratoCreado = 1 });
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        [HttpPost]   
        public IActionResult CrearNuevoContrato(int empleadoId,
                                                    DateTime fechaInicio,
                                                    DateTime fechaFin,
                                                    string cargo,
                                                    int afp,
                                                    bool asignacionFamiliar,
                                                    int valorHora,
                                                    int totalHoras)
        {
            try
            {
                ViewModelGestionarContrato viewModelGestionarContrato;

                Contrato contrato = new Contrato()
                {
                    Empleado = _useCasesGestionarContrato._repositoryEmpleado.GetById(empleadoId),
                    FechaInicio = fechaInicio,
                    FechaFin = fechaFin,
                    Cargo = cargo,
                    EsAsignacionFamiliar = asignacionFamiliar,
                    ValorHora = valorHora,
                    TotalHorasSemanales = totalHoras,
                    EsAnulado = false,
                    AFP = _useCasesGestionarContrato._repositoryAFP.GetById(afp)
                };

                viewModelGestionarContrato = new ViewModelGestionarContrato();

                viewModelGestionarContrato.MensajeError += _useCasesGestionarContrato.RetornarMensajeError(contrato, empleadoId);

                if (!String.IsNullOrEmpty(viewModelGestionarContrato.MensajeError))
                {
                    viewModelGestionarContrato.ErrorDatosContrato = 1;
                    return View("~/Views/GestionarContrato/GestionarContrato.cshtml", viewModelGestionarContrato);
                }

                _useCasesGestionarContrato._repositoryContrato.Add(contrato);
                return View("~/Views/GestionarContrato/GestionarContrato.cshtml", new ViewModelGestionarContrato { ContratoCreado = 1 });
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public IActionResult EditarContrato(ViewModelGestionarContrato viewModelGestionarContrato, int contratoId, int empleadoId)
        {
            try
            {
                Contrato contrato;
                viewModelGestionarContrato.Contrato.Empleado = _useCasesGestionarContrato._repositoryEmpleado.GetById(empleadoId);

                viewModelGestionarContrato.MensajeError += _useCasesGestionarContrato.RetornarMensajeError(viewModelGestionarContrato.Contrato, empleadoId);

                if (!String.IsNullOrEmpty(viewModelGestionarContrato.MensajeError))
                {
                    viewModelGestionarContrato.ErrorDatosContrato = 1;
                    viewModelGestionarContrato.Contrato = null;
                    return View("~/Views/GestionarContrato/GestionarContrato.cshtml", viewModelGestionarContrato);
                }

                contrato = _useCasesGestionarContrato._repositoryContrato.GetById(contratoId);
                contrato.FechaInicio = viewModelGestionarContrato.Contrato.FechaInicio;
                contrato.FechaFin = viewModelGestionarContrato.Contrato.FechaFin;
                contrato.Cargo = viewModelGestionarContrato.Contrato.Cargo;
                contrato.AFP = _useCasesGestionarContrato._repositoryAFP.GetById(viewModelGestionarContrato.Contrato.AFP.IdAFP);
                contrato.EsAsignacionFamiliar = viewModelGestionarContrato.Contrato.EsAsignacionFamiliar;
                contrato.ValorHora = viewModelGestionarContrato.Contrato.ValorHora;
                contrato.TotalHorasSemanales = viewModelGestionarContrato.Contrato.TotalHorasSemanales;

                _useCasesGestionarContrato._repositoryContrato.Edit(contrato);

                return View("~/Views/GestionarContrato/GestionarContrato.cshtml", new ViewModelGestionarContrato { ModificacionesContrato = 1 });
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public IActionResult AnularContrato(int contratoId)
        {
            try
            {
                Contrato contrato = _useCasesGestionarContrato._repositoryContrato.GetById(contratoId);
                contrato.EsAnulado = true;
                _useCasesGestionarContrato._repositoryContrato.Edit(contrato);

                return View("~/Views/GestionarContrato/GestionarContrato.cshtml", new ViewModelGestionarContrato { ContratoAnulado = 1 });
            }
            catch(Exception e)
            {
                throw e;
            } 
        }
    }
}

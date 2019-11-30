using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NominaSoft.Core.Entities;
using NominaSoft.Core.Interfaces;
using NominaSoft.Core.Specifications;
using NominaSoft.Core.DataTransferObjects;
using NominaSoft.Infraestructure.UseCases;

namespace NominaSoft.UI.Controllers
{
    public class GestionarContratoController : Controller
    {
        private readonly GestionarContratoUC _useCasesGestionarContrato = new GestionarContratoUC();

        public GestionarContratoController(IRepository<Empleado> repositoryEmpleado,
                                        IRepository<AFP> repositoryAFP,
                                        IRepository<Contrato> repositoryContrato)
        {
            _useCasesGestionarContrato.Setup(repositoryEmpleado, repositoryAFP, repositoryContrato);
        }
    

        [Route("GestionarContrato")]
        [HttpGet]
        public IActionResult GestionarContrato() => View(new GestionarContratoDTO());

        [Route("GestionarContrato/Empleado")]
        [HttpGet]
        public IActionResult BuscarEmpleado(String dni)
        {
            return View("~/Views/GestionarContrato/GestionarContrato.cshtml", _useCasesGestionarContrato.BuscarEmpleado(dni));
        }

        [HttpPost]
        public IActionResult CrearContrato(GestionarContratoDTO gestionarContratoDTO, int empleadoId)
        {
            return View("~/Views/GestionarContrato/GestionarContrato.cshtml", _useCasesGestionarContrato.CrearContrato(gestionarContratoDTO, empleadoId));
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
                GestionarContratoDTO gestionarContratoDTO;

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

                gestionarContratoDTO = new GestionarContratoDTO();

                gestionarContratoDTO.MensajeError += _useCasesGestionarContrato.RetornarMensajeError(contrato, empleadoId);

                if (!String.IsNullOrEmpty(gestionarContratoDTO.MensajeError))
                {
                    gestionarContratoDTO.ErrorDatosContrato = 1;
                    return View("~/Views/GestionarContrato/GestionarContrato.cshtml", gestionarContratoDTO);
                }

                _useCasesGestionarContrato._repositoryContrato.Add(contrato);
                return View("~/Views/GestionarContrato/GestionarContrato.cshtml", new GestionarContratoDTO { ContratoCreado = 1 });
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public IActionResult EditarContrato(GestionarContratoDTO gestionarContratoDTO, int contratoId, int empleadoId)
        {
            try
            {
                Contrato contrato;
                gestionarContratoDTO.Contrato.Empleado = _useCasesGestionarContrato._repositoryEmpleado.GetById(empleadoId);

                gestionarContratoDTO.MensajeError += _useCasesGestionarContrato.RetornarMensajeError(gestionarContratoDTO.Contrato, empleadoId);

                if (!String.IsNullOrEmpty(gestionarContratoDTO.MensajeError))
                {
                    gestionarContratoDTO.ErrorDatosContrato = 1;
                    gestionarContratoDTO.Contrato = null;
                    return View("~/Views/GestionarContrato/GestionarContrato.cshtml", gestionarContratoDTO);
                }

                contrato = _useCasesGestionarContrato._repositoryContrato.GetById(contratoId);
                contrato.FechaInicio = gestionarContratoDTO.Contrato.FechaInicio;
                contrato.FechaFin = gestionarContratoDTO.Contrato.FechaFin;
                contrato.Cargo = gestionarContratoDTO.Contrato.Cargo;
                contrato.AFP = _useCasesGestionarContrato._repositoryAFP.GetById(gestionarContratoDTO.Contrato.AFP.IdAFP);
                contrato.EsAsignacionFamiliar = gestionarContratoDTO.Contrato.EsAsignacionFamiliar;
                contrato.ValorHora = gestionarContratoDTO.Contrato.ValorHora;
                contrato.TotalHorasSemanales = gestionarContratoDTO.Contrato.TotalHorasSemanales;

                _useCasesGestionarContrato._repositoryContrato.Edit(contrato);

                return View("~/Views/GestionarContrato/GestionarContrato.cshtml", new GestionarContratoDTO { ModificacionesContrato = 1 });
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

                return View("~/Views/GestionarContrato/GestionarContrato.cshtml", new GestionarContratoDTO { ContratoAnulado = 1 });
            }
            catch(Exception e)
            {
                throw e;
            } 
        }
    }
}

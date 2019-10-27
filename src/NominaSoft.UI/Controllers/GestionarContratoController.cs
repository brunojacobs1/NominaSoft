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
    public class GestionarContratoController : Controller
    {
        private readonly IRepository<Empleado> _repositoryEmpleado;
        private readonly IRepository<AFP> _repositoryAFP;
        private readonly IRepository<Contrato> _repositoryContrato;

        public GestionarContratoController(IRepository<Empleado> repositoryEmpleado,
                                            IRepository<AFP> repositoryAFP,
                                            IRepository<Contrato> repositoryContrato)
        {
            _repositoryEmpleado = repositoryEmpleado;
            _repositoryAFP = repositoryAFP;
            _repositoryContrato = repositoryContrato;
        }

        //public String Index()
        //{
            //return _repositoryEmpleado.GetById(1).NombreEmpleado;
        //}

        [HttpGet]
        public IActionResult GestionarContrato()
        {
            ViewModelGestionarContrato viewModelGestionarContrato = new ViewModelGestionarContrato();

            return View(viewModelGestionarContrato);
        }

        [HttpGet]
        public IActionResult BuscarEmpleado(String dni)
        {
            ViewModelGestionarContrato viewModelGestionarContrato = new ViewModelGestionarContrato
            {
                Empleado = _repositoryEmpleado.Get(new BusquedaPorDniSpecification(dni)),
                AFPs = _repositoryAFP.List()
            };
            
            if (viewModelGestionarContrato.Empleado != null)
            {
                foreach (Contrato contrato in viewModelGestionarContrato.Empleado.Contratos.ToList())
                {
                    if (!contrato.VerificarVigencia())
                        viewModelGestionarContrato.Empleado.Contratos.Remove(contrato);
                }
            }
            else
            {
                viewModelGestionarContrato.EmpleadoNoEncontrado = 1;
            }

            return View("~/Views/GestionarContrato/GestionarContrato.cshtml", viewModelGestionarContrato);
        }
        
        [HttpPost]
        public IActionResult CrearContrato(ViewModelGestionarContrato viewModelGestionarContrato, int empleadoId)
        {

            Contrato contrato = new Contrato()
            {
                Empleado = _repositoryEmpleado.GetById(empleadoId),
                FechaInicio = viewModelGestionarContrato.Contrato.FechaInicio,
                FechaFin = viewModelGestionarContrato.Contrato.FechaFin,
                Cargo = viewModelGestionarContrato.Contrato.Cargo,
                AFP = _repositoryAFP.GetById(viewModelGestionarContrato.Contrato.IdAFP),
                EsAsignacionFamiliar = viewModelGestionarContrato.Contrato.EsAsignacionFamiliar,
                ValorHora = viewModelGestionarContrato.Contrato.ValorHora,
                TotalHorasSemanales = viewModelGestionarContrato.Contrato.TotalHorasSemanales,
                EsAnulado = false
            };

            viewModelGestionarContrato = new ViewModelGestionarContrato();

            // LA R02 NO SE APLICA YA QUE SI ES QUE ES LO MISMO QUE DECIR
            // MIENTRAS SE ENCUENTRA CON UN CONTRATO VIGENTE (AUN NO HA TERMINADO O NO ESTA ANULADO)
            // NO SE PUEDE CREAR NINGUN CONTRATO, Y ESO YA SE ESTA HACIENDO IMPLICITAMENTE

            // R03
            if (!contrato.VerificarFechaFin())
            {
                viewModelGestionarContrato.MensajeError = "La fecha fin es incorrecta.";
            }

            // R04
            if(!contrato.VerificarTotalHorasSemanales())
            {
                viewModelGestionarContrato.MensajeError += "El total de horas semanales es incorrecto.";
            }

            // R05
            if (!contrato.VerificarValorHora())
            {
                viewModelGestionarContrato.MensajeError += "El valor por hora es incorrecto.";
            }

            if(!String.IsNullOrEmpty(viewModelGestionarContrato.MensajeError))
            {
                viewModelGestionarContrato.ErrorDatosContrato = 1;
                return View("~/Views/GestionarContrato/GestionarContrato.cshtml", viewModelGestionarContrato);
            }

            _repositoryContrato.Add(contrato);

            viewModelGestionarContrato.ContratoCreado = 1;

            return View("~/Views/GestionarContrato/GestionarContrato.cshtml", viewModelGestionarContrato);
        }
        
    }
}

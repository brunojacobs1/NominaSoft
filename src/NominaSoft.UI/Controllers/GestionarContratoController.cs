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
                Habilitado = true,
                EsAnulado = false
            };

            _repositoryContrato.Add(contrato);

            viewModelGestionarContrato = new ViewModelGestionarContrato
            {
                ContratoCreado = 1
            };

            return View("~/Views/GestionarContrato/GestionarContrato.cshtml", viewModelGestionarContrato);
        }
        
    }
}

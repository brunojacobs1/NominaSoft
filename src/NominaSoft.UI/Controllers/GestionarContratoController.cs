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

        public GestionarContratoController(IRepository<Empleado> repositoryEmpleado)
        {
            _repositoryEmpleado = repositoryEmpleado;
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

        [HttpPost]
        public IActionResult BuscarEmpleado(String dni)
        {
            ViewModelGestionarContrato viewModelGestionarContrato = new ViewModelGestionarContrato
            {
                Empleado = _repositoryEmpleado.Get(new BusquedaPorDniSpecification(dni))
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
        /*
        [HttpGet]
        public IActionResult CrearContrato(ViewModelGestionarContrato viewModelGestionarContrato)
        {

        }
        */
    }
}

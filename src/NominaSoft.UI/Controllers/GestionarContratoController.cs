using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NominaSoft.Core.Entities;
using NominaSoft.Core.Interfaces;
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
            //ViewModelGestionarContrato viewModelGestionarContrato = new ViewModelGestionarContrato();

            return View(/*viewModelGestionarContrato*/);
        }

        [HttpGet]
        public IActionResult BuscarEmpleado(int search)
        {
            ViewModelGestionarContrato viewModelGestionarContrato = new ViewModelGestionarContrato
            {
                Empleado = _repositoryEmpleado.GetById(search)
            };

            return View("~/Views/GestionarContrato/GestionarContrato.cshtml", viewModelGestionarContrato);
        }

    }
}

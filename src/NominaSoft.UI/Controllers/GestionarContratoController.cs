using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NominaSoft.Core.Entities;
using NominaSoft.Core.Interfaces;

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

        public IActionResult GestionarContrato()
        {
            return View();
        }
    }
}

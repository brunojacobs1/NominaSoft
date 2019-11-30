﻿using System;
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
            return View("~/Views/GestionarContrato/GestionarContrato.cshtml", _useCasesGestionarContrato.CrearNuevoContrato(empleadoId, fechaInicio, fechaFin, cargo, afp, asignacionFamiliar, valorHora, totalHoras));
        }

        [HttpPost]
        public IActionResult EditarContrato(GestionarContratoDTO gestionarContratoDTO, int contratoId, int empleadoId)
        {
            return View("~/Views/GestionarContrato/GestionarContrato.cshtml", _useCasesGestionarContrato.EditarContrato(gestionarContratoDTO, contratoId, empleadoId));
        }

        [HttpPost]
        public IActionResult AnularContrato(int contratoId)
        {
            return View("~/Views/GestionarContrato/GestionarContrato.cshtml", _useCasesGestionarContrato.AnularContrato(contratoId));
        }
    }
}

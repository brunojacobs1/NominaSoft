﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NominaSoft.UI.Controllers
{
    public class ProcesarPagosController : Controller
    {
        public IActionResult ProcesarPagos()
        {
            return View();
        }
    }
}

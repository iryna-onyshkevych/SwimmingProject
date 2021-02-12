using ADO.BL.Interfaces;
using ADO.BL.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwimmingWebApp.Controllers
{
    public class SwimStylesController : Controller
    {
        private readonly ISwimStyleService service;
        public SwimStylesController(ISwimStyleService r)
        {
            service = r;
        }

        public IActionResult Index()
        {
            var swimStyles = service.SelectSwimStyles();

            return View(swimStyles);
        }

      
    }
}

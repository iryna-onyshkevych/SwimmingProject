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
        public IActionResult Index()
        {
            SwimStyleService swimStyleService = new SwimStyleService();
            var swimStyles = swimStyleService.SelectSwimStyles();

            return View(swimStyles);
        }

      
    }
}

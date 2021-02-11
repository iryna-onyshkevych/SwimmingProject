using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwimmingWebApp.Controllers
{
    public class TrysController : Controller
    {

        public IActionResult Index()
        {
            ViewData["Message"] = "Hello!";
            return View("Index");
        }
    }
}

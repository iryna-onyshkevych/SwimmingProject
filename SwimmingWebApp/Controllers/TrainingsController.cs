using ADO.BL.Interfaces;
using ADO.BL.Services;
using DTO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace SwimmingWebApp.Controllers
{
    public class TrainingsController : Controller
    {
        private readonly ITrainingViewService service;
        public TrainingsController(ITrainingViewService r)
        {
            service = r;
        }
      

        [HttpGet]
        public IActionResult Index(int page = 1)
        {
            var customers = service.GetTrainings(page);

            return View(customers);
        }

    
    }
}

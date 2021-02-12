using ADO.BL.Interfaces;
using DTO.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwimmingWebApp.Controllers
{
    public class SwimmerTrainingsController : Controller
    {
        private readonly ITrainingService service;
        public SwimmerTrainingsController(ITrainingService r)
        {
            service = r;
        }
                
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TrainingDTO training)
        {
            try
            {
                service.AddTraining(training);
            }
            catch (Exception ex)
            {
                return Content("\tERROR!\n\n" + ex.Message);
            }

            return RedirectToAction("Index", "Trainings");
        }
        
      

    }
}

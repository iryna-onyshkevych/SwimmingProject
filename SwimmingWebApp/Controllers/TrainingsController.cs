using ADO.BL.Services;
using DTO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace SwimmingWebApp.Controllers
{
    public class TrainingsController : Controller
    {
        //private readonly TrainingViewService repo;
        //public TrainingsController(TrainingViewService r)
        //{
        //    repo = r;
        //}
        [HttpGet]
        public ActionResult Index()
        {
            ViewData["Head"] = "Trainings";
            TrainingViewService trainingService = new TrainingViewService();

            var trainings = trainingService.SelectSwimmersTrainings();
            return View(trainings); 


        }


        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TrainingDTO training)
        {
            TrainingService trainingService = new TrainingService();
            try
            {
                trainingService.AddTraining(training);
            }
            catch (Exception ex)
            {
                return Content("\tERROR!\n\n" + ex.Message);
            }

            return RedirectToAction("Index");
        }
    }
}

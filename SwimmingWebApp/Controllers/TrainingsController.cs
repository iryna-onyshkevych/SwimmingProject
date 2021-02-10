using ADO.BL.Services;
using DTO.Models;
using Microsoft.AspNetCore.Mvc;

namespace SwimmingWebApp.Controllers
{
    public class TrainingsController : Controller
    {
        public IActionResult Index()
        {
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
            trainingService.AddTraining(training);

            return RedirectToAction("Index");
        }
    }
}

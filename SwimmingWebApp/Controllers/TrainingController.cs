using ADO.BL.Interfaces;
using ADO.BL.Services;
using DTO.Models;
using Microsoft.AspNetCore.Mvc;

namespace SwimmingWebApp.Controllers
{
    public class TrainingController : Controller
    {
        private readonly ITrainingViewService service;

        public TrainingController(ITrainingViewService r)
        {
            service = r;
        }
      
        [HttpGet]
        public IActionResult Index(int page = 1)
        {
            var customers = service.GetTrainings(page);
            return View(customers);
        }

        public IActionResult Details(int id)
        {
            if (id != null)
            {
                var training = service.GetViewTraining(id);
                return View(training);
            }
            return NotFound();
        }
    }
}

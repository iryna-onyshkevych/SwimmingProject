using ADO.BL.Interfaces;
using ADO.BL.Services;
using DTO.Models;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

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
        public IActionResult Index(int? page)
        {
            var trainings = service.SelectSwimmersTrainings(); 
            var pageNumber = page ?? 1; 
            var onePageOfTrainings = trainings.ToPagedList(pageNumber, 4); 
            ViewBag.OnePageOfTrainings = onePageOfTrainings;
            return View();
        }
        
        public IActionResult Details(int id)
        {
            var training = service.GetViewTraining(id);
            return View(training);
        }
    }
}

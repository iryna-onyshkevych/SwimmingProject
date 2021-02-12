using ADO.BL.Interfaces;
using ADO.BL.Services;
using DTO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SwimmingWebApp.ViewModels;
using System;
using System.Linq;



namespace SwimmingWebApp.Controllers
{
    public class CoachesController : Controller
    {
        //public IConfiguration Configuration { get; }

        //public CoachesController(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}
        ICoachService service;
        public CoachesController(ICoachService r)
        {
            service = r;
        }
        [HttpGet]
        public IActionResult Index(int page = 1)
        {
            var customers = service.GetCoaches(page);

            return View(customers);
        }


      
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CoachDTO coach)
        {
            //service.AddCoach(coach);
            //CoachService coachService = new CoachService();
            try
            {
                service.AddCoach(coach);

            }
            catch (Exception ex)
            {

                return Content("\tERROR!\n\n" + ex.Message);
            }

            return RedirectToAction("Coaches","Index");
        }
        public IActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Update(CoachDTO coach)
        {
            CoachService coachService = new CoachService();
            try
            {
                coachService.UpdateCoach(coach);
            }
            catch (Exception ex)
            {
                return Content("\tERROR!\n\n" + ex.Message);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Delete(int id)
        {

            CoachService coachService = new CoachService();
            try
            {
                coachService.DeleteCoach(id);
            }
            catch (Exception ex)
            {
                return Content("\tERROR!\n\n" + ex.Message);
            }

            return RedirectToAction("Index");
        }
    }
}

using ADO.BL.Interfaces;
using DTO.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace SwimmingWebApp.Controllers
{
    public class CoachController : Controller
    {
        ICoachService service;

        public CoachController(ICoachService r)
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
            try
            {
                service.AddCoach(coach);
            }
            catch (Exception ex)
            {
                return Content("\tERROR!\n\n" + ex.Message);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update(CoachDTO coach)
        {
            try
            {
                service.UpdateCoach(coach);
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
            try
            {
                service.DeleteCoach(id);
            }
            catch (Exception ex)
            {
                return Content("\tERROR!\n\n" + ex.Message);
            }

            return RedirectToAction("Index");
        }
    }
}

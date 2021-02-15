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
        public IActionResult Details(int id)
        {
            if (id != null)
            {
                var coach = service.GetCoach(id);

                return View(coach);
            }
            return NotFound();
        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            if (id != null)
            {

                var coach = service.GetCoach(id);

                return View(coach);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult DeleteCoach(int id)
        {
            if (id != null)
            {
                service.DeleteCoach(id);

                return RedirectToAction("Index");

            }
            return NotFound();
        }
        public IActionResult Edit(int id)
        {
            if (id != null)
            {
                CoachDTO coach = service.GetCoach(id);
                return View(coach);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(CoachDTO coach)
        {
            service.UpdateCoach(coach);
            return RedirectToAction("Index");
        }
    }
}

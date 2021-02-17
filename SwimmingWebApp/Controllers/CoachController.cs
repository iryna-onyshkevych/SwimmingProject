using ADO.BL.Interfaces;
using DTO.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using X.PagedList;

namespace SwimmingWebApp.Controllers
{
    public class CoachController : Controller
    {
        ICoachService service;

        public CoachController(ICoachService _service)
        {
            service = _service;
        }

        [HttpGet]
        public IActionResult Index(int? page)
        {
            var coaches = service.SelectCoaches(); 
            var pageNumber = page ?? 1; 
            var onePageOfCoaches = coaches.ToPagedList(pageNumber, 4); 
            ViewBag.OnePageOfCoaches = onePageOfCoaches;
            return View();
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
            catch
            {
                return Content("\tERROR!\n\n\n Entered data is invalid!\n");
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
            catch 
            {
                return Content("\tERROR!\n\n\n Entered data is invalid! \n");
            }
            return RedirectToAction("Index");
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
                return Content("\tERROR!\n\n ",ex.Message);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var coach = service.GetCoach(id);
            return View(coach);
        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            var coach = service.GetCoach(id);
            return PartialView(coach);
        }

        public IActionResult Edit(int id)
        {
            CoachDTO coach = service.GetCoach(id);
            return View(coach);
        }

        [HttpPost]
        public IActionResult Edit(CoachDTO coach)
        {
            try
            {
                service.UpdateCoach(coach);
            }
            catch
            {
                return Content($"\tERROR!\n\n\n Entered data is invalid! Can't edit {coach.FirstName} {coach.LastName} \n");
            }
            return RedirectToAction("Index");
        }
    }
}

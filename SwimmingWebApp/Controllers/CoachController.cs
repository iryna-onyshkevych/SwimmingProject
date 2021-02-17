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

        public CoachController(ICoachService r)
        {
            service = r;
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
            service.UpdateCoach(coach);
            return RedirectToAction("Index");
        }
    }
}

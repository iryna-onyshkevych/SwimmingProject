using ADO.BL.Interfaces;
using DTO.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using X.PagedList;

namespace SwimmingWebApp.Controllers
{
    public class SwimmerController : Controller
    {
        private readonly ISwimmerService service;

        public SwimmerController(ISwimmerService r)
        {
            service = r;
        }
        
        [HttpGet]
        public IActionResult Index(int? page)
        {
            var swimmers = service.SelectSwimmers();
            var pageNumber = page ?? 1; 
            var onePageOfSwimmers = swimmers.ToPagedList(pageNumber, 4);
            ViewBag.OnePageOfSwimmers = onePageOfSwimmers;
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SwimmerDTO swimmer)
        {
            try
            {
                service.AddSwimmer(swimmer);
            }
            catch ( Exception ex)
            {
                throw new InvalidOperationException("\tERROR!\n\n" + ex.Message);
            }
         
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                service.DeleteSwimmer(id);
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
        public IActionResult Update(SwimmerDTO swimmer)
        {
            try
            {
                service.UpdateSwimmer(swimmer);
            }
            catch (Exception ex)
            {
                return Content("\tERROR!\n\n" + ex.Message);
            }

            return RedirectToAction("Index");
        }
        
        public IActionResult Details(int id)
        {
            var swimmer = service.GetSwimmer(id);
            return View(swimmer);
        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            var swimmer = service.GetSwimmer(id);
            return PartialView(swimmer);
        }

       
        public IActionResult Edit(int id)
        {
            SwimmerDTO swimmer = service.GetSwimmer(id);
            return View(swimmer);
        }

        [HttpPost]
        public IActionResult Edit(SwimmerDTO swimmer)
        {
            service.UpdateSwimmer(swimmer);
            return RedirectToAction("Index");
        }
    }
}

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
            var products = service.SelectSwimmers(); //returns IQueryable<Product> representing an unknown number of products. a thousand maybe?

            var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
            var onePageOfProducts = products.ToPagedList(pageNumber, 4); // will only contain 25 products max because of the pageSize

            ViewBag.OnePageOfProducts = onePageOfProducts;
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
       
        public IActionResult Delete()
        {
            return View();
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
            if (id != null)
            {
                var swimmer = service.GetSwimmer(id);

                return View(swimmer);
            }
            return NotFound();
        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            if (id != null)
            {

                var swimmer = service.GetSwimmer(id);

                return PartialView(swimmer);
            }
            return NotFound();
        }

       
        public IActionResult Edit(int id)
        {
            if (id != null)
            {
                SwimmerDTO swimmer = service.GetSwimmer(id);
                return View(swimmer);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(SwimmerDTO swimmer)
        {
            service.UpdateSwimmer(swimmer);
            return RedirectToAction("Index");
        }
    }
}

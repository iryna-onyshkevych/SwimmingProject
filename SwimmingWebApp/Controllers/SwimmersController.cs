using ADO.BL.Interfaces;
//using ADO.BL.Services;
using DTO.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace SwimmingWebApp.Controllers
{
    public class SwimmersController : Controller
    {
        private readonly ISwimmerService service;
        public SwimmersController(ISwimmerService r)
        {
            service = r;
        }

       
        [HttpGet]
        public IActionResult Index(int page = 1)
        {
            var customers = service.GetSwimmers(page);

            return View(customers);
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
    }
}

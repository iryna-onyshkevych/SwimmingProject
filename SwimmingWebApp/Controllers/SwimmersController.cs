using ADO.BL.Interfaces;
using ADO.BL.Services;
using DTO.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace SwimmingWebApp.Controllers
{
    public class SwimmersController : Controller
    {

        ISwimmerService service;
        public SwimmersController(ISwimmerService r)
        {
            service = r;
        }
        public ViewResult Index()
        {
            //SwimmerService swimmerService = new SwimmerService();
            var swimmers = service.SelectSwimmers();

            return View(swimmers);


        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(SwimmerDTO swimmer)
        {
            SwimmerService swimmerService = new SwimmerService();
            try
            {
                swimmerService.AddSwimmer(swimmer);
            }
            catch ( Exception ex)
            {
                return Content ("\tERROR!\n\n" + ex.Message) ;
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

            SwimmerService swimmerService = new SwimmerService();
            try
            {
                swimmerService.DeleteSwimmer(id);
            }
            catch (Exception ex)
            {
                return Content("\tERROR!\n\n" + ex.Message);
            }

            return RedirectToAction("Index");
        }
    }
}

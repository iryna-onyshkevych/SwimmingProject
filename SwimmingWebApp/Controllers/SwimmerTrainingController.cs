using ADO.BL.Interfaces;
using DTO.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace SwimmingWebApp.Controllers
{
    public class SwimmerTrainingController : Controller
    {
        private readonly ITrainingService service;

        public SwimmerTrainingController(ITrainingService r)
        {
            service = r;
        }
                
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TrainingDTO training)
        {
            try
            {
                service.AddTraining(training);
            }
            catch (Exception ex)
            {
                return Content("\tERROR!\n\n" + ex.Message);
            }

            return RedirectToAction("Index", "Training");
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
                service.DeleteTraining(id);
            }
            catch (Exception ex)
            {
                return Content("\tERROR!\n\n" + ex.Message);
            }

            return RedirectToAction("Index", "Training");
        }
        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update(TrainingDTO training)
        {
            try
            {
                service.UpdateTraining(training);
            }
            catch (Exception ex)
            {
                return Content("\tERROR!\n\n" + ex.Message);
            }

            return RedirectToAction("Index", "Training");
        }
        //public IActionResult Details(int id)
        //{
        //    if (id != null)
        //    {
        //        var training = service.GetTraining(id);

        //        return View(training);
        //    }
        //    return NotFound();
        //}

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            if (id != null)
            {

                var training = service.GetTraining(id);

                return View(training);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult DeleteTraining(int id)
        {
            if (id != null)
            {
                service.DeleteTraining(id);

                return RedirectToAction("Index");

            }
            return NotFound();
        }
        public IActionResult Edit(int id)
        {
            if (id != null)
            {
                TrainingDTO training = service.GetTraining(id);
                return View(training);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(TrainingDTO training)
        {
            service.UpdateTraining(training);
            return RedirectToAction("Index", "Training");

        }
    }
}

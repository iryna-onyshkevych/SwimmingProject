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

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            var training = service.GetTraining(id);
            return PartialView(training);
        }

        public IActionResult Edit(int id)
        {
            TrainingDTO training = service.GetTraining(id);
            return View(training);
        }

        [HttpPost]
        public IActionResult Edit(TrainingDTO training)
        {
            service.UpdateTraining(training);
            return RedirectToAction("Index", "Training");
        }
    }
}

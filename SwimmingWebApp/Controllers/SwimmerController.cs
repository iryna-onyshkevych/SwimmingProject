﻿using ADO.BL.Interfaces;
using DTO.Models;
using Microsoft.AspNetCore.Mvc;
using System;

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
    }
}
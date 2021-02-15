using ADO.BL.Interfaces;
using ADO.BL.Services;
using DTO.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwimmingWebApp.Controllers
{
    public class SwimStyleController : Controller
    {
        private readonly ISwimStyleService service;

        public SwimStyleController(ISwimStyleService r)
        {
            service = r;
        }

        public IActionResult Index()
        {
            var swimStyles = service.SelectSwimStyles();

            return View(swimStyles);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SwimStyleDTO swimStyle)
        {
            try
            {
                service.AddSwimStyle(swimStyle);
            }
            catch (Exception ex)
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
                service.DeleteSwimStyle(id);
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
        public IActionResult Update(SwimStyleDTO swimStyle)
        {
            try
            {
                service.UpdateSwimStyle(swimStyle);
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
                var swimStyle = service.GetSwimStyle(id);

                return View(swimStyle);
            }
            return NotFound();
        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            if (id != null)
            {

                var swimStyle = service.GetSwimStyle(id);

                return View(swimStyle);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult DeleteCoach(int id)
        {
            if (id != null)
            {
                service.DeleteSwimStyle(id);

                return RedirectToAction("Index");

            }
            return NotFound();
        }
        public IActionResult Edit(int id)
        {
            if (id != null)
            {
                SwimStyleDTO swimStyle = service.GetSwimStyle(id);
                return View(swimStyle);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(SwimStyleDTO swimStyle)
        {
            service.UpdateSwimStyle(swimStyle);
            return RedirectToAction("Index");
        }
    }
}

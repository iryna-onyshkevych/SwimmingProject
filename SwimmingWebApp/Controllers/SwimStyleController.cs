using ADO.BL.Interfaces;
using ADO.BL.Services;
using DTO.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using X.PagedList;

namespace SwimmingWebApp.Controllers
{
    public class SwimStyleController : Controller
    {
        private readonly ISwimStyleService service;

        public SwimStyleController(ISwimStyleService r)
        {
            service = r;
        }

        [HttpGet]
        public IActionResult Index(int? page)
        {
            var swimStyles= service.SelectSwimStyles();
            var pageNumber = page ?? 1;
            var onePageOfSwimStyles = swimStyles.ToPagedList(pageNumber, 4);
            ViewBag.OnePageOfSwimStyles = onePageOfSwimStyles;
            return View();
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
            catch 
            {
                return Content($"\tERROR!\n\n\n Entered data is invalid! \n");
            }

            return RedirectToAction("Index");
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
            catch 
            {
                return Content($"\tERROR!\n\n\n Entered data is invalid!");
            }
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var swimStyle = service.GetSwimStyle(id);
            return View(swimStyle);
        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            var swimStyle = service.GetSwimStyle(id);
            return PartialView(swimStyle);
        }

        public IActionResult Edit(int id)
        {
            SwimStyleDTO swimStyle = service.GetSwimStyle(id);
            return View(swimStyle);
        }

        [HttpPost]
        public IActionResult Edit(SwimStyleDTO swimStyle)
        {
            try
            {
                service.UpdateSwimStyle(swimStyle);
            }
            catch
            {
                return Content($"\tERROR!\n\n\n Entered data is invalid! Can't edit {swimStyle.StyleName} \n");
            }
            return RedirectToAction("Index");
        }
    }
}

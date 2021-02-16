using ADO.BL.Interfaces;
using ADO.BL.Services;
using DTO.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            var products = service.SelectSwimStyles(); //returns IQueryable<Product> representing an unknown number of products. a thousand maybe?

            var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
            var onePageOfProducts = products.ToPagedList(pageNumber, 4); // will only contain 25 products max because of the pageSize

            ViewBag.OnePageOfProducts = onePageOfProducts;
            return View();
        }
        //public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        //{
        //    ViewBag.CurrentSort = sortOrder;
        //    ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
        //    ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

        //    if (searchString != null)
        //    {
        //        page = 1;
        //    }
        //    else
        //    {
        //        searchString = currentFilter;
        //    }

        //    ViewBag.CurrentFilter = searchString;

        //    //var students = from s in db.Students
        //    //               select s;
        //    var students = service.SelectSwimStyles();

        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        students = students.Where(s => s.StyleName.Contains(searchString)
        //                              );
        //    }
        //    switch (sortOrder)
        //    {
        //        case "name_desc":
        //            students = students.OrderByDescending(s => s.StyleName);
        //            break;
        //        case "Date":
        //            students = students.OrderBy(s => s.StyleName);
        //            break;
        //        case "date_desc":
        //            students = students.OrderByDescending(s => s.StyleName);
        //            break;
        //        default:  // Name ascending 
        //            students = students.OrderBy(s => s.StyleName    );
        //            break;
        //    }

        //    int pageSize = 3;
        //    int pageNumber = (page ?? 1);
        //    return View(students.ToPagedList(pageNumber, pageSize));
        //}
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
                return PartialView(swimStyle);
            }
            return NotFound();
        }

        [HttpPost]
       

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

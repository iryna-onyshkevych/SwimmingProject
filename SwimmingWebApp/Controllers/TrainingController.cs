using ADO.BL.Interfaces;
using ADO.BL.Services;
using DTO.Models;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace SwimmingWebApp.Controllers
{
    public class TrainingController : Controller
    {
        private readonly ITrainingViewService service;

        public TrainingController(ITrainingViewService r)
        {
            service = r;
        }

        [HttpGet]
        public IActionResult Index(int? page)
        {
            var products = service.SelectSwimmersTrainings(); //returns IQueryable<Product> representing an unknown number of products. a thousand maybe?

            var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
            var onePageOfProducts = products.ToPagedList(pageNumber, 4); // will only contain 25 products max because of the pageSize

            ViewBag.OnePageOfProducts = onePageOfProducts;
            return View();
        }
        //[HttpGet]
        //public IActionResult Index(int page = 1)
        //{
        //    var customers = service.GetTrainings(page);
        //    return View(customers);
        //}

        public IActionResult Details(int id)
        {
            if (id != null)
            {
                var training = service.GetViewTraining(id);
                return View(training);
            }
            return NotFound();
        }
    }
}

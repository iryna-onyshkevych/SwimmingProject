using ADO.BL.Services;
using DTO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SwimmingWebApp.ViewModels;
using System;
using System.Linq;



namespace SwimmingWebApp.Controllers
{
    public class CoachesController : Controller
    {
        public IConfiguration Configuration { get; }

        public CoachesController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //public IActionResult Index()
        //{


        //    //string connectionString = Configuration["ConnectionStrings:DefaultConnection"];

        //    CoachService coachService = new CoachService();
        //    var e = coachService.SelectCoaches();

        //    return View(e);


        //}
        public IActionResult Index(string sortOrder, string searchString,int page = 1)
        {
            int pageSize = 3;   // количество элементов на странице
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            CoachService coachService = new CoachService();
            var coaches = coachService.SelectCoaches();

            if (!String.IsNullOrEmpty(searchString))
            {
                coaches = coaches.Where(s => s.FirstName.Contains(searchString)
                                       || s.LastName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    coaches = coaches.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    coaches = coaches.OrderBy(s => s.WorkExperience);
                    break;
                case "date_desc":
                    coaches = coaches.OrderByDescending(s => s.WorkExperience);
                    break;
                default:
                    coaches = coaches.OrderBy(s => s.LastName);
                    break;
            }
          
           
            var count = coaches.Count();
            var items = coaches.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Coaches = items
            };
            return View(viewModel);
        }
        //public ActionResult Index(string sortOrder, string searchString)
        //{
        //    ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
        //    ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";


        //    CoachService coachService = new CoachService();
        //    var coaches = coachService.SelectCoaches();
        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        coaches = coaches.Where(s => s.FirstName.Contains(searchString)
        //                               || s.LastName.Contains(searchString));
        //    }
        //    switch (sortOrder)
        //    {
        //        case "name_desc":
        //            coaches = coaches.OrderByDescending(s => s.LastName);
        //            break;
        //        case "Date":
        //            coaches = coaches.OrderBy(s => s.WorkExperience);
        //            break;
        //        case "date_desc":
        //            coaches = coaches.OrderByDescending(s => s.WorkExperience);
        //            break;
        //        default:
        //            coaches = coaches.OrderBy(s => s.LastName);
        //            break;
        //    }
        //    return View(coaches.ToList());

        //}
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CoachDTO coach)
        {
            CoachService coachService = new CoachService();
            coachService.AddCoach(coach);

            return RedirectToAction("Index");
        }
        public IActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Update(CoachDTO coach)
        {
            CoachService coachService = new CoachService();
            coachService.UpdateCoach(coach);

            return RedirectToAction("Index");
        }
        public IActionResult Delete()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Delete(int id)
        {

            CoachService coachService = new CoachService();
            coachService.DeleteCoach(id);


            return RedirectToAction("Index");
        }
    }
}

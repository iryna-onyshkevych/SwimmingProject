using ADO.BL.Services;
using DTO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace SwimmingWebApp.Controllers
{
    public class CoachesController : Controller
    {
        public IConfiguration Configuration { get; }

        public CoachesController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IActionResult Index()
        {


            //string connectionString = Configuration["ConnectionStrings:DefaultConnection"];

            CoachService coachService = new CoachService();
            var e = coachService.SelectCoaches();

            return View(e);


        }
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

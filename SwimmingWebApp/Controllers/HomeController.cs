using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace SwimmingWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IConfiguration Configuration { get; }

        public HomeController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

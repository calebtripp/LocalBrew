using Microsoft.AspNetCore.Mvc;

namespace LocalBrew.Controllers
{
    public class BreweryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

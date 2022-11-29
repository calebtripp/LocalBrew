using LocalBrew.API_Client;
using Microsoft.AspNetCore.Mvc;

namespace LocalBrew.Controllers
{
    public class BreweryController : Controller
    {
        private readonly IBreweriesAPI _response;
        
        public BreweryController(IBreweriesAPI response) 
        {
            _response = response;
        }
        public IActionResult Breweries()
        {
            var breweries = _response.GetCityBreweries();

            if (breweries == null)
            {
                return View();
            }  

            if (!breweries.Any())
            {
                return View();
            }

            return View(breweries);
        }
    }
}

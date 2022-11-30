using LocalBrew.API_Client;
using LocalBrew.Models;
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
                return View("ErrorAPI");
            }

            if (!breweries.Any())
            {
                return View("ErrorEmptyBreweryList");
            }

            return View(breweries);
        }

        public IActionResult IndividualBrewery(string id)
        {
            var brewery = _response.GetBrewery(id);

            if (string.IsNullOrWhiteSpace(id))
            {
                return View("ErrorNullID");
            }

            if (brewery == null)
            {
                return View("ErrorAPI");
            }

            return View(brewery);   

        }
    }
}

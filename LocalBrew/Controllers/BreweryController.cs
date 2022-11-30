﻿using LocalBrew.API_Client;
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

        public IActionResult IndividualBrewery(string id)
        {
            var brewery = _response.GetBrewery(id);

            if (string.IsNullOrWhiteSpace(id))
            {
                return View();
            }

            if (brewery == null)
            {
                return View();
            }

            return View(brewery);   

        }
    }
}

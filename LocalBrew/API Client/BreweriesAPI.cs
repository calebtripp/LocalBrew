using LocalBrew.Models;
using Newtonsoft.Json.Linq;

namespace LocalBrew.API_Client
{
    public class BreweriesAPI : IBreweriesAPI
    {
        private const string CityInput = "harrisburg";
        private readonly HttpClient client = new HttpClient();

        public Brewery GetBrewery(string id)
        {
            try
            {
                var APICall = $"https://api.openbrewuerydb.org/breweries/{id}";
                var singleBreweryJSON = client.GetStringAsync(APICall).Result;

                var singleBrewery = new Brewery();
                {
                    singleBrewery.ID = JObject.Parse(singleBreweryJSON).GetValue("id").ToString();
                    singleBrewery.Name = JObject.Parse(singleBreweryJSON).GetValue("name").ToString();
                    singleBrewery.Type = JObject.Parse(singleBreweryJSON).GetValue("brewery_type").ToString();
                    singleBrewery.Street = JObject.Parse(singleBreweryJSON).GetValue("street").ToString();
                    singleBrewery.City = JObject.Parse(singleBreweryJSON).GetValue("city").ToString();
                    singleBrewery.State = JObject.Parse(singleBreweryJSON).GetValue("state").ToString();
                    singleBrewery.Zip = JObject.Parse(singleBreweryJSON).GetValue("postal_code").ToString();
                    singleBrewery.Website = JObject.Parse(singleBreweryJSON).GetValue("website_url").ToString();
                    singleBrewery.Latitude = JObject.Parse(singleBreweryJSON).GetValue("latitude").ToString();
                    singleBrewery.Longitude = JObject.Parse(singleBreweryJSON).GetValue("longitude").ToString();
                }

                return singleBrewery;

            }

            catch
            {

                return null;
            }
        }

        public IEnumerable<Brewery> GetCityBreweries()
        {
            var breweryList = new List<Brewery>();

            try
            {
                var APICall = $"https://api.openbrewerydb.org/breweries?by_city={CityInput}&per_page=20";
                var cityBreweriesJSON = client.GetStringAsync(APICall).Result;
                var brewerynum = JArray.Parse(cityBreweriesJSON).Count();

                for (int i = 0; i < brewerynum; i++)
                {
                    var parsedBreweries = JArray.Parse(cityBreweriesJSON).ElementAt(i).ToString();
                    var newBrewery = new Brewery();
                    {
                        newBrewery.ID = JObject.Parse(parsedBreweries).GetValue("id").ToString();
                        newBrewery.Name = JObject.Parse(parsedBreweries).GetValue("name").ToString();
                        newBrewery.Type = JObject.Parse(parsedBreweries).GetValue("brewery_type").ToString();
                        newBrewery.Street = JObject.Parse(parsedBreweries).GetValue("street").ToString();
                        newBrewery.City = JObject.Parse(parsedBreweries).GetValue("city").ToString();
                        newBrewery.State = JObject.Parse(parsedBreweries).GetValue("state").ToString();
                        newBrewery.Zip = JObject.Parse(parsedBreweries).GetValue("postal_code").ToString();
                        newBrewery.Website = JObject.Parse(parsedBreweries).GetValue("website_url").ToString();
                        newBrewery.Latitude = JObject.Parse(parsedBreweries).GetValue("latitude").ToString();
                        newBrewery.Longitude = JObject.Parse(parsedBreweries).GetValue("longitude").ToString();
                    }

                    breweryList.Add(newBrewery);

                }

                return breweryList;

            }

            catch
            {
                return null;
            }
        }
    }
}

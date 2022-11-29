using LocalBrew.Models;

namespace LocalBrew.API_Client
{
    public interface IBreweriesAPI
    {
        public IEnumerable<Brewery> GetCityBreweries();
        public Brewery GetBrewery(string id);
    }
}

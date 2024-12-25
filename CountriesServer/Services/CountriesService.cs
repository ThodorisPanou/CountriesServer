using CountriesServer.DbContextClasses;
using CountriesServer.DTO;

namespace CountriesServer.Services
{

    public interface ICountriesService
    {
        public List<String> GetCountries();
        public Country GetCountry(string country_name);
        public List<Country> GetTopCountries(int top,int low);
    }
    public class CountriesService : ICountriesService
    {
        private readonly ApplicationDbContext _applicationContext;

        public CountriesService(ApplicationDbContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public List<string> GetCountries()
        {
            return _applicationContext.Countries.Select(x=>x.Name).ToList();
        }

        public Country GetCountry(string country_name)
        {
            Country? country =  _applicationContext.Countries.FirstOrDefault(x=>x.Name== country_name);
            if (country == null)
                throw new Exception($"Cant find country: {country_name}");
            return country;
        }

        public List<Country> GetTopCountries(int top, int low)
        {
            if (top <= 0 || low < 0 || low >= top)
                throw new Exception("Invalid range: Ensure 0 <= low < top");

            return _applicationContext.Countries
                .OrderByDescending(c => c.Population) 
                .Skip(low)                            
                .Take(top - low)                      
                .ToList();
        }
    }
}

using CountriesServer.DbContextClasses;
using CountriesServer.DTO;

namespace CountriesServer.Services
{

    public interface ICountriesService
    {
        public List<String> GetCountries();
        public Country GetCountry(string country_name);
        public List<Country> GetTopCountries(int top);
    }
    public class CountriesService: ICountriesService
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

        public List<Country> GetTopCountries(int top)
        {
            if (top <= 0) throw new Exception("Get Top Countries Exception, top < 0");
            return _applicationContext.Countries.OrderByDescending(c => c.Population).Take(top).ToList();
        }
    }
}

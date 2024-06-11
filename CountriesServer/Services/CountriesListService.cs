using CountriesServer.DbContextClasses;

namespace CountriesServer.Services
{
    public class CountriesListService
    {
        private readonly ApplicationDbContext _applicationContext;

        public CountriesListService(ApplicationDbContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public List<String> GetCountries()
        {
            return _applicationContext.Countries.Select(x=>x.Name).ToList();
        }
    }
}

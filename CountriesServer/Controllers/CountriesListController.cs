using CountriesServer.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CountriesServer.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAllOrigins")]
    [ApiController]
    public class CountriesListController : Controller
    {
        private readonly ICountriesService _Countries_Service;

        public CountriesListController(ICountriesService service) { _Countries_Service = service; }

        [HttpGet("GetCountries")]
        public List<String> GetCountries()
        {
            return _Countries_Service.GetCountries();
        }
    }
}

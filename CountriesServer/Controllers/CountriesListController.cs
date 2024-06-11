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
        private readonly CountriesListService _service;

        public CountriesListController(CountriesListService service) { _service = service; }

        [HttpGet("GetCountries")]
        public List<String> GetCountries()
        {
            return _service.GetCountries();
        }
    }
}

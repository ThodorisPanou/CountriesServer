using CountriesServer.DTO;
using CountriesServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace CountriesServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionsController : Controller
    {
        private readonly SessionService _service;
        public SessionsController(SessionService service) { _service = service; }

        [HttpPost("guess")]
        public async Task<ResponseDTO> Guess([FromBody] Session guessRequest)
        {
            var result = await _service.Guess(guessRequest);
            return result;
        }
    }
}

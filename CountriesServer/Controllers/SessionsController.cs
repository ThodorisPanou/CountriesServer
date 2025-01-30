using CountriesServer.DTO;
using CountriesServer.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CountriesServer.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAllOrigins")]
    [ApiController]
    public class SessionsController : Controller
    {
        private readonly IContextService _service;
        public SessionsController(IContextService service) { _service = service; }

        [HttpPost("guess")]
        public async Task<ResponseDTO> Guess([FromBody] Session guessRequest)
        {
            var result = await _service.Guess(guessRequest);

            return result;
        }
    }
}

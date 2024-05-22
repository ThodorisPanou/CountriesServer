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
        public async Task<IActionResult> Guess([FromBody] DTO.Session guessRequest)
        {
            bool result = await _service.AddSession(guessRequest);
            if (result)
                return Ok("Right Country");
            else
                return Ok("Wrong Country");
        }
    }
}

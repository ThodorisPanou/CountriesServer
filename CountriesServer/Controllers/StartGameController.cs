using CountriesServer.DTO;
using CountriesServer.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CountriesServer.Controllers
{
        [Route("api/[controller]")]
        [EnableCors("AllowAllOrigins")]
        [ApiController]
        public class StartGameController : Controller
        {
            private readonly IContextService _service;

            public StartGameController(IContextService service) { _service = service; }

        [HttpPost("start")]
            public async Task<GameSettingsDTO> StartGame(GameSettingsDTO settings)
            {
                return await _service.CreateGame(settings);
            }
        }
    
}

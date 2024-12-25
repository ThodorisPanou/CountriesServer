using CountriesServer.Data;
using CountriesServer.DbContextClasses;
using CountriesServer.DTO;

namespace CountriesServer.Services
{
    public interface IContextService
    {
        Task<ResponseDTO> Guess(string country,string sessionID);
        Task<GameSettingsDTO> CreateGame(GameSettingsDTO settings);
    }
    public class ContextService: IContextService
    {
        private readonly IUserSessionService _UserSession;
        private readonly ICountriesService _CountriesService;
        public ContextService(
            IUserSessionService userSession,
            ICountriesService countriesService)
        {
            _UserSession = userSession;
            _CountriesService = countriesService;
        }
        public async Task<GameSettingsDTO> CreateGame(GameSettingsDTO settings)
        {
            if (settings == null || settings.Difficulty==null)
                throw new Exception("Values Can't Be Null");
            var DifficultyTuple = Data.GameConstants.MapDifficulty(settings.Difficulty);
            string session = await _UserSession.AddUserSession(DifficultyTuple);
            settings.AccessToken = session;
            return settings;
        }

        public async Task<ResponseDTO> Guess(string country,string sessionID)
        {
            Session foundSession = await _UserSession.GetSession(country, sessionID);

            ResponseDTO response = new ResponseDTO(foundSession);

            response.Success = country == foundSession.Guess;

            Country requestedCountry = _CountriesService.GetCountry(country);
            Country tobeFoundCountry = _CountriesService.GetCountry(foundSession.Guess);

            response.CalculateResponse(requestedCountry, tobeFoundCountry);

            return response;
        }

        
        

        

    }
}

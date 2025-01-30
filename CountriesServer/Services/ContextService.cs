using CountriesServer.Data;
using CountriesServer.DbContextClasses;
using CountriesServer.DTO;

namespace CountriesServer.Services
{
    public interface IContextService
    {
        Task<ResponseDTO> Guess(Session guessRequest);
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

        public async Task<ResponseDTO> Guess(Session guessRequest)
        {
            Session foundSession = await _UserSession.GetSession(guessRequest.Guess, guessRequest.SessionID);

            ResponseDTO response = new ResponseDTO(foundSession);

            response.Success = guessRequest.Guess == foundSession.Guess;

            Country requestedCountry = _CountriesService.GetCountry(guessRequest.Guess);
            Country tobeFoundCountry = _CountriesService.GetCountry(foundSession.Guess);

            response.CalculateResponse(requestedCountry, tobeFoundCountry);

            if ((guessRequest.GuessCount == CountriesConstants.MAX_GUESSES-1)  && (!response.Success ?? true))
                response.CorrectCountry = tobeFoundCountry.Name;

            return response;
        }

        
        

        

    }
}

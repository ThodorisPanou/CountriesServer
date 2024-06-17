using CountriesServer.Data;
using CountriesServer.DbContextClasses;
using CountriesServer.DTO;

namespace CountriesServer.Services
{
    public class SessionService
    {
        private readonly SessionDbContext _context;
        private readonly ApplicationDbContext _applicationContext;
        public SessionService(SessionDbContext context, ApplicationDbContext applicationContext)
        {
            _context = context; _applicationContext = applicationContext;
        }

        public async Task<ResponseDTO> Guess(DTO.Session guess)
        {
            if (guess.SessionID == null && guess.GuessCount == 0)
            {
                guess = await AddUserSession(guess);
            }

            Session foundSession = _context.Sessions.Where(x => x.SessionID == guess.SessionID).First();
            foundSession.GuessCount++;
            guess.GuessCount++;
            await _context.SaveChangesAsync();

            ResponseDTO response = new ResponseDTO(guess);
            response.Success = (guess.Guess == foundSession.Guess);

            Country requestedCountry = _applicationContext.Countries.Where(x=>x.Name == guess.Guess).FirstOrDefault();
            Country tobeFoundCountry = _applicationContext.Countries.Where(x => x.Name == foundSession.Guess).FirstOrDefault();

            response = response.CopyData(requestedCountry);

            if (requestedCountry != null && tobeFoundCountry != null)
            {
                CalculateResponse(response, requestedCountry, tobeFoundCountry);
            }
            return response;
        }

        private static void CalculateResponse(ResponseDTO response, Country requestedCountry, Country tobeFoundCountry)
        {
            response.RegionResponse = (requestedCountry.Region == tobeFoundCountry.Region);
            response.NameResponse = (requestedCountry.Name == tobeFoundCountry.Name);
            response.ContinentResponse = (ContinentRegion.Region_To_Continent_Map[requestedCountry.Region] == ContinentRegion.Region_To_Continent_Map[tobeFoundCountry.Region]);
            if (requestedCountry.Population > tobeFoundCountry.Population)
                response.PopulationResponse = -1;
            else if (requestedCountry.Population < tobeFoundCountry.Population)
                response.PopulationResponse = 1;
            else
                response.PopulationResponse = 0;
            if (requestedCountry.Area > tobeFoundCountry.Area)
                response.AreaResponse = -1;
            else if (requestedCountry.Area < tobeFoundCountry.Area)
                response.AreaResponse = 1;
            else
                response.AreaResponse = 0;
            if (requestedCountry.Latitude > tobeFoundCountry.Latitude)
                response.LatitudeResponse = -1;
            else if (requestedCountry.Latitude < tobeFoundCountry.Latitude)
                response.LatitudeResponse = 1;
            else
                response.LatitudeResponse = 0;
            if (requestedCountry.Longitude > tobeFoundCountry.Longitude)
                response.LongitudeResponse = -1;
            else if (requestedCountry.Longitude < tobeFoundCountry.Longitude)
                response.LongitudeResponse = 1;
            else
                response.LongitudeResponse = 0;
            //if I guess Greece and country to be guessed is USA , then i need to guess Population higher so PopResponse=1
            //if I Guess China and country to be guessed is Albania, then i need to guess Area lower so AreaResponse=-1
        }

        private async Task<DTO.Session> AddUserSession(Session guess)
        {
            DTO.Session emptySession = new DTO.Session();
            emptySession.SessionID = Guid.NewGuid().ToString();
            guess.SessionID = emptySession.SessionID;
            var top25Countries = _applicationContext.Countries.OrderByDescending(c => c.Population).Take(25).ToList();
            Random random = new Random();
            emptySession.Guess = top25Countries[random.Next(top25Countries.Count)].Name;
            emptySession.GuessCount = 1;
            _context.Add(emptySession);
            await _context.SaveChangesAsync();
            return guess;
        }

    }
}

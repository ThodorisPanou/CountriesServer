using CountriesServer.DbContextClasses;
using CountriesServer.DTO;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace CountriesServer.Services
{
    public interface IUserSessionService
    {
        public Task<string> AddUserSession(Tuple<int, int> difficulty);

        public Task<Session> GetSession(string country, string sessionID);
    }
    public class UserSessionService : IUserSessionService
    {
        private readonly SessionDbContext _session_context;
        private readonly ICountriesService _CountriesService;

        public UserSessionService(SessionDbContext session_context, ICountriesService countriesService)
        {
            _session_context = session_context;
            _CountriesService = countriesService;
        }

        public async Task<Session> GetSession(string country, string sessionID)
        {
            Session? foundSession = _session_context.Sessions.Where(x => x.SessionID == sessionID).FirstOrDefault();
            if (foundSession == null)
                throw new Exception("Cant find Session with this ID");
            foundSession.GuessCount++;
            await _session_context.SaveChangesAsync();
            return foundSession;
        }

        public async Task<string> AddUserSession(Tuple<int,int> difficulty)
        {
            Session Session = new Session();
            Session.SessionID = Guid.NewGuid().ToString();
            var topCountries = _CountriesService.GetTopCountries(difficulty.Item2, difficulty.Item1);
            Random random = new Random();
            Session.Guess = topCountries[random.Next(topCountries.Count)].Name;
            Console.WriteLine($"country to be guessed: {Session.Guess}");
            _session_context.Add(Session);
            await _session_context.SaveChangesAsync();
            return Session.SessionID;
        }

        
    }
}

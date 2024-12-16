using CountriesServer.DbContextClasses;
using CountriesServer.DTO;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace CountriesServer.Services
{
    public interface IUserSessionService
    {
        public Task<string> AddUserSession(string country);

        public Task<Session> GetSession(string country, string? sessionID = null);
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

        public async Task<Session> GetSession(string country, string? sessionID = null)
        {
            if (sessionID == null)
            {
                sessionID = await AddUserSession(country);
            }
            Session? foundSession = _session_context.Sessions.Where(x => x.SessionID == sessionID).FirstOrDefault();
            if (foundSession == null)
                throw new Exception("Cant find Session with this ID");
            foundSession.GuessCount++;
            await _session_context.SaveChangesAsync();
            return foundSession;
        }

        public async Task<string> AddUserSession(string country)
        {
            Session Session = new Session();
            Session.SessionID = Guid.NewGuid().ToString();
            var top25Countries = _CountriesService.GetTopCountries(25);
            Random random = new Random();
            Session.Guess = top25Countries[random.Next(top25Countries.Count)].Name;
            _session_context.Add(Session);
            await _session_context.SaveChangesAsync();
            return Session.SessionID;
        }

        
    }
}

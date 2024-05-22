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

        public async Task<ResponseDTO> AddSession(DTO.Session guess)
        {
            if (guess.SessionID == null && guess.GuessCount == 1)
            {
                DTO.Session emptySession = new DTO.Session();
                emptySession.SessionID = Guid.NewGuid().ToString();
                guess.SessionID = emptySession.SessionID;
                var top15Countries = _applicationContext.Countries.OrderByDescending(c => c.Population).Take(15).ToList();
                Random random = new Random();
                emptySession.Guess = top15Countries[random.Next(top15Countries.Count)].Name;
                emptySession.GuessCount = 1;
                _context.Add(emptySession);
                await _context.SaveChangesAsync();
            }
            Session foundSession = _context.Sessions.Where(x => x.SessionID == guess.SessionID).First();
            await _context.SaveChangesAsync();

            ResponseDTO response = new ResponseDTO();
            response.SessionID = guess.SessionID;
            response.GuessCount = foundSession.GuessCount;
            response.Success = (guess.Guess == foundSession.Guess);

            return response;
        }
    }
}

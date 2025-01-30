using System.ComponentModel.DataAnnotations;

namespace CountriesServer.DTO
{
    public class Session
    {
        public string SessionID { get; set; } = string.Empty;

        public string Guess { get; set; } = String.Empty;

        public int? GuessCount { get; set; } = 0;
        
    }
}

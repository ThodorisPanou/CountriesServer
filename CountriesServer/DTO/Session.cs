using System.ComponentModel.DataAnnotations;

namespace CountriesServer.DTO
{
    public class Session
    {
        public string? SessionID { get; set; }

        public string? Guess { get; set; }

        public int? GuessCount { get; set; }
    }
}

namespace CountriesServer.DTO
{
    public class ResponseDTO
    {
        public string? SessionID { get; set; }

        public bool? Success { get; set; }

        public int? GuessCount { get; set; }
    }
}

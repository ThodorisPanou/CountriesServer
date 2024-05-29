namespace CountriesServer.DTO
{
    public class ResponseDTO
    {
        public ResponseDTO() { }

        public ResponseDTO(Session guess) {
            SessionID = guess.SessionID;
            GuessCount = guess.GuessCount+1;
        }
        public string? SessionID { get; set; }

        public bool? Success { get; set; }

        public int? GuessCount { get; set; }
        public string? Name { get; set; }

        public bool? NameResponse { get; set; }
        public string Region { get; set; }
        public bool? RegionResponse { get; set; }
        public double Population { get; set; }
        public int? PopulationResponse { get; set; }
        public double Area { get; set; }
        public int? AreaResponse { get; set; }

        public ResponseDTO CopyData(Country requestedCountry)
        {
            Name = requestedCountry.Name;
            Region = requestedCountry.Region;
            Population = requestedCountry.Population;
            Area = requestedCountry.Area;
            return this;
        }
    }
}

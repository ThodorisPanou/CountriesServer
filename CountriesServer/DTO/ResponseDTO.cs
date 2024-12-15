using CountriesServer.Data;

namespace CountriesServer.DTO
{
    public class ResponseDTO
    {
        public ResponseDTO() { }

        public ResponseDTO(Session guess) {
            SessionID = guess.SessionID;
            GuessCount = guess.GuessCount;
        }
        public string? SessionID { get; set; }

        public bool? Success { get; set; }

        public int? GuessCount { get; set; }
        public string? Name { get; set; }

        public bool? NameResponse { get; set; }
        public string? Region { get; set; }
        public bool? RegionResponse { get; set; }
        public double Population { get; set; }
        public int? PopulationResponse { get; set; }
        public double Area { get; set; }
        public int? AreaResponse { get; set; }
        public string? Continent { get; set; }
        public bool ContinentResponse { get; set; }
        public double? Latitude { get; set; }
        public int? LatitudeResponse { get; set; }
        public double? Longitude { get; set; }
        public int? LongitudeResponse {  get; set; }


        public ResponseDTO CopyData(Country requestedCountry)
        {
            Name = requestedCountry.Name;
            Region = requestedCountry.Region;
            Population = requestedCountry.Population;
            Area = requestedCountry.Area;
            Continent = ContinentRegion.Region_To_Continent_Map[Region];
            Latitude = requestedCountry.Latitude ?? null;
            Longitude = requestedCountry.Longitude ?? null;
            return this;
        }
    }
}

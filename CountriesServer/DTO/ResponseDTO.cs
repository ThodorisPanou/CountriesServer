using CountriesServer.Data;

namespace CountriesServer.DTO
{
    public class ResponseDTO
    {
        public ResponseDTO() { }

        public ResponseDTO(Session session)
        {
            SessionID = session.SessionID;
            GuessCount = session.GuessCount;   
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
        public double? Area { get; set; }
        public int? AreaResponse { get; set; }
        public string? Continent { get; set; }
        public bool? ContinentResponse { get; set; }
        public double? Latitude { get; set; }
        public int? LatitudeResponse { get; set; }
        public double? Longitude { get; set; }
        public int? LongitudeResponse {  get; set; }
        public string? CorrectCountry { get; set; }


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

        public  ResponseDTO CalculateResponse(Country requestedCountry, Country tobeFoundCountry)
        {
            CopyData(requestedCountry);

            RegionResponse = (requestedCountry.Region == tobeFoundCountry.Region);
            NameResponse = (requestedCountry.Name == tobeFoundCountry.Name);
            ContinentResponse = (ContinentRegion.Region_To_Continent_Map[requestedCountry.Region] == ContinentRegion.Region_To_Continent_Map[tobeFoundCountry.Region]);
            if (requestedCountry.Population > tobeFoundCountry.Population)
                PopulationResponse = -1;
            else if (requestedCountry.Population < tobeFoundCountry.Population)
                PopulationResponse = 1;
            else
                PopulationResponse = 0;
            if (requestedCountry.Area > tobeFoundCountry.Area)
                AreaResponse = -1;
            else if (requestedCountry.Area < tobeFoundCountry.Area)
                AreaResponse = 1;
            else
                AreaResponse = 0;
            if (requestedCountry.Latitude > tobeFoundCountry.Latitude)
                LatitudeResponse = -1;
            else if (requestedCountry.Latitude < tobeFoundCountry.Latitude)
                LatitudeResponse = 1;
            else
                LatitudeResponse = 0;
            if (requestedCountry.Longitude > tobeFoundCountry.Longitude)
                LongitudeResponse = -1;
            else if (requestedCountry.Longitude < tobeFoundCountry.Longitude)
                LongitudeResponse = 1;
            else
                LongitudeResponse = 0;

            return this;
            //if I guess Greece and country to be guessed is USA , then i need to guess Population higher so PopResponse=1
            //if I Guess China and country to be guessed is Albania, then i need to guess Area lower so AreaResponse=-1
        }
    }
}

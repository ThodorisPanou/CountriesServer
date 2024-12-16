using Microsoft.EntityFrameworkCore;

namespace CountriesServer.DTO
{
    public class Country
    {
        public string Name { get; set; } = "";
        public string? Region { get; set; }
        public double Population { get; set; }
        public double Area { get; set; }
        public double PopulationDensity { get; set; }
        public double CoastlineRatio { get; set; }
        public double NetMigration { get; set; }
        public double InfantMortality { get; set; }
        public double GDP { get; set; }
        public double Literacy { get; set; }
        public double Phones { get; set; }
        public double Climate { get; set; }
        public double Birthrate { get; set; }
        public double Deathrate { get; set; }
        public double Agriculture { get; set; }
        public double Industry { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

    }
}

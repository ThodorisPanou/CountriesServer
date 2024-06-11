namespace CountriesServer.Data
{
    public static class ContinentRegion
    {
        public static Dictionary<string, string> Region_To_Continent_Map = new Dictionary<string, string>
        {
            { "ASIA (EX. NEAR EAST)", "Asia" },
            { "EASTERN EUROPE", "Europe" },
            { "NORTHERN AFRICA", "Africa" },
            { "OCEANIA", "Oceania" },
            { "WESTERN EUROPE", "Europe" },
            { "SUB-SAHARAN AFRICA", "Africa" },
            { "LATIN AMER. & CARIB", "South America" }, // Assuming Latin America
            { "C.W. OF IND. STATES", "Asia" }, // Commonwealth of Independent States
            { "NEAR EAST", "Asia" },
            { "NORTHERN AMERICA", "North America" },
            { "BALTICS", "Europe" } // Assuming Baltic states
        };
    }
}

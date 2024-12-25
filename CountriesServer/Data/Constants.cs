namespace CountriesServer.Data
{
    public static class CountriesConstants
    {
        public static int MAX_GUESSES = 6;
        
    }

    public static class GameConstants
    {
        private static Tuple<int, int> easy = new Tuple<int, int>(0, 15);
        private static Tuple<int, int> medium = new Tuple<int, int>(16, 40);
        private static Tuple<int, int> hard = new Tuple<int, int>(41, 100);

        public static Tuple<int, int> MapDifficulty(string difficulty)
        {
            if (difficulty == null)
                throw new ArgumentNullException();
            if (difficulty.Equals(nameof(easy)))
                return easy;
            else if (difficulty.Equals(nameof(medium)))
                return medium;
            else if (difficulty.Equals(nameof(hard)))
                return hard;
            else
                throw new ArgumentException("difficulty value is wrong");
        }
    }
}

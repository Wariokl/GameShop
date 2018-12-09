
using System.Collections.Generic;


namespace TestAsp.Models
{
    public class Genre
    {
        public int GenreID { get; set; }
        public string GenreName { get; set; }

        public List<GenreisGames> genreisGames { get; set; }

        public Genre()
        {
            genreisGames = new List<GenreisGames>();
        }
    }


}


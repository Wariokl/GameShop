using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAsp.Models
{
    public class GenreisGames
    {
        public int ID { get; set; }
        public int gameID { get; set; }
        public Game game { get; set; }
        public int genreID { get; set; }
        public Genre genre { get; set; }
    }
}

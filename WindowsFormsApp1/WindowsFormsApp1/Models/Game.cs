
using System.Collections.Generic;


namespace TestAsp.Models
{
    public class Game
    {
       
        public int Id { get; set; }
   
        public string Name { get; set; }
        public string gameCategory { get; set; }
   
        public string gameCompany { get; set; }
        public string gamePrice { get; set; }
     
      
        //public List<GenreisGames> genreisGames { get; set; }


        //public Game()
        //{
        //    genreisGames = new List<GenreisGames>();
        //}

       
    }
}

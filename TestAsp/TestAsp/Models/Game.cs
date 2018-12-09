using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestAsp.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
   
        public string Name { get; set; }
        public Category Categories { get; set; }
        //public DateTime Date { get; set; }
        public Company Companies { get; set; }
        public int Price { get; set; }
       // public Genre genres { get; set; }
        [NotMapped]
        public List<GenreisGames> genreisGames { get; set; }


        public Game()
        {
            genreisGames = new List<GenreisGames>();
        }

       
    }
}

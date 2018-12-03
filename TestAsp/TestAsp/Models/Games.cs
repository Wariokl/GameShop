using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAsp.Models
{
    public class Games
    {
        public int GameID { get; set; }
        public string Name { get; set; }
        public int Genre { get; set; }
        public int Category { get; set; }
        public DateTime Date { get; set; }
        public int Company { get; set; }
        public int Price { get; set; }
    }
}

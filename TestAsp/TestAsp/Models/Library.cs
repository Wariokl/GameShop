using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAsp.Models
{
    public class Library
    {
        public int LibraryID { get; set; }
        public int User { get; set; }
        
        public Game Games { get; set; }
       

    }
}

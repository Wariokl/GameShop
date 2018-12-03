using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAsp.Models
{
    public class Log
    {
        public int LogID { get; set; }
        public int UserID { get; set; }
        public ActionsEnum action { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAsp.Models
{
    public class User
    {

        public int UserId { get; set; }
        public string NickName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Library Library { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAsp
{
    public class signle
    {
        private static signle _instace;

        public signle Intance
        {
            get
            {
                if (_instace == null)
                    _instace = new signle();
                return _instace;
            }
        }

        private signle()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousServer
{
    public class TokenClass
    {
        public string user { get; set; }
        public string token { get; set; }
        public bool RequestToken { get; set; }

        public TokenClass(string uname, string tvalue)
        {
            user = uname;
            token = tvalue;
        }

        public TokenClass(string uname)
        {
            user = uname;
        }

    }
}

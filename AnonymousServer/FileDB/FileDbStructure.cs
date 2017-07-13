using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousServer
{
    public class FileDbStructure
    {
        public string name { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public Usertype usertype { get; set; }
        /// <summary>
        /// This is sample.
        /// </summary>
        /// <param name="uname">UserName</param>
        /// <param name="pwd">Password</param>
        /// <param name="utype">UserType</param>
        /// <returns></returns>
        public FileDbStructure(string nme, string uname, string pwd, Usertype utype)
        {
            name = nme;
            username = uname;
            password = pwd;
            usertype = utype;
        }
    }
}

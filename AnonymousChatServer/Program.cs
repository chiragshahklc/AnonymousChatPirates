using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousChatServer
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.Write("Enter Password:");
            string x = Console.ReadLine();
            ServerSocket server = new ServerSocket();
            server.StartServer();

            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerSide

{
    class Program
    {
        static void Main(string[] args)
        {
            Server serv = new Server(136);
            Thread li = new Thread(serv.startServer);
            li.Start(); //serv.startServer();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WindowsFormsApp2
{
    class Client
    {
        private string ClientName;
        private IPAddress hostName;
        private int port;
        private TcpClient client;

        public Client(string userName, IPAddress hostName,int port)
        {
            this.ClientName = userName;
            this.hostName = hostName;
            this.port = port;
            
        }

        public void clientConnection()
        {
            this.client = new TcpClient(hostName.ToString(), port);
            

        }
        public TcpClient getClient()
        {
            return client;
        }
        public string getClientUsername()
        {
            return ClientName;
        }
        public void sendText(string message)
        {
            StreamWriter w = new StreamWriter(client.GetStream());
            w.Write(message + "\r");
            w.Flush();
        }

    }
}

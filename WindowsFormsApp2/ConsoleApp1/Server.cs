using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using ConsoleApp1;

namespace ServerSide
{
    
    class Server
    {
        private int port;
        private byte[] buffer = new byte[1024];
        public delegate void DisplayInvoker(string t);
        private StringBuilder msgclient = new StringBuilder();
        private TcpListener client;
        static IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
        private IPAddress ipAddress = host.AddressList[0];
        private TcpClient myclient;
        private List<TcpClient> usersConnected = new List<TcpClient>();
        
        

        public Server(int port)
        {
            this.port = port;
            

        }

        public void startServer()
        {
            client = new TcpListener(this.ipAddress, port);
            client.Start();
            SERV a = new SERV();
            a.Visible = true;
            a.textBox1.AppendText("Waiting for a new connection...");
            Console.WriteLine("Waiting for a new connection...");

            while (true)
            {
                myclient = client.AcceptTcpClient();
                usersConnected.Add(myclient);
                a.textBox1.AppendText("New User connected @" + myclient.GetType());
                myclient.GetStream().BeginRead(buffer, 0, 1024, Receive, null);
                a.textBox1.AppendText("Size of List " + usersConnected.Count);

            }
        }

        private void Receive(IAsyncResult ar)
        {
            int intCount;

            try
            {
                lock (myclient.GetStream())
                    intCount = myclient.GetStream().EndRead(ar);
                if (intCount < 1)
                {
                  
                    return;
                }
                Console.WriteLine("MESSAGE RECEIVED " + intCount);
                BuildString(buffer, 0, intCount);

                lock (myclient.GetStream())
                    myclient.GetStream().BeginRead(buffer, 0, 1024, Receive, null);
            }
            catch (Exception e)
            {
                return;
            }
        }
        public void Send(string Data)
        {
            lock (myclient.GetStream())
            {
                System.IO.StreamWriter w = new System.IO.StreamWriter(myclient.GetStream());
                w.Write(Data);
                w.Flush();
            }
        }
        private void BuildString(byte[] buffer, int offset, int count)
        {
            int intIndex;
            for (intIndex = offset; intIndex <= (offset + (count - 1)); intIndex++)
            {
                    msgclient.Append((char)buffer[intIndex]);
            }
              
            
            OnLineReceived(msgclient.ToString());
            msgclient.Length = 0;
            
        }
        private void OnLineReceived(string Data)
        {
            int i = 0;
           
            foreach (TcpClient objClient in usersConnected)
            {
                Console.WriteLine("Sending " + Data + " to " + objClient + i);
                Send(Data);
                i++;
            }
        }



    }
}

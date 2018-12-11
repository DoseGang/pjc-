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
        private List<TcpClient> usersConnected = new List<TcpClient>();
        
        

        public Server(int port)
        {
            this.port = port;
            

        }

        public void startServer()
        {
            client = new TcpListener(ipAddress, port);
            client.Start();
            SERV a = new SERV(); // form ini
            a.Visible = true;
            a.textBox1.AppendText("Waiting for a new connection..." + "\n");
            

            while (true)
            {
                TcpClient objClient = client.AcceptTcpClient();
                usersConnected.Add(objClient);
                a.textBox1.AppendText("New User connected @" + objClient.ToString()+"\n" );
                objClient.GetStream().BeginRead(buffer, 0, 1024, Receive, objClient); // same as client part
                a.textBox1.AppendText("Size of List " + usersConnected.Count + "\n");

            }
        }

        private void Receive(IAsyncResult ar)
        {
            int intCount;
            TcpClient objclient = (TcpClient) ar.AsyncState;
            try
            {
                //SyncLock blocks. 
                //The SyncLock statement is used for thread synchronization to ensure
                //that two threads don't attempt to use the same object at the same time. 
                //. While a lock is held, the thread that holds the lock can again acquire and release the lock.
                //Any other thread is blocked from acquiring the lock and waits until the lock is released.

                lock (objclient.GetStream())
                    intCount = objclient.GetStream().EndRead(ar);
                if (intCount < 1)
                {
                  
                    return;
                }

                BuildString(buffer, 0, intCount);

                lock (objclient.GetStream())
                    objclient.GetStream().BeginRead(buffer, 0, 1024, Receive, objclient);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR IN RECEIVE" + e);
                return;
            }
        }
        public void Send(string Data, TcpClient a)
        {
            lock (a.GetStream())
            {
                StreamWriter w = new StreamWriter(a.GetStream());
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
           
            foreach (TcpClient objClient in usersConnected) //for each client in my list 
                //write data in each client stream
            {
                Console.WriteLine("Sending " + Data + " to " + objClient + i);
                Send(Data,objClient);
                i++;
            }
        }



    }
}

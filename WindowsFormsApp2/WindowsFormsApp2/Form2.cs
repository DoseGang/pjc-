using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {

        private delegate void DisplayInvoker(string t);
        private string currentTopic = null;
        private StringBuilder msg = new StringBuilder();
        static public string MyUser { get; set; }
        static private byte[] buffer = new byte[1024];
        static IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
        static IPAddress ipAddress = host.AddressList[0];
        static Client user = new Client(MyUser, ipAddress, 136);
        public Form2(string User) // when a user is logged in , directly connect him to the server
        {
            
            InitializeComponent();
            MyUser = User;        
            user.clientConnection();
            Thread readingg = new Thread(reading);
            readingg.Start();
            user.sendText(MyUser + " joined the chatroom!" +"\n");
            IPAdress.Text = GetLocalIP(host);
            IPAdress.ReadOnly = true;
        }
        public void reading()
        {
            user.getClient().GetStream().BeginRead(buffer, 0, 1024, ReadFlow, null);
            Console.WriteLine(MyUser + "received a message");
        }
        private void DisplayText(string t)
        {
            UserChat.AppendText(t);
            
        }
        private void BuildString(byte[] buffer,int offset, int count)
        {
            int intIndex;
            for(intIndex = offset; intIndex <= (offset + (count - 1)); intIndex++)
            {
                if (buffer[intIndex] == 10)
                {
                    msg.Append("\n");
                    object[] @params = { msg.ToString() };

                    Invoke(new DisplayInvoker(this.DisplayText),@params);
                    msg.Length = 0;
                }
                else
                {
                    msg.Append((char)buffer[intIndex]);
                }
            }
        }
        private void ReadFlow(IAsyncResult ar)
        {
            
            int intCount;
           
            try
            {
                
                intCount = user.getClient().GetStream().EndRead(ar);
                Console.WriteLine(intCount);
                if (intCount < 1)
                {
                    return;
                }
                Console.WriteLine(MyUser + "received a message");
                BuildString(buffer, 0, intCount);
                
                user.getClient().GetStream().BeginRead(buffer, 0, 1024, this.ReadFlow, null);
                
            }catch(Exception e)
            {
                return;
            }
        }
        private string GetLocalIP(IPHostEntry host)
        {
       
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }

            return "192.168.1.1";
        } // get your local ip
        private void label1_(object sender, EventArgs e)
        {
            this.Text = "Hello " + MyUser;
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void UserMessage_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void UserMessage_Focus(object sender, EventArgs e)
        {
            UserMessage.Text = "";
        }       
        private void UserMessage_Focus2(object sender, EventArgs e)
        {
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(addTopic.Text);
            addTopic.Text = "Add Topic";
        }
        private void button2_(object sender, EventArgs e)
        {

        }
        private void addTopic_(object sender, EventArgs e)
        {
            
        }
        private void addTopic_TextChanged(object sender, EventArgs e)
        {

        }
        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string curItem = listBox1.SelectedItem.ToString();
            label1.Text = "Topic "+curItem;
            currentTopic = curItem;
        }
        private void IPAdress_TextChanged(object sender, EventArgs e)
        {

        }
       // send msg to the server
        private void UserChat_TextChanged(object sender, EventArgs e)
        {

        }
        private void Form2_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Handle event here
            System.Windows.Forms.Application.Exit();
        }
        private void Send_Click_1(object sender, EventArgs e)
        {
            user.sendText(MyUser + ": " + UserMessage.Text +"\n");
            UserMessage.Text = " ";
        }//send message
    }
}

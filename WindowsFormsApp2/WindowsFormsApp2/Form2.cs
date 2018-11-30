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

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        Socket sck;
        EndPoint epLocal, epRemote;
        private string currentTopic = null;
        public string MyUser { get; set; }
        public Form2()
        {
            InitializeComponent();
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Tcp);
            sck.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            IPAdress.Text = GetLocalIP();
            IPAdress.ReadOnly = true;
            Initializeconnection();
            
        }
        private string GetLocalIP()
        {
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach(IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }

            return "192.168.1.1";
        }
        private void Initializeconnection()
        {
            try
            {

                epLocal = new IPEndPoint(IPAddress.Parse(IPAdress.Text),80);
                sck.Bind(epLocal);
                epRemote = new IPEndPoint(IPAddress.Parse(IPAdress.Text),81);
                sck.Connect(epRemote);
                byte[] buffer = new byte[1500];
                sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageCallBack), buffer);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private void MessageCallBack(IAsyncResult aResult)
        {
            try
            {
                int size = sck.EndReceiveFrom(aResult, ref epRemote);
                if (size > 0)
                {
                    byte[] receivedData = new byte[1464];
                    receivedData = (byte[])aResult.AsyncState;
                    ASCIIEncoding eEncoding = new ASCIIEncoding();
                    string receivedMessage = eEncoding.GetString(receivedData);
                    UserChat.AppendText(receivedMessage + "\n");
                    
                }
                byte[] buffer = new byte[1500];
                sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageCallBack), buffer);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }
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
        private void Send_Click(object sender, EventArgs e)
        {
            try
            {
                System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
                byte[] msg = new byte[1500];
                msg = enc.GetBytes(MyUser + ": "+ UserMessage.Text +"\n");
                sck.Send(msg);
                UserChat.AppendText(MyUser + ":  " + UserMessage.Text +"\n");
                UserMessage.Clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void UserChat_TextChanged(object sender, EventArgs e)
        {

        }
        private void Form2_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Handle event here
            System.Windows.Forms.Application.Exit();
        }
    }
}

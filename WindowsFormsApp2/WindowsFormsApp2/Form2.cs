using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        public string MyUser { get; set; }
        public Form2()
        {
            InitializeComponent();
            
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
            UserMessage.Text = "Type your message here...";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(addTopic.Text);
            addTopic.Text = "Add Topic";
        }

        

        private void button2_(object sender, EventArgs e)
        {

        }

        private void   addTopic_(object sender, EventArgs e)
        {
            
        }

        private void addTopic_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string curItem = listBox1.SelectedItem.ToString();
            label1.Text = curItem;
        }

        private void UserChat_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

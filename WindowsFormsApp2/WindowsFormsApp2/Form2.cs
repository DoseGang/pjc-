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
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

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
    }
}

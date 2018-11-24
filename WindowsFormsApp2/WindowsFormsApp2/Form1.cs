using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace WindowsFormsApp2
{
    public partial class Form1 : Form 
    {
        Session user = new Session();
        IFormatter formatter = new BinaryFormatter();

        public Form1()
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string UsernameTyped = textBox1.Text ;
            string PasswordTyped = textBox2.Text ;
            Stream stream = new FileStream("C:\\Users\\Doseeee\\Desktop\\Accounts.txt", FileMode.Open, FileAccess.Read);
            
            user = (Session)formatter.Deserialize(stream);

                Console.WriteLine(user.myuser + "......." + user.mypassword);
            if (user.LoginUser(UsernameTyped, PasswordTyped) == true)
            {
               
                Visible = false;
                Form2 k = new Form2();
                k.ShowDialog();
            }

            
            stream.Close();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            user.createAccount(textBox1.Text, textBox2.Text);
            
            Stream stream = new FileStream("C:\\Users\\Doseeee\\Desktop\\Accounts.txt", FileMode.Open, FileAccess.Write);
            formatter.Serialize(stream, user);
            stream.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

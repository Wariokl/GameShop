using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestAsp.Models;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string GetAccesToken()
        {

            string Login = textBox1.Text;
            string Password = textBox2.Text;
            WebRequest request = WebRequest.Create("http://localhost:5000/user/user/login");
            request.Method = "GET";
            
            request.ContentType = "application/json";
            request.Headers.Add("Login",Login);
            request.Headers.Add("Password",Password);
            string result;
            WebResponse response = request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                }                          
            }
            return result;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Enter_Button_Click(object sender, EventArgs e)
        {
            if(Convert.ToBoolean(GetAccesToken())==true)
            {
                
                Form2 f2 = new Form2();
                this.Hide();
             f2.Show();
                

               



            }
            else
            {
                MessageBox.Show("Wrong");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            this.Hide();
           f3.Show();
        }
    }
}

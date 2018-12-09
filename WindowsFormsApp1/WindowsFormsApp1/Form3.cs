﻿using System;
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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private string RegisteUser()
        {
            string N = textBox1.Text;
            string L = textBox2.Text;
            string P = textBox3.Text;
            WebRequest request = WebRequest.Create("http://localhost:5000/user/");
            request.Method = "Post";

            request.ContentType = "application/json";
           
            request.Headers.Add("L",L);
            request.Headers.Add("P",P);
            request.Headers.Add("N", N);
            request.ContentLength = 0;
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
        private void button1_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(RegisteUser()) == true)
            {

                Form1 f1 = new Form1();
                this.Hide();
                f1.Show();
                MessageBox.Show("succsess");





            }
            else
            {
                MessageBox.Show("Wrong");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();

        }
    }
}
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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void getCategories()
        {
            WebRequest request = WebRequest.Create("http://localhost:5000/category/");
            request.Method = "GET";

            request.ContentType = "application/json";

            List<Category>category= new List<Category>();
            string result;
            WebResponse response = request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                }
                foreach (var item in JsonConvert.DeserializeObject<List<Category>>(result))
                    category.Add(item);
            }
            dataGridView1.DataSource = category;
        }

        private void getCompany()
        {
            WebRequest request = WebRequest.Create("http://localhost:5000/Company/");
            request.Method = "GET";

            request.ContentType = "application/json";

            List<Company> company = new List<Company>();

            string result;
            WebResponse response = request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                }
                foreach (var item in JsonConvert.DeserializeObject<List<Company>>(result))
                    company.Add(item);
            }
            dataGridView1.DataSource = company;
        }

        private void getGames()
        {
            WebRequest request = WebRequest.Create("http://localhost:5000/Games/");
            request.Method = "GET";

            request.ContentType = "application/json";

            List<Game> games = new List<Game>();

            string result;
            WebResponse response = request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                }
                foreach (var item in JsonConvert.DeserializeObject<List<Game>>(result))
                    games.Add(item);
            }
            dataGridView1.DataSource = games;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            getCategories();
            dataGridView1.Columns.RemoveAt(0);
            dataGridView1.RowHeadersVisible = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            getCompany();
            dataGridView1.Columns.RemoveAt(0);
            dataGridView1.RowHeadersVisible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            getGames();
            dataGridView1.Columns.RemoveAt(0);
            dataGridView1.RowHeadersVisible = false;
        }
    }
}

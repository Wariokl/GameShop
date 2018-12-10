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
        public Form2(string _UserId)
        {
            UserID = _UserId;

            InitializeComponent();
        }
        string UserID;
        private void getLibrary()
        {
            WebRequest request = WebRequest.Create("http://localhost:5000/Library/");
            request.Method = "GET";

            request.ContentType = "application/json";

            List<Library> libraries = new List<Library>();

            string result;
            WebResponse response = request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                }
                foreach (var item in JsonConvert.DeserializeObject<List<Library>>(result))
                    libraries.Add(item);
            }
            dataGridView1.DataSource = libraries;
            
        }
        private void AddLibrary()
        {
            WebRequest request = WebRequest.Create("http://localhost:5000/Library/");
            request.Method = "POST";
            request.Headers.Add("_userid", UserID);
            request.Headers.Add("_gameid", Convert.ToString(getIdGame()));
            request.ContentType = "application/json";
            request.ContentLength = 0;
            
            WebResponse response = request.GetResponse();
           

        } 
        private List<Category> getCategories()
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
            //dataGridView1.DataSource = category;
            return category;
        }

        private void AddCategories()
        {
            string _Name = textBox5.Text;
            WebRequest request = WebRequest.Create("http://localhost:5000/category/");
            request.Method = "POST";
            request.ContentLength = 0;
            request.ContentType = "application/json";
            request.Headers.Add("_Name", _Name);
            
            WebResponse response = request.GetResponse();
           
        }
        private List<Genre> getGenries()
        {
            WebRequest request = WebRequest.Create("http://localhost:5000/genre/");
            request.Method = "GET";

            request.ContentType = "application/json";

            List<Genre> genres = new List<Genre>();
            string result;
            WebResponse response = request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                }
                foreach (var item in JsonConvert.DeserializeObject<List<Genre>>(result))
                    genres.Add(item);
            }
            //dataGridView1.DataSource = genres;
            return genres;
        }
        private void AddGenries()
        {
            WebRequest request = WebRequest.Create("http://localhost:5000/genre/");
            request.Method = "POST";
            request.ContentLength = 0;
            request.ContentType = "application/json";
            request.Headers.Add("_Name", textBox6.Text);
           
            WebResponse response = request.GetResponse();
            
        }
        private void AddDataSourse()
        {
            List<string> category = new List<string>();
            for (int i = 0; i < getCategories().Count; i++)
            {
                category.Add(getCategories()[i].CategoryName);
            }

            List<string> company = new List<string>();
            for (int i = 0; i < getCompany().Count; i++)
            {
                company.Add(getCompany()[i].CompanyName);
            }

            List<string> genre = new List<string>();
            for (int i = 0; i < getGenries().Count; i++)
            {
                genre.Add(getGenries()[i].GenreName);
            }

            List<string> game = new List<string>();
            for (int i = 0; i < getGames().Count; i++)
            {
               game.Add(getGames()[i].Name);
            }

            comboBox1.DataSource = category;
            comboBox2.DataSource = company;
            comboBox5.DataSource = genre;
            comboBox3.DataSource = game;
        }
        private List<Company> getCompany()
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
           //dataGridView1.DataSource = company;
            return company;
        }
        private void AddCompany()
        {
            WebRequest request = WebRequest.Create("http://localhost:5000/Company/");
            request.Method = "POST";
            request.ContentLength = 0;
            request.ContentType = "application/json";
            request.Headers.Add("_Name", textBox3.Text);
            request.Headers.Add("_Country", textBox4.Text);

           

           
            WebResponse response = request.GetResponse();
            
            
            
        }
        private void AddGames()
        {
            WebRequest request = WebRequest.Create("http://localhost:5000/Games/");
            request.Method = "POST";
            string _name, _category, _company, _price, _genre;


            _name = textBox1.Text;
            _genre = comboBox5.SelectedItem.ToString();
            _category = comboBox1.SelectedItem.ToString();
            _company = comboBox2.SelectedItem.ToString();
            _price = textBox2.Text;

            request.ContentLength = 0;
            request.ContentType = "application/json";
           
                request.Headers.Add("_Name", _name);
           
                request.Headers.Add("_Genre", _genre);
           
                request.Headers.Add("_Category", _category);
           
                request.Headers.Add("_Company", _company);
            
           
                request.Headers.Add("_Price", _price);
            
            
        
            
            WebResponse response = request.GetResponse();
            
        }
        private List<Game> getGames()
        {
            WebRequest request = WebRequest.Create("http://localhost:5000/Games/");
            request.Method = "GET";
            string _name, _category, _company, _price ,_genre;
           
           
           
           
            
            request.ContentType = "application/json";
            if (checkBox1.Checked)
            {
                _name = textBox1.Text;
                request.Headers.Add("_Name", _name);
            }
            else
                request.Headers.Add("_Name", "");
            if (checkBox5.Checked)
            {
                _genre = comboBox5.SelectedItem.ToString();
                request.Headers.Add("_Genre", _genre);
            }
            else
                request.Headers.Add("_Genre", "");
            if (checkBox2.Checked)
            {
                _category = comboBox1.SelectedItem.ToString();
                request.Headers.Add("_Category", _category);
            }
            else
                request.Headers.Add("_Category", "");
            if (checkBox3.Checked)
            {
                _company = comboBox2.SelectedItem.ToString();
                request.Headers.Add("_Company", _company);
            }
            else
                request.Headers.Add("_Company", "");
            if (checkBox4.Checked)
            {
                _price = textBox2.Text;
                request.Headers.Add("_Price", _price);
            }
            else
                request.Headers.Add("_Price", "");
            request.ContentLength = 0;

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
           // dataGridView1.DataSource = games;
            return games;
        }
        private int getIdGame()
        {
            WebRequest request = WebRequest.Create("http://localhost:5000/Games/");
            request.Method = "GET";
            string _name;





            request.ContentType = "application/json";

            _name = comboBox3.SelectedItem.ToString();
                request.Headers.Add("_Name", _name);
           

            request.Headers.Add("_Genre", "");

            request.Headers.Add("_Category", "");

            request.Headers.Add("_Company", "");


            request.Headers.Add("_Price","");

            request.ContentLength = 0;

            
            int gameid=-1;
            string result;
            WebResponse response = request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                }
                foreach (var item in JsonConvert.DeserializeObject<List<Game>>(result))
                {
                    if(item.Name==_name)
                    {
                        gameid = item.Id;
                    }

                }
            }
            // dataGridView1.DataSource = games;
            return gameid;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            AddDataSourse();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(checkBox10.Checked)
            {
                AddCategories();
                AddDataSourse();
            }
            else
            {
                dataGridView1.DataSource=getCategories();
                dataGridView1.Columns.RemoveAt(0);
                dataGridView1.RowHeadersVisible = false;
            }
       
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if(checkBox9.Checked)
            {
                AddCompany();
            }
            else
            {
                dataGridView1.DataSource = getCompany();
                dataGridView1.Columns.RemoveAt(0);
                dataGridView1.RowHeadersVisible = false;
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                
                AddGames();
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;

            }

            else
            {
               dataGridView1.DataSource=getGames();
                dataGridView1.Columns.RemoveAt(0);
                dataGridView1.RowHeadersVisible = false;
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)
            {
                checkBox1.Checked = true;
                checkBox2.Checked = true;
                checkBox3.Checked = true;
                checkBox4.Checked = true;
                checkBox5.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
            }

        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked)
            {
                label1.Visible = true;
              textBox5.Visible = true;
            }
            else
            {
                label1.Visible = false;
                textBox5.Visible = false;
            }
            
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox12.Checked)
            {
                checkBox13.Visible = true;
                textBox6.Visible = true;
            }
            else
            {
                checkBox13.Visible = false;
                textBox6.Visible = false;
            }
            
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox9.Checked)
            {
                textBox3.Visible = true;
                textBox4.Visible = true;
                checkBox7.Visible = true;
                checkBox8.Visible = true;

            }
            else
            {
                textBox3.Visible = false;
                textBox4.Visible = false;
                checkBox7.Visible = false;
                checkBox8.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(checkBox12.Checked)
            {
                AddGenries();
                AddDataSourse();
            }
            else {
                dataGridView1.DataSource = getGenries();
                dataGridView1.Columns.RemoveAt(0);
                dataGridView1.RowHeadersVisible = false;
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (checkBox14.Checked)
            {
                AddLibrary();
            }
            else
            {
                getLibrary();
            }
        }
    }
}

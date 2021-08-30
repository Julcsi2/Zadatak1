using Newtonsoft.Json.Linq;
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

namespace WindowsFormsApp13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string URL = @"https://api.openweathermap.org/data/2.5/weather?q=%name%&units=metric&appid=b0f365a9cfc8b9f80e1e3f9e3b2ff1d9";
        private void button1_Click(object sender, EventArgs e)
        {
            //Za upisani grad, potraži pripadni json iz kojeg iščitam podatke
            string html = string.Empty;
            Gradovi.Items.Add(textBox1.Text);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL.Replace("%name%", textBox1.Text));
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            //Console.WriteLine(html);

            JObject vrijemejson = JObject.Parse(html);

            Vremenska_prognoza.Items.Clear();
            Vremenska_prognoza.Items.Add(" Grad: "+ textBox1.Text);
            Vremenska_prognoza.Items.Add(" Temperatura: " + vrijemejson["main"]["temp"].ToString());
            Vremenska_prognoza.Items.Add(" Osjet: " + vrijemejson["main"]["feels_like"].ToString());
            Vremenska_prognoza.Items.Add(" Minimalna temperatura: " + vrijemejson["main"]["temp_min"].ToString());
            Vremenska_prognoza.Items.Add(" Maksimalna temperatura: " + vrijemejson["main"]["temp_max"].ToString());
            Vremenska_prognoza.Items.Add(" Izgled: " + vrijemejson["weather"][0]["description"].ToString());
            

            //MessageBox.Show(vrijemejson["weather"][0]["id"].ToString());
            textBox1.Text = "";
        }

        private void Gradovi_SelectedIndexChanged(object sender, EventArgs e)   // ako želimo pogledati neki od nedavno pogledanih ponovno
        {
            string ime_grada = Gradovi.SelectedItem.ToString();

            string html = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL.Replace("%name%", ime_grada));
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            JObject vrijemejson = JObject.Parse(html);

            Vremenska_prognoza.Items.Clear();
            Vremenska_prognoza.Items.Add(" Grad: " + ime_grada);
            Vremenska_prognoza.Items.Add(" Temperatura: " + vrijemejson["main"]["temp"].ToString());
            Vremenska_prognoza.Items.Add(" Osjet: " + vrijemejson["main"]["feels_like"].ToString());
            Vremenska_prognoza.Items.Add(" Minimalna temperatura: " + vrijemejson["main"]["temp_min"].ToString());
            Vremenska_prognoza.Items.Add(" Maksimalna temperatura: " + vrijemejson["main"]["temp_max"].ToString());
            Vremenska_prognoza.Items.Add(" Izgled: " + vrijemejson["weather"][0]["description"].ToString());

        }
    }
}

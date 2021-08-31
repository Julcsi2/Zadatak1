using LiveCharts;
using Newtonsoft.Json;
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

            //za spremanje u bazu koja će biti .json dokument
            if (!Directory.Exists(@"C:\temp2"))
            {
                Directory.CreateDirectory(@"C:\temp2");
                if (!File.Exists(@"C:\temp2\temperature.json"))
                {
                    File.Create(@"C:\temp2\temperature.json");
                }
            }
            
        }

        private readonly string filePath = @"C:\temp2\temperature.json";

        public class Temperature_kroz_minute  
        {
            public int minute { get; set; }
            public double temperatura { get; set; }
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

        private void Pozivanje_Tick(object sender, EventArgs e)
        {
            Pozivanje.Stop();
            string Odabrani_grad = "Osijek";

            string html = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL.Replace("%name%", Odabrani_grad));
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }
            JObject vrijemejson = JObject.Parse(html);

            //Svakih 1 min bi se trebalo pozvati, iščitati te ponovno spremiti podatke u .json dokument.

            Temperature_kroz_minute podatak = new Temperature_kroz_minute();

            podatak.minute = DateTime.Now.Minute;
            podatak.temperatura = Convert.ToDouble(vrijemejson["main"]["temp"]);
            string Podatak = JsonConvert.SerializeObject(podatak);

            List<Temperature_kroz_minute> list=null;

            if (File.Exists(filePath))
                list = JsonConvert.DeserializeObject<List<Temperature_kroz_minute>>(File.ReadAllText(filePath));
            if(list == null) list = new List<Temperature_kroz_minute>();
            list.Add(podatak);

            //Iscrtavanje na dijagramu
            UpdateChart(list);
            File.WriteAllText(filePath, JsonConvert.SerializeObject(list));
            Pozivanje.Start();
        }

        private void UpdateChart(List<Temperature_kroz_minute> list)
        {
            chart.Series["Osijek"].Points.Clear();

            foreach (Temperature_kroz_minute t in list)
            {
                chart.Series["Osijek"].Points.AddXY(t.minute, t.temperatura);
            }
            
        }
    }
}

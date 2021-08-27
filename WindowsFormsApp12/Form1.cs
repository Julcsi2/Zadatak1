using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WindowsFormsApp12
{
    public partial class Form1 : Form
    {
        List<podsjeti> podsjetnici = new List<podsjeti>();
        List<rokO> rokovi = new List<rokO>();

        public Form1()
        {
            InitializeComponent();
            foreach (string data in Enum.GetNames(typeof(Prioritet)))
            {
                cbPrioriteti.Items.Add(data);
            }
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            getPodsjetnici();
        }

        public class podsjeti
        {
            public string naziv { get; set; }
            public TimeSpan interval { get; set; }
            public DateTime date { get; set; }
        }

        public class rokO
        {
            public string putanja { get; set; }
            public DateTime rok { get; set; }
        }

        public class zadatak
        {
            public string naziv { get; set; }
            public string opis { get; set; }
            public DateTime rok { get; set; }
            public DateTime vrijeme_podsjetnika { get; set; }
            public string prioritet { get; set; }
            public bool arhiviran { get; set; }
        }


        private void button1_Click(object sender, EventArgs e)    // klikom se stvori novi zadatak i novi .json
        {
            zadatak zad = new zadatak();
            zad.naziv = textBox1.Text;
            zad.opis = textBox2.Text;
            DateTime d = dtRok.Value;
            DateTime t = dateTimePicker2.Value;
            zad.rok = new DateTime(d.Year, d.Month, d.Day, t.Hour, t.Minute, t.Second);
            d = dtPodsjeti.Value;
            t = dateTimePicker1.Value;
            zad.vrijeme_podsjetnika = zad.vrijeme_podsjetnika = new DateTime(d.Year, d.Month, d.Day, t.Hour, t.Minute, t.Second);
            zad.prioritet = cbPrioriteti.SelectedItem.ToString();

            string result = JsonConvert.SerializeObject(zad);

            if (Directory.Exists(@"C:\temp1"))
            {
                string path = @"C:\temp1\" + textBox1.Text + ".json";

                using (var tw = new StreamWriter(path, true))
                {
                    tw.WriteLine(result.ToString());
                }
            }
            else
            {
                Directory.CreateDirectory(@"C:\temp1");
                string path = @"C:\temp1\" + textBox1.Text + ".json";

                using (var tw = new StreamWriter(path, true))
                {
                    tw.WriteLine(result.ToString());
                }

            }
            textBox1.Text = "";
            textBox2.Text = "";
            dtRok.Value = DateTime.Now;
            dtPodsjeti.Value = DateTime.Now;
            dateTimePicker1.Value = DateTime.Now;
            cbPrioriteti.SelectedIndex = -1;
            getPodsjetnici();

        }

        private void button2_Click(object sender, EventArgs e)         // klikom se ispišu svi aktivni zadaci
        {
            Array svi_zadaci = Directory.GetFileSystemEntries(@"C:\temp1");
            Zadaci.Items.Clear();

            //ispis svih hitnih zadataka    --- na početak
            foreach (string s in svi_zadaci)
            {
                //za dobivanje imena jsona
                string[] stringSeparators = new string[] { "\\" };
                string[] novo = s.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                string naziv_zadatka = novo[novo.Length - 1];
                string naziv = "";
                for (int i = 0; i < naziv_zadatka.Length - 5; i++)
                {
                    naziv += naziv_zadatka[i];
                }

                //za čitanje jsona
                using (StreamReader r = new StreamReader(@"C:\temp1\" + naziv_zadatka))
                {
                    string jsonString = r.ReadToEnd();
                    zadatak zad = JsonConvert.DeserializeObject<zadatak>(jsonString);

                    //za ispis svih aktivnih zadataka 
                    if (!zad.arhiviran)
                    {
                        if (zad.prioritet == "hitno" || zad.prioritet == "Hitno")
                        {
                            Zadaci.Items.Add(naziv);
                        }
                    }
                }
            }
            //ispis svih ne hitnih zadataka  -- idu na kraj dok hitni idu na početak
            foreach (string s in svi_zadaci)
            {
                //za dobivanje imena jsona
                string[] stringSeparators = new string[] { "\\" };
                string[] novo = s.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                string naziv_zadatka = novo[novo.Length - 1];
                string naziv = "";
                for (int i = 0; i < naziv_zadatka.Length - 5; i++)
                {
                    naziv += naziv_zadatka[i];
                }

                //za čitanje jsona
                using (
                StreamReader r = new StreamReader(@"C:\temp1\" + naziv_zadatka))
                {
                    string jsonString = r.ReadToEnd();
                    zadatak zad = JsonConvert.DeserializeObject<zadatak>(jsonString);

                    //za ispis svih aktivnih zadataka 
                    if (!zad.arhiviran)
                    {
                        if (zad.prioritet != "hitno" && zad.prioritet != "Hitno")
                        {
                            Zadaci.Items.Add(naziv);
                        }

                    }
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)       // ispiše sve arhivirane zadatke
        {
            Array svi_zadaci = System.IO.Directory.GetFileSystemEntries(@"C:\temp1");
            Zadaci.Items.Clear();

            //ispis svih zadataka
            foreach (string s in svi_zadaci)
            {
                //za dobivanje imena jsona
                string[] stringSeparators = new string[] { "\\" };
                string[] novo = s.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                string naziv_zadatka = novo[novo.Length - 1];
                string naziv = "";
                for (int i = 0; i < naziv_zadatka.Length - 5; i++)
                {
                    naziv += naziv_zadatka[i];
                }

                //za čitanje jsona
                using (StreamReader r = new StreamReader(@"C:\temp1\" + naziv_zadatka))
                {
                    string jsonString = r.ReadToEnd();
                    zadatak zad = JsonConvert.DeserializeObject<zadatak>(jsonString);

                    //za ispis svih arhiviranih zadataka 
                    if (zad.arhiviran)
                    { Zadaci.Items.Add(naziv); }
                }


            }
        }

        private void Zadaci_SelectedIndexChanged(object sender, EventArgs e)   // kada se klikne na neki od zadataka on se ispiše u najdesniji prozor
        {
            string zadatak_ime = Zadaci.SelectedItem.ToString();

            using (StreamReader r = new StreamReader(@"C:\temp1\" + zadatak_ime + ".json"))
            {
                string jsonString = r.ReadToEnd();
                zadatak zad = JsonConvert.DeserializeObject<zadatak>(jsonString);

                Zadatak.Items.Clear();

                Zadatak.Items.Add("Naziv: " + zad.naziv);
                Zadatak.Items.Add("Opis: " + zad.opis);
                Zadatak.Items.Add("Rok: " + zad.rok);
                Zadatak.Items.Add("Vrijeme podsjetnika: " + zad.vrijeme_podsjetnika);
                Zadatak.Items.Add("Prioritet: " + zad.prioritet);
            }
        }

        private void button5_Click(object sender, EventArgs e)      // mijenjanje je riješeno zamjenom postojećeg s novim
        {
            string zadatak_ime = Zadaci.SelectedItem.ToString();

            if (File.Exists(@"C:\temp1\" + zadatak_ime + ".json"))
            {
                Zadaci.Items.Clear();
                File.Delete(@"C:\temp1\" + zadatak_ime + ".json");

                zadatak zad = new zadatak();        //spremanje novih/straih podataka
                zad.naziv = textBox1.Text;
                zad.opis = textBox2.Text;
                DateTime d = dtRok.Value;
                DateTime t = dateTimePicker2.Value;
                zad.rok = new DateTime(d.Year, d.Month, d.Day, t.Hour, t.Minute, t.Second);
                d = dtPodsjeti.Value;
                t = dateTimePicker1.Value;
                zad.vrijeme_podsjetnika = zad.vrijeme_podsjetnika = new DateTime(d.Year, d.Month, d.Day, t.Hour, t.Minute, t.Second);
                zad.prioritet = cbPrioriteti.SelectedItem.ToString();
                string result = JsonConvert.SerializeObject(zad);

                string path = @"C:\temp1\" + textBox1.Text + ".json";  //sve što je novo ili što nije ponovno sprema

                using (var tw = new StreamWriter(path, true))
                {
                    tw.WriteLine(result.ToString());
                }

                textBox1.Text = "";  //kad je gotovo neka isprazni 
                textBox2.Text = "";
                dtRok.Value = DateTime.Now;
                dtPodsjeti.Value = DateTime.Now;
                dateTimePicker1.Value = DateTime.Now;
                cbPrioriteti.SelectedIndex = -1;

            }
            getPodsjetnici();
        }

        private void button4_Click(object sender, EventArgs e)     // prebaci sve trenutne podatke u textBoxove gdje se mogu mijenjati
        {

            string zadatak_ime = Zadaci.SelectedItem.ToString();

            //čitanje iz jsona
            using (StreamReader r = new StreamReader(@"C:\temp1\" + zadatak_ime + ".json"))
            {
                string jsonString = r.ReadToEnd();
                zadatak zad = JsonConvert.DeserializeObject<zadatak>(jsonString);

                //očisti listbox Zadatak i sav tekst prebaci na početak gdje se može mijenjati
                Zadatak.Items.Clear();

                textBox1.Text = zad.naziv;
                textBox2.Text = zad.opis;
                dtRok.Value = zad.rok;
                dtPodsjeti.Value = zad.vrijeme_podsjetnika;
                cbPrioriteti.SelectedItem = zad.prioritet;
            }
        }

        private void button6_Click(object sender, EventArgs e)    //Brisanje odabranog zadatka briše njegov .json
        {
            timer.Stop();
            timer1.Stop();
            string zadatak_ime = Zadaci.SelectedItem.ToString();

            File.Delete(@"C:\temp1\" + zadatak_ime + ".json");
            Zadatak.Items.Clear();
            button2_Click(sender, e);                             // Pozvala sam ponovno ispisivanje zadataka

            timer.Start();
            timer1.Start();
        }

        private void getPodsjetnici()                             // Za dohvacanje
        {
            podsjetnici.Clear();
            rokovi.Clear();
            timer.Stop();
            Array svi_zadaci = Directory.GetFileSystemEntries(@"C:\temp1");
            foreach (string s in svi_zadaci)
            {

                using (StreamReader r = new StreamReader(s))
                {
                    string jsonString = r.ReadToEnd();
                    zadatak zad = JsonConvert.DeserializeObject<zadatak>(jsonString);
                    if (!zad.arhiviran)
                    {
                        TimeSpan ts = zad.vrijeme_podsjetnika.Subtract(DateTime.Now);
                        if (ts.TotalMilliseconds > 0)
                            podsjetnici.Add(new podsjeti
                            {
                                naziv = zad.naziv,
                                date = zad.vrijeme_podsjetnika,
                                interval = ts
                            });
                        rokovi.Add(new rokO
                        {
                            putanja = s,
                            rok = zad.rok
                        });
                    }

                }
            }
            podsjetnici = podsjetnici.OrderBy(x => x.interval).ToList();
            if (podsjetnici.Count > 0)
            {
                timer.Interval = Convert.ToInt32(podsjetnici[0].interval.TotalMilliseconds);
                timer.Start();
            }
        }

        private void timer_Tick(object sender, EventArgs e)       // timer za podsječanje na neki zadatak
        {
            timer.Stop();
            podsjetnici.RemoveAt(0);
            if (podsjetnici.Count > 0)
            {
                string naziv = podsjetnici[0].naziv;
                foreach (podsjeti p in podsjetnici)
                {
                    p.interval = p.date.Subtract(DateTime.Now);
                }
                timer.Interval = Convert.ToInt32(podsjetnici[0].interval.TotalMilliseconds);
                timer.Start();
                MessageBox.Show("Podsjetnik za zadatak " + naziv, "Podsjetnik");
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)   //Služi za arhiviranje
        {
            DateTime now = DateTime.Now;
            if (rokovi.Any(x => x.rok < now))
            {
                foreach (rokO r in rokovi.Where(x => x.rok < now))
                {
                    string jsonString;
                    using (StreamReader sr = new StreamReader(r.putanja))
                    {
                        jsonString = sr.ReadToEnd();
                    }
                    using (StreamWriter sw = new StreamWriter(r.putanja, false))
                    {
                        zadatak zad = JsonConvert.DeserializeObject<zadatak>(jsonString);
                        zad.arhiviran = true;
                        sw.WriteLine(JsonConvert.SerializeObject(zad));
                    }
                }
                rokovi.RemoveAll(x => x.rok < now);
                if (rokovi.Count == 0) timer1.Stop();
            }
            
        }



        //var date1 = new DateTime(2008, 5, 1, 8, 30, 52); 
    }

    public enum Prioritet
    {
        Nizak = 1,
        Visok = 2,
        Hitno = 3
    }
}

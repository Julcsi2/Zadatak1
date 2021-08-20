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
        public Form1()
        {
            InitializeComponent();

        }

        public class zadatak
        {
            public string naziv { get; set; }
            public string opis { get; set; }
            public string rok { get; set; }
            public string vrijeme_podsjetnika { get; set; }
            public string prioritet { get; set; }
            public bool arhiviran { get; set; }
        }
        

        private void button1_Click(object sender, EventArgs e)    // klikom se stvori novi zadatak i novi .json
        {
            zadatak zad = new zadatak();
            zad.naziv = textBox1.Text;
            zad.opis = textBox2.Text;
            zad.rok = textBox3.Text;
            zad.vrijeme_podsjetnika = textBox4.Text;
            zad.prioritet = textBox5.Text;

            string result = JsonConvert.SerializeObject(zad);

            if (Directory.Exists(@"C:\temp1"))
            {
                string path = @"C:\temp1\"+ textBox1.Text + ".json";

                using (var tw = new StreamWriter(path, true))
                {
                    tw.WriteLine(result.ToString());
                    tw.Close();
                }
            }
            else
            {
                DirectoryInfo novi_album = Directory.CreateDirectory(@"C:\temp1");
                string path = @"C:\temp1\" + textBox1.Text + ".json";

                using (var tw = new StreamWriter(path, true))
                {
                    tw.WriteLine(result.ToString());
                    tw.Close();
                }

            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";

        }

        private void button2_Click(object sender, EventArgs e)         // klikom se ispišu svi aktivni zadaci
        {
            Array svi_zadaci = System.IO.Directory.GetFileSystemEntries(@"C:\temp1");
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
                StreamReader r = new StreamReader(@"C:\temp1\"+naziv_zadatka);
                string jsonString = r.ReadToEnd();                
                zadatak zad = JsonConvert.DeserializeObject<zadatak>(jsonString);

                //za ispis svih aktivnih zadataka 
                if (!zad.arhiviran) 
                { 
                    if(zad.prioritet=="hitno" || zad.prioritet=="Hitno")
                    {
                        Zadaci.Items.Add(naziv);
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
                StreamReader r = new StreamReader(@"C:\temp1\" + naziv_zadatka);
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
                StreamReader r = new StreamReader(@"C:\temp1\" + naziv_zadatka);
                string jsonString = r.ReadToEnd();
                zadatak zad = JsonConvert.DeserializeObject<zadatak>(jsonString);

                //za ispis svih arhiviranih zadataka 
                if (zad.arhiviran)
                { Zadaci.Items.Add(naziv); }


            }
        }

        private void Zadaci_SelectedIndexChanged(object sender, EventArgs e)   // kada se klikne na neki od zadataka on se ispiše u najdesniji prozor
        {
            string zadatak_ime = Zadaci.SelectedItem.ToString();
            
            StreamReader r = new StreamReader(@"C:\temp1\"+zadatak_ime+".json" );
            string jsonString = r.ReadToEnd();
            zadatak zad = JsonConvert.DeserializeObject<zadatak>(jsonString);

            Zadatak.Items.Clear();

            Zadatak.Items.Add("Naziv: " + zad.naziv);
            Zadatak.Items.Add("Opis: " + zad.opis);
            Zadatak.Items.Add("Rok: " + zad.rok);
            Zadatak.Items.Add("Vrijeme podsjetnika: " + zad.vrijeme_podsjetnika);
            Zadatak.Items.Add("Prioritet: " + zad.prioritet);
            
        }

        private void button5_Click(object sender, EventArgs e)      // mijenjanje je riješeno zamjenom postojećeg s novim
        {
            timer.Stop();
            timer1.Stop();
            string zadatak_ime = Zadaci.SelectedItem.ToString(); 

            if (File.Exists(@"C:\temp1\" + zadatak_ime + ".json"))
            {
                Zadaci.Items.Clear();
                File.Delete(@"C:\temp1\" + zadatak_ime + ".json");

                zadatak zad = new zadatak();        //spremanje novih/straih podataka
                zad.naziv = textBox1.Text;
                zad.opis = textBox2.Text;
                zad.rok = textBox3.Text;
                zad.vrijeme_podsjetnika = textBox4.Text;
                zad.prioritet = textBox5.Text;
                string result = JsonConvert.SerializeObject(zad);

                string path = @"C:\temp1\" + textBox1.Text + ".json";  //sve što je novo ili što nije ponovno sprema

                using (var tw = new StreamWriter(path, true))
                {
                    tw.WriteLine(result.ToString());
                    tw.Close();
                }

                textBox1.Text = "";  //kad je gotovo neka isprazni 
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";

            }
            timer.Start();
            timer1.Start();
        }

        private void button4_Click(object sender, EventArgs e)     // prebaci sve trenutne podatke u textBoxove gdje se mogu mijenjati
        {
    
            string zadatak_ime = Zadaci.SelectedItem.ToString();

            //čitanje iz jsona
            StreamReader r = new StreamReader(@"C:\temp1\" + zadatak_ime + ".json");
            string jsonString = r.ReadToEnd();
            zadatak zad = JsonConvert.DeserializeObject<zadatak>(jsonString);

            //očisti listbox Zadatak i sav tekst prebaci na početak gdje se može mijenjati
            Zadatak.Items.Clear();

            textBox1.Text = zad.naziv;
            textBox2.Text = zad.opis;
            textBox3.Text = zad.rok;
            textBox4.Text = zad.vrijeme_podsjetnika;
            textBox5.Text = zad.prioritet;
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

        private void timer_Tick(object sender, EventArgs e)       // timer za podsječanje na neki zadatak
        {
            Array svi_zadaci = System.IO.Directory.GetFileSystemEntries(@"C:\temp1");     //otvori sve zadatke
            string vrijeme_pod = "";
            string nazivi_zadataka = "";
            foreach(string s in svi_zadaci)
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
                StreamReader r = new StreamReader(@"C:\temp1\" + naziv_zadatka);
                string jsonString = r.ReadToEnd();
                zadatak zad = JsonConvert.DeserializeObject<zadatak>(jsonString);

                //dobivanje svih vremena za podsjetnike i naziva zadataka
                if (!zad.arhiviran)
                {
                    vrijeme_pod += zad.vrijeme_podsjetnika + " ";
                    nazivi_zadataka += zad.naziv + " ";
                }
                
            }
            string[] svi_podsjetnici = vrijeme_pod.Split(' ');
            string[] svi_nazivi = nazivi_zadataka.Split(' ');
            int a = -1;  //broj koji će dati indeks
            int b = -1;  //broj za separiranje
            //string broj5 = "";
            foreach (string s in svi_podsjetnici)
            {
                string[] l = s.Split(new string[]{ "," }, StringSplitOptions.RemoveEmptyEntries);
                a++;
                //int x = Convert.ToInt32(l[4]);

                //int y = Convert.ToInt32(l[3]);
                //Console.WriteLine(y);
                b = -1;
                string broj2 = ""; //dan
                string broj3 = "";//sati
                string broj4 = "";//minute
                foreach(char slovo in s)   //petlja da dobijem dane, sate i minute
                {
                    if (b == 1 && slovo != ',')
                    {
                        broj2 += slovo;
                    }
                    if (b == 2 && slovo!=',')
                    {
                        broj3 += slovo;                       
                    }
                    if (b == 3 && slovo!=',')
                    {
                        broj4 += slovo;
                    }
                    
                    if (slovo == ',')
                    {
                        b++;
                    }
                }
                if (broj2 == "")
                {
                    broj2 += 0;
                }
                if (broj3 == "")
                {
                    broj3 += 0;
                }
                if (broj4 == "")
                {
                    broj4 += 0;
                }
                // Uzela sam samo sate i minute jer želim da me što prije podsjeti
                //Console.WriteLine(broj4);
                if (DateTime.Now.Day== (1*Convert.ToInt32(broj2.ToString())) && DateTime.Now.Hour==(1*Convert.ToInt32(broj3.ToString())) && DateTime.Now.Minute == (1*Convert.ToInt32(broj4.ToString())) )//&& DateTime.Now.Second==20)
                {
                   MessageBox.Show("Podsjetnik za zadatak naziva: "+svi_nazivi[a+1]);
                }
            }
            //Console.WriteLine("tick");
        }

        private void timer1_Tick(object sender, EventArgs e)   //Ne valja   služilo bi za arhiviranje
        {   /*
            Array svi_zadaci = System.IO.Directory.GetFileSystemEntries(@"C:\temp1");     //otvori sve zadatke
            string vrijeme_roka = "";
            string nazivi_zadataka = "";
            string ime = "";
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
                StreamReader r = new StreamReader(@"C:\temp1\" + naziv_zadatka);
                string jsonString = r.ReadToEnd();
                zadatak zad = JsonConvert.DeserializeObject<zadatak>(jsonString);

                //dobivanje svih vremena za rokove i nazive
                if (!zad.arhiviran)
                {
                    vrijeme_roka += zad.vrijeme_podsjetnika + " ";
                    nazivi_zadataka += zad.naziv + " ";
                }

                string[] svi_rokovi = vrijeme_roka.Split(' ');
                string[] svi_nazivi = nazivi_zadataka.Split(' ');
                
                int b = -1;  //broj za separiranje

                string broj0 = ""; //godina
                string broj1 = "";  //mjesec
                string broj2 = "";  //dan
                string broj3 = "";
                string broj4 = ""; //minuta
                string broj5 = ""; //sekunda
                foreach (char slovo in s)   //petlja da dobijem dane, sate i minute
                {
                    if (b == -1 && slovo != ',')
                    {
                        broj0 += slovo;
                    }
                    if (b == 0 && slovo != ',')
                    {
                        broj1 += slovo;
                    }
                    if (b == 1 && slovo != ',')
                    {
                        broj2 += slovo;
                    }
                    if (b == 2 && slovo != ',')
                    {
                        broj3 += slovo;
                    }
                    if (b == 3 && slovo != ',')
                    {
                        broj4 += slovo;
                    }
                    if (b == 4 && slovo != ',')
                    {
                        broj5 += slovo;
                    }
                    if (slovo == ',')
                    {
                        b++;
                    }
                }
                if (broj2 == "")
                {
                    broj0 = "0"; broj1 = "0";
                    broj2 += 0; broj3 = "0"; broj4 = "0"; broj5 = "0";
                }

                TimeSpan rok = new TimeSpan(Convert.ToInt32(broj2), Convert.ToInt32(broj3), Convert.ToInt32(broj4), Convert.ToInt32(broj5));
                TimeSpan trenutno = new TimeSpan(DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

                int result = TimeSpan.Compare(rok, trenutno);

                if (result == 0 || result==-1)    //arhiviranje
                {
                    zadatak zad2 = new zadatak();
                    zad2.naziv = zad.naziv;
                    zad2.opis = zad.opis;
                    zad2.rok = zad.rok;
                    zad2.vrijeme_podsjetnika = zad.vrijeme_podsjetnika;
                    zad2.prioritet = zad.prioritet;
                    zad2.arhiviran = true;

                    string result2 = JsonConvert.SerializeObject(zad2);
                    Zadatak.Items.Clear();
                    Zadaci.Items.Clear();
                    File.Delete(@"C:\temp1\" + zad.naziv + ".json");
                    string path = @"C:\temp1\" + zad2.naziv + ".json";  //spremit će kao arhivirano

                    using (var tw = new StreamWriter(path, true))
                    {
                        tw.WriteLine(result2.ToString());
                        tw.Close();
                    }

                    Zadaci.Items.Clear();
                    button2_Click(sender, e);
                }
                
            }/*
            //kada otvorimo program samo onda treba provjeriti ima li novih arhiviranih
            timer1.Enabled = false;
            timer1.Stop();
            timer.Enabled = true;
            timer.Start();
            
             */
        }



        //var date1 = new DateTime(2008, 5, 1, 8, 30, 52); 
    }
}

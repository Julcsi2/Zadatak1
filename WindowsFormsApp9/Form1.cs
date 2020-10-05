using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace WindowsFormsApp9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string filePath = string.Empty;
        int kraj = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
            }
        }
        /* Nakon otvaranja prvo će napraviti sve prefikse, zatim postfikse, stvoriti dvije pa nakon toga tri riječi 
         * iz riječnika s tim uspoređivati našu šifru ako u nekom trenutku naiđe na nju ispisuje se poruka 
         * program se prisilno može zaustaviti,
         * inače nastavlja sa generiranjem svih velikih i malih slova te zamjena s brojevima, ako nismo naišli na šifru 
         * ispisuje se prikladna poruka i možemo zatvoriti program.
         */
        public void provjera(string rj)                       ////////////funkcija za provjeru da li smo izgenerirali šifru
        {
            if (rj == textBox1.Text)
            {
                MessageBox.Show("Šifra nije dovoljno kompleksna.\n Prisilno zaustavite program radi zatvaranja.");
                
                if (MessageBox.Show("Šifra nije dovoljno kompleksna.\n Prisilno zaustavite program radi zatvaranja.") == DialogResult.OK)
                {
                    kraj = 1;
                    this.Close();//Ne radi što bi ja htjela da radi. Ne zautavlja daljnu provjeru samo zatvori prozor

                }
                //this.Close();  ne zaustavlja daljnju provjeru u pozadini
            }
        }
        public void izvođenje(string s)         ///////// dodatna funkcija za slova <-> brojeve 
        {
            StringBuilder rj = new StringBuilder();
            //string rj = "";
            rj.Clear();
            int p = 0;

            while (p < s.Length)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (p < i)
                    {
                        rj.Append(s[i]);
                    }
                    else if (p == i)
                    {
                        rj.Append(s[i].ToString().ToUpper());
                    }
                    else
                    {
                        rj.Append(s[i]);
                    }

                }
                provjera(rj.ToString());
                p++;
                rj.Clear();
            }
            p = 0;

            for (int i = 0; i < s.Length; i++)
            {
                for (int n = 0; n < s.Length; n++)
                {
                    for (int m = 0; m < s.Length; m++)
                    {
                        for (int k = 0; k < s.Length; k++)
                        {
                            if (s.Length > 3)
                            {
                                for (int l = 0; l < s.Length; l++)
                                {
                                    for (int o = 0; o < s.Length; o++)
                                    {
                                        if (s.Length > 5)
                                        {
                                            for (int b = 0; b < s.Length; b++)
                                            {
                                                if (s.Length > 6)
                                                {
                                                    for (int d = 0; d < s.Length; d++)
                                                    {
                                                        for (int h = 0; h < s.Length; h++)
                                                        {
                                                            for (int j = 0; j < s.Length; j++)
                                                            {
                                                                if (i == j || k == j || l == j || n == j || m == j || o == j || b == j || d == j || h == j)
                                                                {
                                                                    rj.Append(s[j].ToString().ToUpper());
                                                                }
                                                                else
                                                                {
                                                                    rj.Append(s[j]);
                                                                }
                                                            }
                                                            provjera(rj.ToString());
                                                            rj.Clear();
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (i == b || k == b || l == b || n == b || m == b)
                                                    {
                                                        rj.Append(s[b].ToString().ToUpper());
                                                    }
                                                    else
                                                    {
                                                        rj.Append(s[b]);
                                                    }
                                                }
                                            }
                                            if (s.Length <= 6)
                                            {
                                                provjera(rj.ToString());
                                                rj.Clear();
                                                if (kraj == 1)
                                                {
                                                    Application.Exit();
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (i == o || k == o || l == o || n == o || m == o)
                                            {
                                                rj.Append(s[o].ToString().ToUpper());
                                            }
                                            else
                                            {
                                                rj.Append(s[o]);
                                            }

                                        }    //zatvara se if i for s b-om
                                    }
                                    if (s.Length <= 5)
                                    {
                                        provjera(rj.ToString());
                                        rj.Clear();
                                        if (kraj == 1)
                                        {
                                            Application.Exit();
                                            break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (i == k || n == k || m == k)
                                {
                                    rj.Append(s[k].ToString().ToUpper());
                                }
                                else
                                {
                                    rj.Append(s[k]);
                                }
                            }
                        }
                        if (s.Length <= 3)
                        {
                            provjera(rj.ToString());
                            rj.Clear();
                            if (kraj == 1)
                            {
                                Application.Exit();
                                break;
                            }
                        }
                    }
                }
            }
        }

            private void button2_Click(object sender, EventArgs e)
        {
            Dictionary<int, string> Rijecnik = new Dictionary<int, string>();
            int a =0;
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line1;

                    while ((line1 = sr.ReadLine()) != null)
                    {
                        //string[] pomocna = line1.Split();
                        //MessageBox.Show(line1);
                        Rijecnik.Add(a, line1);
                        a++;
                    }
                }
            }
            catch (Exception x)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(x.Message);
            }

            Dictionary<int, string>.ValueCollection RijecnikValue = Rijecnik.Values;
            foreach(string s in RijecnikValue)
            {
                provjera(s);
            }

            foreach (string s in RijecnikValue)
            {
                int p = 0;
                int duljina = 0;
                string[] znakovi = textBox2.Text.Split();
                string rj = "";

                if (int.TryParse(textBox3.Text, out p))
                {
                    duljina = Convert.ToInt32(textBox3.Text);
                }


                if (duljina == 0)
                {
                    MessageBox.Show("Nema kombinacija");
                }
                else if (duljina == 1)
                {
                    for (int i = 0; i < znakovi.Length; i++)
                    {
                        rj += znakovi[i];
                        rj += s;
                        provjera(rj);
                        rj = "";
                    }
                }
                else if (duljina == 2)
                {
                    for (int i = 0; i < znakovi.Length; i++)
                    {
                        for (int j = 0; j < znakovi.Length; j++)
                        {
                            rj += znakovi[i];
                            rj += znakovi[j];
                            rj += s;
                            provjera(rj);
                            rj = "";
                        }

                    }
                }
                else if (duljina == 3)
                {
                    for (int i = 0; i < znakovi.Length; i++)
                    {
                        for (int j = 0; j < znakovi.Length; j++)
                        {
                            for (int k = 0; k < znakovi.Length; k++)
                            {

                                rj += znakovi[i];
                                rj += znakovi[j];
                                rj += znakovi[k];
                                rj += s;
                                provjera(rj);
                                rj = "";
                            }

                        }
                    }
                }
                else if (duljina == 4)
                {
                    for (int i = 0; i < znakovi.Length; i++)
                    {
                        for (int j = 0; j < znakovi.Length; j++)
                        {
                            for (int k = 0; k < znakovi.Length; k++)
                            {
                                for (int l = 0; l < znakovi.Length; l++)
                                {

                                    rj += znakovi[i];
                                    rj += znakovi[j];
                                    rj += znakovi[k];
                                    rj += znakovi[l];
                                    rj += s;
                                    provjera(rj);
                                    rj = "";
                                }
                            }

                        }
                    }
                }
                else if (duljina == 5)
                {
                    for (int i = 0; i < znakovi.Length; i++)
                    {
                        for (int j = 0; j < znakovi.Length; j++)
                        {
                            for (int k = 0; k < znakovi.Length; k++)
                            {
                                for (int l = 0; l < znakovi.Length; l++)
                                {
                                    for (int m = 0; m < znakovi.Length; m++)
                                    {

                                        rj += znakovi[i];
                                        rj += znakovi[j];
                                        rj += znakovi[k];
                                        rj += znakovi[l];
                                        rj += znakovi[m];
                                        rj += s;
                                        provjera(rj);
                                        rj = "";
                                    }
                                }
                            }
                        }
                    }
                }
                else if (duljina == 6)
                {
                    for (int i = 0; i < znakovi.Length; i++)
                    {
                        for (int j = 0; j < znakovi.Length; j++)
                        {
                            for (int k = 0; k < znakovi.Length; k++)
                            {
                                for (int l = 0; l < znakovi.Length; l++)
                                {
                                    for (int m = 0; m < znakovi.Length; m++)
                                    {
                                        for (int n = 0; n < znakovi.Length; n++)
                                        {

                                            rj += znakovi[i];
                                            rj += znakovi[j];
                                            rj += znakovi[k];
                                            rj += znakovi[l];
                                            rj += znakovi[m];
                                            rj += znakovi[n];
                                            rj += s;
                                            provjera(rj);
                                            rj = "";
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else if (duljina == 7)
                {
                    for (int i = 0; i < znakovi.Length; i++)
                    {
                        for (int j = 0; j < znakovi.Length; j++)
                        {
                            for (int k = 0; k < znakovi.Length; k++)
                            {
                                for (int l = 0; l < znakovi.Length; l++)
                                {
                                    for (int m = 0; m < znakovi.Length; m++)
                                    {
                                        for (int n = 0; n < znakovi.Length; n++)
                                        {
                                            for (int o = 0; o < znakovi.Length; o++)
                                            {

                                                rj += znakovi[i];
                                                rj += znakovi[j];
                                                rj += znakovi[k];
                                                rj += znakovi[l];
                                                rj += znakovi[m];
                                                rj += znakovi[n];
                                                rj += znakovi[o];
                                                rj += s;
                                                provjera(rj);
                                                rj = "";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else if (duljina == 8)
                {
                    for (int i = 0; i < znakovi.Length; i++)
                    {
                        for (int j = 0; j < znakovi.Length; j++)
                        {
                            for (int k = 0; k < znakovi.Length; k++)
                            {
                                for (int l = 0; l < znakovi.Length; l++)
                                {
                                    for (int m = 0; m < znakovi.Length; m++)
                                    {
                                        for (int n = 0; n < znakovi.Length; n++)
                                        {
                                            for (int o = 0; o < znakovi.Length; o++)
                                            {
                                                for (int r = 0; r < znakovi.Length; r++)
                                                {

                                                    rj += znakovi[i];
                                                    rj += znakovi[j];
                                                    rj += znakovi[k];
                                                    rj += znakovi[l];
                                                    rj += znakovi[m];
                                                    rj += znakovi[n];
                                                    rj += znakovi[o];
                                                    rj += znakovi[r];
                                                    rj += s;
                                                    provjera(rj);
                                                    rj = "";
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            foreach (string s in RijecnikValue)
            {
                int p = 0;
                int duljina = 0;
                string[] znakovi = textBox2.Text.Split();
                string rj = "";

                if (int.TryParse(textBox3.Text, out p))
                {
                    duljina = Convert.ToInt32(textBox3.Text);
                }


                if (duljina == 0)
                {
                    MessageBox.Show("Nema kombinacija");
                }
                else if (duljina == 1)
                {
                    for (int i = 0; i < znakovi.Length; i++)
                    {
                        rj += s;
                        rj += znakovi[i];
                        provjera(rj);
                        rj = "";
                    }
                }
                else if (duljina == 2)
                {
                    for (int i = 0; i < znakovi.Length; i++)
                    {
                        for (int j = 0; j < znakovi.Length; j++)
                        {
                            rj += s;
                            rj += znakovi[i];
                            rj += znakovi[j];
                            provjera(rj);
                            rj = "";
                        }

                    }
                }
                else if (duljina == 3)
                {
                    for (int i = 0; i < znakovi.Length; i++)
                    {
                        for (int j = 0; j < znakovi.Length; j++)
                        {
                            for (int k = 0; k < znakovi.Length; k++)
                            {
                                rj += s;
                                rj += znakovi[i];
                                rj += znakovi[j];
                                rj += znakovi[k];
                                provjera(rj);
                                rj = "";
                            }

                        }
                    }
                }
                else if (duljina == 4)
                {
                    for (int i = 0; i < znakovi.Length; i++)
                    {
                        for (int j = 0; j < znakovi.Length; j++)
                        {
                            for (int k = 0; k < znakovi.Length; k++)
                            {
                                for (int l = 0; l < znakovi.Length; l++)
                                {
                                    rj += s;
                                    rj += znakovi[i];
                                    rj += znakovi[j];
                                    rj += znakovi[k];
                                    rj += znakovi[l];
                                    provjera(rj);
                                    rj = "";
                                }
                            }

                        }
                    }
                }
                else if (duljina == 5)
                {
                    for (int i = 0; i < znakovi.Length; i++)
                    {
                        for (int j = 0; j < znakovi.Length; j++)
                        {
                            for (int k = 0; k < znakovi.Length; k++)
                            {
                                for (int l = 0; l < znakovi.Length; l++)
                                {
                                    for (int m = 0; m < znakovi.Length; m++)
                                    {
                                        rj += s;
                                        rj += znakovi[i];
                                        rj += znakovi[j];
                                        rj += znakovi[k];
                                        rj += znakovi[l];
                                        rj += znakovi[m];
                                        provjera(rj);
                                        rj = "";
                                    }
                                }
                            }
                        }
                    }
                }
                else if (duljina == 6)
                {
                    for (int i = 0; i < znakovi.Length; i++)
                    {
                        for (int j = 0; j < znakovi.Length; j++)
                        {
                            for (int k = 0; k < znakovi.Length; k++)
                            {
                                for (int l = 0; l < znakovi.Length; l++)
                                {
                                    for (int m = 0; m < znakovi.Length; m++)
                                    {
                                        for (int n = 0; n < znakovi.Length; n++)
                                        {
                                            rj += s;
                                            rj += znakovi[i];
                                            rj += znakovi[j];
                                            rj += znakovi[k];
                                            rj += znakovi[l];
                                            rj += znakovi[m];
                                            rj += znakovi[n];
                                            provjera(rj);
                                            rj = "";
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else if (duljina == 7)
                {
                    for (int i = 0; i < znakovi.Length; i++)
                    {
                        for (int j = 0; j < znakovi.Length; j++)
                        {
                            for (int k = 0; k < znakovi.Length; k++)
                            {
                                for (int l = 0; l < znakovi.Length; l++)
                                {
                                    for (int m = 0; m < znakovi.Length; m++)
                                    {
                                        for (int n = 0; n < znakovi.Length; n++)
                                        {
                                            for (int o = 0; o < znakovi.Length; o++)
                                            {
                                                rj += s;
                                                rj += znakovi[i];
                                                rj += znakovi[j];
                                                rj += znakovi[k];
                                                rj += znakovi[l];
                                                rj += znakovi[m];
                                                rj += znakovi[n];
                                                rj += znakovi[o];
                                                provjera(rj);
                                                rj = "";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else if (duljina == 8)
                {
                    for (int i = 0; i < znakovi.Length; i++)
                    {
                        for (int j = 0; j < znakovi.Length; j++)
                        {
                            for (int k = 0; k < znakovi.Length; k++)
                            {
                                for (int l = 0; l < znakovi.Length; l++)
                                {
                                    for (int m = 0; m < znakovi.Length; m++)
                                    {
                                        for (int n = 0; n < znakovi.Length; n++)
                                        {
                                            for (int o = 0; o < znakovi.Length; o++)
                                            {
                                                for (int r = 0; r < znakovi.Length; r++)
                                                {
                                                    rj += s;
                                                    rj += znakovi[i];
                                                    rj += znakovi[j];
                                                    rj += znakovi[k];
                                                    rj += znakovi[l];
                                                    rj += znakovi[m];
                                                    rj += znakovi[n];
                                                    rj += znakovi[o];
                                                    rj += znakovi[r];
                                                    provjera(rj);
                                                    rj = "";
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            foreach (string s in RijecnikValue)
            {
                int p = 0;
                int duljina = 0;
                string[] znakovi = textBox2.Text.Split();
                string rj = "";

                if (int.TryParse(textBox3.Text, out p))
                {
                    duljina = Convert.ToInt32(textBox3.Text);
                }


                if (duljina == 0)
                {
                    MessageBox.Show("Nema kombinacija");
                }
                else if (duljina == 1)
                {
                    for (int i = 0; i < znakovi.Length; i++)
                    {
                        for (int j = 0; j < znakovi.Length; j++)
                        {
                            rj += znakovi[i];
                            rj += s;
                            rj += znakovi[j];
                            provjera(rj);
                            rj = "";
                        }

                    }
                }
                else if (duljina == 2)
                {
                    for (int i = 0; i < znakovi.Length; i++)
                    {
                        for (int j = 0; j < znakovi.Length; j++)
                        {
                            for (int k = 0; k < znakovi.Length; k++)
                            {
                                for (int l = 0; l < znakovi.Length; l++)
                                {
                                    rj += znakovi[i];
                                    rj += znakovi[j];
                                    rj += s;
                                    rj += znakovi[k];
                                    rj += znakovi[l];
                                    provjera(rj);
                                    rj = "";
                                }
                            }
                        }

                    }
                }
                else if (duljina == 3)
                {
                    for (int i = 0; i < znakovi.Length; i++)
                    {
                        for (int j = 0; j < znakovi.Length; j++)
                        {
                            for (int k = 0; k < znakovi.Length; k++)
                            {
                                for (int l = 0; l < znakovi.Length; l++)
                                {
                                    for (int m = 0; m < znakovi.Length; m++)
                                    {
                                        for (int n = 0; n < znakovi.Length; n++)
                                        {
                                            rj += znakovi[i];
                                            rj += znakovi[j];
                                            rj += znakovi[k];
                                            rj += s;
                                            rj += znakovi[l];
                                            rj += znakovi[m];
                                            rj += znakovi[n];
                                            provjera(rj);
                                            rj = "";
                                        }
                                    }
                                }
                            }

                        }
                    }
                }
                else if (duljina == 4)
                {
                    for (int i = 0; i < znakovi.Length; i++)
                    {
                        for (int j = 0; j < znakovi.Length; j++)
                        {
                            for (int k = 0; k < znakovi.Length; k++)
                            {
                                for (int l = 0; l < znakovi.Length; l++)
                                {
                                    for (int m = 0; m < znakovi.Length; m++)
                                    {
                                        for (int n = 0; n < znakovi.Length; n++)
                                        {
                                            for (int o = 0; o < znakovi.Length; o++)
                                            {
                                                for (int r = 0; r < znakovi.Length; r++)
                                                {
                                                    rj += znakovi[i];
                                                    rj += znakovi[j];
                                                    rj += znakovi[k];
                                                    rj += znakovi[l];
                                                    rj += s;
                                                    rj += znakovi[m];
                                                    rj += znakovi[n];
                                                    rj += znakovi[o];
                                                    rj += znakovi[r];
                                                    provjera(rj);
                                                    rj = "";
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                        }
                    }
                }
                else if (duljina == 5)
                {
                    for (int i = 0; i < znakovi.Length; i++)
                    {
                        for (int j = 0; j < znakovi.Length; j++)
                        {
                            for (int k = 0; k < znakovi.Length; k++)
                            {
                                for (int l = 0; l < znakovi.Length; l++)
                                {
                                    for (int m = 0; m < znakovi.Length; m++)
                                    {
                                        for (int n = 0; n < znakovi.Length; n++)
                                        {
                                            for (int o = 0; o < znakovi.Length; o++)
                                            {
                                                for (int q = 0; q < znakovi.Length; q++)
                                                {
                                                    for (int r = 0; r < znakovi.Length; r++)
                                                    {
                                                        for (int t = 0; t < znakovi.Length; t++)
                                                        {
                                                            rj += znakovi[i];
                                                            rj += znakovi[j];
                                                            rj += znakovi[k];
                                                            rj += znakovi[l];
                                                            rj += znakovi[m];
                                                            rj += s;
                                                            rj += znakovi[n];
                                                            rj += znakovi[o];
                                                            rj += znakovi[q];
                                                            rj += znakovi[r];
                                                            rj += znakovi[t];
                                                            provjera(rj);
                                                            rj = "";
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else if (duljina == 6)
                {
                    for (int i = 0; i < znakovi.Length; i++)
                    {
                        for (int j = 0; j < znakovi.Length; j++)
                        {
                            for (int k = 0; k < znakovi.Length; k++)
                            {
                                for (int l = 0; l < znakovi.Length; l++)
                                {
                                    for (int m = 0; m < znakovi.Length; m++)
                                    {
                                        for (int n = 0; n < znakovi.Length; n++)
                                        {
                                            for (int b = 0; b < znakovi.Length; b++)
                                            {
                                                for (int c = 0; c < znakovi.Length; c++)
                                                {
                                                    for (int d = 0; d < znakovi.Length; d++)
                                                    {
                                                        for (int f = 0; f < znakovi.Length; f++)
                                                        {
                                                            for (int g = 0; g < znakovi.Length; g++)
                                                            {
                                                                for (int h = 0; h < znakovi.Length; h++)
                                                                {
                                                                    rj += znakovi[i];
                                                                    rj += znakovi[j];
                                                                    rj += znakovi[k];
                                                                    rj += znakovi[l];
                                                                    rj += znakovi[m];
                                                                    rj += znakovi[n];
                                                                    rj += s;
                                                                    rj += znakovi[b];
                                                                    rj += znakovi[c];
                                                                    rj += znakovi[d];
                                                                    rj += znakovi[f];
                                                                    rj += znakovi[g];
                                                                    rj += znakovi[h];
                                                                    provjera(rj);
                                                                    rj = "";
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else if (duljina == 7)
                {
                    for (int i = 0; i < znakovi.Length; i++)
                    {
                        for (int j = 0; j < znakovi.Length; j++)
                        {
                            for (int k = 0; k < znakovi.Length; k++)
                            {
                                for (int l = 0; l < znakovi.Length; l++)
                                {
                                    for (int m = 0; m < znakovi.Length; m++)
                                    {
                                        for (int n = 0; n < znakovi.Length; n++)
                                        {
                                            for (int o = 0; o < znakovi.Length; o++)
                                            {
                                                for (int b = 0; b < znakovi.Length; b++)
                                                {
                                                    for (int c = 0; c < znakovi.Length; c++)
                                                    {
                                                        for (int d = 0; d < znakovi.Length; d++)
                                                        {
                                                            for (int f = 0; f < znakovi.Length; f++)
                                                            {
                                                                for (int g = 0; g < znakovi.Length; g++)
                                                                {
                                                                    for (int h = 0; h < znakovi.Length; h++)
                                                                    {
                                                                        for (int q = 0; q < znakovi.Length; q++)
                                                                        {
                                                                            rj += znakovi[i];
                                                                            rj += znakovi[j];
                                                                            rj += znakovi[k];
                                                                            rj += znakovi[l];
                                                                            rj += znakovi[m];
                                                                            rj += znakovi[n];
                                                                            rj += znakovi[o];
                                                                            rj += s;
                                                                            rj += znakovi[b];
                                                                            rj += znakovi[c];
                                                                            rj += znakovi[d];
                                                                            rj += znakovi[f];
                                                                            rj += znakovi[g];
                                                                            rj += znakovi[h];
                                                                            rj += znakovi[q];
                                                                            provjera(rj);
                                                                            rj = "";
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else if (duljina == 8)
                {
                    for (int i = 0; i < znakovi.Length; i++)
                    {
                        for (int j = 0; j < znakovi.Length; j++)
                        {
                            for (int k = 0; k < znakovi.Length; k++)
                            {
                                for (int l = 0; l < znakovi.Length; l++)
                                {
                                    for (int m = 0; m < znakovi.Length; m++)
                                    {
                                        for (int n = 0; n < znakovi.Length; n++)
                                        {
                                            for (int o = 0; o < znakovi.Length; o++)
                                            {
                                                for (int r = 0; r < znakovi.Length; r++)
                                                {
                                                    for (int b = 0; b < znakovi.Length; b++)
                                                    {
                                                        for (int c = 0; c < znakovi.Length; c++)
                                                        {
                                                            for (int d = 0; d < znakovi.Length; d++)
                                                            {
                                                                for (int f = 0; f < znakovi.Length; f++)
                                                                {
                                                                    for (int g = 0; g < znakovi.Length; g++)
                                                                    {
                                                                        for (int h = 0; h < znakovi.Length; h++)
                                                                        {
                                                                            for (int q = 0; q < znakovi.Length; q++)
                                                                            {
                                                                                for (int t = 0; t < znakovi.Length; t++)
                                                                                {
                                                                                    rj += znakovi[i];
                                                                                    rj += znakovi[j];
                                                                                    rj += znakovi[k];
                                                                                    rj += znakovi[l];
                                                                                    rj += znakovi[m];
                                                                                    rj += znakovi[n];
                                                                                    rj += znakovi[o];
                                                                                    rj += znakovi[r];
                                                                                    rj += s;
                                                                                    rj += znakovi[b];
                                                                                    rj += znakovi[c];
                                                                                    rj += znakovi[d];
                                                                                    rj += znakovi[f];
                                                                                    rj += znakovi[g];
                                                                                    rj += znakovi[h];
                                                                                    rj += znakovi[q];
                                                                                    rj += znakovi[t];
                                                                                    provjera(rj);
                                                                                    rj = "";
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            int upisana_duljina = 3;
            StringBuilder rj2 = new StringBuilder();
            rj2.Clear();
            int duljina2 = 2;

            while (duljina2 <= upisana_duljina)
            {
                if (duljina2 == 2)
                {
                    for (int i = 0; i < a; i++)
                    {
                        for (int j = i + 1; j < a; j++)
                        {
                            for (int k = 0; k < 2; k++)
                            {
                                if (k == 0)
                                {
                                    rj2.Append(Rijecnik[i]);
                                    rj2.Append(" ");
                                    rj2.Append(Rijecnik[j]);
                                    provjera(rj2.ToString());
                                    rj2.Clear();
                                    rj2.Append(Rijecnik[i]);
                                    rj2.Append(Rijecnik[j]);
                                    provjera(rj2.ToString());
                                    rj2.Clear();
                                }
                                else
                                {
                                    rj2.Append(Rijecnik[j]);
                                    rj2.Append(" ");
                                    rj2.Append(Rijecnik[i]);
                                    provjera(rj2.ToString());
                                    rj2.Clear();
                                    rj2.Append(Rijecnik[j]);
                                    rj2.Append(Rijecnik[i]);
                                    provjera(rj2.ToString());
                                    rj2.Clear();
                                }
                            }
                            if (j == i - 1)
                            {
                                j = a - 1;
                            }
                            else if (j == a - 1 && i != 0)
                            {
                                j = -1;
                            }
                        }
                    }
                    duljina2++;
                }
                else if (duljina2 == 3)
                {
                    for (int i = 0; i < a; i++)
                    {
                        for (int j = 0; j < a; j++)
                        {
                            for (int k = 0; k < a; k++)
                            {
                                if (i != j && j != k && k != i)
                                {
                                    for (int b = 0; b < 3; b++)
                                    {
                                        if (b == 0)
                                        {
                                            rj2.Append(Rijecnik[i]);
                                            rj2.Append(" ");
                                            rj2.Append(Rijecnik[j]);
                                            rj2.Append(" ");
                                            rj2.Append(Rijecnik[k]);
                                            provjera(rj2.ToString());
                                            rj2.Clear();
                                            rj2.Append(Rijecnik[i]);
                                            rj2.Append(Rijecnik[j]);
                                            rj2.Append(Rijecnik[k]);
                                            provjera(rj2.ToString());
                                            rj2.Clear();
                                        }
                                        else if (b == 1)
                                        {
                                            rj2.Append(Rijecnik[j]);
                                            rj2.Append(" ");
                                            rj2.Append(Rijecnik[k]);
                                            rj2.Append(" ");
                                            rj2.Append(Rijecnik[i]);
                                            provjera(rj2.ToString());
                                            rj2.Clear();
                                            rj2.Append(Rijecnik[j]);
                                            rj2.Append(Rijecnik[k]);
                                            rj2.Append(Rijecnik[i]);
                                            provjera(rj2.ToString());
                                            rj2.Clear();
                                        }
                                        else
                                        {
                                            rj2.Append(Rijecnik[k]);
                                            rj2.Append(" ");
                                            rj2.Append(Rijecnik[i]);
                                            rj2.Append(" ");
                                            rj2.Append(Rijecnik[j]);
                                            provjera(rj2.ToString());
                                            rj2.Clear();
                                            rj2.Append(Rijecnik[k]);
                                            rj2.Append(Rijecnik[i]);
                                            rj2.Append(Rijecnik[j]);
                                            provjera(rj2.ToString());
                                            rj2.Clear();
                                        }
                                    }
                                }//kraj if-a i for petlje koja broji 
                            }

                        }
                    }
                    duljina2++;
                }
            }
            StringBuilder z = new StringBuilder();
            z.Clear();
            

            Dictionary<char, char> slova = new Dictionary<char, char>();
            slova.Add('a', '4'); slova.Add('A', '4');
            slova.Add('I', '1'); slova.Add('i', '1');
            slova.Add('b', '8'); slova.Add('t', '7');
            slova.Add('B', '8'); slova.Add('T', '7');
            slova.Add('o', '0'); slova.Add('O', '0');
            slova.Add('E', '3'); slova.Add('e', '3');
            slova.Add('S', '5'); slova.Add('s', '5');
            slova.Add('q', '9'); slova.Add('P', '9');
            slova.Add('G', '6'); slova.Add('R', '2');

            foreach (string s in RijecnikValue)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    for (int k = 0; k < s.Length; k++)             ///svaka posebno
                    {
                        for (int j = 0; j < s.Length; j++)
                        {
                            for (int l = 0; l < s.Length; l++)
                            {
                                if ((i == l && slova.ContainsKey(s[i])) || (k == l && slova.ContainsKey(s[k])) || (j == l && slova.ContainsKey(s[j])))
                                {
                                    z.Append(slova[s[l]]);
                                }
                                else
                                {
                                    z.Append(s[l]);
                                }
                            }
                            izvođenje(z.ToString());
                            z.Clear();
                            if (kraj == 1)
                            {
                                Application.Exit();
                            }
                        }
                    }

                }

                for (int k = 0; k < s.Length; k++)                //zamjeni se svako pojavljivanje tog slova
                {
                    if (slova.ContainsKey(s[k]))
                    {
                        z.Append(s.Replace(s[k], slova[s[k]]));
                        izvođenje(z.ToString());
                        z.Clear();
                    }
                }
            }

            foreach (string s in RijecnikValue)
            {
                izvođenje(s);
            }

            if (kraj == 0)
            {
                MessageBox.Show(" Vaša šifra je dovoljno složena.\n Program je završio, možete zatvoriti program.");
                
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

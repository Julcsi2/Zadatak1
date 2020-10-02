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

namespace WindowsFormsApp7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            provjereno();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            provjereno();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            provjereno();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            provjereno();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            provjereno();
        }


        private void button1_Click(object sender, EventArgs e)        //////////////// za generiranje riječi iz niza znakova
        {
            provjereno();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SaveFile = saveFileDialog1.FileName;
            }
            int p = 0;
            int duljina = 0;
            string[] znakovi = textBox1.Text.Split();
            string rj = "";

            if (int.TryParse(textBox2.Text, out p))
            {
                duljina = Convert.ToInt32(textBox2.Text);
            }


            if (duljina == 0)
            {
                MessageBox.Show("Nema kombinacija");
            }
            else if (duljina == 1)
            {
                for (int i = 0; i < znakovi.Length; i++)
                {
                    rj = znakovi[i];
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
        private void provjereno()                                  //////////////za pristupačnost pisanju i odabir button-a
        {
            if (checkBox1.Checked) { checkBox2.Checked = !checkBox1.Checked; };
            if (checkBox2.Checked) { checkBox1.Checked = !checkBox2.Checked; };
            textBox1.Enabled= checkBox2.Checked;
            textBox2.Enabled= checkBox2.Checked;
            button1.Enabled = checkBox2.Checked;

            btnUcitaj.Enabled = checkBox1.Checked;
            button2.Enabled = checkBox1.Checked;
            button3.Enabled= checkBox1.Checked;
            textBox3.Enabled= checkBox1.Checked;
            textBox4.Enabled= checkBox1.Checked;
            button4.Enabled= checkBox1.Checked;
            button5.Enabled= checkBox1.Checked;
            button6.Enabled= checkBox1.Checked;
            button7.Enabled = checkBox1.Checked;
            button7.Enabled = checkBox1.Checked;
            textBox5.Enabled = checkBox1.Checked;
        }
        string filePath = string.Empty;
        private void btnUcitaj_Click(object sender, EventArgs e)   ////////////za čitanje iz datoteke
        {
            provjereno();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
            }
        }
        string SaveFile = string.Empty;
        private void button2_Click(object sender, EventArgs e)   //////////za spremanje u datoteku
        {
            provjereno();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SaveFile = saveFileDialog1.FileName;
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
                            for (int l = 0; l < s.Length; l++)
                            {
                                for (int o = 0; o < s.Length; o++)
                                {
                                    for (int b = 0; b < s.Length; b++)
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
                                }
                            }
                        }
                    }
                }
            }
        }
    
        public void provjera(string rj)                             ////////////funkcija za spremanje
        {
            //string path = @"C:\Users\Júlia\Desktop\New folder\Nizovi.txt";
            int provjera = 0;
            try
            {
                using (StreamReader sr = new StreamReader(SaveFile))
                {
                    string line1;

                    while ((line1 = sr.ReadLine()) != null)
                    {
                        if (line1.Contains(rj))
                        {
                            provjera = 1;
                        }

                    }
                }
            }
            catch (Exception x)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(x.Message);
            }
            if (provjera == 0)
            {
                using (StreamWriter sw = File.AppendText(SaveFile))
                {
                    sw.WriteLine(rj);
                }
            }
            provjera = 0;

        }

        private void button3_Click(object sender, EventArgs e)         ///////////generiranje velikim i malim slovima
        {
            provjereno();
            Dictionary<string, string> Rijecnik = new Dictionary<string, string>();
            string a = "";
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line1;

                    while ((line1 = sr.ReadLine()) != null)
                    {
                        //string[] pomocna = line1.Split();
                        //MessageBox.Show(line1);
                        Rijecnik.Add(a += '1', line1);
                    }
                }
            }
            catch (Exception x)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(x.Message);
            }

            Dictionary<string, string>.ValueCollection RijecnikValue = Rijecnik.Values;
            foreach (string s in RijecnikValue)
            {
                StringBuilder rj = new StringBuilder();
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
                            rj.Append( s[i].ToString().ToUpper());
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
                                for (int l = 0; l < s.Length; l++)
                                {
                                    for (int o = 0; o < s.Length; o++)
                                    {
                                        for (int b = 0; b < s.Length; b++)
                                        {
                                            for (int d = 0; d < s.Length; d++)
                                            {
                                                for (int h = 0; h < s.Length; h++)
                                                {
                                                    for (int j = 0; j < s.Length; j++)
                                                    {
                                                        if (i == j || k == j || l == j || n == j || m == j || o == j || b == j || d == j || h == j)
                                                        {
                                                            rj.Append( s[j].ToString().ToUpper());
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
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            provjereno();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            provjereno();
        }

        private void button4_Click(object sender, EventArgs e)                               /////////////prefix
        {
            provjereno();
            Dictionary<string, string> Rijecnik = new Dictionary<string, string>();
            string a = "";
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line1;

                    while ((line1 = sr.ReadLine()) != null)
                    {
                        //string[] pomocna = line1.Split();
                        //MessageBox.Show(line1);
                        Rijecnik.Add(a += '1', line1);
                    }
                }
            }
            catch (Exception x)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(x.Message);
            }

            Dictionary<string, string>.ValueCollection RijecnikValue = Rijecnik.Values;
            foreach (string s in RijecnikValue)
            {
                int p = 0;
                int duljina = 0;
                string[] znakovi = textBox3.Text.Split();
                string rj = "";

                if (int.TryParse(textBox4.Text, out p))
                {
                    duljina = Convert.ToInt32(textBox4.Text);
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
        }

        private void button5_Click(object sender, EventArgs e)                            ////////////postfix
        {
            provjereno();
            Dictionary<string, string> Rijecnik = new Dictionary<string, string>();
            string a = "";
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line1;

                    while ((line1 = sr.ReadLine()) != null)
                    {
                        //string[] pomocna = line1.Split();
                        //MessageBox.Show(line1);
                        Rijecnik.Add(a += '1', line1);
                    }
                }
            }
            catch (Exception x)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(x.Message);
            }

            Dictionary<string, string>.ValueCollection RijecnikValue = Rijecnik.Values;
            foreach (string s in RijecnikValue)
            {
                int p = 0;
                int duljina = 0;
                string[] znakovi = textBox3.Text.Split();
                string rj = "";

                if (int.TryParse(textBox4.Text, out p))
                {
                    duljina = Convert.ToInt32(textBox4.Text);
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
        }

        private void button6_Click(object sender, EventArgs e)                      ////////////prefix i postfix
        {
            provjereno();
            Dictionary<string, string> Rijecnik = new Dictionary<string, string>();
            string a = "";
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line1;

                    while ((line1 = sr.ReadLine()) != null)
                    {
                        //string[] pomocna = line1.Split();
                        //MessageBox.Show(line1);
                        Rijecnik.Add(a += '1', line1);
                    }
                }
            }
            catch (Exception x)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(x.Message);
            }

            Dictionary<string, string>.ValueCollection RijecnikValue = Rijecnik.Values;
            foreach (string s in RijecnikValue)
            {
                int p = 0;
                int duljina = 0;
                string[] znakovi = textBox3.Text.Split();
                string rj = "";

                if (int.TryParse(textBox4.Text, out p))
                {
                    duljina = Convert.ToInt32(textBox4.Text);
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
        }

        private void button7_Click(object sender, EventArgs e)        //////////// provjera zamjena slova s brojevima
        {
            provjereno();

            Dictionary<string, string> Rijecnik = new Dictionary<string, string>();
            string a = "";
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line1;

                    while ((line1 = sr.ReadLine()) != null)
                    {
                        //string[] pomocna = line1.Split();
                        //MessageBox.Show(line1);
                        Rijecnik.Add(a += '1', line1);
                    }
                }
            }
            catch (Exception x)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(x.Message);
            }
            StringBuilder b = new StringBuilder();
            b.Clear();
            Dictionary<string, string>.ValueCollection RijecnikValue = Rijecnik.Values;

            Dictionary<char, char> slova = new Dictionary<char, char>();
            slova.Add('a','4'); slova.Add('A', '4');
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
                for(int i = 0; i < s.Length; i++)
                {   
                    for(int k = 0; k < s.Length; k++)             ///svaka posebno
                    {
                        for(int j = 0; j < s.Length; j++)
                        {
                            for(int l = 0; l < s.Length; l++)
                            {
                                if ((i == l && slova.ContainsKey(s[i])) || (k==l && slova.ContainsKey(s[k])) || (j==l && slova.ContainsKey(s[j])))
                                {
                                    b.Append(slova[s[l]]);
                                }
                                else
                                {
                                    b.Append(s[l]);
                                }
                            }
                            izvođenje(b.ToString());
                            b.Clear();
                        }
                    }
                    
                }
                
                for (int k = 0; k < s.Length; k++)                //zamjeni se svako pojavljivanje tog slova
                {
                    if (slova.ContainsKey(s[k]))
                    {
                        b.Append(s.Replace(s[k], slova[s[k]]));
                        izvođenje(b.ToString());
                        b.Clear();
                    }
                }
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            provjereno();
        }

        private void button8_Click(object sender, EventArgs e)        /// sastavljanje novih riječi pomoću riječi iz riječnika
        {
            provjereno();
            Dictionary<int, string> Rijecnik = new Dictionary<int, string>();   //riječnik
            int a = 0;
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line1;

                    while ((line1 = sr.ReadLine()) != null)
                    {
                        //string[] pomocna = line1.Split();
                        //MessageBox.Show(a.ToString());

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

            int upisana_duljina = Convert.ToInt32(textBox5.Text);           ////////program
            
            StringBuilder rj = new StringBuilder();
            rj.Clear();
            int duljina = 2;

            while (duljina <= upisana_duljina)
            {
                if (duljina == 2)
                {
                    for (int i = 0; i < a; i++)
                    {
                        for (int j = i + 1; j < a; j++)
                        {
                            for (int k = 0; k < 2; k++)
                            {
                                if (k == 0)
                                {
                                    rj.Append(Rijecnik[i]);
                                    rj.Append(" ");
                                    rj.Append(Rijecnik[j]);
                                    provjera(rj.ToString());
                                    rj.Clear();
                                    rj.Append(Rijecnik[i]);
                                    rj.Append(Rijecnik[j]);
                                    provjera(rj.ToString());
                                    rj.Clear();
                                }
                                else
                                {
                                    rj.Append(Rijecnik[j]);
                                    rj.Append(" ");
                                    rj.Append(Rijecnik[i]);
                                    provjera(rj.ToString());
                                    rj.Clear();
                                    rj.Append(Rijecnik[j]);
                                    rj.Append(Rijecnik[i]);
                                    provjera(rj.ToString());
                                    rj.Clear();
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
                    duljina++;
                }
                else if (duljina == 3)
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
                                            rj.Append(Rijecnik[i]);
                                            rj.Append(" ");
                                            rj.Append(Rijecnik[j]);
                                            rj.Append(" ");
                                            rj.Append(Rijecnik[k]);
                                            provjera(rj.ToString());
                                            rj.Clear();
                                            rj.Append(Rijecnik[i]);
                                            rj.Append(Rijecnik[j]);
                                            rj.Append(Rijecnik[k]);
                                            provjera(rj.ToString());
                                            rj.Clear();
                                        }
                                        else if (b == 1)
                                        {
                                            rj.Append(Rijecnik[j]);
                                            rj.Append(" ");
                                            rj.Append(Rijecnik[k]);
                                            rj.Append(" ");
                                            rj.Append(Rijecnik[i]);
                                            provjera(rj.ToString());
                                            rj.Clear();
                                            rj.Append(Rijecnik[j]);
                                            rj.Append(Rijecnik[k]);
                                            rj.Append(Rijecnik[i]);
                                            provjera(rj.ToString());
                                            rj.Clear();
                                        }
                                        else
                                        {
                                            rj.Append(Rijecnik[k]);
                                            rj.Append(" ");
                                            rj.Append(Rijecnik[i]);
                                            rj.Append(" ");
                                            rj.Append(Rijecnik[j]);
                                            provjera(rj.ToString());
                                            rj.Clear();
                                            rj.Append(Rijecnik[k]);
                                            rj.Append(Rijecnik[i]);
                                            rj.Append(Rijecnik[j]);
                                            provjera(rj.ToString());
                                            rj.Clear();
                                        }
                                    }
                                }//kraj if-a i for petlje koja broji 
                            }

                        }
                    }
                    duljina++;
                }
            }
            }
    }
}

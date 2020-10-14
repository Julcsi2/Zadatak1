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

namespace WindowsFormsApp11
{
    public partial class Form1 : Form
    {
        int a = 0;
        public Form1()
        {
            InitializeComponent();

            string path1 = @"C:\temp";
            if (!(Directory.Exists(path1))) {
                DirectoryInfo novi_album = Directory.CreateDirectory(@"C:\temp");
            }
            
            string path = @"C:\temp\Upravljanje_albumima.txt";


            int br1 = 0;
            int br2 = 0;
            //string path = @"C:\Upravljanje_albumima.txt";   //ispis iz datoteke
            if (File.Exists(path))/// dodala provjeru za postojanje datoteke
            {
                try
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                        string line1;
                        while ((line1 = sr.ReadLine()) != null)
                        {
                            string[] tri = line1.Split();
                            //Albumi.Items.Add(line1);
                            if (line1[0] == '*')
                            {
                                StringBuilder rj = new StringBuilder();
                                for(int i = 1; i < tri[0].Length; i++)
                                {
                                    rj.Append(line1[i]);
                                }
                                Albumi.Items.Add(rj);
                                Rijecnik.Add(Convert.ToInt32(tri[1]), tri[2]);
                                //a++;
                                //a = Convert.ToInt32(tri[1]);
                            }
                            else
                            {
                                br1++;
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    // Let the user know what went wrong.
                    Console.WriteLine("The file could not be read:");
                    Console.WriteLine(e.Message);
                }
                try
                {
                    using (StreamReader sr = new StreamReader(path))  //dodatni prolazak za bilježenje zadnjeg albuma koji se otvorio
                    {
                        string line1;                                 // tako znam koje slike treba izredati pri otvaranju programa

                        while ((line1 = sr.ReadLine()) != null)
                        {
                            if (line1[0]!='*')
                            {
                                br2++;
                            }
                            if (br2 == br1 && br2!=0)
                            {
                                string[] dva = line1.Split();
                                indeks_odabranog_albuma = Convert.ToInt32(dva[1]);
                                Slike.Items.Clear();
                                nazivi_puteva = System.IO.Directory.GetFileSystemEntries(Rijecnik[indeks_odabranog_albuma]);

                                foreach (string s in nazivi_puteva)
                                {
                                    string[] stringSeparators = new string[] { "\\" };
                                    string[] novo = s.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                                    string naziv_slike = novo[novo.Length - 1];
                                  
                                    Slike.Items.Add(naziv_slike + "      ");

                                }
                                
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    // Let the user know what went wrong.
                    Console.WriteLine("The file could not be read:");
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.Write("");
                }

            }
        }
        
        Dictionary<int, string> Rijecnik = new Dictionary<int, string>();   //riječnik
        
        private void button1_Click(object sender, EventArgs e)     ///dodavanje albuma u listu
        {
            if (Directory.Exists(textBox1.Text))/// dodala provjeru za postojanje albuma
            {
                string[] stringSeparators = new string[] { "\\" };
                string[] novo = textBox1.Text.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                string naziv_albuma = novo[novo.Length - 1];

                Albumi.Items.Add(naziv_albuma);
                Rijecnik.Add(a, textBox1.Text);

                string path = @"C:\temp\Upravljanje_albumima.txt";   //spremanje u datoteku
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine('*'+naziv_albuma+" "+ a +" " +textBox1.Text);
                }
                a++;

            }
            else
            {
                DirectoryInfo novi_album = Directory.CreateDirectory(textBox1.Text);   //napravi novi album ako ne postoji odabrani

                string[] stringSeparators = new string[] { "\\" };
                string[] novo = textBox1.Text.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                string naziv_albuma = novo[novo.Length - 1];
                Albumi.Items.Add(naziv_albuma);

                string path = @"C:\temp\Upravljanje_albumima.txt";    //spremanje u datoteku
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine('*' + naziv_albuma + " " + a + " " + textBox1.Text);
                }
                Rijecnik.Add(a, textBox1.Text);
                a++;
            }
        }

        int indeks_odabranog_albuma=0;
        string[] nazivi_puteva;

        private void button2_Click(object sender, EventArgs e)       /// otvaranje albuma
        {
            string naziv_albuma = Albumi.SelectedItem.ToString();
            indeks_odabranog_albuma = Albumi.SelectedIndex;


            Slike.Items.Clear();
            nazivi_puteva = System.IO.Directory.GetFileSystemEntries(Rijecnik[indeks_odabranog_albuma]);
            
            
            foreach (string s in nazivi_puteva)
            {
                string[] stringSeparators = new string[] { "\\" };
                string[] novo = s.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                string naziv_slike = novo[novo.Length - 1];
                //Button tipka_x = new Button();
                Slike.Items.Add(naziv_slike +"      ");
               
            }
            string path = @"C:\temp\Upravljanje_albumima.txt";      //spremanje u datoteku
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine( naziv_albuma+" "+indeks_odabranog_albuma);
            }

        }

        private void Tipka_X(object seneder, EventArgs e)           // brisanje odabrane slike
        {
            string odabrana_slika = Slike.SelectedItem.ToString();
            int indeks_slike = Slike.SelectedIndex;
            Slike.Items.RemoveAt(indeks_slike);

            File.Delete(nazivi_puteva[indeks_slike]);

            pictureBox1.Image = null;
        }


        private void button4_Click(object sender, EventArgs e)   //dodavanje slika u obliku cut-paste
        {
            string zadnji_put = "";
            if (nazivi_puteva.Length==0)                                //ako je album prazan ili ako nije prazan
            {
                zadnji_put = Rijecnik[indeks_odabranog_albuma];

                StringBuilder put = new StringBuilder();
                string[] stringSeparators = new string[] { "\\" };
                string[] novo = zadnji_put.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < novo.Length ; i++)
                {
                    put.Append(novo[i] + "\\");
                }

                string[] imena = { };
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    imena = openFileDialog.FileNames;
                }

                for (int i = 0; i < imena.Length; i++)
                {
                    string[] stringSeparators2 = new string[] { "\\" };
                    string[] novo2 = imena[i].Split(stringSeparators2, StringSplitOptions.RemoveEmptyEntries);
                    string naziv_slike = novo2[novo2.Length - 1];
                    Slike.Items.Add(naziv_slike + "      ");

                    File.Move(imena[i], put.ToString() + naziv_slike);

                    nazivi_puteva = System.IO.Directory.GetFileSystemEntries(Rijecnik[indeks_odabranog_albuma]);
                }
            }
            else 
            { 
                zadnji_put = nazivi_puteva[nazivi_puteva.Length - 1];

                StringBuilder put = new StringBuilder();
                string[] stringSeparators = new string[] { "\\" };
                string[] novo = zadnji_put.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < novo.Length - 1; i++)
                {
                    put.Append(novo[i] + "\\");
                }

                string[] imena = { };
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    imena = openFileDialog.FileNames;
                }

                for (int i = 0; i < imena.Length; i++)
                {
                    string[] stringSeparators2 = new string[] { "\\" };
                    string[] novo2 = imena[i].Split(stringSeparators2, StringSplitOptions.RemoveEmptyEntries);
                    string naziv_slike = novo2[novo2.Length - 1];
                    Slike.Items.Add(naziv_slike + "      ");

                    File.Move(imena[i], put.ToString() + naziv_slike);

                    nazivi_puteva = System.IO.Directory.GetFileSystemEntries(Rijecnik[indeks_odabranog_albuma]);
                }
            }
            

        }

        private void button5_Click(object sender, EventArgs e)  //brisanje cijelog albuma sa svim slikama
        {
            string naziv_albuma = Albumi.SelectedItem.ToString();
            int indeks_odabranog_albuma = Albumi.SelectedIndex;
            Albumi.Items.RemoveAt(indeks_odabranog_albuma);

            if(nazivi_puteva== System.IO.Directory.GetFileSystemEntries(Rijecnik[indeks_odabranog_albuma]))
            {
                Slike.Items.Clear();
            }
            Directory.Delete(Rijecnik[indeks_odabranog_albuma]);

            pictureBox1.Image = null;
        }


        private void Slike_MouseClick(object sender, MouseEventArgs e)
        {
            pictureBox1.ImageLocation = nazivi_puteva[Slike.SelectedIndex];

        }
    }
}

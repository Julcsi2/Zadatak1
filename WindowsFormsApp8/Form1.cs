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

namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string filePath = string.Empty;
        private void button1_Click(object sender, EventArgs e)
        {
            

               OpenFileDialog openFileDialog = new OpenFileDialog();
               if (openFileDialog.ShowDialog() == DialogResult.OK)
               {
                   filePath = openFileDialog.FileName;
               }
            
        }
        string SaveFile = "";
        private void button2_Click(object sender, EventArgs e)                   ///gdje da se spremi 
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SaveFile = saveFileDialog1.FileName;
            }

            Dictionary<int, string> Rijecnik = new Dictionary<int, string>();   //riječnik
            int a =0;
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

            int upisana_duljina = Convert.ToInt32(textBox1.Text);           ////////program
            /*if (upisana_duljina > a)
            {
                MessageBox.Show("Upisana duljina mora biti manja od "+a);
            }*/
            StringBuilder rj = new StringBuilder();
            rj.Clear();
            int duljina = 2;
            while (duljina <= upisana_duljina)
            {
                if (duljina == 2)
                {
                    for(int i = 0; i < a; i++)
                    {
                        for(int j = i+1; j < a; j++)
                        {
                            for(int k = 0; k < 2; k++)
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
                }else if (duljina == 3)
                {
                    for (int i = 0; i < a; i++)
                    {
                        for (int j = 0; j < a; j++)
                        {
                            for (int k = 0; k < a; k++)
                            {
                                if (i != j && j != k && k != i) {
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
    }
}

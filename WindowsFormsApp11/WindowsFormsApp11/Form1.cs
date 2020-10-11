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
        public Form1()
        {
            InitializeComponent();
        }

        public void ispis() 
        {
            
        }

        Dictionary<int, string> Rijecnik = new Dictionary<int, string>();   //riječnik
        int a = 0;
        private void button1_Click(object sender, EventArgs e)     ///dodavanje albuma u listu
        {
            if (Directory.Exists(textBox1.Text))/// dodala provjeru za postojanje albuma
            {                                   
                Rijecnik.Add(a, textBox1.Text);
                a++;

                string[] stringSeparators = new string[] { "\\" };
                string[] novo = textBox1.Text.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                string naziv_albuma = novo[novo.Length - 1];
                Albumi.Items.Add(naziv_albuma);
            }
            else
            {
                MessageBox.Show("Odaberite album koji postoji");
            }
        }
        Button tipka_x = new Button();

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
              
                tipka_x.DialogResult = DialogResult.OK;
                
            }
            
        }
        private void Tipka_X(object seneder, EventArgs e)           // brisanje odabrane slike
        {
            string odabrana_slika = Slike.SelectedItem.ToString();
            int indeks_slike = Slike.SelectedIndex;
            Slike.Items.RemoveAt(indeks_slike);

            File.Delete(nazivi_puteva[indeks_slike]);
        }

        private void button4_Click(object sender, EventArgs e)   //dodavanje slika u obliku cut-paste
        {
            string zadnji_put = nazivi_puteva[nazivi_puteva.Length - 1];
            StringBuilder put = new StringBuilder();
            string[] stringSeparators = new string[] { "\\" };
            string[] novo = zadnji_put.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < novo.Length-1;i++) 
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

            for(int i = 0; i < imena.Length; i++)
            {
                string[] stringSeparators2 = new string[] { "\\" };
                string[] novo2 = imena[i].Split(stringSeparators2, StringSplitOptions.RemoveEmptyEntries);
                string naziv_slike = novo2[novo2.Length - 1];
                Slike.Items.Add(naziv_slike + "      ");

                File.Move(imena[i], put.ToString()+naziv_slike);

                nazivi_puteva= System.IO.Directory.GetFileSystemEntries(Rijecnik[indeks_odabranog_albuma]);
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
        }
    }
}

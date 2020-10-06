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
namespace WindowsFormsApp10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)  //kreiranje nove mape
        {
            string path = textBox1.Text;
            DirectoryInfo di1 = Directory.CreateDirectory(path);
            fileovi.Items.Add(textBox1.Text);
 
        }
        string filePath;
        private void button3_Click(object sender, EventArgs e)  //otvaranje mape
        {
            fileovi.Items.Clear();
            filePath = textBox2.Text;
            string[] nazivi_datoteka = System.IO.Directory.GetFileSystemEntries(filePath);
            foreach (string s in nazivi_datoteka)
            {
                fileovi.Items.Add(s);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)   /// brisanje mape i svega što je u njoj, 
        {
            Directory.Delete(filePath);                   //treba se otvoriti i onda obrisati
            fileovi.Items.Clear();
            
            filePath = "";
            textBox2.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)   ///premještanje mape u novu ne postojeću mapu
        {
            string path1 = filePath + @"\" + textBox3.Text;
            string path2 = textBox4.Text;
            Directory.Move(path1,path2);

            fileovi.Items.Clear();
            string[] nazivi_datoteka = System.IO.Directory.GetFileSystemEntries(filePath);
            foreach (string s in nazivi_datoteka)
            {
                fileovi.Items.Add(s);
            }

        }

        private void button5_Click(object sender, EventArgs e)    //samo što piše open a zapravo obriše datoteku
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.Delete(openFileDialog.FileName);
            }

            fileovi.Items.Clear();
            string[] nazivi_datoteka = System.IO.Directory.GetFileSystemEntries(filePath);
            foreach (string s in nazivi_datoteka)
            {
                fileovi.Items.Add(s);
            }
        }

        private void button6_Click(object sender, EventArgs e)     // premještanje datoteke 
        {
            string path1 = filePath + @"\" + textBox6.Text;
            string path2 = textBox5.Text;
            File.Move(path1, path2);

            fileovi.Items.Clear();
            string[] nazivi_datoteka = System.IO.Directory.GetFileSystemEntries(filePath);
            foreach (string s in nazivi_datoteka)
            {
                fileovi.Items.Add(s);
            }
        }

        private void button7_Click(object sender, EventArgs e)   //kako iz nekog mjesta prebaciti datoteku u našu otvorenu mapu
        {
            string path1 = textBox7.Text;
            
            string[] stringSeparators = new string[] { "\\" };
            string[] novo =path1.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            
            string path2 = filePath + @"\"+ novo[novo.Length-1];
            File.Move(path1, path2);

            fileovi.Items.Clear();
            string[] nazivi_datoteka = System.IO.Directory.GetFileSystemEntries(filePath);
            foreach (string s in nazivi_datoteka)
            {
                fileovi.Items.Add(s);
            }

            textBox7.Text = "";
        }
    }
}

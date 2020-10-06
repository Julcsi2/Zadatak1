namespace WindowsFormsApp10
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.fileovi = new System.Windows.Forms.CheckedListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(747, 192);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(338, 37);
            this.button1.TabIndex = 0;
            this.button1.Text = "Kreiranje novog albuma, upišite put i naziv";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(745, 277);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(338, 36);
            this.button2.TabIndex = 1;
            this.button2.Text = "Brisanje nekog albuma sa svime što je unutra";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // fileovi
            // 
            this.fileovi.FormattingEnabled = true;
            this.fileovi.Location = new System.Drawing.Point(48, 49);
            this.fileovi.Name = "fileovi";
            this.fileovi.Size = new System.Drawing.Size(646, 344);
            this.fileovi.TabIndex = 2;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(742, 88);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(338, 34);
            this.button3.TabIndex = 3;
            this.button3.Text = "Otvaranje albuma s kojim želimo raditi";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(745, 164);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(335, 22);
            this.textBox1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Imena svih stvari u otvorenom albumu";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(11, 556);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(337, 31);
            this.button4.TabIndex = 6;
            this.button4.Text = "Premještanje mape";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(745, 358);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(335, 31);
            this.button5.TabIndex = 7;
            this.button5.Text = "Brisanje datoteke";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(742, 60);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(335, 22);
            this.textBox2.TabIndex = 8;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(12, 483);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(335, 22);
            this.textBox3.TabIndex = 9;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(11, 528);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(336, 22);
            this.textBox4.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 508);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(337, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "U koju novu, još ne postojeću, mapu da se premjesti";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 463);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(224, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Naziv mape koju želimo premjestiti";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(377, 463);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(244, 17);
            this.label4.TabIndex = 17;
            this.label4.Text = "Naziv datoteke koju želimo premjestiti";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(378, 533);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(336, 22);
            this.textBox5.TabIndex = 15;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(377, 483);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(335, 22);
            this.textBox6.TabIndex = 14;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(380, 561);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(337, 31);
            this.button6.TabIndex = 13;
            this.button6.Text = "Premještanje datoteke";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(375, 513);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(337, 17);
            this.label5.TabIndex = 18;
            this.label5.Text = "U koju novu, još ne postojeću, mapu da se premjesti";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(744, 463);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(361, 17);
            this.label6.TabIndex = 19;
            this.label6.Text = "Put do datoteke koju želimo dodati u naš otvoreni album";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(745, 483);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(335, 22);
            this.textBox7.TabIndex = 20;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(746, 511);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(335, 31);
            this.button7.TabIndex = 21;
            this.button7.Text = "Dodaj datoteku u otvoreni album";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 699);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.fileovi);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckedListBox fileovi;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Button button7;
    }
}


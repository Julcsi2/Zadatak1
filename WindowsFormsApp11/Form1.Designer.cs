namespace WindowsFormsApp11
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
            this.Albumi = new System.Windows.Forms.ListBox();
            this.Slike = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Albumi
            // 
            this.Albumi.FormattingEnabled = true;
            this.Albumi.ItemHeight = 16;
            this.Albumi.Location = new System.Drawing.Point(24, 88);
            this.Albumi.Name = "Albumi";
            this.Albumi.Size = new System.Drawing.Size(288, 356);
            this.Albumi.TabIndex = 0;
            // 
            // Slike
            // 
            this.Slike.FormattingEnabled = true;
            this.Slike.ItemHeight = 16;
            this.Slike.Location = new System.Drawing.Point(341, 88);
            this.Slike.Name = "Slike";
            this.Slike.Size = new System.Drawing.Size(366, 356);
            this.Slike.Sorted = true;
            this.Slike.TabIndex = 1;
            this.Slike.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Slike_MouseClick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(230, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(477, 22);
            this.textBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Dodavanje novog albuma";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(745, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(185, 31);
            this.button1.TabIndex = 4;
            this.button1.Text = "Dodaj album";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(38, 450);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(258, 36);
            this.button2.TabIndex = 5;
            this.button2.Text = "Otvori album";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(373, 450);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(294, 36);
            this.button3.TabIndex = 6;
            this.button3.Text = "Obriši odabranu sliku";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Tipka_X);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(373, 492);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(294, 36);
            this.button4.TabIndex = 7;
            this.button4.Text = "Dodaj još slika";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(38, 492);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(258, 36);
            this.button5.TabIndex = 8;
            this.button5.Text = "Obriši album";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(757, 137);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(287, 253);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 699);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Slike);
            this.Controls.Add(this.Albumi);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox Albumi;
        private System.Windows.Forms.ListBox Slike;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}


namespace WindowsFormsApp13
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Gradovi = new System.Windows.Forms.ListBox();
            this.Vremenska_prognoza = new System.Windows.Forms.ListBox();
            this.Pozivanje = new System.Windows.Forms.Timer(this.components);
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(29, 74);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(186, 22);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(342, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ovdje upišite ime grada za koji želite vidjeti prognozu";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(247, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 28);
            this.button1.TabIndex = 2;
            this.button1.Text = "Pronađi";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nedavno pretraženi gradovi";
            // 
            // Gradovi
            // 
            this.Gradovi.FormattingEnabled = true;
            this.Gradovi.ItemHeight = 16;
            this.Gradovi.Location = new System.Drawing.Point(35, 196);
            this.Gradovi.Name = "Gradovi";
            this.Gradovi.Size = new System.Drawing.Size(180, 196);
            this.Gradovi.TabIndex = 4;
            this.Gradovi.SelectedIndexChanged += new System.EventHandler(this.Gradovi_SelectedIndexChanged);
            // 
            // Vremenska_prognoza
            // 
            this.Vremenska_prognoza.FormattingEnabled = true;
            this.Vremenska_prognoza.ItemHeight = 16;
            this.Vremenska_prognoza.Location = new System.Drawing.Point(247, 145);
            this.Vremenska_prognoza.Name = "Vremenska_prognoza";
            this.Vremenska_prognoza.Size = new System.Drawing.Size(253, 260);
            this.Vremenska_prognoza.TabIndex = 5;
            // 
            // Pozivanje
            // 
            this.Pozivanje.Enabled = true;
            this.Pozivanje.Interval = 60000;
            this.Pozivanje.Tick += new System.EventHandler(this.Pozivanje_Tick);
            // 
            // chart
            // 
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(532, 68);
            this.chart.Name = "chart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Osijek";
            this.chart.Series.Add(series1);
            this.chart.Size = new System.Drawing.Size(672, 310);
            this.chart.TabIndex = 7;
            this.chart.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 450);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.Vremenska_prognoza);
            this.Controls.Add(this.Gradovi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox Gradovi;
        private System.Windows.Forms.ListBox Vremenska_prognoza;
        private System.Windows.Forms.Timer Pozivanje;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
    }
}


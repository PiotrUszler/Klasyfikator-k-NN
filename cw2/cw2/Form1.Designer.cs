namespace cw2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tb_Treningowy = new System.Windows.Forms.TextBox();
            this.tb_Testowy = new System.Windows.Forms.TextBox();
            this.btn_WczytajTrening = new System.Windows.Forms.Button();
            this.btn_WczytajTest = new System.Windows.Forms.Button();
            this.tb_Wynik = new System.Windows.Forms.TextBox();
            this.btn_Oblicz = new System.Windows.Forms.Button();
            this.lbl_Metryka = new System.Windows.Forms.Label();
            this.cb_Metryka = new System.Windows.Forms.ComboBox();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.cb_Sasiedzi = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_Treningowy
            // 
            this.tb_Treningowy.Location = new System.Drawing.Point(12, 12);
            this.tb_Treningowy.Name = "tb_Treningowy";
            this.tb_Treningowy.ReadOnly = true;
            this.tb_Treningowy.Size = new System.Drawing.Size(314, 20);
            this.tb_Treningowy.TabIndex = 0;
            this.tb_Treningowy.Text = "System Treningowy";
            this.tb_Treningowy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_Testowy
            // 
            this.tb_Testowy.Location = new System.Drawing.Point(12, 38);
            this.tb_Testowy.Name = "tb_Testowy";
            this.tb_Testowy.ReadOnly = true;
            this.tb_Testowy.Size = new System.Drawing.Size(314, 20);
            this.tb_Testowy.TabIndex = 1;
            this.tb_Testowy.Text = "System Testowy";
            this.tb_Testowy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_WczytajTrening
            // 
            this.btn_WczytajTrening.Location = new System.Drawing.Point(332, 10);
            this.btn_WczytajTrening.Name = "btn_WczytajTrening";
            this.btn_WczytajTrening.Size = new System.Drawing.Size(75, 23);
            this.btn_WczytajTrening.TabIndex = 2;
            this.btn_WczytajTrening.Text = "...";
            this.btn_WczytajTrening.UseVisualStyleBackColor = true;
            this.btn_WczytajTrening.Click += new System.EventHandler(this.btn_WczytajTrening_Click);
            // 
            // btn_WczytajTest
            // 
            this.btn_WczytajTest.Location = new System.Drawing.Point(332, 36);
            this.btn_WczytajTest.Name = "btn_WczytajTest";
            this.btn_WczytajTest.Size = new System.Drawing.Size(75, 23);
            this.btn_WczytajTest.TabIndex = 3;
            this.btn_WczytajTest.Text = "...";
            this.btn_WczytajTest.UseVisualStyleBackColor = true;
            this.btn_WczytajTest.Click += new System.EventHandler(this.btn_WczytajTest_Click);
            // 
            // tb_Wynik
            // 
            this.tb_Wynik.Location = new System.Drawing.Point(12, 64);
            this.tb_Wynik.Multiline = true;
            this.tb_Wynik.Name = "tb_Wynik";
            this.tb_Wynik.ReadOnly = true;
            this.tb_Wynik.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_Wynik.Size = new System.Drawing.Size(395, 438);
            this.tb_Wynik.TabIndex = 4;
            // 
            // btn_Oblicz
            // 
            this.btn_Oblicz.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Oblicz.Location = new System.Drawing.Point(413, 332);
            this.btn_Oblicz.Name = "btn_Oblicz";
            this.btn_Oblicz.Size = new System.Drawing.Size(75, 170);
            this.btn_Oblicz.TabIndex = 5;
            this.btn_Oblicz.Text = "Oblicz";
            this.btn_Oblicz.UseVisualStyleBackColor = true;
            this.btn_Oblicz.Click += new System.EventHandler(this.btn_Oblicz_Click);
            // 
            // lbl_Metryka
            // 
            this.lbl_Metryka.AutoSize = true;
            this.lbl_Metryka.Location = new System.Drawing.Point(426, 133);
            this.lbl_Metryka.Name = "lbl_Metryka";
            this.lbl_Metryka.Size = new System.Drawing.Size(45, 13);
            this.lbl_Metryka.TabIndex = 6;
            this.lbl_Metryka.Text = "Metryka";
            // 
            // cb_Metryka
            // 
            this.cb_Metryka.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_Metryka.FormattingEnabled = true;
            this.cb_Metryka.Items.AddRange(new object[] {
            "Euklides",
            "Manhattan",
            "Canberra",
            "Czybyszew",
            "Pearson"});
            this.cb_Metryka.Location = new System.Drawing.Point(413, 149);
            this.cb_Metryka.Name = "cb_Metryka";
            this.cb_Metryka.Size = new System.Drawing.Size(75, 21);
            this.cb_Metryka.TabIndex = 7;
            // 
            // ofd
            // 
            this.ofd.FileName = "plik";
            // 
            // cb_Sasiedzi
            // 
            this.cb_Sasiedzi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_Sasiedzi.FormattingEnabled = true;
            this.cb_Sasiedzi.Location = new System.Drawing.Point(413, 220);
            this.cb_Sasiedzi.Name = "cb_Sasiedzi";
            this.cb_Sasiedzi.Size = new System.Drawing.Size(75, 21);
            this.cb_Sasiedzi.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(433, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "k - NN";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 510);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_Sasiedzi);
            this.Controls.Add(this.cb_Metryka);
            this.Controls.Add(this.lbl_Metryka);
            this.Controls.Add(this.btn_Oblicz);
            this.Controls.Add(this.tb_Wynik);
            this.Controls.Add(this.btn_WczytajTest);
            this.Controls.Add(this.btn_WczytajTrening);
            this.Controls.Add(this.tb_Testowy);
            this.Controls.Add(this.tb_Treningowy);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(509, 549);
            this.MinimumSize = new System.Drawing.Size(509, 549);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KNN - Piotr Uszler";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_Treningowy;
        private System.Windows.Forms.TextBox tb_Testowy;
        private System.Windows.Forms.Button btn_WczytajTrening;
        private System.Windows.Forms.Button btn_WczytajTest;
        private System.Windows.Forms.Button btn_Oblicz;
        private System.Windows.Forms.Label lbl_Metryka;
        private System.Windows.Forms.ComboBox cb_Metryka;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.ComboBox cb_Sasiedzi;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox tb_Wynik;
    }
}


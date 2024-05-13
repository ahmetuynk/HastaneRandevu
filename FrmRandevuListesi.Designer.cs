namespace PROJE_HASTANE
{
    partial class FrmRandevuListesi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRandevuListesi));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnRandevuVer = new System.Windows.Forms.Button();
            this.btnRandevuIptal = new System.Windows.Forms.Button();
            this.rchSikayet = new System.Windows.Forms.RichTextBox();
            this.txtRanID = new System.Windows.Forms.TextBox();
            this.lblRandevu = new System.Windows.Forms.Label();
            this.mskHastaTC = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbBrans = new System.Windows.Forms.ComboBox();
            this.txtDoktorAdSyd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.mskSorguTC = new System.Windows.Forms.MaskedTextBox();
            this.txtSorguDokAds = new System.Windows.Forms.TextBox();
            this.mskSorguSaat = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblRandevu2 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(30, 115);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1006, 257);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // btnRandevuVer
            // 
            this.btnRandevuVer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRandevuVer.Enabled = false;
            this.btnRandevuVer.Location = new System.Drawing.Point(1185, 304);
            this.btnRandevuVer.Margin = new System.Windows.Forms.Padding(4);
            this.btnRandevuVer.Name = "btnRandevuVer";
            this.btnRandevuVer.Size = new System.Drawing.Size(255, 38);
            this.btnRandevuVer.TabIndex = 1;
            this.btnRandevuVer.Text = " Randevu Ver";
            this.btnRandevuVer.UseVisualStyleBackColor = true;
            this.btnRandevuVer.Click += new System.EventHandler(this.btnRandevuVer_Click);
            // 
            // btnRandevuIptal
            // 
            this.btnRandevuIptal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRandevuIptal.Enabled = false;
            this.btnRandevuIptal.Location = new System.Drawing.Point(142, 82);
            this.btnRandevuIptal.Margin = new System.Windows.Forms.Padding(4);
            this.btnRandevuIptal.Name = "btnRandevuIptal";
            this.btnRandevuIptal.Size = new System.Drawing.Size(203, 34);
            this.btnRandevuIptal.TabIndex = 3;
            this.btnRandevuIptal.Text = "Randevuyu İptal Et";
            this.btnRandevuIptal.UseVisualStyleBackColor = true;
            this.btnRandevuIptal.Click += new System.EventHandler(this.btnRandevuIptal_Click);
            // 
            // rchSikayet
            // 
            this.rchSikayet.Enabled = false;
            this.rchSikayet.Location = new System.Drawing.Point(1185, 166);
            this.rchSikayet.Margin = new System.Windows.Forms.Padding(4);
            this.rchSikayet.Name = "rchSikayet";
            this.rchSikayet.Size = new System.Drawing.Size(255, 130);
            this.rchSikayet.TabIndex = 4;
            this.rchSikayet.Text = "";
            // 
            // txtRanID
            // 
            this.txtRanID.Enabled = false;
            this.txtRanID.Location = new System.Drawing.Point(1327, 101);
            this.txtRanID.Margin = new System.Windows.Forms.Padding(4);
            this.txtRanID.Name = "txtRanID";
            this.txtRanID.Size = new System.Drawing.Size(65, 36);
            this.txtRanID.TabIndex = 6;
            this.txtRanID.Visible = false;
            // 
            // lblRandevu
            // 
            this.lblRandevu.AutoSize = true;
            this.lblRandevu.Location = new System.Drawing.Point(1178, 44);
            this.lblRandevu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRandevu.Name = "lblRandevu";
            this.lblRandevu.Size = new System.Drawing.Size(280, 28);
            this.lblRandevu.TabIndex = 7;
            this.lblRandevu.Text = "*Randevu Seçimi Yapılmadı..";
            // 
            // mskHastaTC
            // 
            this.mskHastaTC.Enabled = false;
            this.mskHastaTC.Location = new System.Drawing.Point(1185, 101);
            this.mskHastaTC.Mask = "00000000000";
            this.mskHastaTC.Name = "mskHastaTC";
            this.mskHastaTC.Size = new System.Drawing.Size(135, 36);
            this.mskHastaTC.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1078, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 28);
            this.label1.TabIndex = 11;
            this.label1.Text = "Hasta TC:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1091, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 28);
            this.label2.TabIndex = 12;
            this.label2.Text = "Şikayet:";
            // 
            // cmbBrans
            // 
            this.cmbBrans.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBrans.FormattingEnabled = true;
            this.cmbBrans.Location = new System.Drawing.Point(120, 63);
            this.cmbBrans.Name = "cmbBrans";
            this.cmbBrans.Size = new System.Drawing.Size(146, 36);
            this.cmbBrans.TabIndex = 13;
            this.cmbBrans.SelectedIndexChanged += new System.EventHandler(this.cmbBrans_SelectedIndexChanged);
            this.cmbBrans.Enter += new System.EventHandler(this.cmbBrans_Enter);
            // 
            // txtDoktorAdSyd
            // 
            this.txtDoktorAdSyd.Location = new System.Drawing.Point(342, 63);
            this.txtDoktorAdSyd.Name = "txtDoktorAdSyd";
            this.txtDoktorAdSyd.Size = new System.Drawing.Size(210, 36);
            this.txtDoktorAdSyd.TabIndex = 14;
            this.txtDoktorAdSyd.TextChanged += new System.EventHandler(this.txtDoktorAdSyd_TextChanged);
            this.txtDoktorAdSyd.Enter += new System.EventHandler(this.txtDoktorAdSyd_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(364, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 28);
            this.label3.TabIndex = 15;
            this.label3.Text = "Doktor Ad Soyad:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(159, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 28);
            this.label4.TabIndex = 16;
            this.label4.Text = "Branş:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(633, 63);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 36);
            this.dateTimePicker1.TabIndex = 17;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            this.dateTimePicker1.Enter += new System.EventHandler(this.dateTimePicker1_Enter);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(694, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 28);
            this.label5.TabIndex = 18;
            this.label5.Text = "Tarih:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1078, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 28);
            this.label6.TabIndex = 19;
            this.label6.Text = "Randevu:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnRandevuVer);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.rchSikayet);
            this.groupBox2.Controls.Add(this.txtDoktorAdSyd);
            this.groupBox2.Controls.Add(this.txtRanID);
            this.groupBox2.Controls.Add(this.cmbBrans);
            this.groupBox2.Controls.Add(this.lblRandevu);
            this.groupBox2.Controls.Add(this.mskHastaTC);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(23, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1489, 388);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Randevu Ver";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.dataGridView2);
            this.groupBox3.Location = new System.Drawing.Point(23, 406);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1489, 354);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Randevu Sorgula/İptal";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.mskSorguTC);
            this.groupBox4.Controls.Add(this.txtSorguDokAds);
            this.groupBox4.Controls.Add(this.mskSorguSaat);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.dateTimePicker2);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Location = new System.Drawing.Point(1055, 31);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(409, 178);
            this.groupBox4.TabIndex = 32;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Randevu Sorgu";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(44, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 28);
            this.label9.TabIndex = 30;
            this.label9.Text = "Tarih:";
            // 
            // mskSorguTC
            // 
            this.mskSorguTC.Location = new System.Drawing.Point(122, 80);
            this.mskSorguTC.Mask = "00000000000";
            this.mskSorguTC.Name = "mskSorguTC";
            this.mskSorguTC.Size = new System.Drawing.Size(160, 36);
            this.mskSorguTC.TabIndex = 21;
            this.mskSorguTC.TextChanged += new System.EventHandler(this.mskSorguTC_TextChanged);
            this.mskSorguTC.Enter += new System.EventHandler(this.mskSorguTC_Enter);
            // 
            // txtSorguDokAds
            // 
            this.txtSorguDokAds.Location = new System.Drawing.Point(122, 126);
            this.txtSorguDokAds.Name = "txtSorguDokAds";
            this.txtSorguDokAds.Size = new System.Drawing.Size(160, 36);
            this.txtSorguDokAds.TabIndex = 22;
            this.txtSorguDokAds.TextChanged += new System.EventHandler(this.txtSorguDokAds_TextChanged);
            this.txtSorguDokAds.Enter += new System.EventHandler(this.txtSorguDokAds_Enter);
            // 
            // mskSorguSaat
            // 
            this.mskSorguSaat.Location = new System.Drawing.Point(288, 31);
            this.mskSorguSaat.Mask = "00:00";
            this.mskSorguSaat.Name = "mskSorguSaat";
            this.mskSorguSaat.Size = new System.Drawing.Size(65, 36);
            this.mskSorguSaat.TabIndex = 29;
            this.mskSorguSaat.ValidatingType = typeof(System.DateTime);
            this.mskSorguSaat.TextChanged += new System.EventHandler(this.mskSorguSaat_TextChanged);
            this.mskSorguSaat.Enter += new System.EventHandler(this.mskSorguSaat_Enter);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 28);
            this.label8.TabIndex = 25;
            this.label8.Text = "Hasta TC:";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(122, 33);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(160, 36);
            this.dateTimePicker2.TabIndex = 28;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            this.dateTimePicker2.Enter += new System.EventHandler(this.dateTimePicker2_Enter);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(25, 134);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 28);
            this.label10.TabIndex = 27;
            this.label10.Text = "Doktor:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btnRandevuIptal);
            this.groupBox1.Controls.Add(this.lblRandevu2);
            this.groupBox1.Location = new System.Drawing.Point(1055, 215);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(409, 124);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Randevu İptal";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 28);
            this.label7.TabIndex = 20;
            this.label7.Text = "Randevu:";
            // 
            // lblRandevu2
            // 
            this.lblRandevu2.AutoSize = true;
            this.lblRandevu2.Location = new System.Drawing.Point(112, 30);
            this.lblRandevu2.Name = "lblRandevu2";
            this.lblRandevu2.Size = new System.Drawing.Size(280, 28);
            this.lblRandevu2.TabIndex = 5;
            this.lblRandevu2.Text = "*Randevu Seçimi Yapılmadı..";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(30, 35);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(1006, 304);
            this.dataGridView2.TabIndex = 4;
            this.dataGridView2.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellDoubleClick);
            // 
            // FrmRandevuListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1524, 772);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Corbel", 13.8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FrmRandevuListesi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Randevu Listesi";
            this.Load += new System.EventHandler(this.FrmRandevuListesi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnRandevuVer;
        private System.Windows.Forms.Button btnRandevuIptal;
        private System.Windows.Forms.RichTextBox rchSikayet;
        private System.Windows.Forms.TextBox txtRanID;
        private System.Windows.Forms.Label lblRandevu;
        private System.Windows.Forms.MaskedTextBox mskHastaTC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbBrans;
        private System.Windows.Forms.TextBox txtDoktorAdSyd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label lblRandevu2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox mskSorguTC;
        private System.Windows.Forms.TextBox txtSorguDokAds;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox mskSorguSaat;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}
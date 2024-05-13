namespace PROJE_HASTANE
{
    partial class FrmDuyurular
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDuyurular));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnDuyuruSil = new System.Windows.Forms.Button();
            this.btnDuyuruGnclle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(8, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1180, 396);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(21, 427);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(627, 147);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // btnDuyuruSil
            // 
            this.btnDuyuruSil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDuyuruSil.Enabled = false;
            this.btnDuyuruSil.Location = new System.Drawing.Point(674, 437);
            this.btnDuyuruSil.Name = "btnDuyuruSil";
            this.btnDuyuruSil.Size = new System.Drawing.Size(175, 45);
            this.btnDuyuruSil.TabIndex = 2;
            this.btnDuyuruSil.Text = "Duyuruyu Sil";
            this.btnDuyuruSil.UseVisualStyleBackColor = true;
            this.btnDuyuruSil.Click += new System.EventHandler(this.btnDuyuruSil_Click);
            // 
            // btnDuyuruGnclle
            // 
            this.btnDuyuruGnclle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDuyuruGnclle.Enabled = false;
            this.btnDuyuruGnclle.Location = new System.Drawing.Point(674, 514);
            this.btnDuyuruGnclle.Name = "btnDuyuruGnclle";
            this.btnDuyuruGnclle.Size = new System.Drawing.Size(175, 45);
            this.btnDuyuruGnclle.TabIndex = 3;
            this.btnDuyuruGnclle.Text = "Duyuruyu Güncelle";
            this.btnDuyuruGnclle.UseVisualStyleBackColor = true;
            this.btnDuyuruGnclle.Click += new System.EventHandler(this.btnDuyuruGnclle_Click);
            // 
            // FrmDuyurular
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1211, 583);
            this.Controls.Add(this.btnDuyuruGnclle);
            this.Controls.Add(this.btnDuyuruSil);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmDuyurular";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Duyurular";
            this.Load += new System.EventHandler(this.FrmDuyurular_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnDuyuruSil;
        private System.Windows.Forms.Button btnDuyuruGnclle;
    }
}
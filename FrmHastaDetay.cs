using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace PROJE_HASTANE
{
    public partial class FrmHastaDetay : Form
    {
        public FrmHastaDetay()
        {
            InitializeComponent();
        }

        public string tc;

        SqlBaglantisi bgl = new SqlBaglantisi();

        void RandevularımListele()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select Randevuid,RandevuTarih,RandevuSaat,RandevuBrans,RandevuDoktor from Tbl_Randevular where HastaTC=" + tc, bgl.baglanti());
            DataTable dt = new DataTable(); 
            da.Fill(dt);
            dataGridView1.DataSource = dt; 
        }
        
        void Temizle()
        {
            txtID.Clear();
            cmbBrans.SelectedIndex = -1;
            CmbHekm.SelectedIndex = -1;
            rchSikayet.Clear();
            btnRandevuAl.Enabled = false;
            lblRanUyarı.Text = "*Randevu Seçilmedi";
            dataGridView2.DataSource = null;
        }

        private void FrmHastaDetay_Load(object sender, EventArgs e)
        {

            RandevularımListele();

            lblTC.Text = tc;
            //HastaBilgileri getirme
            SqlCommand cmd = new SqlCommand("Select HastaAd,HastaSoyad,HastaBoy,HastaKilo,HastaKanGrubu from Tbl_Hastalar where HastaTC=@tc", bgl.baglanti());
            cmd.Parameters.AddWithValue("@tc", tc);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lblAdSoyad.Text = dr[0].ToString() + "  " + dr[1].ToString(); 
                lblBoy.Text= dr[2].ToString();
                lblKilo.Text= dr[3].ToString();
                lblKanGrubu.Text= dr[4].ToString();
            }
            bgl.baglanti().Close();

            //Branş Çekme
            SqlCommand cmd2 = new SqlCommand("Select BransAd from Tbl_Branslar", bgl.baglanti());
            SqlDataReader drBrans = cmd2.ExecuteReader();
            while (drBrans.Read()) 
            {
                cmbBrans.Items.Add(drBrans[0].ToString());
            }
            bgl.baglanti().Close();
        }

        //Seçilen Doktora Göre Branş Seçme
        private void cmbBrans_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            CmbHekm.Items.Clear();
            SqlCommand cmdDoc = new SqlCommand("Select DoktorAd,DoktorSoyad from Tbl_Doktorlar where DoktorBrans=@brans", bgl.baglanti());
            cmdDoc.Parameters.AddWithValue("@brans", cmbBrans.Text);
            SqlDataReader drDoc = cmdDoc.ExecuteReader();
            while (drDoc.Read())
            {
                CmbHekm.Items.Add(drDoc[0] + " " + drDoc[1]);
            }

            bgl.baglanti().Close();
        }

        //brans ve doktor seçtikten sonra seçilen doktora ait randevular datagridte gösterilecek.
        private void CmbHekm_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            DataTable dtt2 = new DataTable();

            SqlCommand cmd = new SqlCommand("SELECT Randevuid,RandevuTarih,RandevuSaat,RandevuBrans,RandevuDoktor from Tbl_Randevular WHERE RandevuBrans=@p1 and RandevuDoktor=@p2 and RandevuDurum=0", bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", cmbBrans.Text);
            cmd.Parameters.AddWithValue("@p2", CmbHekm.Text);
            SqlDataAdapter daa = new SqlDataAdapter(cmd);
            daa.Fill(dtt2);
            dataGridView2.DataSource = dtt2;
        }

    
        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnRandevuAl.Enabled = true;
            lblRanUyarı.Text = "";
            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            txtID.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
        }

        string randevuID = string.Empty;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            randevuID = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            lblRandevu.Text = dataGridView1.Rows[secilen].Cells[1].Value + " - " + dataGridView1.Rows[secilen].Cells[2].Value + " - " + dataGridView1.Rows[secilen].Cells[3].Value + " - " + dataGridView1.Rows[secilen].Cells[4].Value;
            btnRandevuIptal.Enabled = true;
        }

        private void btnRandevuIptal_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(randevuID))
            {
                DialogResult result = MessageBox.Show("Randevunuz iptal edilecektir, emin misinz?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(bgl.baglanti().ConnectionString))
                        {
                            SqlCommand cmd = new SqlCommand("Update Tbl_Randevular set RandevuDurum=0, HastaTC=NULL,HastaSikayet=NULL where Randevuid=@id", bgl.baglanti());
                            cmd.Parameters.AddWithValue("@id", randevuID);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Randevunuz iptal edilmiştir");
                            RandevularımListele();
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("SQL HATASI: " + ex.Message);
                        return;
                    }
                    finally
                    {
                        randevuID = string.Empty;
                        lblRandevu.Text = "*İptal edilecek randevuyu seçin.";
                        btnRandevuIptal.Enabled = false;
                    }
                }
                if (result == DialogResult.No)
                {
                    lblRandevu.Text = "*İptal edilecek randevuyu seçin.";
                    randevuID=string.Empty;
                    btnRandevuIptal.Enabled = false;
                }

            }
            else
            {
                MessageBox.Show("Randevu seçimi yapmadınız");
                return;
            }
        }

        private void btnRandevuAl_Click_1(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Randevu seçmediniz");
            }

            if(string.IsNullOrEmpty(rchSikayet.Text))
            {
                MessageBox.Show("Lütfen şikayetinizi belirtin");
            }

            try
            {
                SqlCommand command = new SqlCommand("Update Tbl_Randevular set RandevuDurum=1, HastaTC=@p1, HastaSikayet=@p2 where Randevuid=@p3", bgl.baglanti());
                command.Parameters.AddWithValue("@p1", lblTC.Text);
                command.Parameters.AddWithValue("@p2", rchSikayet.Text);
                command.Parameters.AddWithValue("@p3", txtID.Text);
                command.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Randevu Alınmıştır");
                RandevularımListele();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL HATASI: " + ex.Message);
                return;
            }
            finally
            {
                Temizle();
            }
           
        }

        private void lnkBilgiDuzenle_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmBilgiDuzenle fr = new FrmBilgiDuzenle();
            fr.tc_bilgi = lblTC.Text;
            fr.Show();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Oturum kapatılacak, emin misiniz?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                FrmHastaGiris fr = new FrmHastaGiris();
                fr.Show();
                this.Close();
            }
        }
    }
}

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

namespace PROJE_HASTANE
{
    public partial class FrmRandevuListesi : Form
    {
        public FrmRandevuListesi()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        void BosRandevularListele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select Randevuid,RandevuTarih,RandevuSaat,RandevuBrans,RandevuDoktor,RandevuDurum From Tbl_Randevular where RandevuDurum=0 ", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.baglanti().Close();
        }

        void DoluRandevuListele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Randevular where RandevuDurum=1 ", bgl.baglanti());
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            bgl.baglanti().Close();
        }

        void Temizle()
        {
            mskHastaTC.Clear();
            rchSikayet.Clear();
            txtRanID.Clear();
            cmbBrans.SelectedIndex = -1;
            txtDoktorAdSyd.Text = "";
            dateTimePicker1.Value = DateTime.Today;
            lblRandevu.Text = "*Randevu Seçimi Yapılmadı..";
            lblRandevu2.Text = "*Randevu Seçimi Yapılmadı..";
            btnRandevuIptal.Enabled = false;
            btnRandevuVer.Enabled = false;
            mskHastaTC.Enabled = false;
            rchSikayet.Enabled = false;
        }

        void CmbBrans()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Branslar", bgl.baglanti());
            da.Fill(dt);
            cmbBrans.ValueMember = "Bransid";
            cmbBrans.DisplayMember = "BransAd";
            cmbBrans.DataSource = dt;
            cmbBrans.SelectedIndex = -1;
        }

        private void FrmRandevuListesi_Load(object sender, EventArgs e)
        {
            CmbBrans();
            DoluRandevuListele();
            BosRandevularListele();
        }

        private void btnRandevuVer_Click(object sender, EventArgs e)
        {
            if(mskHastaTC.Text.Length<mskHastaTC.Mask.Length)
            {
                MessageBox.Show("TC alanını eksiksiz doldurunuz");
                return;
            }

            if(string.IsNullOrEmpty(rchSikayet.Text))
            {
                MessageBox.Show("Şikayet boş bırakılamaz");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(bgl.baglanti().ConnectionString))//Randevu Alma
                {
                    SqlCommand cmd = new SqlCommand("Update Tbl_Randevular set RandevuDurum=1, HastaTC=@p1, HastaSikayet=@p2 where Randevuid=@p3", bgl.baglanti());
                    cmd.Parameters.AddWithValue("@p1", mskHastaTC.Text);
                    cmd.Parameters.AddWithValue("@p2", rchSikayet.Text);
                    cmd.Parameters.AddWithValue("@p3", randevuID);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Randevu Verilmiştir");
                }
            }

            catch (SqlException ex)
            {
                MessageBox.Show("SQL HATASI: " + ex.Message);
                return;
            }
            finally
            {
                Temizle();
                BosRandevularListele();
                DoluRandevuListele();
            }
        }

        string randevuID;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnRandevuVer.Enabled = true;
            mskHastaTC.Enabled = true;
            rchSikayet.Enabled = true;
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            randevuID = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtRanID.Text = randevuID;
            lblRandevu.Text = dataGridView1.Rows[secilen].Cells[1].Value + " - " + dataGridView1.Rows[secilen].Cells[2].Value + "\n" + dataGridView1.Rows[secilen].Cells[3].Value + " - " + dataGridView1.Rows[secilen].Cells[4].Value;
        }

        private void btnRandevuIptal_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(bgl.baglanti().ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("Update Tbl_Randevular SET RandevuDurum=0,HastaTC= NULL, HastaSikayet= NULL where Randevuid=@p1", bgl.baglanti());
                    cmd.Parameters.AddWithValue("@p1", randevuID);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Randevu iptal edilmiştir");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL HATASI: " + ex.Message);
                return;
            }
            finally
            {
                Temizle();
                DoluRandevuListele();
            }


        }

        private void txtDoktorAdSyd_TextChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from Tbl_Randevular where RandevuDoktor like @adsoyad and RandevuDurum=0", bgl.baglanti());
            cmd.Parameters.AddWithValue("@adsoyad", "%" + txtDoktorAdSyd.Text + "%");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void cmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Randevular where RandevuBrans=@brans and RandevuDurum=0", bgl.baglanti());
            da.SelectCommand.Parameters.AddWithValue("@brans", cmbBrans.Text);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Randevular where RandevuTarih=@tarih and RandevuDurum=0", bgl.baglanti());
            da.SelectCommand.Parameters.AddWithValue("@tarih", dateTimePicker1.Value.Date.ToShortDateString());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnRandevuIptal.Enabled = true;
            int secilen2 = dataGridView2.SelectedCells[0].RowIndex;
            randevuID = dataGridView2.Rows[secilen2].Cells[0].Value.ToString();
            btnRandevuIptal.Enabled = true;
            txtRanID.Text = randevuID;
            lblRandevu2.Text = dataGridView2.Rows[secilen2].Cells[1].Value + " - " + dataGridView2.Rows[secilen2].Cells[2].Value + "\n" + dataGridView2.Rows[secilen2].Cells[3].Value + " - " + dataGridView2.Rows[secilen2].Cells[4].Value;
        }

        private void mskSorguTC_TextChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from Tbl_Randevular where HastaTC like @htc and RandevuDurum=1", bgl.baglanti());
            cmd.Parameters.AddWithValue("@htc", mskSorguTC.Text + "%");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
           
        }

        private void txtSorguDokAds_TextChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from Tbl_Randevular where RandevuDoktor like @adsoyad and RandevuDurum=1", bgl.baglanti());
            cmd.Parameters.AddWithValue("@adsoyad", "%" + txtSorguDokAds.Text + "%");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            
        }


        string tarih = "";
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            tarih = dateTimePicker2.Value.Date.ToShortDateString();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Randevular where RandevuTarih=@tarih and RandevuDurum=1", bgl.baglanti());
            da.SelectCommand.Parameters.AddWithValue("@tarih", tarih);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void mskSorguSaat_TextChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from Tbl_Randevular where RandevuTarih=@trh and RandevuSaat like @saat and RandevuDurum=1", bgl.baglanti());
            cmd.Parameters.AddWithValue("@saat", mskSorguSaat.Text + "%");
            cmd.Parameters.AddWithValue("@trh", dateTimePicker2.Value.Date.ToShortDateString());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void dateTimePicker1_Enter(object sender, EventArgs e)
        {
            txtDoktorAdSyd.Clear();
            cmbBrans.SelectedIndex = -1;
        }

        private void cmbBrans_Enter(object sender, EventArgs e)
        {
            txtDoktorAdSyd.Clear();
            dateTimePicker1.Value = DateTime.Today;
        }

        private void txtDoktorAdSyd_Enter(object sender, EventArgs e)
        {
            cmbBrans.SelectedIndex = -1;
            dateTimePicker1.Value = DateTime.Today;
        }

        private void txtSorguDokAds_Enter(object sender, EventArgs e)
        {
            mskSorguSaat.Clear();
            dateTimePicker2.Value = DateTime.Today;
            mskSorguTC.Clear();
        }

        private void mskSorguTC_Enter(object sender, EventArgs e)
        {
            mskSorguSaat.Clear();
            txtSorguDokAds.Clear();
            dateTimePicker2.Value = DateTime.Today;
        }

        private void dateTimePicker2_Enter(object sender, EventArgs e)
        {
            mskSorguSaat.Clear();
            mskSorguTC.Clear();
            txtSorguDokAds.Clear();
        }

        private void mskSorguSaat_Enter(object sender, EventArgs e)
        {
            mskSorguTC.Clear();
            txtSorguDokAds.Clear();
        }

       
    }
}

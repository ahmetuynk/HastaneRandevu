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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PROJE_HASTANE
{
    public partial class FrmSekreterDetay : Form
    {
        public FrmSekreterDetay()
        {
            InitializeComponent();
        }
        public string sekreterTC;

        SqlBaglantisi bgl = new SqlBaglantisi();

        void Temizle()
        {
            dtpTarih.Value = DateTime.Today;
            MskSaat.Clear();
            //CmbBrans.Text = "";
            //CmbHekim.Text = "";
            CmbHekim.SelectedIndex = -1;
            CmbBrans.SelectedIndex = -1;
            
        }

        private void FrmSekreterDetay_Load(object sender, EventArgs e)
        {
            LblTC.Text = sekreterTC;

            //Ad Soyad Çekme
            SqlCommand cmd = new SqlCommand("Select SekreterAdSoyad from Tbl_Sekreter where SekreterTC=@p1", bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", sekreterTC);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                LblAdSoyad.Text = dr[0].ToString();
            }
            bgl.baglanti().Close();

            bgl.baglanti().Close();

            //CmbBranslara branş çekme
            SqlCommand cmd3 = new SqlCommand("Select BransAd from Tbl_Branslar", bgl.baglanti());
            SqlDataReader dr2 = cmd3.ExecuteReader();
            while (dr2.Read())
            {
                CmbBrans.Items.Add(dr2[0].ToString());
            }
            bgl.baglanti().Close();


        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (MskSaat.Text.Length < MskSaat.Mask.Length || string.IsNullOrWhiteSpace(CmbBrans.Text) || string.IsNullOrWhiteSpace(CmbHekim.Text))
            {
                MessageBox.Show("Tüm alanları eksiksiz doldurunuz.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(bgl.baglanti().ConnectionString))
                {
                    SqlCommand cmd2 = new SqlCommand("Insert into Tbl_Randevular (RandevuTarih,RandevuSaat,RandevuBrans,RandevuDoktor) values(@p1,@p2,@p3,@p4)", bgl.baglanti());

                    cmd2.Parameters.AddWithValue("@p1", dtpTarih.Value.ToString("dd.MM.yyyy"));
                    cmd2.Parameters.AddWithValue("@p2", MskSaat.Text);
                    cmd2.Parameters.AddWithValue("@p3", CmbBrans.Text);
                    cmd2.Parameters.AddWithValue("@p4", CmbHekim.Text);
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Randevu Oluşturuldu");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL HATASI:" + ex.Message);
                return;
            }
            finally
            {
                Temizle();
            }
        }

        private void CmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CmbHekim e seçilen bransa ait hekimleri çekme
            CmbHekim.Text = "";
            CmbHekim.Items.Clear();

            SqlCommand cmd4 = new SqlCommand("Select DoktorAd,DoktorSoyad from Tbl_Doktorlar where DoktorBrans=@p1", bgl.baglanti());
            cmd4.Parameters.AddWithValue("@p1", CmbBrans.Text);
            SqlDataReader drHekim = cmd4.ExecuteReader();
            while (drHekim.Read())
            {
                CmbHekim.Items.Add(drHekim[0] + " " + drHekim[1]);

            }
            bgl.baglanti().Close();
        }

        private void btnDuyuruOlustur_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(RchDuyuru.Text))
            {
                MessageBox.Show("Duyuru metni boş bırakılamaz.");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(bgl.baglanti().ConnectionString))
                {
                    SqlCommand cmdDuyuru = new SqlCommand("INSERT INTO Tbl_Duyurular (Duyuru) VALUES (@p1) ", bgl.baglanti());
                    cmdDuyuru.Parameters.AddWithValue("@p1", RchDuyuru.Text);
                    cmdDuyuru.ExecuteNonQuery();
                    MessageBox.Show("Duyuru Gönderildi");
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL HATASI:" + ex.Message);
                return;
            }
            finally
            {
                RchDuyuru.Text = "";
            }

        }

        private void BtnListe_Click(object sender, EventArgs e)
        {
            FrmRandevuListesi fr = new FrmRandevuListesi();
            fr.Show();
        }

        private void BtnHekimPanel_Click(object sender, EventArgs e)
        {
            FrmDoktorPaneli fr = new FrmDoktorPaneli();
            fr.Show();
        }

        private void BtnBransPanel_Click(object sender, EventArgs e)
        {
            FrmBrans fr = new FrmBrans();
            fr.Show();
        }

        private void btnDuyurular_Click(object sender, EventArgs e)
        {
            FrmDuyurular fr = new FrmDuyurular();
            fr.Show();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Giriş ekranına dönmek istediğinizden emin misiniz?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

                FrmGirisler fr = new FrmGirisler();
                fr.Show();
                this.Close();
            }
           
        }
    }
}

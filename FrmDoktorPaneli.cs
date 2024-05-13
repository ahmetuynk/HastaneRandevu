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
    public partial class FrmDoktorPaneli : Form
    {
        public FrmDoktorPaneli()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();

        void Temizle()
        {
            TxtAd.Clear();
            TxtSoyad.Clear();
            CmbBrans.Items.Clear();
            CmbBrans.Text = "";
            MskTC.Clear();
            TxtSifre.Clear();
            BtnEkle.Enabled= true;
            BtnSil.Enabled = false;
            BtnGuncelle.Enabled = false;
            cmbBrans();
        }

        void doktorListele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Doktorlar ", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        void cmbBrans()//Bransları comboboxa aktarma
        {
            SqlCommand cmdbrans = new SqlCommand("Select BransAd from Tbl_Branslar", bgl.baglanti());
            SqlDataReader drBrans = cmdbrans.ExecuteReader();
            while (drBrans.Read())
            {
                CmbBrans.Items.Add(drBrans[0]);

            }
            bgl.baglanti().Close();
        }

        private void FrmDoktorPaneli_Load(object sender, EventArgs e)
        {
            doktorListele();
            cmbBrans();
        }
        private void BtnEkle_Click(object sender, EventArgs e)
        {
            bool alanlarDolu = true;

            foreach (Control control in groupBox1.Controls)
            {
                if (control is TextBox textBox && string.IsNullOrEmpty(textBox.Text))
                {
                    alanlarDolu = false;
                    break;
                }

                else if (control is ComboBox comboBox && string.IsNullOrEmpty(comboBox.Text))
                {
                    alanlarDolu = false;
                    break;
                }

                else if (control is MaskedTextBox maskedTextBox && maskedTextBox.Text.Length < maskedTextBox.Mask.Length)
                {
                    alanlarDolu = false;
                    break;
                }
            }

            if (!alanlarDolu)
            {
                MessageBox.Show("Tüm alanları eksiksiz doldurunuz", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(bgl.baglanti().ConnectionString))
                {

                    SqlCommand cmdHekimEkle = new SqlCommand("Insert into Tbl_Doktorlar (DoktorAd,DoktorSoyad,DoktorBrans,DoktorTC,DoktorSifre) values (@p1,@p2,@p3,@p4,@p5) ", bgl.baglanti());
                    cmdHekimEkle.Parameters.AddWithValue("@p1", TxtAd.Text);
                    cmdHekimEkle.Parameters.AddWithValue("@p2", TxtSoyad.Text);
                    cmdHekimEkle.Parameters.AddWithValue("@p3", CmbBrans.Text);
                    cmdHekimEkle.Parameters.AddWithValue("@p4", MskTC.Text);
                    cmdHekimEkle.Parameters.AddWithValue("@p5", TxtSifre.Text);
                    cmdHekimEkle.ExecuteNonQuery();
                    MessageBox.Show("Hekim Eklendi");
                   
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL HATASI:" + ex.Message);
                return;
            }
            doktorListele();
            Temizle();

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {

            if(string.IsNullOrEmpty(MskTC.Text))
            {
                MessageBox.Show("Seçim yapmadınız, Lütfen sistemden kaldırmak istediğiniz hekimi seçin");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(bgl.baglanti().ConnectionString))
                {
                    SqlCommand HekimSil = new SqlCommand("Delete from Tbl_Doktorlar where DoktorTC=@p1", bgl.baglanti());
                    HekimSil.Parameters.AddWithValue("@p1", MskTC.Text);
                    HekimSil.ExecuteNonQuery();
                    MessageBox.Show("Hekim Sistemden Silindi");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL HATASI: "+ex.Message);
                return;
            }
            finally
            {
                doktorListele();
                Temizle();
            }
            
        }

        private void BtnGuncelle_Click(object sender, EventArgs e) //Şifre değiştir
        {
            if (string.IsNullOrEmpty(MskTC.Text) || MskTC.Text.Length < MskTC.Mask.Length)
            {
                MessageBox.Show("Seçim yapmadınız, Lütfen şifresini değiştirmek istediğiniz hekimi seçin");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(bgl.baglanti().ConnectionString))
                {
                    SqlCommand HekimGncl = new SqlCommand("Update Tbl_Doktorlar set DoktorSifre=@p4 where DoktorTC=@p5", bgl.baglanti());
                    HekimGncl.Parameters.AddWithValue("@p4", TxtSifre.Text);
                    HekimGncl.Parameters.AddWithValue("@p5", MskTC.Text);
                    HekimGncl.ExecuteNonQuery();
                    MessageBox.Show(TxtAd.Text + " " + TxtSoyad.Text + " Şifresi değiştirilmiştir. Yeni Şifre: " + TxtSifre.Text);
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
                doktorListele();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selected = dataGridView1.SelectedCells[0].RowIndex; 
            TxtAd.Text = dataGridView1.Rows[selected].Cells[1].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[selected].Cells[2].Value.ToString();
            CmbBrans.Text = dataGridView1.Rows[selected].Cells[3].Value.ToString();
            MskTC.Text = dataGridView1.Rows[selected].Cells[4].Value.ToString();
            TxtSifre.Text = dataGridView1.Rows[selected].Cells[5].Value.ToString();
            BtnEkle.Enabled = true;
            BtnSil.Enabled = true;
            BtnGuncelle.Enabled = true;
        }     
    }
}

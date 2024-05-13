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
    public partial class FrmBrans : Form
    {
        public FrmBrans()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        void BransListele()
        {
            DataTable dtBrans = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Branslar", bgl.baglanti());
            da.Fill(dtBrans);
            dataGridView1.DataSource = dtBrans;
            bgl.baglanti().Close();
        }

        void Temizle()
        {
            TxtBrans.Text = "";
            Txtid.Text = "";
            BransListele();
            BtnGuncelle.Enabled = false;
            BtnSil.Enabled = false;
            BtnEkle.Enabled = true;
        }

        private void FrmBrans_Load(object sender, EventArgs e)
        {
            BransListele();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            Txtid.Text= dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            TxtBrans.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TxtBrans.Focus();
            BtnSil.Enabled = true;
            BtnGuncelle.Enabled = true;
            BtnEkle.Enabled = false;
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtBrans.Text))
            {
                MessageBox.Show("Branş belirtmediniz");
                return;
            }

            SqlCommand cmdEkle = new SqlCommand("Insert into Tbl_Branslar (BransAd) values (@p2)", bgl.baglanti());
            cmdEkle.Parameters.AddWithValue("@p2", TxtBrans.Text);
            cmdEkle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Brans Eklendi");
            Temizle();
           
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtBrans.Text))
            {
                MessageBox.Show("Branş seçmediniz, Silmek istediğiniz branşı seçin.");
                return;
            }

            SqlCommand cmdSil = new SqlCommand("Delete from Tbl_Branslar where Bransid=@id",bgl.baglanti());
            cmdSil.Parameters.AddWithValue("@id", Txtid.Text);
            cmdSil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Brans Silindi");
            Temizle();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtBrans.Text))
            {
                MessageBox.Show("Branş belirtmediniz, Güncellemek istedğiniz branşı seçin.");
                return;
            }

            SqlCommand cmdGnc = new SqlCommand("Update Tbl_Branslar set BransAd=@ad where Bransid=@id",bgl.baglanti());
            cmdGnc.Parameters.AddWithValue("@ad", TxtBrans.Text);
            cmdGnc.Parameters.AddWithValue("@id", Txtid.Text);
            cmdGnc.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Brans Güncellendi");
            Temizle();
        }
    }
}

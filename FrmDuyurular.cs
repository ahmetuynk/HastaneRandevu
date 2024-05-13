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
    public partial class FrmDuyurular : Form
    {
        public FrmDuyurular()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();

        void duyuruListele()
        {
            DataTable dtDuyurular = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Duyurular", bgl.baglanti());
            da.Fill(dtDuyurular);
            dataGridView1.DataSource = dtDuyurular;
            bgl.baglanti().Close();
        }

        private void FrmDuyurular_Load(object sender, EventArgs e)
        {
            duyuruListele();
        }


        string id = "";
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDuyuruSil.Enabled = true;
            btnDuyuruGnclle.Enabled = true;
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            richTextBox1.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }

        private void btnDuyuruSil_Click(object sender, EventArgs e)
        {

            try
            {
                SqlCommand cmd = new SqlCommand("Delete from Tbl_Duyurular where Duyuruid=" + id, bgl.baglanti());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Duyuru silinmiştir");
                duyuruListele();

            }
            catch (Exception)
            {
                MessageBox.Show("Duyuru seçilmedi");
                return;
            }
            finally
            {
                bgl.baglanti().Close();
            }
            richTextBox1.Clear();
            btnDuyuruSil.Enabled = false;
            btnDuyuruGnclle.Enabled = false;
            id = "";

        }

        private void btnDuyuruGnclle_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(richTextBox1.Text))
            {
                MessageBox.Show("Güncellemek istedğiniz duyuruyu seçin, Duyuru boş olamaz");
                return;
            }

            try
            {
                SqlCommand cmd = new SqlCommand("Update Tbl_Duyurular set Duyuru=@p1 where Duyuruid=@p2", bgl.baglanti());
                cmd.Parameters.AddWithValue("@p1", richTextBox1.Text);
                cmd.Parameters.AddWithValue("@p2", id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Duyuru güncellenmiştir");
                duyuruListele();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL HATASI: " + ex.Message);
                return;
            }
            finally
            {
                bgl.baglanti().Close();
            }
            btnDuyuruSil.Enabled = false;
            btnDuyuruGnclle.Enabled = false;
            richTextBox1.Clear();
        }
    }
}

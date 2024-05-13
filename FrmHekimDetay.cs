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
    public partial class FrmHekimDetay : Form
    {
        public FrmHekimDetay()
        {
            InitializeComponent();
        }
        public string doktorTC;
        SqlBaglantisi bgl = new SqlBaglantisi();
        private void FrmHekimDetay_Load(object sender, EventArgs e)
        {
            //TC ve Ad Soyad Çekme --Sol Üst kısım

            lblTC.Text = doktorTC;
            SqlCommand cmd = new SqlCommand("Select DoktorAd,DoktorSoyad from Tbl_Doktorlar where DoktorTC=@p1", bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", lblTC.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lblAdSoyad.Text = dr[0] + " " + dr[1];
            }
            bgl.baglanti().Close();

            //**Doktora ait aktif randevuları çekmek , randevuların hepsi de çekilebilirdi ve parameter kullanmadan dogurdan '"+lblAdSoyad.Text +"'de yazılabılırdı sorguya

            DataTable dt = new DataTable();
            SqlCommand cmd2 = new SqlCommand("Select * from Tbl_Randevular where RandevuDurum=1 and RandevuDoktor=@p1", bgl.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            {
                cmd2.Parameters.AddWithValue("@p1", lblAdSoyad.Text);
                da.Fill(dt);
            }
            dataGridView1.DataSource = dt;

            bgl.baglanti().Close();

        }

        string hastaTC;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            hastaTC = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            rchSikayet.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();

            SqlCommand cmd = new SqlCommand("Select HastaAd,HastaSoyad,HastaBoy,HastaKilo,HastaKanGrubu from Tbl_Hastalar where HastaTC=" + hastaTC, bgl.baglanti());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lblHads.Text = dr[0] + " " + dr[1]; 
                lblHboy.Text = dr[2].ToString();
                lblHkilo.Text= dr[3].ToString();
                lblHkangrup.Text= dr[4].ToString();
            }
        }

        private void btnDuyurular_Click(object sender, EventArgs e)
        {
            FrmHekimDuyurular fr = new FrmHekimDuyurular();
            fr.Show();
            
        }

        private void btnBilgiGuncelle_Click(object sender, EventArgs e)
        {
            FrmHekimBilgiDuzenle fr = new FrmHekimBilgiDuzenle();
            fr.dtc = lblTC.Text;
            fr.Show();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Giriş ekranına dönmek istediğinizden emin misiniz?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                FrmHekimGiris fr = new FrmHekimGiris();
                fr.Show();
                this.Close();
            }          
        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from Tbl_Randevular where HastaTC like @htc and RandevuDurum=1 and RandevuDoktor=@dok", bgl.baglanti());
            cmd.Parameters.AddWithValue("@htc", maskedTextBox1.Text + "%");
            cmd.Parameters.AddWithValue("@dok", lblAdSoyad.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}

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
    public partial class FrmBilgiDuzenle : Form
    {
        public FrmBilgiDuzenle()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();

        public string tc_bilgi;
        private void FrmBilgiDuzenle_Load(object sender, EventArgs e)
        {
            
            mskTC.Text = tc_bilgi;
            SqlCommand cmd = new SqlCommand("Select HastaTelefon,HastaCinsiyet,HastaSifre,HastaBoy,HastaKilo from Tbl_Hastalar where HastaTC=@p1",bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", tc_bilgi);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                mskTelefon.Text = dr[0].ToString();
                cmbCinsiyet.Text = dr[1].ToString();
                txtSifre.Text = dr[2].ToString();
                mskBoy.Text = dr[3].ToString();
                mskKilo.Text= dr[4].ToString();
            }
            bgl.baglanti().Close();
        }

        private void btnBilgiGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd1 = new SqlCommand("Update Tbl_Hastalar set HastaBoy=@p1, HastaKilo=@p2,HastaTelefon=@p4,HastaCinsiyet=@p5,HastaSifre=@p6 where HastaTC=@p3",bgl.baglanti());

            cmd1.Parameters.AddWithValue("@p1", mskBoy.Text);
            cmd1.Parameters.AddWithValue("@p2", mskKilo.Text);
            cmd1.Parameters.AddWithValue("@p3",mskTC.Text);
            cmd1.Parameters.AddWithValue("@p4",mskTelefon.Text);
            cmd1.Parameters.AddWithValue("@p5",cmbCinsiyet.Text);
            cmd1.Parameters.AddWithValue("@p6",txtSifre.Text);
            cmd1.ExecuteNonQuery();

            bgl.baglanti().Close();
            MessageBox.Show("Bilgieriniz Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //this.Hide();
           
        }
    }
}

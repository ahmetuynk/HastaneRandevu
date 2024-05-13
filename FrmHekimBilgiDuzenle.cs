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
    public partial class FrmHekimBilgiDuzenle : Form
    {
        public FrmHekimBilgiDuzenle()
        {
            InitializeComponent();
        }
        public string dtc;

        SqlBaglantisi bgl = new SqlBaglantisi();
        private void FrmHekimBilgiDuzenle_Load(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("Select DoktorAd,DoktorSoyad,DoktorTC,DoktorBrans,DoktorSifre from Tbl_Doktorlar where DoktorTC=@tc",bgl.baglanti());
            cmd.Parameters.AddWithValue("@tc", dtc);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtAd.Text = dr[0].ToString();
                txtSoyad.Text = dr[1].ToString();
                mskTC.Text = dr[2].ToString();
                cmbBrans.Text = dr[3].ToString();
                txtSifre.Text = dr[4].ToString();
            }
            bgl.baglanti().Close();


            //cmbBransa bransları çekme:
            SqlCommand cmdbrans = new SqlCommand("Select BransAd from Tbl_Branslar", bgl.baglanti());
            SqlDataReader drbrans = cmdbrans.ExecuteReader();
            while (drbrans.Read())
            {
                cmbBrans.Items.Add(drbrans[0].ToString());
            }

        }

        private void btnBilgiGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand cmdGnc = new SqlCommand("Update Tbl_Doktorlar set DoktorAd=@p1,DoktorSoyad=@p2,DoktorBrans=@p3,DoktorSifre=@p4 where DoktorTC=@p5", bgl.baglanti());
            cmdGnc.Parameters.AddWithValue("@p1",txtAd.Text);
            cmdGnc.Parameters.AddWithValue("@p2", txtSoyad.Text);
            cmdGnc.Parameters.AddWithValue("@p3", cmbBrans.Text);
            cmdGnc.Parameters.AddWithValue("@p4", txtSifre.Text);
            cmdGnc.Parameters.AddWithValue("@p5", mskTC.Text); 
            cmdGnc.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bilgiler Güncellendi");
        }
    }
}

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
    public partial class FrmHekimGiris : Form
    {
        public FrmHekimGiris()
        {
            InitializeComponent();
        }
        
        SqlBaglantisi bgl = new SqlBaglantisi();
        
        private void btnGiris_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select DoktorTC, DoktorSifre from Tbl_Doktorlar where DoktorTC=@p1 and DoktorSifre=@p2", bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", mskTC.Text);
            cmd.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                FrmHekimDetay fR = new FrmHekimDetay();
                fR.doktorTC = mskTC.Text;
                fR.Show();
                this.Hide();
            }
            else
            {
              MessageBox.Show("TC veya Şifreyi hatalı girdiniz","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                mskTC.Focus();
                mskTC.Text = "";
                txtSifre.Text = "";
                    
            }
            bgl.baglanti().Close();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            FrmGirisler fr = new FrmGirisler();
            fr.Show();
            this.Close();
        }
    }
}

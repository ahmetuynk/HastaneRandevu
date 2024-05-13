using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PROJE_HASTANE
{
    public partial class FrmHastaGiris : Form
    {
        public FrmHastaGiris()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        private void lnkKayitOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmHastaKayitOl fr = new FrmHastaKayitOl();
            fr.Show();
            this.Close();
            
           
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select HastaTC,HastaSifre from Tbl_Hastalar where HastaTC=@p1 and HastaSifre=@p2 ",bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", mskTC.Text);
            cmd.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr =cmd.ExecuteReader();
            if (dr.Read())
            {
                FrmHastaDetay fr = new FrmHastaDetay();
                fr.tc = mskTC.Text;
                fr.Show();
                this.Hide();
                
            }
            else
            {
                MessageBox.Show("TC Kimlik No veya Şifrenizi Yanlış Girdiniz, Tekrar Deneyin", "HATA",MessageBoxButtons.OK, MessageBoxIcon.Error);
                mskTC.Text = "";
                txtSifre.Text = "";
                mskTC.Focus();
            }
            bgl.baglanti().Close();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            FrmGirisler fr = new FrmGirisler();
            fr.Show();
            this.Close();
        }

        private void FrmHastaGiris_Load(object sender, EventArgs e)
        {
            mskTC.Focus();
        }
    }
}

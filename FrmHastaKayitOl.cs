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
    public partial class FrmHastaKayitOl : Form
    {
        public FrmHastaKayitOl()
        {
            InitializeComponent();
        }

       SqlBaglantisi bgl = new SqlBaglantisi();

        FrmHastaGiris fr = new FrmHastaGiris();
       
        private void btnKaydol_Click(object sender, EventArgs e)
        {

            try
            {
                SqlCommand komut = new SqlCommand("insert into Tbl_Hastalar (HastaAd,HastaSoyad,HastaTC,HastaTelefon,HastaSifre,HastaCinsiyet,HastaBoy,HastaKilo,HastaKanGrubu) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", txtAd.Text);
                komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
                komut.Parameters.AddWithValue("@p3", mskTC.Text);
                komut.Parameters.AddWithValue("@p4", mskTelefon.Text);
                komut.Parameters.AddWithValue("@p5", txtSifre.Text);
                komut.Parameters.AddWithValue("@p6", cmbCinsiyet.Text);
                komut.Parameters.AddWithValue("@p7", mskBoy.Text);
                komut.Parameters.AddWithValue("@p8", mskKilo.Text);
                komut.Parameters.AddWithValue("@p9", cmbKan.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Başarıyla Kayıt Oldunuz Şifreniz: " + txtSifre.Text, "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fr.Show();
                this.Close();
            }
            catch (SqlException ex)
            {

                MessageBox.Show("SQL HATASI:" + ex.Message);
                return;
            }  
           
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            FrmHastaGiris frm = new FrmHastaGiris();
            frm.Show();
            this.Close();
        }
    }
}

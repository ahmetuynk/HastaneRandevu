using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace PROJE_HASTANE
{
    internal class SqlBaglantisi
    {
        public SqlConnection baglanti() 
        {                                           //KENDI SUNUCU BAGLANTINIZI GİRİN:
            SqlConnection baglan = new SqlConnection("Data Source=/*SUNUCUADINIZ*/\\SQLEXPRESS;Initial Catalog=HastaneProje;Integrated Security=True");
            baglan.Open();   
            return baglan;
        }
    }
}

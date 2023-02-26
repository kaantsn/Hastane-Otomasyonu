using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaneProje
{
    internal class sqlBaglantisi
    {
        public SqlConnection baglanti()
        {   //SQL bağlantısı için SqlConnection sınıfı oluşturuldu.
            
            SqlConnection baglan = new SqlConnection("Data Source=;Initial Catalog=HastaneProje;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}

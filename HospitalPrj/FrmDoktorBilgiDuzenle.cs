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

namespace HastaneProje
{
    public partial class FrmDoktorBilgiDuzenle : Form
    {
        public FrmDoktorBilgiDuzenle()
        {
            InitializeComponent();
        }
        sqlBaglantisi bgl = new sqlBaglantisi();

        public string dtc;
        private void FrmDoktorBilgiDuzenle_Load(object sender, EventArgs e)
        {
            msktc.Text = dtc;

            SqlCommand komut = new SqlCommand("select * from Doktorlar where DoktorTC=@d1 ", bgl.baglanti());
            komut.Parameters.AddWithValue("@d1", msktc.Text);
            SqlDataReader dataReader1= komut.ExecuteReader();
            while (dataReader1.Read())
            {
                lblad.Text = dataReader1[1].ToString();
                lblsoyad.Text = dataReader1[2].ToString();
                txtsifre.Text= dataReader1[5].ToString();
                cmbbrans.Text = dataReader1[3].ToString();

            }
            bgl.baglanti().Close();
        }

        private void btnbilgileriguncelle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update Doktorlar set DoktorAd=@d2,DoktorSoyad=@d3,DoktorSifre=@d4,DoktorBrans=@d5 where DoktorTC = @d1",bgl.baglanti());
            cmd.Parameters.AddWithValue("@d1", msktc.Text);
            cmd.Parameters.AddWithValue("@d2", lblad.Text);
            cmd.Parameters.AddWithValue("@d3",lblsoyad.Text);
            cmd.Parameters.AddWithValue("@d4", txtsifre.Text);
            cmd.Parameters.AddWithValue("@d5", cmbbrans.Text);
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bilgiler Güncellendi!","Uyarı!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

    }
}

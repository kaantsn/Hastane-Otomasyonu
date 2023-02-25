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

namespace HastaneProje
{
    public partial class FrmHastaBilgiDuzenle : Form
    {
        public FrmHastaBilgiDuzenle()
        {
            InitializeComponent();
        }

        public string tcno;

        sqlBaglantisi bgl = new sqlBaglantisi();

        private void FrmHastaBilgiDuzenle_Load(object sender, EventArgs e)
        {
            msktc.Text = tcno;

            SqlCommand komut = new SqlCommand("select * from Hastalar where HastaTC = @d1", bgl.baglanti());
            komut.Parameters.AddWithValue("@d1",msktc.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtad.Text = dr[2].ToString();
                txtsoyad.Text = dr[3].ToString();
                txttelefon.Text = dr[4].ToString();
                cmbcinsiyet.Text = dr[5].ToString();
                txtsifre.Text = dr[6].ToString();
            }

        }

        private void btnbilgileriguncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("update Hastalar set HastaAd=@d1,HastaSoyad=@d2, HastaTelefon=@d3,HastaCinsiyet=@d4,HastaSifre=@d5 where HastaTC = @d6",bgl.baglanti());
            komut2.Parameters.AddWithValue("@d1", txtad.Text);
            komut2.Parameters.AddWithValue("@d2", txtsoyad.Text);
            komut2.Parameters.AddWithValue("@d3", txttelefon.Text);
            komut2.Parameters.AddWithValue("@d4", cmbcinsiyet.Text);
            komut2.Parameters.AddWithValue("@d5", txtsifre.Text);
            komut2.Parameters.AddWithValue("@d6", msktc.Text);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bilgileriniz Güncellendi!");

        }
    }
}

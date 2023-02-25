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
    public partial class FrmHastaKayit : Form
    {
        public FrmHastaKayit()
        {
            InitializeComponent();
        }


        sqlBaglantisi bgl = new sqlBaglantisi();

        private void FrmHastaKayit_Load(object sender, EventArgs e)
        {

        }

        private void btnkayitol_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Hastalar (HastaTC,HastaAd,HastaSoyad,HastaTelefon,HastaCinsiyet,HastaSifre) values (@d1,@d2,@d3,@d4,@d5,@d6)", bgl.baglanti());
            komut.Parameters.AddWithValue("@d1", msktc.Text);
            komut.Parameters.AddWithValue("@d2", txtad.Text);
            komut.Parameters.AddWithValue("@d3", txtsoyad.Text);
            komut.Parameters.AddWithValue("@d4", txttelefon.Text);
            komut.Parameters.AddWithValue("@d5", cmbcinsiyet.Text);
            komut.Parameters.AddWithValue("@d6", txtsifre.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt başarıyla gerçekleşti. Şifreniz: " + txtsifre.Text, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}

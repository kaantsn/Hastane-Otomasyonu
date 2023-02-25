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
    public partial class FrmSekreterGiris : Form
    {
        public FrmSekreterGiris()
        {
            InitializeComponent();
        }

        sqlBaglantisi bgl = new sqlBaglantisi();
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from Sekreter where SekreterTC =@d1 and SekreterSifre=@d2",bgl.baglanti());
            komut.Parameters.AddWithValue("d1", msktc.Text);
            komut.Parameters.AddWithValue("d2", txtsifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrmSekreterDetay frm = new FrmSekreterDetay();
                frm.tcnumara = msktc.Text;
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("TC veya Şifre yanlış!");
            }
            bgl.baglanti().Close();

        }
    }
}

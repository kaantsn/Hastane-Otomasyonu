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
using System.Data.SqlClient;

namespace HastaneProje
{
    public partial class FrmSekreterDetay : Form
    {
        public FrmSekreterDetay()
        {
            InitializeComponent();
        }
        sqlBaglantisi bgl = new sqlBaglantisi();

        private void label9_Click(object sender, EventArgs e)
        {

        }
        public string tcnumara;

        private void FrmSekreterDetay_Load(object sender, EventArgs e)
        {
            lbltc.Text = tcnumara;

            //Ad Soyad
            SqlCommand komut = new SqlCommand("select SekreterAdSoyad from Sekreter where SekreterTC = @d1", bgl.baglanti());
            komut.Parameters.AddWithValue("@d1", lbltc.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lbladsoyad.Text = dr[0].ToString();
            }
            bgl.baglanti().Close();


            //Branşları datagride çekme
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select BransAd from Branslar ", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.baglanti().Close();


            //Doktorları Listeye Ekleme
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select (DoktorAd+' '+DoktorSoyad) as Doktor,DoktorBrans from Doktorlar", bgl.baglanti());
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;
            bgl.baglanti().Close();


            //Branşları comboboxa çekme

            SqlCommand komut5 = new SqlCommand("select BransAd from Branslar", bgl.baglanti());
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                cmbbrans.Items.Add(dr5[0].ToString());
            }
            bgl.baglanti().Close();

        }

        private void cmbdoktor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            //Randevu oluşturma
            SqlCommand komut = new SqlCommand("insert into Randevular (RandevuTarih,RandevuSaat,RandevuBrans,RandevuDoktor) values (@d1,@d2,@d3,@d4)", bgl.baglanti());
            komut.Parameters.AddWithValue("@d1", msktarih.Text);
            komut.Parameters.AddWithValue("@d2", msksaat.Text);
            komut.Parameters.AddWithValue("@d3", cmbbrans.Text);
            komut.Parameters.AddWithValue("@d4", cmbdoktor.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu Başarıyla Oluşturuldu!");
            txtid.Text = "";

            msktarih.Text = "";
            msksaat.Text = "";
            cmbbrans.Text = "";
            cmbdoktor.Text = "";
            msktc.Text = "";


        }

        private void cmbbrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbdoktor.Items.Clear();
            cmbdoktor.Text = "";


            //İlgili branşa ait doktoru comboboxa çekme
            SqlCommand komut = new SqlCommand("select DoktorAd,DoktorSoyad from Doktorlar where DoktorBrans = @d1", bgl.baglanti());
            komut.Parameters.AddWithValue("@d1", cmbbrans.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbdoktor.Items.Add(dr[0].ToString() + ' ' + dr[1].ToString());
            }
        }

        private void btnolustur_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Duyurular (Duyuru) values (@d1)", bgl.baglanti());
            komut.Parameters.AddWithValue("@d1", richduyuruolustur.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Duyuru Oluşturuldu!");

        }

        private void btndoktorpaneli_Click(object sender, EventArgs e)
        {
            FrmDoktorPaneli frm = new FrmDoktorPaneli();
            frm.Show();

            sqlBaglantisi bgl = new sqlBaglantisi();



        }

        private void btnbranspaneli_Click(object sender, EventArgs e)
        {
            FrmBransPaneli frm = new FrmBransPaneli();
            frm.Show();
        }

        private void btnrandevuliste_Click(object sender, EventArgs e)
        {
            FrmRandevuListesi frm = new FrmRandevuListesi();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmDuyurular frm = new FrmDuyurular();
            frm.Show();
        }
    }
}

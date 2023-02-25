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
    public partial class FrmDoktorDetay : Form
    {
        public FrmDoktorDetay()
        {
            InitializeComponent();
        }
        sqlBaglantisi bgl = new sqlBaglantisi();
        public string tcnoo;
        private void FrmDoktorDetay_Load(object sender, EventArgs e)
        {
            lbltc.Text = tcnoo;



            //Doktor Ad Soyad Çekme
            SqlCommand cmd = new SqlCommand("select DoktorAd, DoktorSoyad from Doktorlar where DoktorTC= @d1", bgl.baglanti());
            cmd.Parameters.AddWithValue("@d1", lbltc.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lbladsoyad.Text = dr[0].ToString() + " " + dr[1].ToString();
            }
            bgl.baglanti().Close();


            //Randevu Getirme
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Randevular where RandevuDoktor = '"+lbladsoyad.Text +"'" ,bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            
            
            
        }

        private void btnbilgiduzenle_Click(object sender, EventArgs e)
        {
            FrmDoktorBilgiDuzenle frm = new FrmDoktorBilgiDuzenle();
            frm.dtc = lbltc.Text;
            frm.Show();
        }

        private void btncikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            richsikayet.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();

            
        }
    }
}

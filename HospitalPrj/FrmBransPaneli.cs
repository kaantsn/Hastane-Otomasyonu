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
    public partial class FrmBransPaneli : Form
    {
        public FrmBransPaneli()
        {
            InitializeComponent();
        }

        //Sql bağlantısı oluşturuldu.
        sqlBaglantisi bgl = new sqlBaglantisi();

        private void FrmBransPaneli_Load(object sender, EventArgs e)
        {
            //Form yüklenirken Branşlar tablosundaki veriler yüklenir.

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Branslar",bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource= dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridView üzerinde bir kez tıklandığında ID ve BranşAdını textboxlara çeker.
            
            int secilen = dataGridView1.SelectedCells[0].RowIndex; //dataGridViewin hücrelerinde gezmek için değişken oluşturuldu.
            txtid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString(); //dataGridViewin ilk sütunundaki değer textboxa aktarıldı.
            txtbransad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString(); //dataGridViewin ikinci sütunundaki değer textboxa aktarıldı.
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            //Ekle butonuna bastıktan sonra veritabanına branş eklemesi yapar.

            SqlCommand komut = new SqlCommand("insert into Branslar (BransAd) values (@d1) ",bgl.baglanti()); //Sql tarafında tabloya veri ekleme komutları kullanıldı.
            komut.Parameters.AddWithValue("@d1", txtbransad.Text); // branşadını textboxtan alınıyor.
            komut.ExecuteNonQuery(); //ekleme-silme-güncelleme işlemi yapıldığı için NonQuery kullanılıyor.
            bgl.baglanti().Close();
            MessageBox.Show("Branş Başarıyla Eklendi!","Bilgi",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            //Sil butonuna bastıktan sonra veritabanından branş siler.

            SqlCommand komut = new SqlCommand("delete from Branslar where BransAd = @d1 ", bgl.baglanti());
            komut.Parameters.AddWithValue("@d1", txtbransad.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Branş Başarıyla Silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            //Güncelle butonuna bastıktan sonra veritabanında güncelleme yapar.

            SqlCommand komut = new SqlCommand("update Branslar set BransAd=@d1 where Bransid = @d2", bgl.baglanti());
            komut.Parameters.AddWithValue("@d1", txtbransad.Text);
            komut.Parameters.AddWithValue("@d2", txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Branş Başarıyla Güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}

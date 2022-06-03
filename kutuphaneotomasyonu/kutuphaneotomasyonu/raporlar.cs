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
using KP.ORM.Facade;
using KP.ORM.Entity;
namespace kutuphaneotomasyonu
{
    public partial class raporlar : Form
    {
        public raporlar()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Server=.;Database=kutuphane;Integrated Security=true;");
        private void raporlar_Load(object sender, EventArgs e)
        {

        }

        private void anasayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            anasayfa git = new anasayfa();
            git.Show();
            this.Hide();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnsatici1_Click(object sender, EventArgs e)
        {//Öğrencilerin aldığı kitapları gösteren sorgu

            dataGridView1.DataSource = ogrencilers.Listele1(); //Facade ın içinde prosedür Listele1 metotu içinde çağrıldı.
        }

        private void btnsatici2_Click(object sender, EventArgs e)
        {
            // Belli bir tarihte kitap alan öğrencileri ve kitapları gösteren sorgu
            dataGridView1.DataSource = ogrencilers.Listele2();
        }

        private void btnsatici3_Click(object sender, EventArgs e)
        {
            // Hangi görevlinin hangi öğrenciye kitap verdiğini gösteren sorgu
            dataGridView1.DataSource = ogrencilers.Listele3();
        }

        private void btnurun1_Click(object sender, EventArgs e)
        {
            //Kitap adeti 2'den büyük olan kitapları getiren sorgu
            dataGridView1.DataSource = ogrencilers.Listele4();
        }

        private void btnurun2_Click(object sender, EventArgs e)
        {
            //Kitap türü roman olan kitapları desc sıralama
            dataGridView1.DataSource = ogrencilers.Listele5();
        }

        private void btnurun3_Click(object sender, EventArgs e)
        {
            //Görünmez Dünya kitabını alan öğrencilerin bilgileri
            dataGridView1.DataSource = ogrencilers.Listele6();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Doğum tarihi 1996 dan küçük olan öğrencilerin okudukları toplam kitap sayısı ve türü
            dataGridView1.DataSource = ogrencilers.Listele14();
        }

        private void btnsiparis3_Click(object sender, EventArgs e)
        {
            //Kitap adeti 2 den fazla olan kitapları tür ve yazar göre gruplayan sorgu
            dataGridView1.DataSource = ogrencilers.Listele13();
        }

        private void btnsiparis2_Click(object sender, EventArgs e)
        {
            // S harfi ile başlayan kitapları getiren sorgu
            dataGridView1.DataSource = ogrencilers.Listele12();
        }

        private void btnsiparis1_Click(object sender, EventArgs e)
        {
            // Piraye adlı yazara ait kitapları getiren sorgu
            dataGridView1.DataSource = ogrencilers.Listele11();
        }

        private void btnmusteri3_Click(object sender, EventArgs e)
        {
            // Toplam kitap sayısını getiren sorgu
            dataGridView1.DataSource = ogrencilers.Listele10();
        }

        private void btnmusteri2_Click(object sender, EventArgs e)
        {
            // En son eklenen 5 öğrenci kaydı
            dataGridView1.DataSource = ogrencilers.Listele9();
        }

        private void btnmusteri1_Click(object sender, EventArgs e)
        {
            //Basımyılı 2019'dan büyük kitapların sayfa sayısı toplamını getiren sorgu
            dataGridView1.DataSource = ogrencilers.Listele8();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Kitap türü roman olanları ve sayfa sayısı 200'den küçük olanları gösteren sorgu
            dataGridView1.DataSource = ogrencilers.Listele7();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KP.ORM.Entity;//ekle
using KP.ORM.Facade;//ekle

namespace kutuphaneotomasyonu
{
    public partial class ogrenci : Form
    {
        public ogrenci()
        {
            InitializeComponent();
        }
        
        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void anasayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            anasayfa git = new anasayfa();
            git.Show();
            this.Hide();
        }

        private void btnraporlar_Click(object sender, EventArgs e)
        {
            raporlar git = new raporlar();
            git.Show();
            this.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            txtogrenciadsoyad.Tag = satir.Cells["ogrencino"].Value.ToString();
            txtogrenciadsoyad.Text = satir.Cells["ogrenciadsoyad"].Value.ToString();
            dateTimePicker1.Text = satir.Cells["dogumtarihi"].Value.ToString();
            txtcinsiyet.Text = satir.Cells["cinsiyet"].Value.ToString();
            maskedTextBox1.Text = satir.Cells["telefon"].Value.ToString();
            txtemail.Text = satir.Cells["email"].Value.ToString();
            txtadres.Text = satir.Cells["adres"].Value.ToString();
        }

        private void ogrenci_Load(object sender, EventArgs e)
        {

        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ogrencilers.Listele();//facade ki adını yazdık kp.orm yi kutuphaneotomasyonu.cs altına ekliyoruz.referencesdan
        }

        private void btnekle_Click(object sender, EventArgs e)//EKLE
        {
            ogrenciler ekle = new ogrenciler(); //entitydeki adı ogrenciler
            ekle.ogrenciadsoyad = txtogrenciadsoyad.Text;
            ekle.dogumtarihi = dateTimePicker1.Text;
            ekle.cinsiyet =txtcinsiyet.Text;
            ekle.telefon = maskedTextBox1.Text;
            ekle.email = txtemail.Text;
            ekle.adres = txtadres.Text;
            if (!ogrencilers.Kaydet(ekle)) //ogrencilers facade daki adı ve kaydet facade ki metot
                MessageBox.Show("Veriler eklenemedi");
            dataGridView1.DataSource = ogrencilers.Listele(); //ogrencilers facade daki ad
        }

        private void btnguncelle_Click(object sender, EventArgs e)//YENİLE
        {
            ogrenciler yenile = new ogrenciler();
            yenile.ogrencino = Convert.ToInt32(txtogrenciadsoyad.Tag);
            yenile.ogrenciadsoyad = txtogrenciadsoyad.Text;
            yenile.dogumtarihi = dateTimePicker1.Text;
            yenile.cinsiyet = txtcinsiyet.Text;
            yenile.telefon = maskedTextBox1.Text;
            yenile.email =txtemail.Text;
            yenile.adres = txtadres.Text;
            if (!ogrencilers.Yenile(yenile))
                MessageBox.Show("Güncellendi");
            dataGridView1.DataSource = ogrencilers.Listele();
        }

        private void btnara_Click(object sender, EventArgs e)//ARA
        {
            ogrenciler aa = new ogrenciler();//entitydeki ad
            aa.ogrenciadsoyad = txtogrenciadsoyad.Text;
            dataGridView1.DataSource = ogrencilers.Ara(aa);//facade daki adlar
        }

        private void btnsil_Click(object sender, EventArgs e)//SİL
        {
            ogrenciler sil = new ogrenciler();
            sil.ogrencino = Convert.ToInt32(txtogrenciadsoyad.Tag);
            if (!ogrencilers.Sil(sil))
                MessageBox.Show("Silinemedi");
            dataGridView1.DataSource = ogrencilers.Listele();
        }
    }
}

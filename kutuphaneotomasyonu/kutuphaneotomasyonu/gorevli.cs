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
    public partial class gorevli : Form
    {
        public gorevli()
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
            txtgorevliadsoyad.Tag = satir.Cells["gorevlino"].Value.ToString();
            txtgorevliadsoyad.Text = satir.Cells["gorevliadsoyad"].Value.ToString();
            dateTimePicker1.Text = satir.Cells["dogumtarihi"].Value.ToString();
            txtcinsiyet.Text = satir.Cells["cinsiyet"].Value.ToString();
            maskedTextBox1.Text = satir.Cells["telefon"].Value.ToString();
            txtemail.Text = satir.Cells["email"].Value.ToString();
            txtadres.Text = satir.Cells["adres"].Value.ToString();
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = gorevlilers.Listele();//facade ki adını yazdık kp.orm yi kutuphaneotomasyonu.cs altına ekliyoruz.referencesdan
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            gorevliler ekle = new gorevliler(); //entitydeki adı ogrenciler
            ekle.gorevliadsoyad = txtgorevliadsoyad.Text;
            ekle.dogumtarihi = dateTimePicker1.Text;
            ekle.cinsiyet = txtcinsiyet.Text;
            ekle.telefon = maskedTextBox1.Text;
            ekle.email = txtemail.Text;
            ekle.adres = txtadres.Text;
            if (!gorevlilers.Kaydet(ekle)) //ogrencilers facade daki adı ve kaydet facade ki metot
                MessageBox.Show("Veriler eklenemedi");
            dataGridView1.DataSource = gorevlilers.Listele(); //ogrencilers facade daki ad
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            gorevliler yenile = new gorevliler();
            yenile.gorevlino = Convert.ToInt32(txtgorevliadsoyad.Tag);
            yenile.gorevliadsoyad = txtgorevliadsoyad.Text;
            yenile.dogumtarihi = dateTimePicker1.Text;
            yenile.cinsiyet = txtcinsiyet.Text;
            yenile.telefon = maskedTextBox1.Text;
            yenile.email = txtemail.Text;
            yenile.adres = txtadres.Text;
            if (!gorevlilers.Yenile(yenile))
                MessageBox.Show("Güncellendi");
            dataGridView1.DataSource = gorevlilers.Listele();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            gorevliler sil = new gorevliler();
            sil.gorevlino = Convert.ToInt32(txtgorevliadsoyad.Tag);
            if (!gorevlilers.Sil(sil))
                MessageBox.Show("Silinemedi");
            dataGridView1.DataSource = gorevlilers.Listele();
        }

        private void btnara_Click(object sender, EventArgs e)
        {
            gorevliler aa = new gorevliler();
            aa.gorevliadsoyad = txtgorevliadsoyad.Text;
            dataGridView1.DataSource = gorevlilers.Ara(aa);
        }
    }
}

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
    public partial class kitap : Form
    {
        public kitap()
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
            txtkitapadi.Tag = satir.Cells["kitapno"].Value.ToString();
            txtkitapadi.Text = satir.Cells["kitapadi"].Value.ToString();
            txtyazaradi.Text = satir.Cells["yazaradi"].Value.ToString();
            comboBox1.Text = satir.Cells["tür"].Value.ToString();
            txtsayfasayisi.Text = satir.Cells["kitapsayfasayisi"].Value.ToString();
            txtbasimyili.Text = satir.Cells["kitapbasimyili"].Value.ToString();
            txtyayinevi.Text = satir.Cells["kitapyayinevi"].Value.ToString();
            txtadet.Text = satir.Cells["kitapadet"].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            kitaplar ekle = new kitaplar(); //entitydeki adı ogrenciler
            ekle.kitapadi = txtkitapadi.Text;
            ekle.yazaradi = txtyazaradi.Text;
            ekle.tür = comboBox1.Text;
            ekle.kitapsayfasayisi = Convert.ToInt32(txtsayfasayisi.Text);
            ekle.kitapbasimyili = txtbasimyili.Text;
            ekle.kitapyayinevi = txtyayinevi.Text;
            ekle.kitapadet = Convert.ToInt32(txtadet.Text);
            if (!kitaplars.Kaydet(ekle)) //ogrencilers facade daki adı ve kaydet facade ki metot
                MessageBox.Show("Veriler eklenemedi");
            dataGridView1.DataSource = kitaplars.Listele(); //ogrencilers facade daki ad
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = kitaplars.Listele();//facade ki adını yazdık kp.orm yi kutuphaneotomasyonu.cs altına ekliyoruz.referencesdan
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            kitaplar yenile = new kitaplar();
            yenile.kitapno = Convert.ToInt32(txtkitapadi.Tag);
            yenile.kitapadi = txtkitapadi.Text;
            yenile.yazaradi = txtyazaradi.Text;
            yenile.tür = comboBox1.Text;
            yenile.kitapsayfasayisi = Convert.ToInt32(txtsayfasayisi.Text);
            yenile.kitapbasimyili = txtbasimyili.Text;
            yenile.kitapyayinevi = txtyayinevi.Text;
            yenile.kitapadet = Convert.ToInt32(txtadet.Text);
            if (!kitaplars.Yenile(yenile))
                MessageBox.Show("Güncellendi");
            dataGridView1.DataSource = kitaplars.Listele();
        }

        private void btnara_Click(object sender, EventArgs e)
        {
            kitaplar aa = new kitaplar();//entitydeki ad
            aa.kitapadi = txtkitapadi.Text;
            dataGridView1.DataSource = kitaplars.Ara(aa);//facade daki adlar
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            kitaplar sil = new kitaplar();
            sil.kitapno = Convert.ToInt32(txtkitapadi.Tag);
            if (!kitaplars.Sil(sil))
                MessageBox.Show("Silinemedi");
            dataGridView1.DataSource = kitaplars.Listele();
        }
    }
}

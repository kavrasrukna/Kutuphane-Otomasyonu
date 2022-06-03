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
    public partial class odunc : Form
    {
        public odunc()
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
            txtogrencino.Tag = satir.Cells["oduncno"].Value.ToString();
            txtogrencino.Text = satir.Cells["ogrencino"].Value.ToString();
            txtgorevlino.Text = satir.Cells["gorevlino"].Value.ToString();
            txtkitapno.Text = satir.Cells["kitapno"].Value.ToString();
            dateTimePicker1.Text = satir.Cells["verilistarihi"].Value.ToString();
            dateTimePicker2.Text = satir.Cells["teslimtarihi"].Value.ToString();
  
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = odunclers.Listele();//facade ki adını yazdık kp.orm yi kutuphaneotomasyonu.cs altına ekliyoruz.referencesdan
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            oduncler ekle = new oduncler(); //entitydeki adı ogrenciler
            ekle.ogrencino = Convert.ToInt32(txtogrencino.Text);
            ekle.gorevlino = Convert.ToInt32(txtgorevlino.Text);
            ekle.kitapno = Convert.ToInt32(txtkitapno.Text);
            ekle.verilistarihi = dateTimePicker1.Text;
            ekle.teslimtarihi = dateTimePicker2.Text;
            if (!odunclers.Kaydet(ekle)) //ogrencilers facade daki adı ve kaydet facade ki metot
                MessageBox.Show("Veriler eklenemedi");
            dataGridView1.DataSource = odunclers.Listele(); //ogrencilers facade daki ad
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            oduncler yenile = new oduncler();
            yenile.oduncno = Convert.ToInt32(txtogrencino.Tag);
            yenile.ogrencino = Convert.ToInt32(txtogrencino.Text);
            yenile.gorevlino = Convert.ToInt32(txtgorevlino.Text);
            yenile.kitapno = Convert.ToInt32(txtkitapno.Text);
            yenile.verilistarihi = dateTimePicker1.Text;
            yenile.teslimtarihi = dateTimePicker2.Text;
            if (!odunclers.Yenile(yenile))
                MessageBox.Show("Güncellendi");
            dataGridView1.DataSource = odunclers.Listele();
        }

        private void btnara_Click(object sender, EventArgs e)
        {
            oduncler aa = new oduncler();//entitydeki ad
            aa.ogrencino = Convert.ToInt32(txtogrencino.Text);
            dataGridView1.DataSource = odunclers.Ara(aa);//facade daki adlar
        }

        private void btnsil_Click(object sender, EventArgs e)//bu
        {
            oduncler sil = new oduncler();
            sil.oduncno = Convert.ToInt32(txtogrencino.Tag);
            if (!odunclers.Sil(sil))
                MessageBox.Show("Silinemedi");
            dataGridView1.DataSource = odunclers.Listele();
        }
    }
}

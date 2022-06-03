using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kutuphaneotomasyonu
{
    public partial class anasayfa : Form
    {
        public anasayfa()
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

        private void btnmusteriler_Click(object sender, EventArgs e)
        {
            gorevli git = new gorevli();
            git.Show();
            this.Hide();
        }

        private void btnbayiler_Click(object sender, EventArgs e)
        {
            kitap git = new kitap();
            git.Show();
            this.Hide();
        }

        private void btnarabalar_Click(object sender, EventArgs e)
        {
            ogrenci git = new ogrenci();
            git.Show();
            this.Hide();
        }

        private void btnodemeler_Click(object sender, EventArgs e)
        {
            odunc git = new odunc();
            git.Show();
            this.Hide();
        }
    }
}

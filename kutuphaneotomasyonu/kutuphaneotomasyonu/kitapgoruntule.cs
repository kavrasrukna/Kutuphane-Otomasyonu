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
    public partial class kitapgoruntule : Form
    {
        public kitapgoruntule()
        {
            InitializeComponent();
        }

        private void anasayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void kitapgoruntule_Load(object sender, EventArgs e)
        {

        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = kitaplars.Listele();
        }

        private void btnara_Click(object sender, EventArgs e)
        {
            kitaplar aa = new kitaplar();//entitydeki ad
            aa.kitapadi = txtkitapadi.Text;
            dataGridView1.DataSource = kitaplars.Ara(aa);//facade daki adlar
        }
    }
}

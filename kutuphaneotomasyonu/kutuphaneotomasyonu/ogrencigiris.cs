using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;//bunu ekledik

namespace kutuphaneotomasyonu
{
    public partial class ogrencigiris : Form
    {
        public ogrencigiris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Server=.;Database=kutuphane;Integrated Security=true");
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void anasayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kutuphanegiris git = new kutuphanegiris();
            git.Show();
            this.Hide();
        }

        private void btngiris_Click(object sender, EventArgs e)
        {

            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "ogrgiris";
            komut.Parameters.AddWithValue("ogrencino", txtogrencino.Text);
            komut.Parameters.AddWithValue("sifre", txtsifre.Text); //polno poladi tablodaki kolnlarımın adı
            baglanti.Open();
            SqlDataReader dr = komut.ExecuteReader();

            if (dr.Read())
            {
                MessageBox.Show("Tebrikler! Başarılı bir şekilde giriş yaptınız.");
                kitapgoruntule git = new kitapgoruntule();
                git.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adınız veya şifreniz hatalı.Tekrar deneyiniz");
                txtogrencino.Clear();
                txtsifre.Clear();
            }
            baglanti.Close();
        }
    }
}

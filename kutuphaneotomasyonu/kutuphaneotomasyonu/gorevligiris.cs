﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;//ekledik

namespace kutuphaneotomasyonu
{//görevli giriş tc:11111111112,sifre:11
    //tc:67, sifre:6767
    //öğrenci girişi:no:12 sifre:1234
    public partial class gorevligiris : Form
    {
        public gorevligiris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Server=.;Database=kutuphane;Integrated Security=true");
        private void btngiris_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "grvligiris";
            komut.Parameters.AddWithValue("gorevlitcno", txttcno.Text);
            komut.Parameters.AddWithValue("sifre", txtsifre.Text); //polno poladi tablodaki kolnlarımın adı
            baglanti.Open();
            SqlDataReader dr = komut.ExecuteReader();

            if (dr.Read())
            {
                MessageBox.Show("Tebrikler! Başarılı bir şekilde giriş yaptınız.");
                anasayfa git = new anasayfa();
                git.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adınız veya şifreniz hatalı.Tekrar deneyiniz");
                txttcno.Clear();
                txtsifre.Clear();
            }
            baglanti.Close();
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
    }
}

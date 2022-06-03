using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KP.ORM.Entity;//BU KÜTÜPHANEYİ EKLEDİM OLUŞTURDUĞUMUZ
using System.Data;//BU KÜTÜPHANEYİ EKLEDİM
using System.Data.SqlClient;//BU KÜTÜPHANEYİ EKLEDİM
namespace KP.ORM.Facade
{
    public class gorevlilers
    {
        public static DataTable Listele()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("gorevlilistele", Tools.Baglanti);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        public static DataTable Ara(gorevliler ara2)//ogrenciler entity üstüne gelince gözüküyor
        {
            SqlCommand ara = new SqlCommand("gorevliara", Tools.Baglanti);
            ara.CommandType = CommandType.StoredProcedure;
            ara.Parameters.AddWithValue("gorevliadsoyad", ara2.gorevliadsoyad);
            Tools.ExecuteNonQuery(ara);

            SqlDataAdapter adapter = new SqlDataAdapter(ara);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        public static bool Sil(gorevliler gsil) // uretim class usil nesne ürettik
        {
            SqlCommand sil = new SqlCommand("gorevlisil", Tools.Baglanti); //bağlanti
            sil.CommandType = CommandType.StoredProcedure;
            sil.Parameters.AddWithValue("gorevlino", gsil.gorevlino);//usilden aldığı parametreyi uretimno ya atar
            return Tools.ExecuteNonQuery(sil);
        }
        public static bool Kaydet(gorevliler ekle)
        {
            SqlCommand insert = new SqlCommand("gorevliekle", Tools.Baglanti);
            insert.CommandType = CommandType.StoredProcedure;
            insert.Parameters.AddWithValue("gorevliadsoyad", ekle.gorevliadsoyad);
            insert.Parameters.AddWithValue("dogumtarihi", ekle.dogumtarihi);
            insert.Parameters.AddWithValue("cinsiyet", ekle.cinsiyet);
            insert.Parameters.AddWithValue("telefon", ekle.telefon);
            insert.Parameters.AddWithValue("email", ekle.email);
            insert.Parameters.AddWithValue("adres", ekle.adres);
            return Tools.ExecuteNonQuery(insert);
        }
        public static bool Yenile(gorevliler yenile)
        {
            SqlCommand yy = new SqlCommand("gorevliyenile", Tools.Baglanti);
            yy.CommandType = CommandType.StoredProcedure;
            yy.Parameters.AddWithValue("gorevlino", yenile.gorevlino);
            yy.Parameters.AddWithValue("gorevliadsoyad", yenile.gorevliadsoyad);
            yy.Parameters.AddWithValue("dogumtarihi", yenile.dogumtarihi);
            yy.Parameters.AddWithValue("cinsiyet", yenile.cinsiyet);
            yy.Parameters.AddWithValue("telefon", yenile.telefon);
            yy.Parameters.AddWithValue("email", yenile.email);
            yy.Parameters.AddWithValue("adres", yenile.adres);
            return Tools.ExecuteNonQuery(yy);
        }
        //public static bool Arama(gorevliler ara)
        //{
        //    //SqlCommand a = new SqlCommand("gorevliara", Tools.Baglanti);
        //    //a.CommandType = CommandType.StoredProcedure;
        //    //a.Parameters.AddWithValue("gorevlino", ara.gorevlino);
        //    //a.Parameters.AddWithValue("gorevliadsoyad", ara.gorevliadsoyad);
        //    //a.Parameters.AddWithValue("dogumtarihi", ara.dogumtarihi);
        //    //a.Parameters.AddWithValue("cinsiyet", ara.cinsiyet);
        //    //a.Parameters.AddWithValue("telefon", ara.telefon);
        //    //a.Parameters.AddWithValue("email", ara.email);
        //    //a.Parameters.AddWithValue("adres", ara.adres);
        //    //return Tools.ExecuteNonQuery(a);
            
        //}
    }
}

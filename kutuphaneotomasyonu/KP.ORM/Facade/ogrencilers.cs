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
    public class ogrencilers
    {
        public static DataTable Listele()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("ogrencilistele", Tools.Baglanti);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        public static DataTable Ara(ogrenciler ara1)//ogrenciler entity üstüne gelince gözüküyor
        {
            SqlCommand ara = new SqlCommand("ogrenciara", Tools.Baglanti);
            ara.CommandType = CommandType.StoredProcedure;
            ara.Parameters.AddWithValue("ogrenciadsoyad", ara1.ogrenciadsoyad);
            Tools.ExecuteNonQuery(ara);

            SqlDataAdapter adapter = new SqlDataAdapter(ara);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        public static bool Sil(ogrenciler gsil) // uretim class usil nesne ürettik
        {
            SqlCommand sil = new SqlCommand("ogrencisil", Tools.Baglanti); //bağlanti
            sil.CommandType = CommandType.StoredProcedure;
            sil.Parameters.AddWithValue("ogrencino", gsil.ogrencino);//usilden aldığı parametreyi uretimno ya atar
            return Tools.ExecuteNonQuery(sil);
        }
        public static bool Kaydet(ogrenciler ekle)
        {
            SqlCommand insert = new SqlCommand("ogrenciekle", Tools.Baglanti);
            insert.CommandType = CommandType.StoredProcedure;
            insert.Parameters.AddWithValue("ogrenciadsoyad", ekle.ogrenciadsoyad);
            insert.Parameters.AddWithValue("dogumtarihi", ekle.dogumtarihi);
            insert.Parameters.AddWithValue("cinsiyet", ekle.cinsiyet);
            insert.Parameters.AddWithValue("telefon", ekle.telefon);
            insert.Parameters.AddWithValue("email", ekle.email);
            insert.Parameters.AddWithValue("adres", ekle.adres);
            return Tools.ExecuteNonQuery(insert);
        }
        public static bool Yenile(ogrenciler yenile)
        {
            SqlCommand yy = new SqlCommand("ogrenciyenile", Tools.Baglanti);
            yy.CommandType = CommandType.StoredProcedure;
            yy.Parameters.AddWithValue("ogrencino", yenile.ogrencino);
            yy.Parameters.AddWithValue("ogrenciadsoyad", yenile.ogrenciadsoyad);
            yy.Parameters.AddWithValue("dogumtarihi", yenile.dogumtarihi);
            yy.Parameters.AddWithValue("cinsiyet", yenile.cinsiyet);
            yy.Parameters.AddWithValue("telefon", yenile.telefon);
            yy.Parameters.AddWithValue("email", yenile.email);
            yy.Parameters.AddWithValue("adres", yenile.adres);
            return Tools.ExecuteNonQuery(yy);
        }
        public static DataTable Listele1() //procesürleri facade da çağırıyoruz. Buradaki listele1 metodunuda raporlar içinde çağırıyorum
        {
            SqlDataAdapter adapter = new SqlDataAdapter("ogrencikitap", Tools.Baglanti);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        public static DataTable Listele2()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("kitaptarih", Tools.Baglanti);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        public static DataTable Listele3()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("ogrencigorevli", Tools.Baglanti);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        public static DataTable Listele4()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("kitapadet", Tools.Baglanti);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        public static DataTable Listele5()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("kitaptur", Tools.Baglanti);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        public static DataTable Listele6()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("kitapogrenci2", Tools.Baglanti);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        public static DataTable Listele7()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("turroman", Tools.Baglanti);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        public static DataTable Listele8()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("toplamsayfa", Tools.Baglanti);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        public static DataTable Listele9()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("sonkayit", Tools.Baglanti);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        public static DataTable Listele10()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("toplamkitapsayisi", Tools.Baglanti);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        public static DataTable Listele11()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("kitapyazar", Tools.Baglanti);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        public static DataTable Listele12()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("kitaparama", Tools.Baglanti);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        public static DataTable Listele13()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("kitapgrupla", Tools.Baglanti);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        public static DataTable Listele14()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("kitapogrenci1", Tools.Baglanti);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
    }
}

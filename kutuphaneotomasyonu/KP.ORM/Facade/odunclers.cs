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
    public class odunclers
    {
        public static DataTable Listele()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("odunclistele", Tools.Baglanti);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        public static DataTable Ara(oduncler ara1)//ogrenciler entity üstüne gelince gözüküyor
        {
            SqlCommand ara = new SqlCommand("oduncara", Tools.Baglanti);
            ara.CommandType = CommandType.StoredProcedure;
            ara.Parameters.AddWithValue("ogrencino", ara1.ogrencino);
            Tools.ExecuteNonQuery(ara);

            SqlDataAdapter adapter = new SqlDataAdapter(ara);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        public static bool Sil(oduncler gsil) // uretim class usil nesne ürettik
        {
            SqlCommand sil = new SqlCommand("oduncsil", Tools.Baglanti); //bağlanti
            sil.CommandType = CommandType.StoredProcedure;
            sil.Parameters.AddWithValue("oduncno", gsil.oduncno);//usilden aldığı parametreyi uretimno ya atar
            return Tools.ExecuteNonQuery(sil);
        }
        public static bool Kaydet(oduncler ekle)
        {
            SqlCommand insert = new SqlCommand("oduncekle", Tools.Baglanti);
            insert.CommandType = CommandType.StoredProcedure;
            insert.Parameters.AddWithValue("ogrencino", ekle.ogrencino);
            insert.Parameters.AddWithValue("gorevlino", ekle.gorevlino);
            insert.Parameters.AddWithValue("kitapno", ekle.kitapno);
            insert.Parameters.AddWithValue("verilistarihi", ekle.verilistarihi);
            insert.Parameters.AddWithValue("teslimtarihi", ekle.teslimtarihi);
            return Tools.ExecuteNonQuery(insert);
        }
        public static bool Yenile(oduncler yenile)
        {
            SqlCommand yy = new SqlCommand("oduncyenile", Tools.Baglanti);
            yy.CommandType = CommandType.StoredProcedure;
            yy.Parameters.AddWithValue("oduncno", yenile.gorevlino);
            yy.Parameters.AddWithValue("ogrencino", yenile.ogrencino);
            yy.Parameters.AddWithValue("gorevlino", yenile.gorevlino);
            yy.Parameters.AddWithValue("kitapno", yenile.kitapno);
            yy.Parameters.AddWithValue("verilistarihi", yenile.verilistarihi);
            yy.Parameters.AddWithValue("teslimtarihi", yenile.teslimtarihi);
            return Tools.ExecuteNonQuery(yy);
        }
    }
}

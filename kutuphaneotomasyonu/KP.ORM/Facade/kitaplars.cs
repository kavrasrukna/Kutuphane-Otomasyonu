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
    public class kitaplars
    {
        public static DataTable Listele()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("kitaplistele", Tools.Baglanti);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        public static DataTable Ara(kitaplar ara1)//ogrenciler entity üstüne gelince gözüküyor
        {
            SqlCommand ara = new SqlCommand("kitapara", Tools.Baglanti);
            ara.CommandType = CommandType.StoredProcedure;
            ara.Parameters.AddWithValue("kitapadi", ara1.kitapadi);
            Tools.ExecuteNonQuery(ara);

            SqlDataAdapter adapter = new SqlDataAdapter(ara);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        public static bool Sil(kitaplar gsil) // uretim class usil nesne ürettik
        {
            SqlCommand sil = new SqlCommand("kitapsil", Tools.Baglanti); //bağlanti
            sil.CommandType = CommandType.StoredProcedure;
            sil.Parameters.AddWithValue("kitapno", gsil.kitapno);//usilden aldığı parametreyi uretimno ya atar
            return Tools.ExecuteNonQuery(sil);
        }
        public static bool Kaydet(kitaplar ekle)
        {
            SqlCommand insert = new SqlCommand("kitapekle", Tools.Baglanti);
            insert.CommandType = CommandType.StoredProcedure;
            insert.Parameters.AddWithValue("kitapadi", ekle.kitapadi);
            insert.Parameters.AddWithValue("yazaradi", ekle.yazaradi);
            insert.Parameters.AddWithValue("tür", ekle.tür);
            insert.Parameters.AddWithValue("kitapsayfasayisi", ekle.kitapsayfasayisi);
            insert.Parameters.AddWithValue("kitapbasimyili", ekle.kitapbasimyili);
            insert.Parameters.AddWithValue("kitapyayinevi", ekle.kitapyayinevi);
            insert.Parameters.AddWithValue("kitapadet", ekle.kitapadet);
            return Tools.ExecuteNonQuery(insert);
        }
        public static bool Yenile(kitaplar yenile)
        {
            SqlCommand yy = new SqlCommand("kitapyenile", Tools.Baglanti);
            yy.CommandType = CommandType.StoredProcedure;
            yy.Parameters.AddWithValue("kitapno", yenile.kitapno);
            yy.Parameters.AddWithValue("kitapadi", yenile.kitapadi);
            yy.Parameters.AddWithValue("yazaradi", yenile.yazaradi);
            yy.Parameters.AddWithValue("tür", yenile.tür);
            yy.Parameters.AddWithValue("kitapsayfasayisi", yenile.kitapsayfasayisi);
            yy.Parameters.AddWithValue("kitapbasimyili", yenile.kitapbasimyili);
            yy.Parameters.AddWithValue("kitapyayinevi", yenile.kitapyayinevi);
            yy.Parameters.AddWithValue("kitapadet", yenile.kitapadet);
            return Tools.ExecuteNonQuery(yy);
        }
    }
}

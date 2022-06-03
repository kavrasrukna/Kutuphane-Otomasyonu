using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;//ekledik
using System.Data;//ekledik
using System.Data.SqlClient;//ekledik


namespace KP.ORM
{
    public class Tools
    {
        //propert poliformizm
            private static SqlConnection baglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["kutuphane"].ConnectionString); //kutuphane adında bağlantı cümlesi oluşturduk.kutuphane çağırdığında veritabanına bağlanabileceğim
                                                                                                                                         //baglantı yönetici çalışşın connectionstrings app.configte ona gider bakar connection strins ler app configle burada aynı adda olmalı
            public static SqlConnection Baglanti //field
            {
                get { return baglanti; }
                set { baglanti = value; }
            }
            public static bool ExecuteNonQuery(SqlCommand komut) //static olduğunda nesne üretmeden her yerden ulaşabiliyoruz
            {
                try
                {
                    if (komut.Connection.State != ConnectionState.Open)  //bağlantı açık mı
                        komut.Connection.Open();//değilse aç
                    return komut.ExecuteNonQuery() > 0;//satır dönüyor mu bak
                }
                catch
                {
                    return false; //veritabanını açamaz catche düşürür
                }
                finally
                {
                    if (komut.Connection.State != ConnectionState.Closed)//işlem bittiğinde veritabanı kapalı mı bak kapalı mı 
                        komut.Connection.Close(); //değilse kapat
                }
            }
        }
}

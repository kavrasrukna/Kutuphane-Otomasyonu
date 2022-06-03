--��rencilerin ald��� kitaplar� g�steren sorgu--inner join
create proc ogrencikitap
as
begin
select ogrenciadsoyad,kitapadi from kitaplar k inner join oduncler o on k.kitapno=o.kitapno inner join ogrenciler ogr on o.ogrencino=ogr.ogrencino
end
exec ogrencikitap

--Belli bir tarihte kitap alan ��rencileri ve kitaplar� g�steren sorgu
create proc kitaptarih
as
begin
select ogrenciadsoyad,kitapadi,verilistarihi from kitaplar k inner join oduncler o on k.kitapno=o.kitapno inner join ogrenciler ogr on o.ogrencino=ogr.ogrencino
where verilistarihi='23.01.2021'
end
exec kitaptarih

--Hangi g�revlinin hangi ��renciye kitap verdi�ini g�steren sorgu
create proc ogrencigorevli
as
begin
select ogrenciadsoyad,kitapadi,gorevliadsoyad from kitaplar k inner join oduncler o on k.kitapno=o.kitapno inner join ogrenciler ogr on o.ogrencino=ogr.ogrencino
inner join gorevliler g on o.gorevlino=g.gorevlino
end
exec ogrencigorevli

--Kitap adeti 2'den b�y�k olan kitaplar� getiren sorgu
create proc kitapadet
as
begin
select kitapadi,kitapadet from kitaplar where kitapadet>2
end
exec kitapadet

--Kitap t�r� roman olan kitaplar� desc s�ralama
create proc kitaptur
as
begin
select kitapadi,t�r from kitaplar where t�r='roman' order by kitapadi desc 
end
exec kitaptur

--G�r�nmez D�nya kitab�n� alan ��rencilerin bilgileri
create proc kitapogrenci2
as
begin
select kitapadi,ogrenciadsoyad,dogumtarihi,cinsiyet,telefon,email,adres from kitaplar k inner join oduncler o on k.kitapno=o.kitapno inner join ogrenciler ogr on o.ogrencino=ogr.ogrencino
where kitapadi='g�r�nmez d�nya' 
end
exec kitapogrenci2

--Kitap t�r� roman olanlar� ve sayfa say�s� 200'den k���k olanlar� g�steren sorgu
create proc turroman
as
begin
select kitapadi,t�r,kitapsayfasayisi from kitaplar where t�r='roman' and kitapsayfasayisi<200
end
exec turroman

--Bas�my�l� 2019'dan b�y�k kitaplar�n sayfa say�s� toplam�n� getiren sorgu
create proc toplamsayfa
as
begin
select sum(kitapsayfasayisi) as '2019 y�l�ndan sonra bas�lan kitaplar�n toplam sayfa say�s�' from kitaplar where kitapbasimyili>'2019'
end
exec toplamsayfa

--En son eklenen 3 ��renci kayd�
create proc sonkayit
as
begin
select top 3 * from ogrenciler order by ogrencino desc
end
exec sonkayit

--Toplam kitap say�s�n� getiren sorgu
create proc toplamkitapsayisi
as
begin
select sum(kitapadet) as 'toplam kitap say�s�' from kitaplar 
end
exec toplamkitapsayisi

--Piraye adl� yazara ait kitaplar� getiren sorgu
create proc kitapyazar
as
begin
select kitapadi,yazaradi from kitaplar where yazaradi='piraye'
end
exec kitapyazar

--S harfi ile ba�layan kitaplar� getiren sorgu
create proc kitaparama
as
begin
select kitapadi from kitaplar where kitapadi like 's%'
end
exec kitaparama

--Kitap adeti 2 den fazla olan kitaplar� t�r ve yazar g�re gruplayan sorgu 
create proc kitapgrupla
as
begin
select t�r,yazaradi from kitaplar where kitapadet>2 group by t�r,yazaradi
end
exec kitapgrupla

--Do�um tarihi 1996 dan k���k olan ��rencilerin okuduklar� toplam kitap say�s�
create proc kitapogrenci1
as
begin
select sum(kitapadet) as '1996 dan k���k olan ��rencilerin okudular� toplam kitap say�s�' from kitaplar k inner join oduncler o on k.kitapno=o.kitapno inner join ogrenciler ogr on o.ogrencino=ogr.ogrencino
where kitapadet>2 
end
exec kitapogrenci1


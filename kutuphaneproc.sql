--Öðrencilerin aldýðý kitaplarý gösteren sorgu--inner join
create proc ogrencikitap
as
begin
select ogrenciadsoyad,kitapadi from kitaplar k inner join oduncler o on k.kitapno=o.kitapno inner join ogrenciler ogr on o.ogrencino=ogr.ogrencino
end
exec ogrencikitap

--Belli bir tarihte kitap alan öðrencileri ve kitaplarý gösteren sorgu
create proc kitaptarih
as
begin
select ogrenciadsoyad,kitapadi,verilistarihi from kitaplar k inner join oduncler o on k.kitapno=o.kitapno inner join ogrenciler ogr on o.ogrencino=ogr.ogrencino
where verilistarihi='23.01.2021'
end
exec kitaptarih

--Hangi görevlinin hangi öðrenciye kitap verdiðini gösteren sorgu
create proc ogrencigorevli
as
begin
select ogrenciadsoyad,kitapadi,gorevliadsoyad from kitaplar k inner join oduncler o on k.kitapno=o.kitapno inner join ogrenciler ogr on o.ogrencino=ogr.ogrencino
inner join gorevliler g on o.gorevlino=g.gorevlino
end
exec ogrencigorevli

--Kitap adeti 2'den büyük olan kitaplarý getiren sorgu
create proc kitapadet
as
begin
select kitapadi,kitapadet from kitaplar where kitapadet>2
end
exec kitapadet

--Kitap türü roman olan kitaplarý desc sýralama
create proc kitaptur
as
begin
select kitapadi,tür from kitaplar where tür='roman' order by kitapadi desc 
end
exec kitaptur

--Görünmez Dünya kitabýný alan öðrencilerin bilgileri
create proc kitapogrenci2
as
begin
select kitapadi,ogrenciadsoyad,dogumtarihi,cinsiyet,telefon,email,adres from kitaplar k inner join oduncler o on k.kitapno=o.kitapno inner join ogrenciler ogr on o.ogrencino=ogr.ogrencino
where kitapadi='görünmez dünya' 
end
exec kitapogrenci2

--Kitap türü roman olanlarý ve sayfa sayýsý 200'den küçük olanlarý gösteren sorgu
create proc turroman
as
begin
select kitapadi,tür,kitapsayfasayisi from kitaplar where tür='roman' and kitapsayfasayisi<200
end
exec turroman

--Basýmyýlý 2019'dan büyük kitaplarýn sayfa sayýsý toplamýný getiren sorgu
create proc toplamsayfa
as
begin
select sum(kitapsayfasayisi) as '2019 yýlýndan sonra basýlan kitaplarýn toplam sayfa sayýsý' from kitaplar where kitapbasimyili>'2019'
end
exec toplamsayfa

--En son eklenen 3 öðrenci kaydý
create proc sonkayit
as
begin
select top 3 * from ogrenciler order by ogrencino desc
end
exec sonkayit

--Toplam kitap sayýsýný getiren sorgu
create proc toplamkitapsayisi
as
begin
select sum(kitapadet) as 'toplam kitap sayýsý' from kitaplar 
end
exec toplamkitapsayisi

--Piraye adlý yazara ait kitaplarý getiren sorgu
create proc kitapyazar
as
begin
select kitapadi,yazaradi from kitaplar where yazaradi='piraye'
end
exec kitapyazar

--S harfi ile baþlayan kitaplarý getiren sorgu
create proc kitaparama
as
begin
select kitapadi from kitaplar where kitapadi like 's%'
end
exec kitaparama

--Kitap adeti 2 den fazla olan kitaplarý tür ve yazar göre gruplayan sorgu 
create proc kitapgrupla
as
begin
select tür,yazaradi from kitaplar where kitapadet>2 group by tür,yazaradi
end
exec kitapgrupla

--Doðum tarihi 1996 dan küçük olan öðrencilerin okuduklarý toplam kitap sayýsý
create proc kitapogrenci1
as
begin
select sum(kitapadet) as '1996 dan küçük olan öðrencilerin okudularý toplam kitap sayýsý' from kitaplar k inner join oduncler o on k.kitapno=o.kitapno inner join ogrenciler ogr on o.ogrencino=ogr.ogrencino
where kitapadet>2 
end
exec kitapogrenci1


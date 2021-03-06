USE [master]
GO
/****** Object:  Database [kutuphane]    Script Date: 31.5.2022 20:30:54 ******/
CREATE DATABASE [kutuphane]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'kutuphane', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\kutuphane.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'kutuphane_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\kutuphane_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [kutuphane] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [kutuphane].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [kutuphane] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [kutuphane] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [kutuphane] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [kutuphane] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [kutuphane] SET ARITHABORT OFF 
GO
ALTER DATABASE [kutuphane] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [kutuphane] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [kutuphane] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [kutuphane] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [kutuphane] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [kutuphane] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [kutuphane] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [kutuphane] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [kutuphane] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [kutuphane] SET  DISABLE_BROKER 
GO
ALTER DATABASE [kutuphane] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [kutuphane] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [kutuphane] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [kutuphane] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [kutuphane] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [kutuphane] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [kutuphane] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [kutuphane] SET RECOVERY FULL 
GO
ALTER DATABASE [kutuphane] SET  MULTI_USER 
GO
ALTER DATABASE [kutuphane] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [kutuphane] SET DB_CHAINING OFF 
GO
ALTER DATABASE [kutuphane] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [kutuphane] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [kutuphane] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [kutuphane] SET QUERY_STORE = OFF
GO
USE [kutuphane]
GO
/****** Object:  User [HP_\RÜKNA]    Script Date: 31.5.2022 20:30:55 ******/
CREATE USER [HP_\RÜKNA] FOR LOGIN [HP_\RÜKNA] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [HP_\RÜKNA]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [HP_\RÜKNA]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [HP_\RÜKNA]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [HP_\RÜKNA]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [HP_\RÜKNA]
GO
ALTER ROLE [db_datareader] ADD MEMBER [HP_\RÜKNA]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [HP_\RÜKNA]
GO
ALTER ROLE [db_denydatareader] ADD MEMBER [HP_\RÜKNA]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [HP_\RÜKNA]
GO
/****** Object:  Table [dbo].[gorevligiris]    Script Date: 31.5.2022 20:30:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[gorevligiris](
	[gorevlitcno] [nchar](11) NULL,
	[sifre] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[gorevliler]    Script Date: 31.5.2022 20:30:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[gorevliler](
	[gorevlino] [int] IDENTITY(1,1) NOT NULL,
	[gorevliadsoyad] [varchar](50) NULL,
	[dogumtarihi] [varchar](50) NULL,
	[cinsiyet] [varchar](50) NULL,
	[telefon] [nchar](15) NULL,
	[email] [varchar](50) NULL,
	[adres] [varchar](50) NULL,
 CONSTRAINT [PK_gorevliler] PRIMARY KEY CLUSTERED 
(
	[gorevlino] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[kitaplar]    Script Date: 31.5.2022 20:30:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[kitaplar](
	[kitapno] [int] IDENTITY(1,1) NOT NULL,
	[kitapadi] [varchar](50) NULL,
	[yazaradi] [varchar](50) NULL,
	[tür] [varchar](50) NULL,
	[kitapsayfasayisi] [int] NULL,
	[kitapbasimyili] [varchar](50) NULL,
	[kitapyayinevi] [varchar](50) NULL,
	[kitapadet] [int] NULL,
 CONSTRAINT [PK_kiaplar] PRIMARY KEY CLUSTERED 
(
	[kitapno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[oduncler]    Script Date: 31.5.2022 20:30:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[oduncler](
	[oduncno] [int] IDENTITY(1,1) NOT NULL,
	[ogrencino] [int] NULL,
	[gorevlino] [int] NULL,
	[kitapno] [int] NULL,
	[verilistarihi] [varchar](50) NULL,
	[teslimtarihi] [varchar](50) NULL,
 CONSTRAINT [PK_oduncler] PRIMARY KEY CLUSTERED 
(
	[oduncno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ogrencigiris]    Script Date: 31.5.2022 20:30:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ogrencigiris](
	[ogrencino] [int] NULL,
	[sifre] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ogrenciler]    Script Date: 31.5.2022 20:30:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ogrenciler](
	[ogrencino] [int] IDENTITY(1,1) NOT NULL,
	[ogrenciadsoyad] [varchar](50) NULL,
	[dogumtarihi] [varchar](50) NULL,
	[cinsiyet] [varchar](50) NULL,
	[telefon] [nchar](15) NULL,
	[email] [varchar](50) NULL,
	[adres] [varchar](50) NULL,
 CONSTRAINT [PK_ogrenciler] PRIMARY KEY CLUSTERED 
(
	[ogrencino] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[gorevligiris] ([gorevlitcno], [sifre]) VALUES (N'67         ', N'6767')
INSERT [dbo].[gorevligiris] ([gorevlitcno], [sifre]) VALUES (N'1234       ', N'1234')
GO
SET IDENTITY_INSERT [dbo].[gorevliler] ON 

INSERT [dbo].[gorevliler] ([gorevlino], [gorevliadsoyad], [dogumtarihi], [cinsiyet], [telefon], [email], [adres]) VALUES (1, N'Rükna Kavraş', N'23 Ocak 1997 Perşembe', N'Kız', N'(536) 959-5858 ', N'rukna@gmail.com', N'Sancaktepe')
INSERT [dbo].[gorevliler] ([gorevlino], [gorevliadsoyad], [dogumtarihi], [cinsiyet], [telefon], [email], [adres]) VALUES (2, N'Gizem Öz', N'31 Temmuz 1997 Perşembe', N'Kız', N'(569) 598-2424 ', N'gizem@gmail.com', N'Ümraniye')
INSERT [dbo].[gorevliler] ([gorevlino], [gorevliadsoyad], [dogumtarihi], [cinsiyet], [telefon], [email], [adres]) VALUES (3, N'Tibet Şahin', N'15 Ocak 1996 Pazartesi', N'Erkek', N'(532) 598-2525 ', N'tibet@gmail.com', N'Çekmeköy')
SET IDENTITY_INSERT [dbo].[gorevliler] OFF
GO
SET IDENTITY_INSERT [dbo].[kitaplar] ON 

INSERT [dbo].[kitaplar] ([kitapno], [kitapadi], [yazaradi], [tür], [kitapsayfasayisi], [kitapbasimyili], [kitapyayinevi], [kitapadet]) VALUES (1, N'Seyir', N'Piraye', N'Roman', 408, N'2019', N'Mona', 2)
INSERT [dbo].[kitaplar] ([kitapno], [kitapadi], [yazaradi], [tür], [kitapsayfasayisi], [kitapbasimyili], [kitapyayinevi], [kitapadet]) VALUES (2, N'Son Ada', N'Livaneli', N'Roman', 170, N'2013', N'Doğan Kitap', 3)
INSERT [dbo].[kitaplar] ([kitapno], [kitapadi], [yazaradi], [tür], [kitapsayfasayisi], [kitapbasimyili], [kitapyayinevi], [kitapadet]) VALUES (3, N'Beyaz Gemi', N'Cengiz Aytmatov', N'Roman', 112, N'2021', N'Cengiz Aytmatov', 4)
INSERT [dbo].[kitaplar] ([kitapno], [kitapadi], [yazaradi], [tür], [kitapsayfasayisi], [kitapbasimyili], [kitapyayinevi], [kitapadet]) VALUES (10, N'Da Vinci Şifresi', N'Dan Brown', N'Macera', 120, N'2014', N'Altın Kitaplar', 2)
INSERT [dbo].[kitaplar] ([kitapno], [kitapadi], [yazaradi], [tür], [kitapsayfasayisi], [kitapbasimyili], [kitapyayinevi], [kitapadet]) VALUES (11, N'Görünmez Dünya', N'William Gibson', N'Macera', 200, N'2000', N'Artemis Yayınları', 1)
SET IDENTITY_INSERT [dbo].[kitaplar] OFF
GO
SET IDENTITY_INSERT [dbo].[oduncler] ON 

INSERT [dbo].[oduncler] ([oduncno], [ogrencino], [gorevlino], [kitapno], [verilistarihi], [teslimtarihi]) VALUES (1, 4, 2, 1, N'23.01.2021', N'01.02.2021')
INSERT [dbo].[oduncler] ([oduncno], [ogrencino], [gorevlino], [kitapno], [verilistarihi], [teslimtarihi]) VALUES (2, 4, 1, 2, N'14 Ocak 2021 Perşembe', N'1 Şubat 2021 Pazartesi')
INSERT [dbo].[oduncler] ([oduncno], [ogrencino], [gorevlino], [kitapno], [verilistarihi], [teslimtarihi]) VALUES (7, 7, 2, 10, N'8 Şubat 2019 Cuma', N'6 Şubat 2019 Çarşamba')
INSERT [dbo].[oduncler] ([oduncno], [ogrencino], [gorevlino], [kitapno], [verilistarihi], [teslimtarihi]) VALUES (8, 4, 1, 2, N'14 Ocak 2021 Perşembe', N'1 Şubat 2021 Pazartesi')
INSERT [dbo].[oduncler] ([oduncno], [ogrencino], [gorevlino], [kitapno], [verilistarihi], [teslimtarihi]) VALUES (9, 8, 2, 10, N'6 Şubat 2019 Çarşamba', N'6 Şubat 2019 Çarşamba')
INSERT [dbo].[oduncler] ([oduncno], [ogrencino], [gorevlino], [kitapno], [verilistarihi], [teslimtarihi]) VALUES (10, 7, 1, 11, N'8 Şubat 2019 Cuma', N'6 Şubat 2019 Çarşamba')
SET IDENTITY_INSERT [dbo].[oduncler] OFF
GO
INSERT [dbo].[ogrencigiris] ([ogrencino], [sifre]) VALUES (1234, N'1234')
GO
SET IDENTITY_INSERT [dbo].[ogrenciler] ON 

INSERT [dbo].[ogrenciler] ([ogrencino], [ogrenciadsoyad], [dogumtarihi], [cinsiyet], [telefon], [email], [adres]) VALUES (4, N'Zeynep Köse', N'06.05.1998', N'Kız', N'5396595968     ', N'kubra@gmail.com', N'Çekmeköy')
INSERT [dbo].[ogrenciler] ([ogrencino], [ogrenciadsoyad], [dogumtarihi], [cinsiyet], [telefon], [email], [adres]) VALUES (5, N'Ayşe Uğuz', N'02.02.1991', N'Kız', N'5365965986     ', N'ayse@gmail.com', N'Ümraniye')
INSERT [dbo].[ogrenciler] ([ogrencino], [ogrenciadsoyad], [dogumtarihi], [cinsiyet], [telefon], [email], [adres]) VALUES (6, N'Şevval Çelik', N'01.03.1995', N'Kız', N'5365965956     ', N'sevval@gmail.com', N'Pendik')
INSERT [dbo].[ogrenciler] ([ogrencino], [ogrenciadsoyad], [dogumtarihi], [cinsiyet], [telefon], [email], [adres]) VALUES (7, N'Mehmet Öztürk', N'06.07.1996', N'Erkek', N'5369589598     ', N'mehmet@gmail.com', N'Maltepe')
INSERT [dbo].[ogrenciler] ([ogrencino], [ogrenciadsoyad], [dogumtarihi], [cinsiyet], [telefon], [email], [adres]) VALUES (8, N'Emre Coşkun', N'27 Temmuz 1997 Pazar', N'Erkek', N'(538) 569-2525 ', N'emre@gmail.com', N'Esenyurt')
SET IDENTITY_INSERT [dbo].[ogrenciler] OFF
GO
ALTER TABLE [dbo].[oduncler]  WITH CHECK ADD  CONSTRAINT [FK_oduncler_gorevliler] FOREIGN KEY([gorevlino])
REFERENCES [dbo].[gorevliler] ([gorevlino])
GO
ALTER TABLE [dbo].[oduncler] CHECK CONSTRAINT [FK_oduncler_gorevliler]
GO
ALTER TABLE [dbo].[oduncler]  WITH CHECK ADD  CONSTRAINT [FK_oduncler_kitaplar] FOREIGN KEY([kitapno])
REFERENCES [dbo].[kitaplar] ([kitapno])
GO
ALTER TABLE [dbo].[oduncler] CHECK CONSTRAINT [FK_oduncler_kitaplar]
GO
ALTER TABLE [dbo].[oduncler]  WITH CHECK ADD  CONSTRAINT [FK_oduncler_ogrenciler] FOREIGN KEY([ogrencino])
REFERENCES [dbo].[ogrenciler] ([ogrencino])
GO
ALTER TABLE [dbo].[oduncler] CHECK CONSTRAINT [FK_oduncler_ogrenciler]
GO
/****** Object:  StoredProcedure [dbo].[gorevliara]    Script Date: 31.5.2022 20:30:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[gorevliara] (
@gorevliadsoyad varchar(50)
)
as 
begin
select * from gorevliler where gorevliadsoyad=@gorevliadsoyad
end
GO
/****** Object:  StoredProcedure [dbo].[gorevliekle]    Script Date: 31.5.2022 20:30:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[gorevliekle]( 
@gorevliadsoyad varchar(50),
@dogumtarihi varchar(50),
@cinsiyet varchar(50),
@telefon nchar(15),
@email varchar(50),
@adres varchar(50)
)
as begin
insert into gorevliler(gorevliadsoyad,dogumtarihi,cinsiyet,telefon,email,adres) values (@gorevliadsoyad,@dogumtarihi,@cinsiyet,@telefon,@email,@adres)
end
GO
/****** Object:  StoredProcedure [dbo].[gorevlilistele]    Script Date: 31.5.2022 20:30:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[gorevlilistele] 
as begin
select * from gorevliler
end
GO
/****** Object:  StoredProcedure [dbo].[gorevlisil]    Script Date: 31.5.2022 20:30:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[gorevlisil] 
@gorevlino int
as begin
delete from gorevliler where gorevlino=@gorevlino
end
GO
/****** Object:  StoredProcedure [dbo].[gorevliyenile]    Script Date: 31.5.2022 20:30:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[gorevliyenile]( 
@gorevlino int,
@gorevliadsoyad varchar(50),
@dogumtarihi varchar(50),
@cinsiyet varchar(50),
@telefon nchar(15),
@email varchar(50),
@adres varchar(50)
)
as begin
update gorevliler set
gorevliadsoyad=@gorevliadsoyad,dogumtarihi=@dogumtarihi,cinsiyet=@cinsiyet,telefon=@telefon,email=@email,adres=@adres
where gorevlino=@gorevlino
end
GO
/****** Object:  StoredProcedure [dbo].[grvligiris]    Script Date: 31.5.2022 20:30:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[grvligiris](
@gorevlitcno nchar(11),
@sifre varchar(50)
)
as 
begin
select * from gorevligiris where gorevlitcno=@gorevlitcno and sifre=@sifre
end
GO
/****** Object:  StoredProcedure [dbo].[kitapadet]    Script Date: 31.5.2022 20:30:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[kitapadet]
as
begin
select kitapadi,kitapadet from kitaplar where kitapadet>2
end
GO
/****** Object:  StoredProcedure [dbo].[kitapara]    Script Date: 31.5.2022 20:30:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[kitapara] (
@kitapadi varchar(50)
)
as 
begin
select * from kitaplar where kitapadi=@kitapadi
end
GO
/****** Object:  StoredProcedure [dbo].[kitaparama]    Script Date: 31.5.2022 20:30:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[kitaparama]
as
begin
select kitapadi from kitaplar where kitapadi like 's%'
end
GO
/****** Object:  StoredProcedure [dbo].[kitapekle]    Script Date: 31.5.2022 20:30:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[kitapekle]( 
@kitapadi varchar(50),
@yazaradi varchar(50),
@tür varchar(50),
@kitapsayfasayisi int,
@kitapbasimyili varchar(50),
@kitapyayinevi varchar(50),
@kitapadet int
)
as begin
insert into kitaplar(kitapadi,yazaradi,tür,kitapsayfasayisi,kitapbasimyili,kitapyayinevi,kitapadet) values (@kitapadi,@yazaradi,@tür,@kitapsayfasayisi,@kitapbasimyili,@kitapyayinevi,@kitapadet)
end
GO
/****** Object:  StoredProcedure [dbo].[kitapgrupla]    Script Date: 31.5.2022 20:30:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[kitapgrupla]
as
begin
select tür,yazaradi from kitaplar where kitapadet>2 group by tür,yazaradi
end
GO
/****** Object:  StoredProcedure [dbo].[kitaplistele]    Script Date: 31.5.2022 20:30:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[kitaplistele] 
as begin
select * from kitaplar
end
GO
/****** Object:  StoredProcedure [dbo].[kitapogrenci1]    Script Date: 31.5.2022 20:30:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[kitapogrenci1]
as
begin
select sum(kitapadet) as '1996 dan küçük olan öğrencilerin okuduları toplam kitap sayısı' from kitaplar k inner join oduncler o on k.kitapno=o.kitapno inner join ogrenciler ogr on o.ogrencino=ogr.ogrencino
where kitapadet>2 
end
GO
/****** Object:  StoredProcedure [dbo].[kitapogrenci2]    Script Date: 31.5.2022 20:30:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[kitapogrenci2]
as
begin
select kitapadi,ogrenciadsoyad,dogumtarihi,cinsiyet,telefon,email,adres from kitaplar k inner join oduncler o on k.kitapno=o.kitapno inner join ogrenciler ogr on o.ogrencino=ogr.ogrencino
where kitapadi='görünmez dünya' 
end
GO
/****** Object:  StoredProcedure [dbo].[kitapsil]    Script Date: 31.5.2022 20:30:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[kitapsil] 
@kitapno int
as begin
delete from kitaplar where kitapno=@kitapno
end
GO
/****** Object:  StoredProcedure [dbo].[kitaptarih]    Script Date: 31.5.2022 20:30:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[kitaptarih]
as
begin
select ogrenciadsoyad,kitapadi,verilistarihi from kitaplar k inner join oduncler o on k.kitapno=o.kitapno inner join ogrenciler ogr on o.ogrencino=ogr.ogrencino
where verilistarihi='23.01.2021'
end
GO
/****** Object:  StoredProcedure [dbo].[kitaptur]    Script Date: 31.5.2022 20:30:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[kitaptur]
as
begin
select kitapadi,tür from kitaplar where tür='roman' order by kitapadi desc 
end
GO
/****** Object:  StoredProcedure [dbo].[kitapyazar]    Script Date: 31.5.2022 20:30:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[kitapyazar]
as
begin
select kitapadi,yazaradi from kitaplar where yazaradi='piraye'
end
GO
/****** Object:  StoredProcedure [dbo].[kitapyenile]    Script Date: 31.5.2022 20:30:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[kitapyenile]( 
@kitapno int,
@kitapadi varchar(50),
@yazaradi varchar(50),
@tür varchar(50),
@kitapsayfasayisi int,
@kitapbasimyili varchar(50),
@kitapyayinevi varchar(50),
@kitapadet int
)
as begin
update kitaplar set
kitapadi=@kitapadi,yazaradi=@yazaradi,tür=@tür,kitapsayfasayisi=@kitapsayfasayisi,kitapbasimyili=@kitapbasimyili,kitapyayinevi=@kitapyayinevi,kitapadet=@kitapadet
where kitapno=@kitapno
end
GO
/****** Object:  StoredProcedure [dbo].[oduncara]    Script Date: 31.5.2022 20:30:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[oduncara] (
@ogrencino varchar(50)
)
as 
begin
select * from oduncler where ogrencino=@ogrencino
end
GO
/****** Object:  StoredProcedure [dbo].[oduncekle]    Script Date: 31.5.2022 20:30:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[oduncekle]( 
@ogrencino int,
@gorevlino int,
@kitapno int,
@verilistarihi varchar(50),
@teslimtarihi varchar(50)
)
as begin
insert into oduncler(ogrencino,gorevlino,kitapno,verilistarihi,teslimtarihi) values (@ogrencino,@gorevlino,@kitapno,@verilistarihi,@teslimtarihi)
end
GO
/****** Object:  StoredProcedure [dbo].[odunclistele]    Script Date: 31.5.2022 20:30:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[odunclistele] 
as begin
select * from oduncler
end
GO
/****** Object:  StoredProcedure [dbo].[oduncsil]    Script Date: 31.5.2022 20:30:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[oduncsil] 
@oduncno int
as begin
delete from oduncler where oduncno=@oduncno
end
GO
/****** Object:  StoredProcedure [dbo].[oduncyenile]    Script Date: 31.5.2022 20:30:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[oduncyenile]( 
@oduncno int,
@ogrencino int,
@gorevlino int,
@kitapno int,
@verilistarihi varchar(50),
@teslimtarihi varchar(50)
)
as begin
update oduncler set
ogrencino=@ogrencino,gorevlino=@gorevlino,kitapno=@kitapno,verilistarihi=@verilistarihi,teslimtarihi=@teslimtarihi
where kitapno=@kitapno
end
GO
/****** Object:  StoredProcedure [dbo].[ogrenciara]    Script Date: 31.5.2022 20:30:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ogrenciara] (
@ogrenciadsoyad varchar(50)
)
as 
begin
select * from ogrenciler where ogrenciadsoyad=@ogrenciadsoyad
end
GO
/****** Object:  StoredProcedure [dbo].[ogrenciekle]    Script Date: 31.5.2022 20:30:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ogrenciekle]( 
@ogrenciadsoyad varchar(50),
@dogumtarihi varchar(50),
@cinsiyet varchar(50),
@telefon nchar(15),
@email varchar(50),
@adres varchar(50)
)
as begin
insert into ogrenciler(ogrenciadsoyad,dogumtarihi,cinsiyet,telefon,email,adres) values (@ogrenciadsoyad,@dogumtarihi,@cinsiyet,@telefon,@email,@adres)
end
GO
/****** Object:  StoredProcedure [dbo].[ogrencigorevli]    Script Date: 31.5.2022 20:30:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ogrencigorevli]
as
begin
select ogrenciadsoyad,kitapadi,gorevliadsoyad from kitaplar k inner join oduncler o on k.kitapno=o.kitapno inner join ogrenciler ogr on o.ogrencino=ogr.ogrencino
inner join gorevliler g on o.gorevlino=g.gorevlino
end
GO
/****** Object:  StoredProcedure [dbo].[ogrencikitap]    Script Date: 31.5.2022 20:30:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ogrencikitap]
as
begin
select ogrenciadsoyad,kitapadi from kitaplar k inner join oduncler o on k.kitapno=o.kitapno inner join ogrenciler ogr on o.ogrencino=ogr.ogrencino
end
GO
/****** Object:  StoredProcedure [dbo].[ogrencilistele]    Script Date: 31.5.2022 20:30:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ogrencilistele] 
as begin
select * from ogrenciler
end
GO
/****** Object:  StoredProcedure [dbo].[ogrencisil]    Script Date: 31.5.2022 20:30:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ogrencisil] 
@ogrencino int
as begin
delete from ogrenciler where ogrencino=@ogrencino
end
GO
/****** Object:  StoredProcedure [dbo].[ogrenciyenile]    Script Date: 31.5.2022 20:30:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ogrenciyenile]( 
@ogrencino int,
@ogrenciadsoyad varchar(50),
@dogumtarihi varchar(50),
@cinsiyet varchar(50),
@telefon nchar(15),
@email varchar(50),
@adres varchar(50)
)
as begin
update ogrenciler set
ogrenciadsoyad=@ogrenciadsoyad,dogumtarihi=@dogumtarihi,cinsiyet=@cinsiyet,telefon=@telefon,email=@email,adres=@adres
where ogrencino=@ogrencino
end
GO
/****** Object:  StoredProcedure [dbo].[ogrgiris]    Script Date: 31.5.2022 20:30:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ogrgiris](
@ogrencino int,
@sifre varchar(50)
)
as 
begin
select * from ogrencigiris where ogrencino=@ogrencino and sifre=@sifre
end
GO
/****** Object:  StoredProcedure [dbo].[sonkayit]    Script Date: 31.5.2022 20:30:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sonkayit]
as
begin
select top 3 * from ogrenciler order by ogrencino desc
end
GO
/****** Object:  StoredProcedure [dbo].[toplamkitapsayisi]    Script Date: 31.5.2022 20:30:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[toplamkitapsayisi]
as
begin
select sum(kitapadet) as 'toplam kitap sayısı' from kitaplar 
end
GO
/****** Object:  StoredProcedure [dbo].[toplamsayfa]    Script Date: 31.5.2022 20:30:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[toplamsayfa]
as
begin
select sum(kitapsayfasayisi) as '2019 yılından sonra basılan kitapların toplam sayfa sayısı' from kitaplar where kitapbasimyili>'2019'
end
GO
/****** Object:  StoredProcedure [dbo].[turroman]    Script Date: 31.5.2022 20:30:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[turroman]
as
begin
select kitapadi,tür,kitapsayfasayisi from kitaplar where tür='roman' and kitapsayfasayisi<200
end
GO
USE [master]
GO
ALTER DATABASE [kutuphane] SET  READ_WRITE 
GO

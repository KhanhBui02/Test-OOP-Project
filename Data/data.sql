USE [master]
GO
/****** Object:  Database [QuanLyQuanAnKLKK]    Script Date: 12/5/2021 12:26:07 PM ******/
CREATE DATABASE [QuanLyQuanAnKLKK]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLyQuanAnKLKK', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\QuanLyQuanAnKLKK.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QuanLyQuanAnKLKK_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\QuanLyQuanAnKLKK_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [QuanLyQuanAnKLKK] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyQuanAnKLKK].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyQuanAnKLKK] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyQuanAnKLKK] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyQuanAnKLKK] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyQuanAnKLKK] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyQuanAnKLKK] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyQuanAnKLKK] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QuanLyQuanAnKLKK] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyQuanAnKLKK] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyQuanAnKLKK] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyQuanAnKLKK] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyQuanAnKLKK] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyQuanAnKLKK] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyQuanAnKLKK] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyQuanAnKLKK] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyQuanAnKLKK] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QuanLyQuanAnKLKK] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyQuanAnKLKK] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyQuanAnKLKK] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyQuanAnKLKK] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyQuanAnKLKK] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyQuanAnKLKK] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyQuanAnKLKK] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyQuanAnKLKK] SET RECOVERY FULL 
GO
ALTER DATABASE [QuanLyQuanAnKLKK] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyQuanAnKLKK] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyQuanAnKLKK] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyQuanAnKLKK] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyQuanAnKLKK] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QuanLyQuanAnKLKK] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'QuanLyQuanAnKLKK', N'ON'
GO
ALTER DATABASE [QuanLyQuanAnKLKK] SET QUERY_STORE = OFF
GO
USE [QuanLyQuanAnKLKK]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [QuanLyQuanAnKLKK]
GO
/****** Object:  UserDefinedFunction [dbo].[GetUnsignString]    Script Date: 12/5/2021 12:26:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetUnsignString](@strInput NVARCHAR(4000)) 
RETURNS NVARCHAR(4000)
AS
BEGIN     
    IF @strInput IS NULL RETURN @strInput
    IF @strInput = '' RETURN @strInput
    DECLARE @RT NVARCHAR(4000)
    DECLARE @SIGN_CHARS NCHAR(136)
    DECLARE @UNSIGN_CHARS NCHAR (136)

    SET @SIGN_CHARS       = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệếìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵýĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ'+NCHAR(272)+ NCHAR(208)
    SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeeeiiiiiooooooooooooooouuuuuuuuuuyyyyyAADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIIIOOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD'

    DECLARE @COUNTER int
    DECLARE @COUNTER1 int
    SET @COUNTER = 1
 
    WHILE (@COUNTER <=LEN(@strInput))
    BEGIN   
      SET @COUNTER1 = 1
      --Tim trong chuoi mau
       WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1)
       BEGIN
     IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) )
     BEGIN           
          IF @COUNTER=1
              SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1)                   
          ELSE
              SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER)    
              BREAK         
               END
             SET @COUNTER1 = @COUNTER1 +1
       END
      --Tim tiep
       SET @COUNTER = @COUNTER +1
    END
    RETURN @strInput
END
GO
/****** Object:  Table [dbo].[Account]    Script Date: 12/5/2021 12:26:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[UserName] [nvarchar](50) NOT NULL,
	[DisplayName] [nvarchar](50) NOT NULL,
	[MatKhau] [nvarchar](1000) NOT NULL,
	[Loai] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 12/5/2021 12:26:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[IDBill] [int] IDENTITY(1,1) NOT NULL,
	[DateCheckIn] [date] NOT NULL,
	[DateCheckOut] [date] NULL,
	[IDTable] [int] NOT NULL,
	[TinhTrang] [int] NOT NULL,
	[discount] [int] NULL,
	[totalPrice] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[IDBill] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BillInfo]    Script Date: 12/5/2021 12:26:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillInfo](
	[IDBillInfo] [int] IDENTITY(1,1) NOT NULL,
	[IDBill] [int] NOT NULL,
	[IDFood] [int] NOT NULL,
	[CountFood] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDBillInfo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Food]    Script Date: 12/5/2021 12:26:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Food](
	[IDFood] [int] IDENTITY(1,1) NOT NULL,
	[NameFood] [nvarchar](100) NOT NULL,
	[IDCategory] [int] NOT NULL,
	[Price] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDFood] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FoodCategory]    Script Date: 12/5/2021 12:26:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FoodCategory](
	[IDCategory] [int] IDENTITY(1,1) NOT NULL,
	[NameCategory] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDCategory] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TableFood]    Script Date: 12/5/2021 12:26:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TableFood](
	[IDTable] [int] IDENTITY(1,1) NOT NULL,
	[TENBAN] [nvarchar](30) NOT NULL,
	[TinhTrang] [nvarchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDTable] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Account] ([UserName], [DisplayName], [MatKhau], [Loai]) VALUES (N'thanhloi', N'Thành Lợi', N'19410212215111233119891703916020115525510316', 1)
INSERT [dbo].[Account] ([UserName], [DisplayName], [MatKhau], [Loai]) VALUES (N'trungkien', N'Trung Kiên', N'123', 0)
SET IDENTITY_INSERT [dbo].[Bill] ON 

INSERT [dbo].[Bill] ([IDBill], [DateCheckIn], [DateCheckOut], [IDTable], [TinhTrang], [discount], [totalPrice]) VALUES (1, CAST(N'2021-12-05' AS Date), NULL, 1, 0, 0, NULL)
SET IDENTITY_INSERT [dbo].[Bill] OFF
SET IDENTITY_INSERT [dbo].[BillInfo] ON 

INSERT [dbo].[BillInfo] ([IDBillInfo], [IDBill], [IDFood], [CountFood]) VALUES (1, 1, 1, 1)
SET IDENTITY_INSERT [dbo].[BillInfo] OFF
SET IDENTITY_INSERT [dbo].[Food] ON 

INSERT [dbo].[Food] ([IDFood], [NameFood], [IDCategory], [Price]) VALUES (1, N'Tiramisu', 1, 29000)
INSERT [dbo].[Food] ([IDFood], [NameFood], [IDCategory], [Price]) VALUES (2, N'Bánh Mousse', 1, 32000)
INSERT [dbo].[Food] ([IDFood], [NameFood], [IDCategory], [Price]) VALUES (3, N'Bánh Cupcake', 1, 29000)
INSERT [dbo].[Food] ([IDFood], [NameFood], [IDCategory], [Price]) VALUES (4, N'Bánh Donut ', 1, 25000)
INSERT [dbo].[Food] ([IDFood], [NameFood], [IDCategory], [Price]) VALUES (5, N'Bánh Butter Chocolate', 1, 30000)
INSERT [dbo].[Food] ([IDFood], [NameFood], [IDCategory], [Price]) VALUES (6, N'Bánh Matcha Chocolate', 1, 29000)
INSERT [dbo].[Food] ([IDFood], [NameFood], [IDCategory], [Price]) VALUES (7, N'Bánh Cheese Caramel', 1, 25000)
INSERT [dbo].[Food] ([IDFood], [NameFood], [IDCategory], [Price]) VALUES (8, N'Bánh bông lan trứng muối', 1, 20000)
INSERT [dbo].[Food] ([IDFood], [NameFood], [IDCategory], [Price]) VALUES (9, N'Bánh Su kem', 1, 15000)
INSERT [dbo].[Food] ([IDFood], [NameFood], [IDCategory], [Price]) VALUES (10, N'Trà sữa trân châu đường đen ', 2, 40000)
INSERT [dbo].[Food] ([IDFood], [NameFood], [IDCategory], [Price]) VALUES (11, N'Sữa tươi trân châu đường đen', 2, 45000)
INSERT [dbo].[Food] ([IDFood], [NameFood], [IDCategory], [Price]) VALUES (12, N'Matcha Freeze', 2, 45000)
INSERT [dbo].[Food] ([IDFood], [NameFood], [IDCategory], [Price]) VALUES (13, N'Chocolate Freeze', 2, 50000)
INSERT [dbo].[Food] ([IDFood], [NameFood], [IDCategory], [Price]) VALUES (14, N'Oreo Freeze', 2, 50000)
INSERT [dbo].[Food] ([IDFood], [NameFood], [IDCategory], [Price]) VALUES (15, N'Cacao Freeze ', 2, 50000)
INSERT [dbo].[Food] ([IDFood], [NameFood], [IDCategory], [Price]) VALUES (16, N'Trà sữa Matcha ', 2, 40000)
INSERT [dbo].[Food] ([IDFood], [NameFood], [IDCategory], [Price]) VALUES (17, N'Trà Đào', 3, 30000)
INSERT [dbo].[Food] ([IDFood], [NameFood], [IDCategory], [Price]) VALUES (18, N'Trà Vải', 3, 29000)
INSERT [dbo].[Food] ([IDFood], [NameFood], [IDCategory], [Price]) VALUES (19, N'Trà Chanh', 3, 29000)
INSERT [dbo].[Food] ([IDFood], [NameFood], [IDCategory], [Price]) VALUES (20, N'Trà Tắc', 3, 30000)
INSERT [dbo].[Food] ([IDFood], [NameFood], [IDCategory], [Price]) VALUES (21, N'Trà Đào Dâu', 3, 40000)
INSERT [dbo].[Food] ([IDFood], [NameFood], [IDCategory], [Price]) VALUES (22, N'Trà Đào Sữa', 3, 40000)
INSERT [dbo].[Food] ([IDFood], [NameFood], [IDCategory], [Price]) VALUES (23, N'Trà Sen', 3, 45000)
INSERT [dbo].[Food] ([IDFood], [NameFood], [IDCategory], [Price]) VALUES (24, N'Cà phê đen', 4, 35000)
INSERT [dbo].[Food] ([IDFood], [NameFood], [IDCategory], [Price]) VALUES (25, N'Cà phê sữa đá', 4, 35000)
INSERT [dbo].[Food] ([IDFood], [NameFood], [IDCategory], [Price]) VALUES (26, N'Capuchino', 4, 40000)
INSERT [dbo].[Food] ([IDFood], [NameFood], [IDCategory], [Price]) VALUES (27, N'Latte', 4, 40000)
INSERT [dbo].[Food] ([IDFood], [NameFood], [IDCategory], [Price]) VALUES (28, N'Bạc xỉu', 4, 30000)
INSERT [dbo].[Food] ([IDFood], [NameFood], [IDCategory], [Price]) VALUES (29, N'Milo dầm', 5, 28000)
INSERT [dbo].[Food] ([IDFood], [NameFood], [IDCategory], [Price]) VALUES (30, N'Coca', 5, 20000)
INSERT [dbo].[Food] ([IDFood], [NameFood], [IDCategory], [Price]) VALUES (31, N'Đá bào nhiệt đới', 5, 25000)
INSERT [dbo].[Food] ([IDFood], [NameFood], [IDCategory], [Price]) VALUES (32, N'Yaourt đá', 5, 25000)
INSERT [dbo].[Food] ([IDFood], [NameFood], [IDCategory], [Price]) VALUES (33, N'7 up', 5, 20000)
INSERT [dbo].[Food] ([IDFood], [NameFood], [IDCategory], [Price]) VALUES (34, N'Sting', 5, 20000)
INSERT [dbo].[Food] ([IDFood], [NameFood], [IDCategory], [Price]) VALUES (35, N'Sinh tố bơ', 6, 40000)
INSERT [dbo].[Food] ([IDFood], [NameFood], [IDCategory], [Price]) VALUES (36, N'Sinh tố mít', 6, 30000)
INSERT [dbo].[Food] ([IDFood], [NameFood], [IDCategory], [Price]) VALUES (37, N'Sinh tố dưa gang', 6, 40000)
INSERT [dbo].[Food] ([IDFood], [NameFood], [IDCategory], [Price]) VALUES (38, N'Sinh tố dâu', 6, 45000)
INSERT [dbo].[Food] ([IDFood], [NameFood], [IDCategory], [Price]) VALUES (39, N'Combo sinh tố bơ + mít', 6, 45000)
INSERT [dbo].[Food] ([IDFood], [NameFood], [IDCategory], [Price]) VALUES (40, N'Combo sinh tố bơ + yaourt', 6, 50000)
SET IDENTITY_INSERT [dbo].[Food] OFF
SET IDENTITY_INSERT [dbo].[FoodCategory] ON 

INSERT [dbo].[FoodCategory] ([IDCategory], [NameCategory]) VALUES (1, N'Bánh')
INSERT [dbo].[FoodCategory] ([IDCategory], [NameCategory]) VALUES (2, N'Trà sữa')
INSERT [dbo].[FoodCategory] ([IDCategory], [NameCategory]) VALUES (3, N'Trà')
INSERT [dbo].[FoodCategory] ([IDCategory], [NameCategory]) VALUES (4, N'Cà phê')
INSERT [dbo].[FoodCategory] ([IDCategory], [NameCategory]) VALUES (5, N'Thức uống')
INSERT [dbo].[FoodCategory] ([IDCategory], [NameCategory]) VALUES (6, N'Sinh tố')
SET IDENTITY_INSERT [dbo].[FoodCategory] OFF
SET IDENTITY_INSERT [dbo].[TableFood] ON 

INSERT [dbo].[TableFood] ([IDTable], [TENBAN], [TinhTrang]) VALUES (1, N'Bàn 1', N'Có người')
INSERT [dbo].[TableFood] ([IDTable], [TENBAN], [TinhTrang]) VALUES (2, N'Bàn 2', N'Trống')
INSERT [dbo].[TableFood] ([IDTable], [TENBAN], [TinhTrang]) VALUES (3, N'Bàn 3', N'Trống')
INSERT [dbo].[TableFood] ([IDTable], [TENBAN], [TinhTrang]) VALUES (4, N'Bàn 4', N'Trống')
INSERT [dbo].[TableFood] ([IDTable], [TENBAN], [TinhTrang]) VALUES (5, N'Bàn 5', N'Trống')
INSERT [dbo].[TableFood] ([IDTable], [TENBAN], [TinhTrang]) VALUES (6, N'Bàn 6', N'Trống')
INSERT [dbo].[TableFood] ([IDTable], [TENBAN], [TinhTrang]) VALUES (7, N'Bàn 7', N'Trống')
INSERT [dbo].[TableFood] ([IDTable], [TENBAN], [TinhTrang]) VALUES (8, N'Bàn 8', N'Trống')
INSERT [dbo].[TableFood] ([IDTable], [TENBAN], [TinhTrang]) VALUES (9, N'Bàn 9', N'Trống')
INSERT [dbo].[TableFood] ([IDTable], [TENBAN], [TinhTrang]) VALUES (10, N'Bàn 10', N'Trống')
INSERT [dbo].[TableFood] ([IDTable], [TENBAN], [TinhTrang]) VALUES (11, N'Bàn 11', N'Trống')
INSERT [dbo].[TableFood] ([IDTable], [TENBAN], [TinhTrang]) VALUES (12, N'Bàn 12', N'Trống')
INSERT [dbo].[TableFood] ([IDTable], [TENBAN], [TinhTrang]) VALUES (13, N'Bàn 13', N'Trống')
INSERT [dbo].[TableFood] ([IDTable], [TENBAN], [TinhTrang]) VALUES (14, N'Bàn 14', N'Trống')
INSERT [dbo].[TableFood] ([IDTable], [TENBAN], [TinhTrang]) VALUES (15, N'Bàn 15', N'Trống')
INSERT [dbo].[TableFood] ([IDTable], [TENBAN], [TinhTrang]) VALUES (16, N'Bàn 16', N'Trống')
INSERT [dbo].[TableFood] ([IDTable], [TENBAN], [TinhTrang]) VALUES (17, N'Bàn 17', N'Trống')
INSERT [dbo].[TableFood] ([IDTable], [TENBAN], [TinhTrang]) VALUES (18, N'Bàn 18', N'Trống')
INSERT [dbo].[TableFood] ([IDTable], [TENBAN], [TinhTrang]) VALUES (19, N'Bàn 19', N'Trống')
INSERT [dbo].[TableFood] ([IDTable], [TENBAN], [TinhTrang]) VALUES (20, N'Bàn 20', N'Trống')
SET IDENTITY_INSERT [dbo].[TableFood] OFF
ALTER TABLE [dbo].[Account] ADD  DEFAULT ((0)) FOR [MatKhau]
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT ((0)) FOR [Loai]
GO
ALTER TABLE [dbo].[Bill] ADD  DEFAULT (getdate()) FOR [DateCheckIn]
GO
ALTER TABLE [dbo].[Bill] ADD  DEFAULT ((0)) FOR [TinhTrang]
GO
ALTER TABLE [dbo].[BillInfo] ADD  DEFAULT ((0)) FOR [CountFood]
GO
ALTER TABLE [dbo].[Food] ADD  DEFAULT (N'chưa đặt tên') FOR [NameFood]
GO
ALTER TABLE [dbo].[Food] ADD  DEFAULT ((0)) FOR [Price]
GO
ALTER TABLE [dbo].[FoodCategory] ADD  DEFAULT (N'Chưa đặt tên') FOR [NameCategory]
GO
ALTER TABLE [dbo].[TableFood] ADD  DEFAULT (N'Bàn này chưa có tên') FOR [TENBAN]
GO
ALTER TABLE [dbo].[TableFood] ADD  DEFAULT (N'Trống') FOR [TinhTrang]
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD FOREIGN KEY([IDTable])
REFERENCES [dbo].[TableFood] ([IDTable])
GO
ALTER TABLE [dbo].[BillInfo]  WITH CHECK ADD FOREIGN KEY([IDBill])
REFERENCES [dbo].[Bill] ([IDBill])
GO
ALTER TABLE [dbo].[BillInfo]  WITH CHECK ADD FOREIGN KEY([IDFood])
REFERENCES [dbo].[Food] ([IDFood])
GO
ALTER TABLE [dbo].[Food]  WITH CHECK ADD FOREIGN KEY([IDCategory])
REFERENCES [dbo].[FoodCategory] ([IDCategory])
GO
/****** Object:  StoredProcedure [dbo].[USP_GetListAccountByUserName]    Script Date: 12/5/2021 12:26:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_GetListAccountByUserName]
@userName nvarchar (50)
as
begin
	select *
	from Account
	where UserName = @userName
end
GO
/****** Object:  StoredProcedure [dbo].[USP_GetListBillByDate]    Script Date: 12/5/2021 12:26:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetListBillByDate]
@checkin date, @checkout date
AS
BEGIN
	SELECT TB.TENBAN AS[Tên bàn],B.totalPrice AS [Tổng tiền],B.DateCheckIn AS [Ngày vào],B.DateCheckOut AS [Ngày ra],B.discount  AS[Giảm giá]
	FROM Bill AS B , TableFood AS TB
	WHERE B.DateCheckIn >=@checkin AND B.DateCheckOut <=@checkout AND B.TinhTrang= 1 
	AND TB.IDTable = B.IDTable
END
GO
/****** Object:  StoredProcedure [dbo].[USP_GetListBillByDateAndPage]    Script Date: 12/5/2021 12:26:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROC [dbo].[USP_GetListBillByDateAndPage]
@checkin date, @checkout date, @page int
AS
BEGIN
	DECLARE @pageRows int = 10
	DECLARE @selectRows int = @pageRows
	DECLARE @exceptRows int = (@page -1) * @pageRows
	;WITH BillShow AS (SELECT B.IDBill,TB.TENBAN AS[Tên bàn],B.totalPrice AS [Tổng tiền],B.DateCheckIn AS [Ngày vào],B.DateCheckOut AS [Ngày ra],B.discount  AS[Giảm giá]
	FROM Bill AS B , TableFood AS TB
	WHERE B.DateCheckIn >=@checkin AND B.DateCheckOut <=@checkout AND B.TinhTrang= 1 
	AND TB.IDTable = B.IDTable)

	SELECT TOP (@selectRows) * FROM BillShow WHERE IDBill NOT IN (SELECT TOP (@exceptRows) IDBill FROM BillShow)
END
GO
/****** Object:  StoredProcedure [dbo].[USP_GetNumBillByDate]    Script Date: 12/5/2021 12:26:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROC [dbo].[USP_GetNumBillByDate]
@checkin date, @checkout date
AS
BEGIN
	SELECT COUNT(*)
	FROM Bill AS B , TableFood AS TB
	WHERE B.DateCheckIn >=@checkin AND B.DateCheckOut <=@checkout AND B.TinhTrang= 1 
	AND TB.IDTable = B.IDTable
END
GO
/****** Object:  StoredProcedure [dbo].[USP_GetTableList]    Script Date: 12/5/2021 12:26:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetTableList]
AS SELECT * FROM TableFood
GO
/****** Object:  StoredProcedure [dbo].[USP_InsertBill]    Script Date: 12/5/2021 12:26:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_InsertBill]
@IDTable INT
AS 
BEGIN
	INSERT Bill
	(
		DateCheckIn,
		DateCheckOut,
		IDTable,
		TinhTrang,
		discount
	)
	VALUES 
	(
		GETDATE() ,
		NULL,
		@idTable,
		0,
		0
	)
END
GO
/****** Object:  StoredProcedure [dbo].[USP_InsertBillInfor]    Script Date: 12/5/2021 12:26:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_InsertBillInfor] 
@IDBill INT, @idFood INT, @CountFood INT
AS
BEGIN
	DECLARE @isExitsBillInfor INT

	DECLARE @Count INT = 1

	SELECT @isExitsBillInfor = IDBill, @Count = CountFood from BillInfo where IDBill = @IDBill AND IDFood = @idFood

	IF(@isExitsBillInfor) >0 
	BEGIN
		DECLARE @newCount INT = @Count + @CountFood
		IF(@newCount >0)
			UPDATE BillInfo SET CountFood = @Count + @CountFood WHERE IDFood = @idFood AND IDBill = @IDBill
		ELSE
			DELETE BillInfo WHERE IDBill = @IDBill AND IDFood = @idFood
	END
	ELSE 
	BEGIN
		INSERT BillInfo
		VALUES 
		(
			@IDBill,
			@idFood,
			@CountFood
		)
		END
END
GO
/****** Object:  StoredProcedure [dbo].[USP_Login]    Script Date: 12/5/2021 12:26:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_Login]
@userName nvarchar(100), @password nvarchar(100)
as
begin
select* from dbo.Account where UserName = @userName and MatKhau = @password
end
GO
/****** Object:  StoredProcedure [dbo].[USP_SwapTable]    Script Date: 12/5/2021 12:26:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_SwapTable]
@idTable1 int ,@idTable2 int 
AS BEGIN

	DECLARE @idFirstBill int
	DECLARE @idSecondBill int
	DECLARE @IsFirstTableEmpty int = 1
	DECLARE @IsSecondTableEmpty int = 1
	SELECT @idFirstBill = IDBill FROM Bill WHERE IDTable = @idTable1 AND TinhTrang = 0
	SELECT @idSecondBill = IDBill FROM Bill WHERE IDTable = @idTable2 AND TinhTrang = 0

	IF(@idFirstBill IS NULL)
	BEGIN
		INSERT INTO Bill
					( DateCheckIn,
					  DateCheckOut,
					  IDTable,
					  TinhTrang
					 )
				VALUES( GETDATE(),
						NULL,
						@idTable1,
						0
					  )
		SELECT @idFirstBill = MAX(IDBill) FROM Bill WHERE IDTable = @idTable1 AND TinhTrang = 0
	END

	SELECT @IsFirstTableEmpty = COUNT(*) FROM BillInfo WHERE IDBill = @idFirstBill

		IF(@idSecondBill IS NULL)
	BEGIN
		INSERT INTO Bill
					( DateCheckIn,
					  DateCheckOut,
					  IDTable,
					  TinhTrang
					 )
               VALUES( GETDATE(),
					   NULL,
					   @idTable2,
					   0
					 )
		SELECT @idSecondBill = MAX(IDBill) FROM Bill WHERE IDTable = @idTable2 AND TinhTrang = 0
	END

	SELECT @IsSecondTableEmpty = COUNT(*) FROM BillInfo WHERE IDBill = @idSecondBill

	SELECT IDBillInfo INTO IDBillInfoTable FROM BillInfo WHERE idBill = @idSecondBill

	UPDATE BillInfo SET IDBill = @idSecondBill WHERE IDBill = @idFirstBill
	 
	UPDATE BillInfo SET IDBill = @idFirstBill WHERE IDBillInfo IN (SELECT * FROM IDBillInfoTable)

	DROP TABLE IDBillInfoTable

	IF(@IsFirstTableEmpty = 0)
		UPDATE TableFood SET TinhTrang = N'Trống' WHERE IDTable = @idTable2
	IF(@IsSecondTableEmpty = 0)
		UPDATE TableFood SET TinhTrang = N'Trống' WHERE IDTable = @idTable1
END
GO
/****** Object:  StoredProcedure [dbo].[USP_UpdateAccount]    Script Date: 12/5/2021 12:26:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_UpdateAccount]
@userName nvarchar(100), @displayName nvarchar(100), @matKhau nvarchar(100), @matKhauMoi nvarchar(100)
as
begin
	declare @dungMatKhau int = 0

	select @dungMatKhau = count(*) from dbo.Account where  UserName = @userName and MatKhau = @matKhau

	if (@dungMatKhau = 1)
	begin
		if (@matKhauMoi = NULL or @matKhauMoi='')
		begin
			update dbo.Account set DisplayName = @displayName where UserName = @userName
		end
		else
			update dbo.Account set DisplayName = @displayName, MatKhau = @matKhauMoi where UserName = @userName
	end
end
GO

-------------------------------------
CREATE TRIGGER UTG_UpdateBillInfor
ON BillInfo FOR INSERT, UPDATE 
AS
BEGIN
	DECLARE @IDBill INT

	SELECT @IDBill=IDBill FROM inserted

	DECLARE @IDTable INT

	SELECT @IDTable = IDTable FROM Bill WHERE IDBill = @IDBill AND TinhTrang = 0
	DECLARE @count int
	SELECT @count = count(*) FROM BillInfo WHERE IDBill = @IDBill
	IF(@count > 0)
	UPDATE TableFood SET TinhTrang = N'Có người' WHERE IDTable = @IDTable
	ELSE
	UPDATE TableFood SET TinhTrang = N'Trống' WHERE IDTable = @IDTable
END
GO
CREATE TRIGGER UTG_Checkout
ON Bill FOR UPDATE 
AS
BEGIN
	DECLARE @IDBill INT

	SELECT @IDBill = IDBill FROM Inserted

	DECLARE @IDTable INT

	SELECT @IDTable = IDTable FROM Bill WHERE IDBill = @IDBill

	DECLARE @Count INT = 0

	SELECT @Count = Count (*) FROM Bill WHERE IDTable = @IDTable AND TinhTrang = 0

	IF(@Count = 0) UPDATE TableFood SET TinhTrang = N'Trống' WHERE IDTable = @IDTable
END
GO
create trigger UTG_DeleteBillInfo
on BillInfo for delete
as
Begin 
	declare @IDBillInfo int
	declare @IDBill int
	select @IDBillInfo = IDBill,  @IDBill = Deleted.IDBill from Deleted

	declare @IDTable int
	select @IDTable = Bill.IDTable from Bill where IDBill = @IDBill

	declare @count int = 0

	select @count = count(*) from BillInfo as Bi,Bill as B
	where B.IDBill = Bi.IDBill and B.IDBill = @IDBill and B.TinhTrang = 0

	if(@count = 0)
		update TableFood set TinhTrang = N'Trống' where TableFood.IDTable = @IDTable
end 
go
---------------------------------------------------------------

USE [master]
GO
ALTER DATABASE [QuanLyQuanAnKLKK] SET  READ_WRITE 
GO

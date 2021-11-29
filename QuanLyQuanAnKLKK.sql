create database QuanLyQuanAnKLKK
go

use QuanLyQuanAnKLKK
go

--các table cần tạo
--Food
--TableFood
--FoodCategory
--Account
--Bill
--BillInfo


--TableFood
create table TableFood
(	
	IDTable INT IDENTITY Primary key,										--ID của bàn	
	TENBAN NVARCHAR(30) not null default N'Bàn này chưa có tên',			--Tên Bàn  
	TinhTrang NVARCHAR(10) not null	default N'Trống'						--Trống || Có người
)
go

--Account
create table Account
(
	UserName NVARCHAR(50) primary key,				--tên đăng nhập	
	DisplayName NVARCHAR(50) not null,				--Tên hiển thị
	MatKhau NVARCHAR(1000) not null default 0,		--mật khẩu	
	Loai int not null default 0 					--1: Admin || 0: Nhân viên
)
go

--FoodCategory
create table FoodCategory
(
	IDCategory int identity primary key,							--ID thể loại món ăn
	NameCategory nvarchar(100) not null default N'Chưa đặt tên',	--Tên thể loại món ăn
	
)
go

--Food
create table Food
(
	IDFood int identity primary key,								--ID món ăn
	NameFood nvarchar(100) not null default N'chưa đặt tên',		--Tên món ăn
	IDCategory int not null,										--ID thể loại món ăn
	Price float not null default 0 									--giá tiền món ăn

	foreign key (IDCategory) references FoodCategory(IDCategory)	--khoá ngoại IDCategory tới khoá chính IDCategory của bản FoodCategory
)
go

--Bill
create table Bill
(
	IDBill int identity primary key,					--ID thanh toán
	DateCheckIn date not null default getdate(),		--ngày vào
	DateCheckOut date,									--ngày ra
	IDTable int not null,								--ID của bàn
	TinhTrang int not null default 0 ,					--1: đã thanh toán || 0:chưa thanh toán

	foreign key (IDTable) references TableFood(IDTable)	--khoá ngoại IDTable tới khoá chính IDTable bảng TableFood 
)
go

--BillInfo
create table BillInfo
(
	IDBillInfo int identity primary key,		--ID 
	IDBill int not null,						--ID thanh toán
	IDFood int not null,						--ID món ăn
	CountFood int not null default 0			--số lượng món ăn

	foreign key (IDBill) references Bill(IDbill),	--khoá ngoại IDBill tới khoá chính IDBill bảng Bill
	foreign key (IDFood) references Food(IDFood)	--khoá ngoại IDFood tới khoá chính IDFood bảng Food 
)
go

--Tale List
SELECT * FROM TableFood
DELETE TableFood

--Tạo 9 bàn
DECLARE @i INT = 1

WHILE @i <=10
BEGIN 
	INSERT TableFood (TENBAN) VALUES (N'Bàn '+ CAST(@i AS nvarchar(100)))
	SET @i = @i+1
END
go

--Thêm Category
SELECT * FROM FoodCategory
INSERT FoodCategory(NameCategory)
VALUES (N'Hải sản')
go
INSERT FoodCategory(NameCategory)
VALUES (N'Gà')
go
INSERT FoodCategory(NameCategory)
VALUES (N'Bò')
go
INSERT FoodCategory(NameCategory)
VALUES (N'Mì')
go
INSERT FoodCategory(NameCategory)
VALUES (N'Nước giải khát')
go

--Thêm món ăn
SELECT * FROM Food
group by IDCategory
INSERT Food(NameFood,IDCategory,Price)
VALUES (N'Tôm hấp bia',1,120000)
go
INSERT Food(NameFood,IDCategory,Price)
VALUES (N'Mực nướng sa tế',1,180000)
go
INSERT Food(NameFood,IDCategory,Price)
VALUES (N'Cua biển rang muối',1,100000)
go
--
INSERT Food(NameFood,IDCategory,Price)
VALUES (N'Bò lúc lắc',2,80000)
go
INSERT Food(NameFood,IDCategory,Price)
VALUES (N'Bò né',2,80000)
go
--
INSERT Food(NameFood,IDCategory,Price)
VALUES (N'Gà chiên nước mắm',3,80000)
go
INSERT Food(NameFood,IDCategory,Price)
VALUES (N'Gà chiên giòn',3,70000)
go
--
INSERT Food(NameFood,IDCategory,Price)
VALUES (N'Mì xào giòn',4,80000)
go
INSERT Food(NameFood,IDCategory,Price)
VALUES (N'Mì xào hải sản',4,120000)
go

INSERT Food(NameFood,IDCategory,Price)
VALUES (N'Pepsi',5,12000)
go
INSERT Food(NameFood,IDCategory,Price)
VALUES (N'7 UP',5,12000)
go
INSERT Food(NameFood,IDCategory,Price)
VALUES (N'Bia',5,15000)
go

--Thêm bill
INSERT Bill(DateCheckIn,DateCheckOut,IDTable,TinhTrang)
VALUES 
(
	GETDATE() ,
	NULL,
	1,
	0
)
go
INSERT Bill(DateCheckIn,DateCheckOut,IDTable,TinhTrang)
VALUES 
(
	GETDATE() ,
	NULL,
	2,
	0
)
go
INSERT Bill(DateCheckIn,DateCheckOut,IDTable,TinhTrang)
VALUES 
(
	GETDATE() ,
	GETDATE(),
	2,
	1
)
go
INSERT Bill(DateCheckIn,DateCheckOut,IDTable,TinhTrang)
VALUES 
(
	GETDATE() ,
	NULL,
	3,
	0
)
go
SELECT * FROM Bill
SELECT MAX(IDBill) FROM Bill

--THÊM BillInfo
INSERT BillInfo(IDBill,IDFood,CountFood)
VALUES
(	1,
	1,
	2
)
go
INSERT BillInfo(IDBill,IDFood,CountFood)
VALUES
(	1,
	3,
	4
)
go
INSERT BillInfo(IDBill,IDFood,CountFood)
VALUES
(	1,
	5,
	2
)
go
INSERT BillInfo(IDBill,IDFood,CountFood)
VALUES
(	2,
	6,
	2
)
go
INSERT BillInfo(IDBill,IDFood,CountFood)
VALUES
(	3,
	5,
	2
)
go
SELECT * FROM BillInfo

--Tạo proc thêm bill
CREATE PROC USP_InsertBill
@IDTable INT
AS 
BEGIN
	INSERT Bill
	(
		DateCheckIn,
		DateCheckOut,
		IDTable,
		TinhTrang
	)
	VALUES 
	(
		GETDATE() ,
		NULL,
		@idTable,
		0
	)
END
GO

--Tạo proc danh sách bàn ăn
CREATE PROC USP_GetTableList
AS SELECT * FROM TableFood
GO
USP_GetTableList

--Tạo proc billinfo
DELETE Bill
go

CREATE PROC USP_InsertBillInfor 
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

--Trigger khi insert và update
DELETE BillInfo
go
CREATE TRIGGER UTG_UpdateBillInfor
ON BillInfo FOR INSERT, UPDATE 
AS
BEGIN
	DECLARE @IDBill INT

	SELECT @IDBill=IDBill FROM inserted

	DECLARE @IDTable INT

	SELECT @IDTable = IDTable FROM Bill WHERE IDBill = @IDBill AND TinhTrang = 0

	UPDATE TableFood SET TinhTrang = N'Có người' WHERE IDTable = @IDTable
END
GO

--Trigger tạo ra bill mới
DELETE Bill
go
CREATE TRIGGER UTG_Checkout
ON Bill FOR UPDATE 
AS
BEGIN
	DECLARE @IDBill INT

	SELECT @IDBill=IDBill FROM Inserted

	DECLARE @IDTable INT

	SELECT @IDTable = IDTable FROM Bill WHERE IDBill = @IDBill

	DECLARE @Count INT = 0

	SELECT @Count = Count (*) FROM Bill WHERE IDTable = @IDTable AND TinhTrang = 0

	IF(@Count = 0) UPDATE TableFood SET TinhTrang = N'Trống' WHERE IDTable = @IDTable
END
GO

--TEST DATAPROVIDER
insert into Account
	(
		UserName,
		DisplayName,
		MatKhau,
		Loai
	)
values 
	(
		N'thanhloi',
		N'Thành Lợi',
		N'12',
		1	
	)
go

insert into Account
(
	UserName,
	DisplayName,
	MatKhau,
	Loai
)
values(
	N'trungkien',
	N'Trung Kiên',
	N'123',
	0	
)
go

select*
from Account
go 

create proc USP_GetListAccountByUserName
@userName nvarchar (50)
as
begin
	select *
	from Account
	where UserName = @userName
end
go
exec USP_GetListAccountByUserName @userName = N'thanhloi'

select*
from dbo.Account
where  UserName = N'thanhloi' and MatKhau = N'12'
go

create proc USP_Login
@userName nvarchar(100), @password nvarchar(100)
as
begin
select* from dbo.Account where UserName = @userName and MatKhau = @password
end
go

-- thêm discount vào table Bill--
ALTER TABLE Bill
ADD discount INT
go
UPDATE Bill SET discount = 0
go
-- Update InsertBill thêm discount--
ALTER PROC USP_InsertBill
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

select * from Bill
go

--áaasd
--asdasd
--asdasdas
--ádasdasd

---B.Khanh đã thêm phần này
create proc USP_UpdateAccount
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
go
--end
select * from Bill
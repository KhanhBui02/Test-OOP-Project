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
	DateChekOut date,									--ngày ra
	IDTable int not null,								--ID của bàn
	TinhTrang int not null default 0 ,					--1: đã thanh toán || 0:chưa thanh toán

	foreign key (IDTable) references TableFood(IDTable)	--khoá ngoại IDTable tới khoá chính IDTable bảng TableFood 
)
go

create table BillInfo
(
	IDBillInfo int identity primary key,		--ID 
	IDBill int not null,						--ID thanh toán
	idFood int not null,						--ID món ăn
	CountFood int not null default 0			--số lượng món ăn

	foreign key (IDBill) references Bill(IDbill),	--khoá ngoại IDBill tới khoá chính IDBill bảng Bill
	foreign key (IDFood) references Food(IDFood)	--khoá ngoại IDFood tới khoá chính IDFood bảng Food 
)
go


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
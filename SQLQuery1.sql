use master
drop database WebsiteBanHang

create database WebsiteBanHang
use WebsiteBanHang

CREATE TABLE Brand
(
Id INT IDENTITY(1,1),
Name nVarchar(100),
Avatar Varchar(100),
Slug Varchar(100),
ShowOnHomePage bit,
DisplayOrder int,
CreatedOnUtc datetime,
UpdateddOnUtc DATETIME,
Deleted bit,
CONSTRAINT PK_Brand PRIMARY KEY(Id)
)

Insert into Brand values ('Apple', 'apple.jpg', 'apple', 1, 1, null, null, 0)
Insert into Brand values ('Samsung', 'samsung.jpg', 'samsung', 1, 2, null, null, 0)
Insert into Brand values ('Xiaomi', 'xiaomi.jpg', 'xiaomi', 1, 3, null, null, 0)


CREATE TABLE Category
(
Id INT IDENTITY(1,1),
Name nVarchar(100),
Avatar Varchar(100),
Slug Varchar(100),
ShowOnHomePage bit,
DisplayOrder int,
CreatedOnUtc datetime,
UpdateddOnUtc DATETIME,
Deleted bit,
CONSTRAINT PK_Category PRIMARY KEY(Id)
)

Insert into Category values ('Dien Thoai', 'dien_thoai.jpg', 'dien-thoai', 1, 1, null, null, 0)
Insert into Category values ('May Tinh', 'may_tinh.jpg', 'may-tinh', 1, 2, null, null, 0)
Insert into Category values ('Phu Kien', 'phu_kien.jpg', 'phu-kien', 1, 3, null, null, 0)
Insert into Category values ('Dong Ho', 'dong_ho.jpg', 'dong_ho', 1, 4, null, null, 0)

CREATE TABLE Orders
(
Id INT IDENTITY(1,1),
Name nVarchar(100),
ProductId int,
Price float,
Status int,
CreatedOnUtc datetime,
UpdateddOnUtc DATETIME,
CONSTRAINT PK_Orders PRIMARY KEY(Id),
CONSTRAINT FK_Orders_Category FOREIGN KEY (ProductId)
REFERENCES Category(Id),
)

CREATE TABLE Product
(
Id INT IDENTITY(1,1),
Name nVarchar(100),
Avatar Varchar(100),
CategoryId int,
ShortDes nVarchar(100),
FullDescription nVarchar(100),
Price float,
PriceDiscount float,
TypeId int,
Slug Varchar(100),
BrandId int,
Deleted bit,
ShowOnHomePage bit,
DisplayOrder int,
CreatedOnUtc datetime,
UpdateddOnUtc DATETIME,
CONSTRAINT PK_Product PRIMARY KEY(Id),
CONSTRAINT FK_Product_Category FOREIGN KEY (CategoryId)
REFERENCES Category(Id),
CONSTRAINT FK_Product_Brand FOREIGN KEY (BrandId)
REFERENCES Brand(Id),
)

Insert into Product values ('iphone 6', 'iphone.jpg', 1, 'Mo ta', 'Mo ta', 10000000, 9000000, 1, 'iphone 6', 1, 0, 1, 1,null,null)
Insert into Product values ('iphone 7', 'iphone.jpg', 1, 'Mo ta', 'Mo ta', 10000000, 9000000, 1, 'iphone 6', 1, 0, 1, 1,null,null)
Insert into Product values ('iphone 8', 'iphone.jpg', 1, 'Mo ta', 'Mo ta', 10000000, 9000000, 1, 'iphone 6', 1, 0, 1, 1,null,null)
Insert into Product values ('iphone 9', 'iphone.jpg', 1, 'Mo ta', 'Mo ta', 10000000, 9000000, 1, 'iphone 6', 1, 0, 1, 1,null,null)
Insert into Product values ('iphone 10', 'iphone.jpg', 1, 'Mo ta', 'Mo ta', 10000000, 9000000, 1, 'iphone 6', 1, 0, 1, 1,null,null)
CREATE TABLE Users
(
Id INT IDENTITY(1,1),
FistName nVarchar(100),
LastName nVarchar(100),
Email nVarchar(100),
Password nVarchar(100),
IsAdmin bit,
CONSTRAINT PK_Users PRIMARY KEY(Id),
)
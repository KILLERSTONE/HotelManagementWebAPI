

create table [dbo].[Hotel](
	[Hotel_Id][int] identity(1,1) not null primary key,
	[Hotel_Name][nvarchar](100)not null unique,
	[Hotel_Location][nvarchar](100)not null
)
ALTER TABLE [dbo].[Hotel]
ADD CONSTRAINT UC_Hotel_Name UNIQUE ([Hotel_Name]);


create table [dbo].[HotelEmployee](

	[Employee_Id][int] identity(1,1)not null primary key,
	[Employee_Name] [nvarchar](100) not null,
	[Employee_Password] [nvarchar](100) not null,
	[Employee_Designation] [nvarchar](100) not null,
	[Employee_Address] [nvarchar](100) not null,
	[Employee_Email] [nvarchar](100) not null,
	[Hotel_Id][int]not null,
	constraint FK_Employee_Hotel foreign key([Hotel_Id])references [dbo].[Hotel]([Hotel_Id])
)

create table [dbo].[Rooms](
	[Room_No][int] identity(1,1)not null primary key,
	[Room_Type][nvarchar](100) not null,
	[is_Available][bit] not null,
	[Room_Price][decimal](8,2) not null,
	[Room_Amenities][nvarchar](max)NULL,
	[Hotel_Id][int] not null,

	constraint FK_Rooms_Hotel foreign key([Hotel_Id]) references [dbo].[Hotel]([Hotel_Id])
)


create table [dbo].[Customer](
	[Customer_Id][int]identity(1,1) not null primary key,
	[Customer_Name][nvarchar](100) not null,
	[Customer_Phno][nvarchar](14)not null unique,
	[Customer_SSN][nvarchar](12)not null unique
)

create table [dbo].[Booking](
	[Booking_Date][DateTime] not null,
	[Booking_ID][int] identity(1,1) not null primary key,
	[Room_No][int] not null unique,
	[Customer_Id] [int] not null,
	[Price][decimal](8,2) not null,
	[DOJ][DateTime] not null,
	[DOL][DateTime]not null,
	constraint FK_Booking_Rooms foreign key([Room_No]) references [dbo].[Rooms]([Room_No]),
	constraint FK_Booking_Customer foreign key([Customer_Id]) references [dbo].[Customer]([Customer_Id]) 
)

create table [dbo].[CheckIn](
    [Employee_Id][int] not null,
    [Room_No][int] not null,
	[Booking_ID][int] not null,
    [checkIn_Status][bit] not null,
    [checkIn_Id][int]identity(1,1) not null primary key,
    constraint FK_CheckIn_Users foreign key([Employee_Id]) references [dbo].[HotelEmployee]([Employee_Id]),
    constraint FK_CheckIn_Rooms foreign key([Room_No]) references [dbo].[Rooms]([Room_No]),
    constraint FK_CheckIn_Booking foreign key([Booking_ID]) references [dbo].[Booking]([Booking_ID])
)

------------------------------------------Relationships-------------------------------



CREATE TABLE [dbo].[ClerkOrManager] (
    [Employee_Id][int] primary key,
    foreign key (Employee_Id) references HotelEmployee(Employee_Id)
);

CREATE TABLE [dbo].[Check_Rooms] (
    [Employee_Id][int],
    [Room_No][int],
    foreign key (Employee_Id) references HotelEmployee(Employee_Id),
    foreign key (Room_No) references Rooms(Room_No)
);

CREATE TABLE [dbo].[Wants] (
    [Customer_Id][int],
    [Room_No][int],
    foreign key (Customer_Id) references Customer(Customer_Id),
    foreign key (Room_No) references Rooms(Room_No)
);


select * from INFORMATION_SCHEMA.Tables;

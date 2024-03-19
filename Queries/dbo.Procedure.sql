CREATE PROCEDURE [dbo].[returnClerkOrManager]
AS
begin
	SELECT Employee_Id from HotelEmployee where Employee_Designation in('Clerk','Manager');
end
GO;



CREATE PROCEDURE [dbo].[bookTheRoom]
@Room_No int,
@Customer_Id int,
@DOJ DateTime,
@DOL DateTime
AS
Begin
	Set nocount on;

	Declare @Booking_Date datetime=getdate();
	declare @Price Decimal(8,2);

	if exists(select 1 from Booking b where b.Room_No=@Room_No and b.DOJ<@DOL and b.DOL>@DOJ)
	begin
		print'Room is not available for booking';
	end
	else
	begin

		select @Price=Room_Price from Rooms where Room_No=@Room_No;

		insert into Booking (Booking_Date,Room_No,Customer_Id,Price,DOJ,DOL)
		values (@Booking_Date,@Room_No,@Customer_Id,@Price,@DOJ,@DOL);


		print 'Room booked successfully';
	end
end;
go;


CREATE PROCEDURE [dbo].[checkInRoom]
@Employee_Id int,
@Room_No int,
@Customer_Id int,
@Booking_Id int

as
begin
	if exists(select 1 from HotelEmployee where Employee_Id=@Employee_Id)
	begin
		if exists(select 1 from Rooms R inner join Booking B on R.Room_No=B.Room_No where R.Room_No=@Room_No and R.is_Available=1 and B.Customer_Id=@Customer_Id and B.Booking_ID=@Booking_ID )
		begin
			insert into CheckIn(Employee_Id,Room_No,checkIn_Status,Booking_ID)
			values(@Employee_Id,@Room_No,1,@Booking_Id);

			print'Checked in';
		end
		else
		begin
			print'Invalid room details';
		end
	end
	else
	begin
		print'Unauthorized Employee Id';
	end
end


CREATE PROCEDURE 
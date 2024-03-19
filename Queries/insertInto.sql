
INSERT INTO [dbo].[Hotel] ([Hotel_Name], [Hotel_Location])
VALUES ('Hotel A', 'City A'),
       ('Hotel B', 'City B');


INSERT INTO [dbo].[HotelEmployee] ([Employee_Name], [Employee_Password], [Employee_Designation], [Employee_Address], [Employee_Email], [Hotel_Id])
VALUES ('Jeewan Ghimire', 'root', 'Manager', 'Address 123', 'jeewan@ilink-systems.com', 1);


INSERT INTO [dbo].[Rooms] ([Room_Type], [is_Available], [Room_Price], [Room_Amenities], [Hotel_Id])
VALUES ('Suite', 1, 100.00, 'WiFi, TV', 1);


INSERT INTO [dbo].[Customer] ([Customer_Name], [Customer_Phno], [Customer_SSN])
VALUES ('Customer 1', '1234567890', '111111111111');


INSERT INTO [dbo].[Booking] ([Booking_Date], [Room_No], [Customer_Id], [Price], [DOJ], [DOL])
VALUES ('2024-03-14 10:00:00', 1, 1, 100.00, '2024-03-14 12:00:00', '2024-03-15 12:00:00');


INSERT INTO [dbo].[CheckIn] ([Employee_Id], [Room_No], [Booking_ID], [checkIn_Status])
VALUES (1, 1, 1, 1);



INSERT INTO [dbo].[ClerkOrManager] ([Employee_Id])
VALUES (1);

INSERT INTO [dbo].[Check_Rooms] ([Employee_Id], [Room_No])
VALUES (1, 1);

INSERT INTO [dbo].[Wants] ([Customer_Id], [Room_No])
VALUES (1, 1);


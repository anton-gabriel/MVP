USE [Hotel.Services.HotelContext]
GO

INSERT INTO RoomImages(RoomId, Image, Deleted)
Values (1, (SELECT * FROM OPENROWSET(BULK N'D:\GitHub\MVP\Hotel\Hotel\Data\Images\1.jpg', SINGLE_BLOB) AS CategoryImage),0),
		(1, (SELECT * FROM OPENROWSET(BULK N'D:\GitHub\MVP\Hotel\Hotel\Data\Images\2.jpg', SINGLE_BLOB) AS CategoryImage),0),
		(1, (SELECT * FROM OPENROWSET(BULK N'D:\GitHub\MVP\Hotel\Hotel\Data\Images\3.jpg', SINGLE_BLOB) AS CategoryImage),0),
		(1, (SELECT * FROM OPENROWSET(BULK N'D:\GitHub\MVP\Hotel\Hotel\Data\Images\4.jpg', SINGLE_BLOB) AS CategoryImage),0),
		(1, (SELECT * FROM OPENROWSET(BULK N'D:\GitHub\MVP\Hotel\Hotel\Data\Images\5.jpg', SINGLE_BLOB) AS CategoryImage),0),
		(1, (SELECT * FROM OPENROWSET(BULK N'D:\GitHub\MVP\Hotel\Hotel\Data\Images\6.jpg', SINGLE_BLOB) AS CategoryImage),0)

GO
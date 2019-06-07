CREATE PROCEDURE [dbo].[AddRoomFeature]
	@roomId int = 0,
	@featureId int,
	@deleted bit
	
AS
BEGIN

	SET NOCOUNT ON;  	

	INSERT INTO RoomFeatures(RoomId, FeatureId,Deleted)
	VALUES (@roomId,@featureId, @deleted)
END
GO

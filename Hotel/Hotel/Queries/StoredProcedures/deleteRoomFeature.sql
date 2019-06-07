CREATE PROCEDURE [dbo].[UpdateRoomFeature]
	@roomFeatureId int,
	@roomId int,
	@featureId int,
	@deleted bit
	
AS
BEGIN

	UPDATE RoomFeatures SET RoomId = @roomId, FeatureId = @featureId, Deleted = @deleted
END
GO

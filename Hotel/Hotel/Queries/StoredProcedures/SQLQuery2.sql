CREATE PROCEDURE [dbo].[GetAllFeaturesForRoom]
	@roomId int
	
AS
BEGIN

	SELECT f.* FROM Features f INNER JOIN RoomFeatures on RoomFeatures.RoomId = f.Id
	WHERE RoomId = @roomId

END
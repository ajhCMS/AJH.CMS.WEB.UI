﻿CREATE PROCEDURE [SETUP].[PublishDelete]
	@P_PUBLISH_ID int
AS
BEGIN
	SET NOCOUNT ON;
	Delete from [SETUP].[PUBLISH]
		Where [PUBLISH_ID] = @P_PUBLISH_ID
END
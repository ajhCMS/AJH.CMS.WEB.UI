﻿CREATE PROCEDURE [SETUP].[PublishDeleteByObjID]
	@P_PUBLISH_OBJECT_ID int,
	@P_PUBLISH_MODULE_ID int
AS
BEGIN
	SET NOCOUNT ON;
	Delete from [SETUP].[PUBLISH]
		Where [PUBLISH_OBJECT_ID] = @P_PUBLISH_OBJECT_ID and
		  PUBLISH_MODULE_ID = @P_PUBLISH_MODULE_ID   
END

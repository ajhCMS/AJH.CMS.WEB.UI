﻿CREATE PROCEDURE [SETUP].[CMSControlDelete]
	@P_CMSCONTROL_ID int
AS
BEGIN
	SET NOCOUNT ON;
	Delete from [SETUP].[CMSCONTROL]
		Where [CMSCONTROL_ID] = @P_CMSCONTROL_ID
END

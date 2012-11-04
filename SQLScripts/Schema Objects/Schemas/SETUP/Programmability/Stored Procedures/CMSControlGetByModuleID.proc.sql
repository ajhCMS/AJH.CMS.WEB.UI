﻿CREATE PROCEDURE [SETUP].[CMSControlGetByModuleID]
	@P_CMSCONTROL_MODULE_ID int
AS
BEGIN
	SET NOCOUNT ON;
	Select 
	[CMSCONTROL_ID]
	,[CMSCONTROL_NAME]
	,[CMSCONTROL_DESCRIPTION]
	,[CMSCONTROL_USER_CONTROL_PATH]
	,[CMSCONTROL_MODULE_ID]
	,[CMSCONTROL_IS_DELETED]
	,[CMSCONTROL_CREATION_DAY]
	,[CMSCONTROL_CREATION_SEC]
	,[CMSCONTROL_CREATED_BY]
 from [SETUP].[CMSCONTROL]
	where 
	[CMSCONTROL_MODULE_ID] = @P_CMSCONTROL_MODULE_ID
	and
	[CMSCONTROL_IS_DELETED] = 0
END
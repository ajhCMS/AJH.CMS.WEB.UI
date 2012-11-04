﻿CREATE PROCEDURE [SETUP].[HtmlBlockGetByID]
	@P_HTMLBLOCK_ID int
AS
BEGIN
	SET NOCOUNT ON;
	Select 
	[HTMLBLOCK_ID]
	,[HTMLBLOCK_NAME]
	,[HTMLBLOCK_DETAILS]
	,[HTMLBLOCK_IS_DELETED]
	,[HTMLBLOCK_PORTAL_ID]
	,[HTMLBLOCK_LANGUAGE_ID]
	,[HTMLBLOCK_CREATION_DAY]
	,[HTMLBLOCK_CREATION_SEC]
	,[HTMLBLOCK_CREATED_BY]
 from [SETUP].[HTMLBLOCK]
		Where [HTMLBLOCK_ID] = @P_HTMLBLOCK_ID
		and
		[HTMLBLOCK_IS_DELETED] = 0
END
﻿CREATE PROCEDURE [SETUP].[HtmlBlockGetByPortalLanguage]
	@P_HTMLBLOCK_PORTAL_ID int,
	@P_HTMLBLOCK_LANGUAGE_ID int
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
	where 
	[HTMLBLOCK_PORTAL_ID] = @P_HTMLBLOCK_PORTAL_ID
	and
	[HTMLBLOCK_LANGUAGE_ID] = @P_HTMLBLOCK_LANGUAGE_ID
	and
	[HTMLBLOCK_IS_DELETED] = 0
END
﻿CREATE PROCEDURE [SETUP].[CategoryGetAll]
AS
BEGIN
	SET NOCOUNT ON;
	Select 
	[CATEGORY_ID]
	,[CATEGORY_NAME]
	,[CATEGORY_DESCRIPTION]
	,[CATEGORY_MODULE_ID]
	,[CATEGORY_IS_DELETED]
	,[CATEGORY_PORTAL_ID]
	,[CATEGORY_LANGUAGE_ID]
	,[CATEGORY_CREATION_DAY]
	,[CATEGORY_CREATION_SEC]
	,[CATEGORY_PARENT_ID]
	,[CATEGORY_ORDER]
	,[CATEGORY_CREATED_BY]
	,[CATEGORY_IMAGE]
 from [SETUP].[CATEGORY]
 where [CATEGORY_IS_DELETED] = 0
 order by [CATEGORY_ORDER]
END
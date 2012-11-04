﻿CREATE PROCEDURE [ARTICLE].[ArticleAdd]
	@P_ARTICLE_ID int output,
    @P_ARTICLE_NAME nvarchar(500),
    @P_ARTICLE_DESCRIPTION nvarchar(1000),
    @P_ARTICLE_SUMMARY nvarchar(1000),
	@P_ARTICLE_KEYWORDS nvarchar(1000),
	@P_ARTICLE_SEO_NAME nvarchar(1000),
	@P_ARTICLE_DETAILS ntext,
    @P_ARTICLE_URL nvarchar(1000),
	@P_ARTICLE_IMAGE nvarchar(500),	
	@P_ARTICLE_CATEGORY_ID int,
	@P_ARTICLE_CREATION_DAY int,
	@P_ARTICLE_CREATION_SEC int,
	@P_ARTICLE_IS_DELETED bit,
	@P_ARTICLE_PORTAL_ID int,
	@P_ARTICLE_LANGUAGE_ID int,
	@P_ARTICLE_TYPE int,
	@P_ARTICLE_ORDER int,
	@P_ARTICLE_CREATED_BY int,
	@P_ARTICLE_PARENT_OBJ_ID int,
	@P_ARTICLE_VIEW_COUNT int
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [ARTICLE].[ARTICLE]
		(
		[ARTICLE_NAME]
		,[ARTICLE_DESCRIPTION]
		,[ARTICLE_KEYWORDS]
		,[ARTICLE_SEO_NAME]
		,[ARTICLE_DETAILS]
		,[ARTICLE_URL]
		,[ARTICLE_IMAGE]
		,[ARTICLE_SUMMARY]
		,[ARTICLE_CATEGORY_ID]
		,[ARTICLE_CREATION_DAY]
		,[ARTICLE_CREATION_SEC]
		,[ARTICLE_IS_DELETED]
		,[ARTICLE_PORTAL_ID]
		,[ARTICLE_LANGUAGE_ID]
		,[ARTICLE_TYPE]
		,[ARTICLE_ORDER]
		,[ARTICLE_CREATED_BY]
		,[ARTICLE_PARENT_OBJ_ID] 
		,[ARTICLE_VIEW_COUNT]
		)
	VALUES
		(
		@P_ARTICLE_NAME,
		@P_ARTICLE_DESCRIPTION,
		@P_ARTICLE_KEYWORDS,
		@P_ARTICLE_SEO_NAME,
		@P_ARTICLE_DETAILS,
		@P_ARTICLE_URL,
		@P_ARTICLE_IMAGE,
		@P_ARTICLE_SUMMARY,
		@P_ARTICLE_CATEGORY_ID,
		@P_ARTICLE_CREATION_DAY,
		@P_ARTICLE_CREATION_SEC,
		@P_ARTICLE_IS_DELETED,
		@P_ARTICLE_PORTAL_ID,
		@P_ARTICLE_LANGUAGE_ID,
		@P_ARTICLE_TYPE,
		@P_ARTICLE_ORDER,
		@P_ARTICLE_CREATED_BY,
		@P_ARTICLE_PARENT_OBJ_ID ,
		@P_ARTICLE_VIEW_COUNT 
		)
		
		set @P_ARTICLE_ID=SCOPE_IDENTITY()
END
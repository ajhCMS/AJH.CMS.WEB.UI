﻿CREATE PROCEDURE [ARTICLE].[ArticleGetParentByCategory]
	@P_ARTICLE_CATEGORY_ID int,
	@P_PUBLISH_MODULE_ID int 
	
AS
BEGIN
	SET NOCOUNT ON;
	Select 
	A.[ARTICLE_ID],
	A.[ARTICLE_NAME],
	A.[ARTICLE_DESCRIPTION],
	A.[ARTICLE_KEYWORDS],
	A.[ARTICLE_SEO_NAME],
	A.[ARTICLE_DETAILS],
	A.[ARTICLE_URL],
	A.[ARTICLE_IMAGE],
	A.[ARTICLE_SUMMARY],
	A.[ARTICLE_CATEGORY_ID],
	A.[ARTICLE_CREATION_DAY],
	A.[ARTICLE_CREATION_SEC],
	A.[ARTICLE_IS_DELETED],
	A.[ARTICLE_PORTAL_ID],
	A.[ARTICLE_LANGUAGE_ID],
	A.[ARTICLE_TYPE],
	A.[ARTICLE_ORDER],
	A.[ARTICLE_CREATED_BY],
	A.[ARTICLE_PARENT_OBJ_ID] ,
	A.[ARTICLE_VIEW_COUNT],
	 P.[PUBLISH_TYPE_ID]
 from [ARTICLE].[ARTICLE] AS A
		LEFT OUTER JOIN
	  [SETUP].[PUBLISH] AS P
	    ON 
	  A.[ARTICLE_ID] = P.[PUBLISH_OBJECT_ID]
	    AND	
      A.[ARTICLE_PORTAL_ID] = P.[PUBLISH_PORTAL_ID]
        AND
	  A.[ARTICLE_LANGUAGE_ID] = P.[PUBLISH_LANGUAGE_ID]
	    AND
	  P.[PUBLISH_MODULE_ID] = @P_PUBLISH_MODULE_ID  
	where
	[ARTICLE_PARENT_OBJ_ID] = 0
	and
	[ARTICLE_CATEGORY_ID] = @P_ARTICLE_CATEGORY_ID
	and
		[ARTICLE_IS_DELETED] = 0
 order by [ARTICLE_ORDER],[ARTICLE_CREATION_DAY],[ARTICLE_CREATION_SEC]
END

﻿CREATE PROCEDURE [SETUP].[MenuGetByID]
	@P_MENU_ID int,
	@P_PUBLISH_MODULE_ID int
AS
BEGIN
	SET NOCOUNT ON;
	Select 
	M.[MENU_ID],
	M.[MENU_NAME],
	M.[MENU_DESCRIPTION],
	M.[MENU_KEYWORDS],
	M.[MENU_SEO_NAME],
	M.[MENU_DETAILS],
	M.[MENU_URL],
	M.[MENU_IMAGE],
	M.[MENU_PAGE_ID],
	M.[MENU_CATEGORY_ID],
	M.[MENU_PARENT_ID],
	M.[MENU_CREATION_DAY],
	M.[MENU_CREATION_SEC],
	M.[MENU_IS_DELETED],
	M.[MENU_PORTAL_ID],
	M.[MENU_LANGUAGE_ID],
	M.[MENU_TYPE],
	M.[MENU_ORDER],
	M.[MENU_CREATED_BY],
	M.[MENU_PARENT_OBJ_ID],
	P.[PUBLISH_TYPE_ID]
 from [SETUP].[MENU] AS M
  LEFT OUTER JOIN
      [SETUP].PUBLISH AS P
      ON 
      M.[MENU_ID]=P.[PUBLISH_OBJECT_ID] 
      AND
      M.[MENU_LANGUAGE_ID] = P.[PUBLISH_LANGUAGE_ID] 
      AND
      M.[MENU_PORTAL_ID] = P.[PUBLISH_PORTAL_ID]
      AND
      P.[PUBLISH_MODULE_ID] = @P_PUBLISH_MODULE_ID  
		Where [MENU_ID] = @P_MENU_ID
		and
		[MENU_IS_DELETED] = 0
		order by [MENU_ORDER]
END

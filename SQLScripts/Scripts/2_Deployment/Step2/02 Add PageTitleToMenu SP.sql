﻿GO
/****** Object:  StoredProcedure [SETUP].[MenuAdd]    Script Date: 01/26/2013 15:07:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SETUP].[MenuAdd]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SETUP].[MenuAdd]
GO
/****** Object:  StoredProcedure [SETUP].[MenuDelete]    Script Date: 01/26/2013 15:07:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SETUP].[MenuDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SETUP].[MenuDelete]
GO
/****** Object:  StoredProcedure [SETUP].[MenuDeleteLogical]    Script Date: 01/26/2013 15:07:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SETUP].[MenuDeleteLogical]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SETUP].[MenuDeleteLogical]
GO
/****** Object:  StoredProcedure [SETUP].[MenuGetAll]    Script Date: 01/26/2013 15:07:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SETUP].[MenuGetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SETUP].[MenuGetAll]
GO
/****** Object:  StoredProcedure [SETUP].[MenuGetByCategory]    Script Date: 01/26/2013 15:07:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SETUP].[MenuGetByCategory]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SETUP].[MenuGetByCategory]
GO
/****** Object:  StoredProcedure [SETUP].[MenuGetByID]    Script Date: 01/26/2013 15:07:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SETUP].[MenuGetByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SETUP].[MenuGetByID]
GO
/****** Object:  StoredProcedure [SETUP].[MenuGetByIDAndLang]    Script Date: 01/26/2013 15:07:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SETUP].[MenuGetByIDAndLang]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SETUP].[MenuGetByIDAndLang]
GO
/****** Object:  StoredProcedure [SETUP].[MenuGetByPage]    Script Date: 01/26/2013 15:07:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SETUP].[MenuGetByPage]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SETUP].[MenuGetByPage]
GO
/****** Object:  StoredProcedure [SETUP].[MenuGetByParent]    Script Date: 01/26/2013 15:07:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SETUP].[MenuGetByParent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SETUP].[MenuGetByParent]
GO
/****** Object:  StoredProcedure [SETUP].[MenuGetByParentObjID]    Script Date: 01/26/2013 15:07:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SETUP].[MenuGetByParentObjID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SETUP].[MenuGetByParentObjID]
GO
/****** Object:  StoredProcedure [SETUP].[MenuGetByPortalLanguage]    Script Date: 01/26/2013 15:07:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SETUP].[MenuGetByPortalLanguage]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SETUP].[MenuGetByPortalLanguage]
GO
/****** Object:  StoredProcedure [SETUP].[MenuGetParentObjByCategory]    Script Date: 01/26/2013 15:07:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SETUP].[MenuGetParentObjByCategory]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SETUP].[MenuGetParentObjByCategory]
GO
/****** Object:  StoredProcedure [SETUP].[MenuUpdate]    Script Date: 01/26/2013 15:07:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SETUP].[MenuUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SETUP].[MenuUpdate]
GO
/****** Object:  StoredProcedure [SETUP].[MenuUpdate]    Script Date: 01/26/2013 15:07:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SETUP].[MenuUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [SETUP].[MenuUpdate]
	@P_MENU_ID int,
    @P_MENU_NAME nvarchar(500),
    @P_MENU_DESCRIPTION nvarchar(1000),
	@P_MENU_KEYWORDS nvarchar(1000),
	@P_MENU_SEO_NAME nvarchar(1000),
	@P_MENU_DETAILS ntext,
    @P_MENU_URL nvarchar(1000),
	@P_MENU_IMAGE nvarchar(500),
	@P_MENU_PAGE_ID int,
	@P_MENU_CATEGORY_ID int,
	@P_MENU_PARENT_ID int,
	@P_MENU_CREATION_DAY int,
	@P_MENU_CREATION_SEC int,
	@P_MENU_IS_DELETED bit,
	@P_MENU_PORTAL_ID int,
	@P_MENU_LANGUAGE_ID int,
	@P_MENU_TYPE int,
	@P_MENU_ORDER int,
	@P_MENU_CREATED_BY int,
	@P_MENU_PARENT_OBJ_ID int,
	@P_MENU_GALLERY_CATEGORY_ID int,
	@P_MENU_PAGE_TITLE nvarchar(500) = null
AS
BEGIN
	SET NOCOUNT ON;
	Update [SETUP].[MENU] SET
		[MENU_NAME]=@P_MENU_NAME
		,[MENU_DESCRIPTION]=@P_MENU_DESCRIPTION
		,[MENU_KEYWORDS]=@P_MENU_KEYWORDS
		,[MENU_SEO_NAME]=@P_MENU_SEO_NAME
		,[MENU_DETAILS]=@P_MENU_DETAILS
		,[MENU_URL]=@P_MENU_URL
		,[MENU_IMAGE]=@P_MENU_IMAGE
		,[MENU_PAGE_ID]=@P_MENU_PAGE_ID
		,[MENU_CATEGORY_ID]=@P_MENU_CATEGORY_ID
		,[MENU_PARENT_ID]=@P_MENU_PARENT_ID
		,[MENU_CREATION_DAY]=@P_MENU_CREATION_DAY
		,[MENU_CREATION_SEC]=@P_MENU_CREATION_SEC
		,[MENU_IS_DELETED]=@P_MENU_IS_DELETED
		,[MENU_PORTAL_ID]=@P_MENU_PORTAL_ID
		,[MENU_LANGUAGE_ID]=@P_MENU_LANGUAGE_ID
		,[MENU_TYPE]=@P_MENU_TYPE
		,[MENU_ORDER]=@P_MENU_ORDER
		,[MENU_CREATED_BY] = @P_MENU_CREATED_BY
		,[MENU_PARENT_OBJ_ID] = @P_MENU_PARENT_OBJ_ID
		,[MENU_GALLERY_CATEGORY_ID] = @P_MENU_GALLERY_CATEGORY_ID
		,[MENU_PAGE_TITLE] = @P_MENU_PAGE_TITLE
		Where MENU_ID = @P_MENU_ID
END
' 
END
GO
/****** Object:  StoredProcedure [SETUP].[MenuGetParentObjByCategory]    Script Date: 01/26/2013 15:07:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SETUP].[MenuGetParentObjByCategory]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [SETUP].[MenuGetParentObjByCategory]
	@P_MENU_CATEGORY_ID int,
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
	M.[MENU_GALLERY_CATEGORY_ID],
	M.[MENU_PAGE_TITLE],
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
	where
	[MENU_PARENT_OBJ_ID] = 0
	and
	[MENU_CATEGORY_ID] = @P_MENU_CATEGORY_ID
	and
	[MENU_IS_DELETED] = 0
	order by [MENU_ORDER]
END
' 
END
GO
/****** Object:  StoredProcedure [SETUP].[MenuGetByPortalLanguage]    Script Date: 01/26/2013 15:07:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SETUP].[MenuGetByPortalLanguage]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [SETUP].[MenuGetByPortalLanguage]
	@P_MENU_PORTAL_ID int,
	@P_MENU_LANGUAGE_ID int,
	@P_PUBLISH_MODULE_ID int
AS
BEGIN
	SET NOCOUNT ON;
	Select 
	[MENU_ID],
	[MENU_NAME],
	[MENU_DESCRIPTION],
	[MENU_KEYWORDS],
	[MENU_SEO_NAME],
	[MENU_DETAILS],
	[MENU_URL],
	[MENU_IMAGE],
	[MENU_PAGE_ID],
	[MENU_CATEGORY_ID],
	[MENU_PARENT_ID],
	[MENU_CREATION_DAY],
	[MENU_CREATION_SEC],
	[MENU_IS_DELETED],
	[MENU_PORTAL_ID],
	[MENU_LANGUAGE_ID],
	[MENU_TYPE],
	[MENU_ORDER],
	[MENU_CREATED_BY],
	[MENU_PARENT_OBJ_ID],
	[MENU_GALLERY_CATEGORY_ID],
	[MENU_PAGE_TITLE],
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
	where 
	[MENU_PORTAL_ID] = @P_MENU_PORTAL_ID
	and
	[MENU_LANGUAGE_ID] = @P_MENU_LANGUAGE_ID
	and
	[MENU_IS_DELETED] = 0
	order by [MENU_ORDER]
END
' 
END
GO
/****** Object:  StoredProcedure [SETUP].[MenuGetByParentObjID]    Script Date: 01/26/2013 15:07:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SETUP].[MenuGetByParentObjID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [SETUP].[MenuGetByParentObjID]
	@P_MENU_PARENT_OBJ_ID int,
	@P_MENU_LANGUAGE_ID int,
	@P_PUBLISH_MODULE_ID int
AS
BEGIN
	SET NOCOUNT ON;
	Select 
	[MENU_ID],
	[MENU_NAME],
	[MENU_DESCRIPTION],
	[MENU_KEYWORDS],
	[MENU_SEO_NAME],
	[MENU_DETAILS],
	[MENU_URL],
	[MENU_IMAGE],
	[MENU_PAGE_ID],
	[MENU_CATEGORY_ID],
	[MENU_PARENT_ID],
	[MENU_CREATION_DAY],
	[MENU_CREATION_SEC],
	[MENU_IS_DELETED],
	[MENU_PORTAL_ID],
	[MENU_LANGUAGE_ID],
	[MENU_TYPE],
	[MENU_ORDER],
	[MENU_CREATED_BY],
	[MENU_PARENT_OBJ_ID],
	[MENU_GALLERY_CATEGORY_ID],
	[MENU_PAGE_TITLE]
 from [SETUP].[MENU] AS M
  
	where
	[MENU_PARENT_OBJ_ID] = @P_MENU_PARENT_OBJ_ID
	and
	[MENU_LANGUAGE_ID] = @P_MENU_LANGUAGE_ID
	
	and
	[MENU_IS_DELETED] = 0
	
END
' 
END
GO
/****** Object:  StoredProcedure [SETUP].[MenuGetByParent]    Script Date: 01/26/2013 15:07:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SETUP].[MenuGetByParent]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [SETUP].[MenuGetByParent]
	@P_MENU_PARENT_ID int,
	@P_MENU_PORTAL_ID int,
	@P_MENU_LANGUAGE_ID int,
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
	M.[MENU_GALLERY_CATEGORY_ID],
	M.[MENU_PAGE_TITLE],
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
	where
	[MENU_PARENT_ID] = @P_MENU_PARENT_ID
	and
	[MENU_PORTAL_ID] = @P_MENU_PORTAL_ID
	and
	[MENU_LANGUAGE_ID] = @P_MENU_LANGUAGE_ID
	and
	[MENU_IS_DELETED] = 0
	order by [MENU_ORDER]
END
' 
END
GO
/****** Object:  StoredProcedure [SETUP].[MenuGetByPage]    Script Date: 01/26/2013 15:07:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SETUP].[MenuGetByPage]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [SETUP].[MenuGetByPage]
	@P_MENU_PAGE_ID int,
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
	M.[MENU_GALLERY_CATEGORY_ID],
	M.[MENU_PAGE_TITLE],
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
	where [MENU_PAGE_ID] = @P_MENU_PAGE_ID
	and
		[MENU_IS_DELETED] = 0
	order by [MENU_ORDER]
END
' 
END
GO
/****** Object:  StoredProcedure [SETUP].[MenuGetByIDAndLang]    Script Date: 01/26/2013 15:07:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SETUP].[MenuGetByIDAndLang]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create PROCEDURE [SETUP].[MenuGetByIDAndLang]
	@P_MENU_ID int,
	@P_MENU_LANGUAGE_ID int,
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
	M.[MENU_GALLERY_CATEGORY_ID],
	M.[MENU_PAGE_TITLE],
	P.[PUBLISH_TYPE_ID]
 from [SETUP].[MENU] AS M
  LEFT OUTER JOIN
      [SETUP].PUBLISH AS P
      ON 
     P.[PUBLISH_OBJECT_ID]  = case when M.[MENU_PARENT_OBJ_ID] >0 then M.[MENU_PARENT_OBJ_ID] else  M.[MENU_ID] end
      AND
      M.[MENU_LANGUAGE_ID] = @P_MENU_LANGUAGE_ID 
      AND
      M.[MENU_PORTAL_ID] = P.[PUBLISH_PORTAL_ID]
      AND
      P.[PUBLISH_MODULE_ID] = @P_PUBLISH_MODULE_ID  
		Where [MENU_ID] = @P_MENU_ID
		and
		[MENU_IS_DELETED] = 0
		order by [MENU_ORDER]
END
' 
END
GO
/****** Object:  StoredProcedure [SETUP].[MenuGetByID]    Script Date: 01/26/2013 15:07:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SETUP].[MenuGetByID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [SETUP].[MenuGetByID]
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
	M.[MENU_GALLERY_CATEGORY_ID],
	M.[MENU_PAGE_TITLE],
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
' 
END
GO
/****** Object:  StoredProcedure [SETUP].[MenuGetByCategory]    Script Date: 01/26/2013 15:07:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SETUP].[MenuGetByCategory]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [SETUP].[MenuGetByCategory]
	@P_MENU_CATEGORY_ID int,
	@P_PUBLISH_MODULE_ID int,
	@P_MENU_LANGUAGE_ID int
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
	M.[MENU_GALLERY_CATEGORY_ID],
	M.[MENU_PAGE_TITLE],
	(select top 1 MENU_PARENT_ID from SETUP.MENU where M.[MENU_ID] = 
			case when M.[MENU_PARENT_OBJ_ID] > 0 then M.[MENU_PARENT_OBJ_ID] else M.[MENU_ID] end )
				 as MAIN_PARENT_ID, --parent id of parent Obj ID
				 
	P.[PUBLISH_TYPE_ID]
  from [SETUP].[MENU] AS M
 
	  LEFT OUTER JOIN
      [SETUP].PUBLISH AS P
      ON 
      P.[PUBLISH_OBJECT_ID] = case when M.[MENU_PARENT_OBJ_ID] > 0 then P.[PUBLISH_OBJECT_ID] else M.[MENU_ID] end
      AND
      M.[MENU_LANGUAGE_ID] = P.[PUBLISH_LANGUAGE_ID] 
      AND
      M.[MENU_PORTAL_ID] = P.[PUBLISH_PORTAL_ID]
      AND
      P.[PUBLISH_MODULE_ID] = @P_PUBLISH_MODULE_ID
      
	where [MENU_CATEGORY_ID] = @P_MENU_CATEGORY_ID
	and
		[MENU_IS_DELETED] = 0 and [MENU_LANGUAGE_ID] =@P_MENU_LANGUAGE_ID
	order by [MENU_ORDER]
END
' 
END
GO
/****** Object:  StoredProcedure [SETUP].[MenuGetAll]    Script Date: 01/26/2013 15:07:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SETUP].[MenuGetAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [SETUP].[MenuGetAll]
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
	M.[MENU_GALLERY_CATEGORY_ID],
	M.[MENU_PAGE_TITLE],
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
    
 where [MENU_IS_DELETED] = 0
 order by [MENU_ORDER]
END
' 
END
GO
/****** Object:  StoredProcedure [SETUP].[MenuDeleteLogical]    Script Date: 01/26/2013 15:07:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SETUP].[MenuDeleteLogical]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [SETUP].[MenuDeleteLogical]
	@P_MENU_ID int
AS
BEGIN
	SET NOCOUNT ON;
	Update [SETUP].[MENU] set
	[MENU_IS_DELETED]=1
	Where
	MENU_ID = @P_MENU_ID
	or
	MENU_PARENT_OBJ_ID = @P_MENU_ID 
END
' 
END
GO
/****** Object:  StoredProcedure [SETUP].[MenuDelete]    Script Date: 01/26/2013 15:07:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SETUP].[MenuDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [SETUP].[MenuDelete]
	@P_MENU_ID int
AS
BEGIN
	SET NOCOUNT ON;
	Delete from [SETUP].[MENU] 
		Where
		MENU_ID = @P_MENU_ID
		or
		MENU_PARENT_OBJ_ID = @P_MENU_ID
END
' 
END
GO
/****** Object:  StoredProcedure [SETUP].[MenuAdd]    Script Date: 01/26/2013 15:07:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SETUP].[MenuAdd]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [SETUP].[MenuAdd]
	@P_MENU_ID int output,
    @P_MENU_NAME nvarchar(500),
    @P_MENU_DESCRIPTION nvarchar(1000),
	@P_MENU_KEYWORDS nvarchar(1000),
	@P_MENU_SEO_NAME nvarchar(1000),
	@P_MENU_DETAILS ntext,
    @P_MENU_URL nvarchar(1000),
	@P_MENU_IMAGE nvarchar(500),
	@P_MENU_PAGE_ID int,
	@P_MENU_CATEGORY_ID int,
	@P_MENU_PARENT_ID int,
	@P_MENU_CREATION_DAY int,
	@P_MENU_CREATION_SEC int,
	@P_MENU_IS_DELETED bit,
	@P_MENU_PORTAL_ID int,
	@P_MENU_LANGUAGE_ID int,
	@P_MENU_TYPE int,
	@P_MENU_ORDER int,
	@P_MENU_CREATED_BY int,
	@P_MENU_PARENT_OBJ_ID int,
	@P_MENU_GALLERY_CATEGORY_ID int,
	@P_MENU_PAGE_TITLE nvarchar(500) = null
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [SETUP].[MENU]
		(
		[MENU_NAME]
		,[MENU_DESCRIPTION]
		,[MENU_KEYWORDS]
		,[MENU_SEO_NAME]
		,[MENU_DETAILS]
		,[MENU_URL]
		,[MENU_IMAGE]
		,[MENU_PAGE_ID]
		,[MENU_CATEGORY_ID]
		,[MENU_PARENT_ID]
		,[MENU_CREATION_DAY]
		,[MENU_CREATION_SEC]
		,[MENU_IS_DELETED]
		,[MENU_PORTAL_ID]
		,[MENU_LANGUAGE_ID]
		,[MENU_TYPE]
		,[MENU_ORDER]
		,[MENU_CREATED_BY]
		,[MENU_PARENT_OBJ_ID]
		,[MENU_GALLERY_CATEGORY_ID]
		,[MENU_PAGE_TITLE]
		)
	VALUES
		(
		@P_MENU_NAME,
		@P_MENU_DESCRIPTION,
		@P_MENU_KEYWORDS,
		@P_MENU_SEO_NAME,
		@P_MENU_DETAILS,
		@P_MENU_URL,
		@P_MENU_IMAGE,
		@P_MENU_PAGE_ID,
		@P_MENU_CATEGORY_ID,
		@P_MENU_PARENT_ID,
		@P_MENU_CREATION_DAY,
		@P_MENU_CREATION_SEC,
		@P_MENU_IS_DELETED,
		@P_MENU_PORTAL_ID,
		@P_MENU_LANGUAGE_ID,
		@P_MENU_TYPE,
		@P_MENU_ORDER,
		@P_MENU_CREATED_BY,
		@P_MENU_PARENT_OBJ_ID,
		@P_MENU_GALLERY_CATEGORY_ID,
		@P_MENU_PAGE_TITLE
		)
		
		set @P_MENU_ID=SCOPE_IDENTITY()
END
' 
END
GO
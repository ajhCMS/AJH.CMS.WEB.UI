﻿CREATE PROCEDURE [SETUP].[XSLTemplateUpdate]
	@P_XSLTEMPLATE_ID int,
	@P_XSLTEMPLATE_NAME nvarchar(500),
	@P_XSLTEMPLATE_DESCRIPTION nvarchar(1000),
	@P_XSLTEMPLATE_DETAILS ntext,
	@P_XSLTEMPLATE_MODULE_ID int,
	@P_XSLTEMPLATE_IS_DELETED bit,
	@P_XSLTEMPLATE_PORTAL_ID int,
	@P_XSLTEMPLATE_LANGUAGE_ID int,
	@P_XSLTEMPLATE_CREATION_DAY int,
	@P_XSLTEMPLATE_CREATION_SEC int,
	@P_XSLTEMPLATE_CREATED_BY int
AS
BEGIN
	SET NOCOUNT ON;
	Update [SETUP].[XSLTEMPLATE] SET
		[XSLTEMPLATE_NAME] = @P_XSLTEMPLATE_NAME
		,[XSLTEMPLATE_DESCRIPTION] = @P_XSLTEMPLATE_DESCRIPTION
		,[XSLTEMPLATE_DETAILS] = @P_XSLTEMPLATE_DETAILS
		,[XSLTEMPLATE_MODULE_ID] = @P_XSLTEMPLATE_MODULE_ID
		,[XSLTEMPLATE_IS_DELETED] = @P_XSLTEMPLATE_IS_DELETED
		,[XSLTEMPLATE_PORTAL_ID] = @P_XSLTEMPLATE_PORTAL_ID
		,[XSLTEMPLATE_LANGUAGE_ID] = @P_XSLTEMPLATE_LANGUAGE_ID
		,[XSLTEMPLATE_CREATION_DAY] = @P_XSLTEMPLATE_CREATION_DAY
		,[XSLTEMPLATE_CREATION_SEC] = @P_XSLTEMPLATE_CREATION_SEC
		,[XSLTEMPLATE_CREATED_BY] = @P_XSLTEMPLATE_CREATED_BY
		Where [XSLTEMPLATE_ID] = @P_XSLTEMPLATE_ID
END

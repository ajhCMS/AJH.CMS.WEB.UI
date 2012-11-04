﻿CREATE PROCEDURE [SETUP].[TemplateDelete]
	@P_TEMPLATE_ID int
AS
BEGIN
	SET NOCOUNT ON;
	Delete from [SETUP].[TEMPLATE]
		Where [TEMPLATE_ID] = @P_TEMPLATE_ID
END
﻿CREATE PROCEDURE [SECURITY].[FormRoleGetByFormRole]
	@P_FORM_ROLE_FORM_ID int,
	@P_FORM_ROLE_ROLE_ID int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT
		fr.[FORM_ROLE_ID]
		,fr.[FORM_ROLE_FORM_ID]
		,fr.[FORM_ROLE_ROLE_ID]
		,fr.[FORM_ROLE_ACCESS_TYPE]
		,f.[FORM_CODE]
		,r.[ROLE_NAME]
	FROM
	[SECURITY].[FORM_ROLE] fr
	INNER JOIN
	[SECURITY].[FORM] f
	on
	fr.FORM_ROLE_FORM_ID = f.[FORM_ID]
	INNER JOIN
	[SECURITY].[ROLE] r
	on
	fr.FORM_ROLE_ROLE_ID = r.[ROLE_ID]
	where
	(@P_FORM_ROLE_FORM_ID = -1 or fr.[FORM_ROLE_FORM_ID] = @P_FORM_ROLE_FORM_ID)
	and
	(@P_FORM_ROLE_ROLE_ID = -1 or fr.[FORM_ROLE_ROLE_ID] = @P_FORM_ROLE_ROLE_ID)
	and
	f.[FORM_IS_DELETED] = 0
	and
	r.[ROLE_IS_DELETED] = 0
END
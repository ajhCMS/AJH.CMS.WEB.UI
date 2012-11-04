﻿CREATE PROCEDURE [SECURITY].[RoleGetNotInForm]
	@P_FORM_ID int
AS
BEGIN
	SET NOCOUNT ON;
	Select 
	r.[ROLE_ID]
	,r.[ROLE_NAME]
	,r.[ROLE_DESCRIPTION]
	,r.[ROLE_IS_DELETED]
 from
 [SECURITY].[ROLE] r
Where
	not EXISTS(
		select [FORM_ROLE_ID]
		from
		[SECURITY].[FORM_ROLE]
		where [FORM_ROLE_ROLE_ID] = r.[ROLE_ID] and [FORM_ROLE_FORM_ID] = @P_FORM_ID)	
	and
	r.[ROLE_IS_DELETED] = 0
END
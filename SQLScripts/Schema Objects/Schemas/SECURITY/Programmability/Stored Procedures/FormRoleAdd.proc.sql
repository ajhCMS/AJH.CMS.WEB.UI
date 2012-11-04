﻿CREATE PROCEDURE [SECURITY].[FormRoleAdd]
	@P_FORM_ROLE_ID int output,
	@P_FORM_ROLE_FORM_ID int,
	@P_FORM_ROLE_ROLE_ID int,
	@P_FORM_ROLE_ACCESS_TYPE int
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [SECURITY].[FORM_ROLE]
		(
		[FORM_ROLE_FORM_ID]
		,[FORM_ROLE_ROLE_ID]
		,[FORM_ROLE_ACCESS_TYPE]
		)
	VALUES
		(
		@P_FORM_ROLE_FORM_ID
		,@P_FORM_ROLE_ROLE_ID
		,@P_FORM_ROLE_ACCESS_TYPE
		)
		
		set @P_FORM_ROLE_ID=SCOPE_IDENTITY()
END

﻿CREATE PROCEDURE [SECURITY].[FormUserDeleteByFormUser]
	@P_FORM_USER_FORM_ID int,
	@P_FORM_USER_USER_ID int
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM [SECURITY].[FORM_USER]
	where
		(@P_FORM_USER_FORM_ID = -1 or [FORM_USER_FORM_ID] = @P_FORM_USER_FORM_ID)
		and
		(@P_FORM_USER_USER_ID = -1 or [FORM_USER_USER_ID] = @P_FORM_USER_USER_ID)
END

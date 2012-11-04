﻿CREATE PROCEDURE [SECURITY].[RoleUserAdd]
	@P_ROLE_ID int,
	@P_USER_ID int
AS
BEGIN
	SET NOCOUNT ON;
	Insert Into [SECURITY].[ROLE_USER]
	(
		[ROLE_USER_ROLE_ID]
		,[ROLE_USER_USER_ID]		
	)
	values
	(
		@P_ROLE_ID,
		@P_USER_ID
	)
END

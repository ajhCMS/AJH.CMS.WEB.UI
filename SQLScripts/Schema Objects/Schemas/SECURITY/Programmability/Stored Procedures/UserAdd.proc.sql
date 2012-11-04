﻿CREATE PROCEDURE [SECURITY].[UserAdd]
	@P_USER_ID int output,
	@P_USER_NAME nvarchar(1000),
	@P_USER_EMAIL nvarchar(1000),
	@P_USER_PASSWORD nvarchar(max),
	@P_USER_IS_ACTIVE bit,
	@P_USER_CREATION_DAY int,
	@P_USER_CREATION_SEC int,
	@P_USER_IS_DELETED bit
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [SECURITY].[USER]
		(
		[USER_NAME]
		,[USER_EMAIL]
		,[USER_PASSWORD]
		,[USER_IS_ACTIVE]
		,[USER_CREATION_DAY]
		,[USER_CREATION_SEC]
		,[USER_IS_DELETED]
		)
	VALUES
		(
		@P_USER_NAME
		,@P_USER_EMAIL
		,@P_USER_PASSWORD
		,@P_USER_IS_ACTIVE
		,@P_USER_CREATION_DAY
		,@P_USER_CREATION_SEC
		,@P_USER_IS_DELETED
		)
		
		set @P_USER_ID=SCOPE_IDENTITY()
END

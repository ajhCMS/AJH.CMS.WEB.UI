﻿CREATE PROCEDURE [SETUP].[LanguageDelete]

@P_LANGUAGE_ID int

AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM [SETUP].[LANGUAGE] 
		WHERE 		
		    LANGUAGE_ID = @P_LANGUAGE_ID 
END

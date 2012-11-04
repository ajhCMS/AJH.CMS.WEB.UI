﻿CREATE PROCEDURE [SETUP].[LanguageGetByID]

@P_LANGUAGE_ID int

AS
BEGIN
	SET NOCOUNT ON;
	SELECT
		LANGUAGE_ID,
		LANGUAGE_NAME,
		LANGUAGE_CULTURE,
		LANGUAGE_IMAGE
	FROM			
		[SETUP].[LANGUAGE] 
	WHERE 
	    LANGUAGE_ID = @P_LANGUAGE_ID
		
		
		
END

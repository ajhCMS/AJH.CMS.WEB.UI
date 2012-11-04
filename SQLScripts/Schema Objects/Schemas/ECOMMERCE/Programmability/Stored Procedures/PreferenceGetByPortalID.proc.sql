﻿CREATE PROCEDURE [ECOMMERCE].[PreferenceGetByPortalID]
	@P_PREFERENCE_PORTAL_ID INT
    
AS
BEGIN
	SET NOCOUNT ON;

		select
			 PREFERENCE_ID,
			 PREFERENCE_NAME,
			 PREFERENCE_PORTAL_ID,
			 PREFERENCE_IS_ENABLED
	
		from [ECOMMERCE].[PREFERENCE]
		
			where 
			 PREFERENCE_PORTAL_ID = @P_PREFERENCE_PORTAL_ID
			
END

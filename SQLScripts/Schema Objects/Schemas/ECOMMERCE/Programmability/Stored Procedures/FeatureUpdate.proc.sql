﻿CREATE PROCEDURE [ECOMMERCE].[FeatureUpdate]
	@P_FEATURE_ID INT OUTPUT,
	@P_FEATURE_PORTAL_ID INT,
	
	@P_FEATURE_NAME NVARCHAR(500),
	@P_MODULE_ID INT,
	@P_ECO_LAN_LAN_ID INT
    
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @Transaction VARCHAR(100);
	SELECT @Transaction = 'Transaction';

	BEGIN TRANSACTION @Transaction;
	
	UPDATE [ECOMMERCE].[FEATURE] SET [FEATURE_PORTAL_ID] =@P_FEATURE_PORTAL_ID
	
		update [ECOMMERCE].[ECOMMERCE_LANGUAGE]
			set 
				[ECO_LAN_NAME] = @P_FEATURE_NAME
			where
				[ECO_LAN_OBJ_ID] = @P_FEATURE_ID
				and
				[ECO_LAN_MODULE_ID] = @P_MODULE_ID
				and
				[ECO_LAN_LAN_ID] = @P_ECO_LAN_LAN_ID
		
		IF @@ERROR != 0
            BEGIN 
                  ROLLBACK TRANSACTION
                  RETURN
            END

			COMMIT TRANSACTION @Transaction	
END

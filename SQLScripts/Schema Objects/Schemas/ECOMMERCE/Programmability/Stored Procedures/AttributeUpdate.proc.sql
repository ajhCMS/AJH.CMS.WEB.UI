﻿CREATE PROCEDURE [ECOMMERCE].[AttributeUpdate]
	@P_ATTRIBUTE_ID int,
	@P_ATTRIBUTE_GROUP_ID int,
	@P_ATTRIBUTE_PORTAL_ID int,
	@P_ATTRIBUTE_NAME NVARCHAR(500),
	@P_MODULE_ID INT,
	@P_ECO_LAN_LAN_ID INT
    
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @Transaction VARCHAR(100);
	SELECT @Transaction = 'Transaction';

	BEGIN TRANSACTION @Transaction;
	
	update  [ECOMMERCE].[ATTRIBUTE] set
	
		[ATTRIBUTE_GROUP_ID] = @P_ATTRIBUTE_GROUP_ID,
		[ATTRIBUTE_PORTAL_ID] = @P_ATTRIBUTE_PORTAL_ID
		where
		ATTRIBUTE_ID = @P_ATTRIBUTE_ID
		
		UPDATE [ECOMMERCE].[ECOMMERCE_LANGUAGE]
			SET 
			    [ECO_LAN_NAME] = @P_ATTRIBUTE_NAME
					WHERE 
				[ECO_LAN_OBJ_ID] = @P_ATTRIBUTE_ID
			AND
				[ECO_LAN_MODULE_ID] = @P_MODULE_ID
			AND
				[ECO_LAN_LAN_ID] = @P_ECO_LAN_LAN_ID
		
		IF @@ERROR != 0
            BEGIN 
                  ROLLBACK TRANSACTION
                  RETURN
            END

			COMMIT TRANSACTION @Transaction
		END
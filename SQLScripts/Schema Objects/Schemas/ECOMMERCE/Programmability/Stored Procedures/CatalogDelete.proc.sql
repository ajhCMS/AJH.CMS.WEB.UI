﻿CREATE PROCEDURE [ECOMMERCE].[CatalogDelete]
	@P_CATALOG_ID int,
	@P_MODULE_ID INT,
	@P_ECO_LAN_LAN_ID INT 	
    
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @Transaction VARCHAR(100);
	SELECT @Transaction = 'Transaction';

	BEGIN TRANSACTION @Transaction;
	
		delete from [ECOMMERCE].[ECOMMERCE_LANGUAGE]
			where
					[ECO_LAN_OBJ_ID] = @P_CATALOG_ID
					and
					[ECO_LAN_MODULE_ID] = @P_MODULE_ID
					and
					[ECO_LAN_LAN_ID] = @P_ECO_LAN_LAN_ID
					
					
	delete from [ECOMMERCE].[CATALOG]
	where 
		CATALOG_ID = @P_CATALOG_ID
		
		IF @@ERROR != 0
            BEGIN 
                  ROLLBACK TRANSACTION
                  RETURN
            END

			COMMIT TRANSACTION @Transaction
END
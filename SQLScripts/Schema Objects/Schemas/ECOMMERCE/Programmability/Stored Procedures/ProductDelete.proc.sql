CREATE PROCEDURE [ECOMMERCE].[ProductDelete]
	@P_PRODUCT_ID INT,
	
	@P_MODULE_ID INT,
	@P_ECO_LAN_LAN_ID INT
    
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @Transaction VARCHAR(100);
	SELECT @Transaction = 'Transaction';

	BEGIN TRANSACTION @Transaction;
		
	delete from  [ECOMMERCE].[ECOMMERCE_LANGUAGE]
		WHERE 
				[ECO_LAN_OBJ_ID] = @P_PRODUCT_ID
			AND
				[ECO_LAN_MODULE_ID] = @P_MODULE_ID
			AND
				[ECO_LAN_LAN_ID] = @P_ECO_LAN_LAN_ID
				
		delete from  [ECOMMERCE].[PRODUCT]
	where
		[PRODUCT_ID] = @P_PRODUCT_ID			
	
	IF @@ERROR != 0
            BEGIN 
                  ROLLBACK TRANSACTION
                  RETURN
            END

			COMMIT TRANSACTION @Transaction		
END

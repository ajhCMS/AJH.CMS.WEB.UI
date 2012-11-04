CREATE PROCEDURE [ECOMMERCE].[AttributeDelete]
	@P_ATTRIBUTE_ID int,
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
					[ECO_LAN_OBJ_ID] = @P_ATTRIBUTE_ID
					and
					[ECO_LAN_MODULE_ID] = @P_MODULE_ID
					and
					[ECO_LAN_LAN_ID] = @P_ECO_LAN_LAN_ID
					
		delete from  [ECOMMERCE].[ATTRIBUTE] 
		where
		ATTRIBUTE_ID = @P_ATTRIBUTE_ID
		
		IF @@ERROR != 0
            BEGIN 
                  ROLLBACK TRANSACTION
                  RETURN
            END

			COMMIT TRANSACTION @Transaction
			
		END

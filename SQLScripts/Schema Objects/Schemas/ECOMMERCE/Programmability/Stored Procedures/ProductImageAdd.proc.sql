﻿CREATE PROCEDURE [ECOMMERCE].[ProductImageAdd]

	@P_PROD_IMAGE_ID int output,
	@P_PROD_PRODUCT_ID	int,
	@P_PROD_IMAGE_NAME	nvarchar(500),
	@P_PROD_IMAGE_IS_COVER_IMAGE bit,
	
	@P_PROD_IMAGE_CAPTION	nvarchar(500),
	@P_MODULE_ID INT,
	@P_ECO_LAN_LAN_ID INT
    
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @Transaction VARCHAR(100);
	SELECT @Transaction = 'Transaction';

	BEGIN TRANSACTION @Transaction;

	INSERT INTO [ECOMMERCE].[PRODUCT_IMAGE]
		(
			PROD_PRODUCT_ID	,
			PROD_IMAGE_NAME,
			PROD_IMAGE_IS_COVER_IMAGE
		)
	VALUES
		(
			@P_PROD_PRODUCT_ID,
			@P_PROD_IMAGE_NAME,
			@P_PROD_IMAGE_IS_COVER_IMAGE
		)
		
		set @P_PROD_IMAGE_ID = SCOPE_IDENTITY()
		
		INSERT INTO [ECOMMERCE].[ECOMMERCE_LANGUAGE]
			(
				[ECO_LAN_OBJ_ID],
				[ECO_LAN_MODULE_ID],
				[ECO_LAN_LAN_ID],		
				[ECO_LAN_NAME]	
			)
			VALUES
			(
				@P_PROD_IMAGE_ID,
				@P_MODULE_ID,
				@P_ECO_LAN_LAN_ID,
				@P_PROD_IMAGE_CAPTION
			)
			
			IF @@ERROR != 0
            BEGIN 
                  ROLLBACK TRANSACTION
                  RETURN
            END

			COMMIT TRANSACTION @Transaction

			
END
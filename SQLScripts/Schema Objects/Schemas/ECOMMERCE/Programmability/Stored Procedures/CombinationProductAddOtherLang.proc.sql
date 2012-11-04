﻿CREATE PROCEDURE [ECOMMERCE].[CombinationProductAddOtherLang]

	@P_COMBINATION_ID	int,
	
	@P_COMBINATION_PRODUCT_LOCATION NVARCHAR(500),
	@P_MODULE_ID INT,
	@P_ECO_LAN_LAN_ID INT
    
AS
BEGIN
	SET NOCOUNT ON;
	
		INSERT INTO [ECOMMERCE].[ECOMMERCE_LANGUAGE]
			(
				[ECO_LAN_OBJ_ID],
				[ECO_LAN_MODULE_ID],
				[ECO_LAN_LAN_ID],		
				[ECO_LAN_NAME]	
			)
			VALUES
			(
				@P_COMBINATION_ID,
				@P_MODULE_ID,
				@P_ECO_LAN_LAN_ID,
				@P_COMBINATION_PRODUCT_LOCATION
			)
		

			
END

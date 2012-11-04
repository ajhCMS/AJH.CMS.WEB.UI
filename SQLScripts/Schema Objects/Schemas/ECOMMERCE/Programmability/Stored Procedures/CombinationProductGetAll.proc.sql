﻿CREATE PROCEDURE [ECOMMERCE].[CombinationProductGetAll]
	@P_MODULE_ID INT,
	@P_ECO_LAN_LAN_ID INT
AS
BEGIN
	SET NOCOUNT ON;
	SELECT
			C.[COMBINATION_ID],
			C.[COMBINATION_PRODUCT_ID],
			C.[COMBINATION_PRODUCT_REFERENCE],
			C.[COMBINATION_PRODUCT_EAN13],
			C.[COMBINATION_PRODUCT_UPC],
			C.[COMBINATION_PRODUCT_SUPPLIER_REFERENCE],
			C.[COMBINATION_PRODUCT_WHOLESALE_PRICE],
			C.[COMBINATION_PRODUCT_IMPACT_ON_PRICE],
			C.[COMBINATION_PRODUCT_IMPACT_ON_WEIGHT],
			C.[COMBINATION_PRODUCT_INITIAL_STOCK],
			C.[COMBINATION_PRODUCT_MINIMUM_QUANTITY],
			C.[COMBINATION_PRODUCT_IS_DEFAULT],
			C.[COMBINATION_PRODUCT_COLOR],
			C.[COMBINATION_IS_DELETED],
			EL.[ECO_LAN_NAME],
			EL.[ECO_LAN_OBJ_ID],
			EL.[ECO_LAN_LAN_ID]
	 FROM  [ECOMMERCE].[COMBINATION_PRODUCT] AS C
			LEFT OUTER JOIN
		   ECOMMERCE.ECOMMERCE_LANGUAGE AS EL
	 ON	
				EL.[ECO_LAN_OBJ_ID] = C.[COMBINATION_ID]
			AND
				EL.[ECO_LAN_MODULE_ID] = @P_MODULE_ID
			AND
				EL.[ECO_LAN_LAN_ID] = @P_ECO_LAN_LAN_ID
		WHERE C.[COMBINATION_IS_DELETED]=0
	END

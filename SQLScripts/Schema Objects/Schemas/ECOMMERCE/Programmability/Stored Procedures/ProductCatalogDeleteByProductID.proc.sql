﻿CREATE PROCEDURE [ECOMMERCE].[ProductCatalogDeleteByProductID]

	@P_PRODUCT_ID int
AS
BEGIN
	SET NOCOUNT ON;
	
	delete from  [ECOMMERCE].[PRODUCT_CATALOG]
		where
			[PRODUCT_ID] = @P_PRODUCT_ID
	
END

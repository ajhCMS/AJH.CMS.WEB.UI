﻿CREATE PROCEDURE [ECOMMERCE].[ProductCatalogDelete]

		@P_PRODUCT_ID	int,	
		@P_CATALOG_ID	int	
    
AS
BEGIN
	SET NOCOUNT ON;
	
	delete from  [ECOMMERCE].[PRODUCT_CATALOG]
		where
			[PRODUCT_ID] = @P_PRODUCT_ID
			and	
			[CATALOG_ID]= @P_CATALOG_ID	
	
END

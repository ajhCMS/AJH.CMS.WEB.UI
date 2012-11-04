﻿CREATE PROCEDURE [ECOMMERCE].[CatalogImageGetByCatalogID]
	
		@P_CATALOG_ID int
		
    
AS
BEGIN
	SET NOCOUNT ON;

SELECT 
		CATALOG_IMAGE_ID,
		CATALOG_ID,
		CATALOG_IMAGE_NAME,
		CATALOG_IMAGE_IS_COVER_IMAGE,
		CATALOG_IMAGE_IS_DELETED
		
FROM ECOMMERCE.CATALOG_IMAGE

WHERE 
 CATALOG_ID= @P_CATALOG_ID
	
	
END

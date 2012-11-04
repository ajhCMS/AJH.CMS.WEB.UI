﻿CREATE PROCEDURE [ECOMMERCE].[CatalogImageUpdate]
	
		@P_CATALOG_IMAGE_ID int ,
		@P_CATALOG_IMAGE_IS_COVER_IMAGE bit,
		@P_CATALOG_IMAGE_NAME nvarchar(500)
    
AS
BEGIN
	SET NOCOUNT ON;

	update[ECOMMERCE].[CATALOG_IMAGE]
	set
		CATALOG_IMAGE_IS_COVER_IMAGE = @P_CATALOG_IMAGE_IS_COVER_IMAGE,
		CATALOG_IMAGE_NAME = @P_CATALOG_IMAGE_NAME
	
	where CATALOG_IMAGE_ID =  @P_CATALOG_IMAGE_ID
	
	
END


 
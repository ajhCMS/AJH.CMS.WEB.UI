﻿CREATE PROCEDURE [ECOMMERCE].[ManufacturareDeleteLogical]
	@P_MANUFACTURARE_ID int
	
AS
BEGIN
	SET NOCOUNT ON;
	
	update  [ECOMMERCE].[MANUFACTURARE] set
		[MANUFACTURARE_IS_DELETED] = 1
		where
		MANUFACTURARE_ID = @P_MANUFACTURARE_ID
		
		END
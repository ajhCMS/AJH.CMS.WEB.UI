﻿CREATE PROCEDURE [ECOMMERCE].[CombinationProductDeleteLogical]
	@P_COMBINATION_ID int
	
AS
BEGIN
	SET NOCOUNT ON;
	
	update  [ECOMMERCE].[COMBINATION_PRODUCT] set
		[COMBINATION_IS_DELETED] = 1
		where
		COMBINATION_ID = @P_COMBINATION_ID
		
		END

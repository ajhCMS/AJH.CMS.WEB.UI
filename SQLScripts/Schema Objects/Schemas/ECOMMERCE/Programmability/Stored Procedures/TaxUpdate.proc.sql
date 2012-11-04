﻿CREATE PROCEDURE [ECOMMERCE].[TaxUpdate]

		@P_TAX_ID	int	,
		@P_TAX_RATE	decimal(9,2),
		@P_TAX_IS_ENABLED	bit,	
		@P_TAX_PORTAL_ID	int
    
AS
BEGIN
	SET NOCOUNT ON;
	
	update  [ECOMMERCE].[TAX]
		set
		[TAX_RATE] = @P_TAX_RATE,
		[TAX_IS_ENABLED] = @P_TAX_IS_ENABLED,
		[TAX_PORTAL_ID] = @P_TAX_PORTAL_ID
		
		where 
			TAX_ID = @P_TAX_ID
		
END

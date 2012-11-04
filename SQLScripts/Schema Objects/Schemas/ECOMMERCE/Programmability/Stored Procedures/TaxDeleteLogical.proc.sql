CREATE PROCEDURE [ECOMMERCE].[TaxDeleteLogical]
	@P_Tax_ID int
	
AS
BEGIN
	SET NOCOUNT ON;
	
	update  [ECOMMERCE].[Tax] set
		[Tax_IS_DELETED] = 1
		where
		[Tax_ID] = @P_Tax_ID
		
		END

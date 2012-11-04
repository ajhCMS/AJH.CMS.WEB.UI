CREATE PROCEDURE [ECOMMERCE].[TaxDelete]

	@P_TAX_ID	int	
AS
BEGIN
	SET NOCOUNT ON;
	
	delete from  [ECOMMERCE].[TAX]
		
		where 
			TAX_ID = @P_TAX_ID
		
END

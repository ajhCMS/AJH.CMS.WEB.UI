CREATE PROCEDURE [ECOMMERCE].[TaxGetById]

   @P_TAX_ID int ,
   @P_TAX_PORTAL_ID	int
AS
BEGIN
	SET NOCOUNT ON;
	
	select 
	
		[TAX_ID],
		[TAX_RATE] ,
		[TAX_IS_ENABLED],
		[TAX_PORTAL_ID],
		[TAX_IS_DELETED]  
		
		from 
	 [ECOMMERCE].[TAX]
	 where [TAX_ID] =  @P_TAX_ID and [TAX_PORTAL_ID] = @P_TAX_PORTAL_ID	
		
			
		
END

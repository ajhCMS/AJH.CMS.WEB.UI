CREATE PROCEDURE [ECOMMERCE].[FeatureDeleteLogical]
	@P_Feature_ID int
	
AS
BEGIN
	SET NOCOUNT ON;
	
	update  [ECOMMERCE].[Feature] set
		[Feature_IS_DELETED] = 1
		where
		[Feature_ID] = @P_Feature_ID
		
		END

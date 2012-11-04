﻿CREATE PROCEDURE [ECOMMERCE].[CatalogAdd]
		@P_CATALOG_ID int output,
		@P_CATALOG_IS_DISPLAYED	bit,
		@P_CATALOG_IS_GALLERY_ONLY	bit,
		@P_CATALOG_PARENT_CATALOG_ID int,
		@P_CATALOG_IS_PUBLISHED BIT,	
		@P_CATALOG_PORTAL_ID INT,
		@P_ECO_LAN_NAME nvarchar(500),
		@P_ECO_LAN_DESC nvarchar(500),
		@P_ECO_LAN_NAME2 nvarchar(500),
		@P_ECO_LAN_DESC2 nvarchar(500),
		@P_ECO_LAN_KEYWORD nvarchar(500),
		@P_MODULE_ID INT,
		@P_ECO_LAN_LAN_ID INT,
		@P_CATALOG_ORDER INT	
    
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @Transaction VARCHAR(100);
	SELECT @Transaction = 'Transaction';

	BEGIN TRANSACTION @Transaction;
	insert into [ECOMMERCE].[CATALOG]
	(
		[CATALOG_IS_DISPLAYED],
		[CATALOG_IS_GALLERY_ONLY],
		[CATALOG_PARENT_CATALOG_ID],
		[CATALOG_PORTAL_ID],
		[CATALOG_ORDER],
		[CATALOG_IS_PUBLISHED]
	)
	values
	(
		@P_CATALOG_IS_DISPLAYED	,
		@P_CATALOG_IS_GALLERY_ONLY	,
		case when @P_CATALOG_PARENT_CATALOG_ID >0 then @P_CATALOG_PARENT_CATALOG_ID else null end,	
		@P_CATALOG_PORTAL_ID,
		@P_CATALOG_ORDER,
		@P_CATALOG_IS_PUBLISHED	
	)
	
	set @P_CATALOG_ID = SCOPE_IDENTITY()
	
	INSERT INTO [ECOMMERCE].[ECOMMERCE_LANGUAGE]
			(
				[ECO_LAN_OBJ_ID],
				[ECO_LAN_MODULE_ID],
				[ECO_LAN_LAN_ID],
				[ECO_LAN_NAME],
				[ECO_LAN_DESC],
				[ECO_LAN_NAME2],
				[ECO_LAN_DESC2],
				[ECO_LAN_KEYWORD]
			)
			VALUES
			(
				@P_CATALOG_ID,
				@P_MODULE_ID,
				@P_ECO_LAN_LAN_ID,
				@P_ECO_LAN_NAME,
				@P_ECO_LAN_DESC ,
				@P_ECO_LAN_NAME2 ,
				@P_ECO_LAN_DESC2 ,
				@P_ECO_LAN_KEYWORD
			)
			
			IF @@ERROR != 0
            BEGIN 
                  ROLLBACK TRANSACTION
                  RETURN
            END

			COMMIT TRANSACTION @Transaction
END

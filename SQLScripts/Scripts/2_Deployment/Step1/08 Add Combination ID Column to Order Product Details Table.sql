if  not exists(select * from sys.columns 
            where Name = N'ORD_PRO_DET_COMBINATION_ID' and Object_ID = Object_ID(N'[ECOMMERCE].[ORDER_PRODUCT_DETAILS]'))    
begin
    ALTER TABLE [ECOMMERCE].[ORDER_PRODUCT_DETAILS] 
ADD [ORD_PRO_DET_COMBINATION_ID] int not null default(0)
end
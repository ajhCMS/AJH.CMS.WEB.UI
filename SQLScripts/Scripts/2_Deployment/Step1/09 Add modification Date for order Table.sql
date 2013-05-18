if  not exists(select * from sys.columns 
            where Name = N'ORDER_MODIFICATION_DATE' and Object_ID = Object_ID(N'[ECOMMERCE].[ORDER]'))    
begin
    ALTER TABLE [ECOMMERCE].[ORDER] 
ADD [ORDER_MODIFICATION_DATE] datetime null
end
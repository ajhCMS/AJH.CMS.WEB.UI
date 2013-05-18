if  not exists(select * from sys.columns 
            where Name = N'CUSTOMER_EDUCATION' and Object_ID = Object_ID(N'[ECOMMERCE].[CUSTOMER]'))    
begin
    ALTER TABLE [ECOMMERCE].[CUSTOMER] 
ADD [CUSTOMER_EDUCATION] nvarchar(50) NULL DEFAULT ''
end

if  not exists(select * from sys.columns 
            where Name = N'CUSTOMER_POSITION' and Object_ID = Object_ID(N'[ECOMMERCE].[CUSTOMER]'))    
begin
    ALTER TABLE [ECOMMERCE].[CUSTOMER] 
ADD [CUSTOMER_POSITION] nvarchar(50) NULL DEFAULT ''
end

if  not exists(select * from sys.columns 
            where Name = N'CUSTOMER_LOCATION' and Object_ID = Object_ID(N'[ECOMMERCE].[CUSTOMER]'))    
begin
    ALTER TABLE [ECOMMERCE].[CUSTOMER] 
ADD [CUSTOMER_LOCATION] nvarchar(50) NULL DEFAULT ''
end
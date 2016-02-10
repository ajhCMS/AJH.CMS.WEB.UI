
if  NOT Exists(select * from sys.columns where Name = N'MENU_PAGE_TITLE'
            and Object_ID = Object_ID(N'[SETUP].[MENU]'))
	ALTER TABLE [SETUP].[MENU]
	ADD MENU_PAGE_TITLE nvarchar(500) null;
GO
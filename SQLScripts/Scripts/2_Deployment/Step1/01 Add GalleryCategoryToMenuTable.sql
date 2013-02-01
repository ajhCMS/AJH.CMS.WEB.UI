
if  NOT Exists(select * from sys.columns where Name = N'MENU_GALLERY_CATEGORY_ID'
            and Object_ID = Object_ID(N'[SETUP].[MENU]'))
	ALTER TABLE [SETUP].[MENU]
	ADD MENU_GALLERY_CATEGORY_ID int null;
GO
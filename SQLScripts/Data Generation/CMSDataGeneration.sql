SET NOCOUNT ON;
SET XACT_ABORT ON;
GO

SET IDENTITY_INSERT [SECURITY].[FORM] ON;

BEGIN TRANSACTION;
INSERT INTO [SECURITY].[FORM]([FORM_ID], [FORM_NAME], [FORM_DESCRIPTION], [FORM_URL], [FORM_CODE], [FORM_MODULE_ID], [FORM_IS_DELETED])
SELECT 13, N'Category', N'Category', N'~/Admin/Category/FrmCategory.aspx', N'/Admin/Category/FrmCategory.aspx', 0, 0 UNION ALL
SELECT 14, N'Article', N'Article', N'~/Admin/Article/FrmArticle.aspx"', N'/Admin/Article/FrmArticle.aspx', 0, 0 UNION ALL
SELECT 15, N'Menu', N'Menu', N'~/Admin/Menu/FrmMenu.aspx', N'/Admin/Menu/FrmMenu.aspx', 0, 0 UNION ALL
SELECT 16, N'Gallery', N'Gallery', N'~/Admin/Gallery/FrmGallery.aspx', N'/Admin/Gallery/FrmGallery.aspx', 0, 0 UNION ALL
SELECT 17, N'HTML', N'HTML', N'~/Admin/HTML/FrmHtmlBlock.aspx', N'/Admin/HTML/FrmHtmlBlock.aspx', 0, 0 UNION ALL
SELECT 18, N'Template', N'Template', N'~/Admin/Template/FrmTemplate.aspx', N'/Admin/Template/FrmTemplate.aspx', 0, 0 UNION ALL
SELECT 19, N'Page', N'Page', N'~/Admin/Page/FrmPage.aspx', N'/Admin/Page/FrmPage.aspx', 0, 0 UNION ALL
SELECT 20, N'Style', N'Style', N'~/Admin/Style/FrmStyle.aspx', N'/Admin/Style/FrmStyle.aspx', 0, 0 UNION ALL
SELECT 21, N'XSL Template', N'XSL Template', N'~/Admin/XSLTemplate/FrmXSLTemplate.aspx', N'/Admin/XSLTemplate/FrmXSLTemplate.aspx', 0, 0 UNION ALL
SELECT 22, N'Controls', N'Controls', N'~/Admin/CMSControl/FrmCMSControl.aspx', N'/Admin/CMSControl/FrmCMSControl.aspx', 0, 0 UNION ALL
SELECT 23, N'Users', N'Users', N'~/Admin/Security/FrmUser.aspx', N'/Admin/Security/FrmUser.aspx', 0, 0 UNION ALL
SELECT 24, N'Permission', N'Permission', N'~/Admin/Security/FrmPermission.aspx', N'/Admin/Security/FrmPermission.aspx', 0, 0 UNION ALL
SELECT 25, N'Role', N'Role', N'~/Admin/Security/FrmRole.aspx', N'/Admin/Security/FrmRole.aspx', 0, 0 UNION ALL
SELECT 26, N'Form', N'Form', N'~/Admin/Security/FrmForm.aspx', N'/Admin/Security/FrmForm.aspx', 0, 0 UNION ALL
SELECT 27, N'Catalog', N'Catalog', N'~/Admin/ECommerce/Catalog/FrmCatalog.aspx', N'/Admin/ECommerce/Catalog/FrmCatalog.aspx', 0, 0 UNION ALL
SELECT 28, N'Group', N'Group', N'~/Admin/ECommerce/Group/FrmGroup.aspx', N'/Admin/ECommerce/Group/FrmGroup.aspx', 0, 0 UNION ALL
SELECT 29, N'Attribute', N'Attribute', N'~/Admin/ECommerce/Attribute/FrmAttribute.aspx', N'/Admin/ECommerce/Attribute/FrmAttribute.aspx', 0, 0 UNION ALL
SELECT 30, N'Feature', N'Feature', N'~/Admin/ECommerce/Feature/FrmFeature.aspx', N'/Admin/ECommerce/Feature/FrmFeature.aspx', 0, 0 UNION ALL
SELECT 31, N'Tax', N'Tax', N'~/Admin/ECommerce/Tax/FrmTax.aspx', N'/Admin/ECommerce/Tax/FrmTax.aspx', 0, 0 UNION ALL
SELECT 32, N'Supplier', N'Supplier', N'~/Admin/ECommerce/Supplier/FrmSupplier.aspx', N'/Admin/ECommerce/Supplier/FrmSupplier.aspx', 0, 0 UNION ALL
SELECT 33, N'Manufacturar', N'Manufacturar', N'~/Admin/ECommerce/Manufacturar/FrmManufacturar.aspx', N'/Admin/ECommerce/Manufacturar/FrmManufacturar.aspx', 0, 0 UNION ALL
SELECT 34, N'Landing', N'Landing', N'~/Admin/FrmLanding.aspx', N'/Admin/FrmLanding.aspx', 0, 0 UNION ALL
SELECT 36, N'ProductSearch', N'ProductSearch', N'~/Admin/ECommerce/Product/FrmProductSearch.aspx', N'/Admin/ECommerce/Product/FrmProductSearch.aspx', 0, 0 UNION ALL
SELECT 37, N'Product', N'Product', N'~/Admin/ECommerce/Product/FrmProduct.aspx', N'/Admin/ECommerce/Product/FrmProduct.aspx', 0, 0 UNION ALL
SELECT 38, N'PageDesign', N'PageDesign', N'~/Admin/Page/FrmPageDesign.aspx', N'/Admin/Page/FrmPageDesign.aspx', 0, 0 UNION ALL
SELECT 40, N'TemplateDesign', N'TemplateDesign', N'~/Admin/Template/FrmTemplateDesign.aspx', N'/Admin/Template/FrmTemplateDesign.aspx', 0, 0 UNION ALL
SELECT 41, N'Preference', N'Preference', N'~/Admin/ECommerce/Preference/FrmPreference.aspx', N'/Admin/ECommerce/Preference/FrmPreference.aspx', 0, 0
COMMIT;
RAISERROR (N'[SECURITY].[FORM]: Insert Batch: 1.....Done!', 10, 1) WITH NOWAIT;
GO

SET IDENTITY_INSERT [SECURITY].[FORM] OFF;

SET IDENTITY_INSERT [SECURITY].[FORM_ROLE] ON;

BEGIN TRANSACTION;
INSERT INTO [SECURITY].[FORM_ROLE]([FORM_ROLE_ID], [FORM_ROLE_FORM_ID], [FORM_ROLE_ROLE_ID], [FORM_ROLE_ACCESS_TYPE])
SELECT 1, 13, 1, 1 UNION ALL
SELECT 2, 14, 1, 1 UNION ALL
SELECT 3, 15, 1, 1 UNION ALL
SELECT 4, 16, 1, 1 UNION ALL
SELECT 5, 17, 1, 1 UNION ALL
SELECT 6, 18, 1, 1 UNION ALL
SELECT 7, 19, 1, 1 UNION ALL
SELECT 8, 20, 1, 1 UNION ALL
SELECT 9, 21, 1, 1 UNION ALL
SELECT 10, 22, 1, 1 UNION ALL
SELECT 11, 23, 1, 1 UNION ALL
SELECT 12, 24, 1, 1 UNION ALL
SELECT 13, 25, 1, 1 UNION ALL
SELECT 14, 26, 1, 1 UNION ALL
SELECT 15, 27, 1, 1 UNION ALL
SELECT 16, 28, 1, 1 UNION ALL
SELECT 17, 29, 1, 1 UNION ALL
SELECT 18, 30, 1, 1 UNION ALL
SELECT 19, 31, 1, 1 UNION ALL
SELECT 20, 32, 1, 1 UNION ALL
SELECT 21, 33, 1, 1 UNION ALL
SELECT 22, 34, 1, 1 UNION ALL
SELECT 24, 36, 1, 1 UNION ALL
SELECT 25, 37, 1, 1 UNION ALL
SELECT 27, 38, 1, 1 UNION ALL
SELECT 28, 40, 1, 1 UNION ALL
SELECT 29, 41, 1, 1
COMMIT;
RAISERROR (N'[SECURITY].[FORM_ROLE]: Insert Batch: 1.....Done!', 10, 1) WITH NOWAIT;
GO

SET IDENTITY_INSERT [SECURITY].[FORM_ROLE] OFF;

SET IDENTITY_INSERT [SECURITY].[ROLE] ON;

BEGIN TRANSACTION;
INSERT INTO [SECURITY].[ROLE]([ROLE_ID], [ROLE_NAME], [ROLE_DESCRIPTION], [ROLE_IS_DELETED])
SELECT 1, N'Admin', N'Admin', 0
COMMIT;
RAISERROR (N'[SECURITY].[ROLE]: Insert Batch: 1.....Done!', 10, 1) WITH NOWAIT;
GO

SET IDENTITY_INSERT [SECURITY].[ROLE] OFF;

BEGIN TRANSACTION;
INSERT INTO [SECURITY].[ROLE_USER]([ROLE_USER_ROLE_ID], [ROLE_USER_USER_ID])
SELECT 1, 1
COMMIT;
RAISERROR (N'[SECURITY].[ROLE_USER]: Insert Batch: 1.....Done!', 10, 1) WITH NOWAIT;
GO

SET IDENTITY_INSERT [SECURITY].[USER] ON;

BEGIN TRANSACTION;
INSERT INTO [SECURITY].[USER]([USER_ID], [USER_NAME], [USER_EMAIL], [USER_PASSWORD], [USER_IS_ACTIVE], [USER_CREATION_DAY], [USER_CREATION_SEC], [USER_IS_DELETED])
SELECT 1, N'admin', N'admin', N'y0pOy6EEgrc=', 1, 8124, 69178, 0
COMMIT;
RAISERROR (N'[SECURITY].[USER]: Insert Batch: 1.....Done!', 10, 1) WITH NOWAIT;
GO

SET IDENTITY_INSERT [SECURITY].[USER] OFF;

SET IDENTITY_INSERT [SETUP].[CMSCONTROL] ON;

BEGIN TRANSACTION;
INSERT INTO [SETUP].[CMSCONTROL]([CMSCONTROL_ID], [CMSCONTROL_NAME], [CMSCONTROL_DESCRIPTION], [CMSCONTROL_USER_CONTROL_PATH], [CMSCONTROL_IS_DELETED], [CMSCONTROL_CREATION_DAY], [CMSCONTROL_CREATION_SEC], [CMSCONTROL_MODULE_ID], [CMSCONTROL_CREATED_BY])
SELECT 1, N'ArticleDetails', N'Article Details', N'~/GUI/Article/ArticleDetails_UC.ascx', 0, 8129, 23565, 1, 1 UNION ALL
SELECT 2, N'ArticleTemplate', N'Article Template', N'~/GUI/Article/ArticleXSL_UC.ascx', 0, 8129, 23614, 1, 1 UNION ALL
SELECT 3, N'CategoryTemplate', N'Category Template', N'~/GUI/Category/CategoryXSL_UC.ascx', 0, 8129, 23718, 8, 1 UNION ALL
SELECT 4, N'HTMLViewer', N'HTML Viewer', N'~/GUI/HTML/HTMLViewer_UC.ascx', 0, 8129, 23767, 2, 1 UNION ALL
SELECT 5, N'MenuDetails', N'Menu Details', N'~/GUI/Menu/MenuDetails_UC.ascx', 0, 8129, 23829, 3, 1 UNION ALL
SELECT 6, N'MenuTemplate', N'Menu Template', N'~/GUI/Menu/MenuXSL_UC.ascx', 0, 8129, 23860, 3, 1 UNION ALL
SELECT 7, N'Catalog Template', N'Catalog Template', N'~/GUI/ECommerce/Catalog/CatalogXSL_UC.ascx', 0, 8198, 4658, 9, 1 UNION ALL
SELECT 8, N'CatalogDetails', N'CatalogDetails', N'~/GUI/ECommerce/Catalog/CatalogDetailsXSL_UC.ascx', 0, 8209, 78213, 9, 1 UNION ALL
SELECT 9, N'Product XSL', N'Product XSL', N'~/GUI/ECommerce/Product/ProductXSL_UC.ascx', 0, 8215, 63425, 9, 1 UNION ALL
SELECT 10, N'ProductDetails', N'ProductDetails', N'~/GUI/ECommerce/Product/ProductDetailsXSL_UC.ascx', 0, 8216, 55562, 9, 1 UNION ALL
SELECT 11, N'ProductSitePath', N'ProductSitePath', N'~/GUI/ECommerce/Product/ProductSitePath.ascx', 0, 8220, 74, 9, 1 UNION ALL
SELECT 12, N'Career_UC', N'Career_UC', N'~/GUI/Contact/Career_UC.ascx', 0, 8225, 79324, 7, 1 UNION ALL
SELECT 13, N'Menu site Path', N'Menu Site Path', N'~/GUI/Menu/SitePathXSL_UC.ascx', 0, 8232, 79637, 3, 1 UNION ALL
SELECT 14, N'CatalogSitePath', N'CatalogSitePath', N'~/GUI/ECommerce/Catalog/CatalogSitePath.ascx', 0, 8232, 82820, 9, 1 UNION ALL
SELECT 15, N'ContactUs_UC', N'ContactUs_UC', N'~/GUI/Contact/ContactUs_UC.ascx', 0, 8242, 5427, 3, 1 UNION ALL
SELECT 16, N'Gallery Template Server', N'Gallery Template Server', N'~/GUI/Gallery/GalleryXSL_UC.ascx', 0, 8244, 67766, 4, 1 UNION ALL
SELECT 17, N'Gallery Template Service', N'Gallery Template Service', N'~/GUI/Gallery/GalleryServiceXSL_UC.ascx', 0, 8244, 67793, 4, 1 UNION ALL
SELECT 18, N'Menu Item Template XSL', N'Menu Item Template', N'~/GUI/Menu/MenuItemTemplateXSL_UC.ascx', 0, 8246, 3057, 3, 1
COMMIT;
RAISERROR (N'[SETUP].[CMSCONTROL]: Insert Batch: 1.....Done!', 10, 1) WITH NOWAIT;
GO

SET IDENTITY_INSERT [SETUP].[CMSCONTROL] OFF;

SET IDENTITY_INSERT [SETUP].[MODULE] ON;

BEGIN TRANSACTION;
INSERT INTO [SETUP].[MODULE]([MODULE_ID], [MODULE_NAME], [MODULE_DESCRIPTION], [MODULE_IMAGE], [MODULE_IS_DELETED], [MODULE_CREATION_DAY], [MODULE_CREATION_SEC], [MODULE_CREATED_BY], [MODULE_PARENT_ID])
SELECT 1, N'Article', N'Article', N'', 0, 0, 0, 1, 0 UNION ALL
SELECT 2, N'HTML', N'HTML', N'', 0, 0, 0, 1, 0 UNION ALL
SELECT 3, N'Menu', N'Menu', N'', 0, 0, 0, 1, 0 UNION ALL
SELECT 4, N'Gallery', N'Gallery', N'', 0, 0, 0, 1, 0 UNION ALL
SELECT 5, N'Event', N'Event', N'', 0, 0, 0, 1, 0 UNION ALL
SELECT 6, N'Banner', N'Banner', N'', 0, 0, 0, 1, 0 UNION ALL
SELECT 7, N'General', N'General', N'', 0, 0, 0, 1, 0 UNION ALL
SELECT 9, N'ECommerce', N'ECommerce', N' ', 0, 0, 0, 1, 0
COMMIT;
RAISERROR (N'[SETUP].[MODULE]: Insert Batch: 1.....Done!', 10, 1) WITH NOWAIT;
GO

SET IDENTITY_INSERT [SETUP].[MODULE] OFF;
GO
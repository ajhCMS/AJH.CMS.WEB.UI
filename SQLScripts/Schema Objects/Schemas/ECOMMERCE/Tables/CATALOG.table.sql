CREATE TABLE [ECOMMERCE].[CATALOG] (
    [CATALOG_ID]                INT            IDENTITY (1, 1) NOT NULL,
    [CATALOG_IS_DISPLAYED]      BIT            NOT NULL,
    [CATALOG_IS_GALLERY_ONLY]   BIT            NOT NULL,
    [CATALOG_IMAGE]             NVARCHAR (100) NULL,
    [CATALOG_PARENT_CATALOG_ID] INT            NULL,
    [CATALOG_IS_DELETED]        BIT            NOT NULL,
    [CATALOG_PORTAL_ID]         INT            NOT NULL,
    [CATALOG_ORDER]             INT            NOT NULL,
    [CATALOG_IS_PUBLISHED]      BIT            NOT NULL
);


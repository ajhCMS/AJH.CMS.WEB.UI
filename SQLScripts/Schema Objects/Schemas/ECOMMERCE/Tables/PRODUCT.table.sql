CREATE TABLE [ECOMMERCE].[PRODUCT] (
    [PRODUCT_ID]                       INT             IDENTITY (1, 1) NOT NULL,
    [PRODUCT_SUPPLIER_ID]              INT             NULL,
    [PRODUCT_EAN13_OR_JAN]             NVARCHAR (500)  NULL,
    [PRODUCT_UPC]                      NVARCHAR (500)  NULL,
    [PRODUCT_LOCATION]                 NVARCHAR (500)  NULL,
    [PRODUCT_IS_DOWNLODABLE]           BIT             NOT NULL,
    [PRODUCT_DISPLAY_ON_SALE_ICON]     BIT             NOT NULL,
    [PRODUCT_INITIAL_STOCK]            INT             NOT NULL,
    [PRODUCT_MINIMUM_QUANTITY]         INT             NOT NULL,
    [PRODUCT_ADDITIONAL_SHIPPING_COST] DECIMAL (18, 2) NOT NULL,
    [PRODUCT_MANUFACTURER_ID]          INT             NULL,
    [PRODUCT_IS_ENABLED]               BIT             NOT NULL,
    [PRODUCT_IS_DELETED]               BIT             NOT NULL,
    [PRODUCT_PORTAL_ID]                INT             NOT NULL,
    [PRODUCT_TAX_ID]                   INT             NULL
);


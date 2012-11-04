CREATE TABLE [ECOMMERCE].[TAX] (
    [TAX_ID]         INT            IDENTITY (1, 1) NOT NULL,
    [TAX_RATE]       DECIMAL (9, 2) NOT NULL,
    [TAX_IS_ENABLED] BIT            NOT NULL,
    [TAX_PORTAL_ID]  INT            NOT NULL,
    [TAX_IS_DELETED] BIT            NOT NULL
);


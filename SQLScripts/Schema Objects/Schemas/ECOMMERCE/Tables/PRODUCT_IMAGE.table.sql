﻿CREATE TABLE [ECOMMERCE].[PRODUCT_IMAGE] (
    [PROD_IMAGE_ID]             INT            IDENTITY (1, 1) NOT NULL,
    [PROD_PRODUCT_ID]           INT            NOT NULL,
    [PROD_IMAGE_NAME]           NVARCHAR (500) NOT NULL,
    [PROD_IMAGE_IS_COVER_IMAGE] BIT            NOT NULL,
    [PROD_IMAGE_IS_DELETED]     BIT            NOT NULL
);

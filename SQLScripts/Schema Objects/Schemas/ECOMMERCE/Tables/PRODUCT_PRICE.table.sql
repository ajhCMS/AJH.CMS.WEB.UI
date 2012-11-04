﻿CREATE TABLE [ECOMMERCE].[PRODUCT_PRICE] (
    [PRODUCT_PRICE_ID]             INT             NOT NULL,
    [PRODUCT_PRICE_CURRENCY_ID]    INT             NOT NULL,
    [PRODUCT_PRICE_COUNTRY_ID]     INT             NOT NULL,
    [PRODUCT_PRICE_FROM_DAY]       INT             NOT NULL,
    [PRODUCT_PRICE_FROM_SEC]       INT             NOT NULL,
    [PRODUCT_PRICE_TO_DAY]         INT             NOT NULL,
    [PRODUCT_PRICE_TO_SEC]         INT             NOT NULL,
    [PRODUCT_PRICE_START_AT]       INT             NOT NULL,
    [PRODUCT_PRICE_VALUE]          DECIMAL (18, 2) NOT NULL,
    [PRODUCT_PRICE_DISCOUNT_VALUE] DECIMAL (18, 2) NOT NULL,
    [PRODUCT_PRICE_DISCOUNT_TYPE]  INT             NOT NULL,
    [PRODUCT_PRICE_PRODUCT_ID]     INT             NOT NULL,
    [PRODUCT_PRICE_IS_DELETED]     BIT             NOT NULL
);

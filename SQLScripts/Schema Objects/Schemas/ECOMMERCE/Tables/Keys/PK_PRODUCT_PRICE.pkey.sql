﻿ALTER TABLE [ECOMMERCE].[PRODUCT_PRICE]
    ADD CONSTRAINT [PK_PRODUCT_PRICE] PRIMARY KEY CLUSTERED ([PRODUCT_PRICE_ID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


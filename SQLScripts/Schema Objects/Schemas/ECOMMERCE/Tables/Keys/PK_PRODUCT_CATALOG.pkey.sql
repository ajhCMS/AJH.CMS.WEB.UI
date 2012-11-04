﻿ALTER TABLE [ECOMMERCE].[PRODUCT_CATALOG]
    ADD CONSTRAINT [PK_PRODUCT_CATALOG] PRIMARY KEY CLUSTERED ([PRODUCT_ID] ASC, [CATALOG_ID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);

